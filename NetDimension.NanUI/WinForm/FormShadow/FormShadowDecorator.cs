using NetDimension.Windows.Imports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.WinForm.FormShadow
{
	/// <summary>
	/// 窗口投影装饰器
	/// </summary>
	public class FormShadowDecorator : NativeWindow, IDisposable
	{
		const int ACTIVE_ALPHA = 224;
		const int INACTIVE_ALPHA = 172;

		private IntPtr parentWindowHWnd;
		private Form parentWindow;

		private FormShadowElement topFormShadow;
		private FormShadowElement leftFormShadow;
		private FormShadowElement bottomFormShadow;
		private FormShadowElement rightFormShadow;

		private WINDOWPOS lastLocation;

		private readonly List<FormShadowElement> shadows = new List<FormShadowElement>();
		private Color activeColor = Color.FromArgb(ACTIVE_ALPHA, 0, 0, 0);
		private Color inactiveColor = Color.FromArgb(INACTIVE_ALPHA, 0, 0, 0);
		private bool isEnabled;
		private bool setTopMost = true;
		private bool isFocused = false;
		private bool isWindowMinimized = false;
		private bool isAnimationDelayed = false;

		/// <summary>
		/// 设置或获取投影窗口是否至于顶层。
		/// </summary>
		internal bool TopMost
		{
			get
			{
				return setTopMost;
			}
			set
			{
				setTopMost = value;
				AlignSideShadowToTopMost();
			}
		}


		internal Color ActiveColor
		{
			get
			{
				return Color.FromArgb(255, activeColor.R,activeColor.G, activeColor.B);
			}

			set
			{
				activeColor = Color.FromArgb(ACTIVE_ALPHA, value.R, value.G,value.B);
				foreach (FormShadowElement sideShadow in shadows)
				{
					sideShadow.ActiveColor = activeColor;
				}
			}
		}


		internal Color InactiveColor
		{
			get
			{
				return Color.FromArgb(255, inactiveColor.R, inactiveColor.G, inactiveColor.B);
			}

			set
			{
				inactiveColor = Color.FromArgb(INACTIVE_ALPHA, value.R, value.G, value.B);
				foreach (FormShadowElement sideShadow in shadows)
				{
					sideShadow.InactiveColor = inactiveColor;
				}
			}
		}


		public bool IsEnabled
		{
			get { return isEnabled; }
		}


		public FormShadowDecorator(Form window, bool enable = true)
		{
			parentWindow = window;
			parentWindowHWnd = window.Handle;

			topFormShadow = new FormShadowElement(FormShadowDockPositon.Top, parentWindowHWnd, this);
			leftFormShadow = new FormShadowElement(FormShadowDockPositon.Left, parentWindowHWnd, this);
			bottomFormShadow = new FormShadowElement(FormShadowDockPositon.Bottom, parentWindowHWnd, this);
			rightFormShadow = new FormShadowElement(FormShadowDockPositon.Right, parentWindowHWnd, this);

			shadows.Add(topFormShadow);
			shadows.Add(leftFormShadow);
			shadows.Add(bottomFormShadow);
			shadows.Add(rightFormShadow);

			AssignHandle(parentWindowHWnd);


			User32.ShowWindow(topFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
			User32.ShowWindow(leftFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
			User32.ShowWindow(bottomFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);
			User32.ShowWindow(rightFormShadow.Handle, ShowWindowStyles.SW_SHOWNOACTIVATE);


			isEnabled = enable;
			AlignSideShadowToTopMost();

			ActiveColor = ActiveColor;
			InactiveColor = inactiveColor;




		}

		/// <summary>
		/// 启用或禁用窗体投影效果。
		/// </summary>
		/// <param name="enable">True/False</param>
		public void Enable(bool enable)
		{
			if (isEnabled && !enable)
			{
				ShowBorder(false);
				UnregisterEvents();
			}
			else if (!isEnabled && enable)
			{
				RegisterEvents();
				if (parentWindow != null)
				{
					UpdateLocations(new WINDOWPOS
					{
						x = (int)parentWindow.Left,
						y = (int)parentWindow.Top,
						cx = (int)parentWindow.Width,
						cy = (int)parentWindow.Height,
						flags = (int)SetWindowPosFlags.SWP_SHOWWINDOW
					});


					UpdateSizes(parentWindow.Width, parentWindow.Height);
				}
			}

			isEnabled = enable;
		}

		internal bool IsAnimationDelayed
		{
			get
			{
				return isAnimationDelayed;
			}
		}

		protected override void WndProc(ref Message m)
		{

			if (!isEnabled || IsDisposed)
			{
				base.WndProc(ref m);
				return;
			}
			var msg = (WindowsMessages)m.Msg;

			switch (msg)
			{
				case WindowsMessages.WM_WINDOWPOSCHANGED:
					base.WndProc(ref m);
					lastLocation = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
					WindowPosChanged(lastLocation);
					break;
				case WindowsMessages.WM_ACTIVATE:
					if(m.WParam == (IntPtr)WindowActiveFlags.WA_INACTIVE)
					{

					}

					var className = new StringBuilder(256);

					if (m.LParam != IntPtr.Zero && User32.GetClassName(m.LParam, className, className.Capacity) != 0)
					{
						var hWndShadow = m.LParam;
						var name = className.ToString();
						if (name.StartsWith(CONSTS.CLASS_NAME) && isFocused && shadows.Exists(p => p.Handle == hWndShadow))
						{
							return;
						}
					}


					if (Win32.Loword((int)m.WParam) == 0)
					{
						isFocused = false;
						KillFocus();
						//Debug.WriteLine("INACTIVE");
					}
					else
					{
						isFocused = true;
						SetFocus();
						//Debug.WriteLine("ACTIVE");
					}

					base.WndProc(ref m);
					break;
				case WindowsMessages.WM_ACTIVATEAPP:
					{


						base.WndProc(ref m);

					}
					break;

				case WindowsMessages.WM_SIZE:

					Size(m.WParam, m.LParam);


					base.WndProc(ref m);

					break;
				default:
					base.WndProc(ref m);
					break;
			}

		}


		private void DestroyShadows()
		{
			parentWindowHWnd = IntPtr.Zero;

			CloseShadows();

			parentWindow = null;
		}

		private void RegisterEvents()
		{

			if (parentWindow != null)
			{
				parentWindow.VisibleChanged += HandleWindowVisibleChanged;
			}
		}

		private void HandleWindowVisibleChanged(object sender, EventArgs e)
		{
			ShowBorder(parentWindow.Visible);
		}

		private void UnregisterEvents()
		{
			if (parentWindow != null)
			{
				parentWindow.VisibleChanged -= HandleWindowVisibleChanged;
			}
		}

		private void CloseShadows()
		{
			foreach (var sideShadow in shadows)
			{
				sideShadow.Close();
			}

			shadows.Clear();

			topFormShadow = null;
			bottomFormShadow = null;
			leftFormShadow = null;
			rightFormShadow = null;
		}

		private void ShowBorder(bool show)
		{
			var action = new Action(() =>
			{

				foreach (FormShadowElement sideShadow in shadows)
				{
					sideShadow.Show(show);
				}

				if (show)
				{
					isWindowMinimized = false;
				}
			});

			if (show == true && isWindowMinimized)
			{
				if (isAnimationDelayed)
				{
					return;
				}

				isAnimationDelayed = true;
				Task.Factory.StartNew(() =>
				{
					System.Threading.Thread.Sleep(150);
					parentWindow.Invoke(new MethodInvoker(action));

					isAnimationDelayed = false;
				});

			}
			else
			{
				action();

				isAnimationDelayed = false;
			}

		}

		private void UpdateZOrder()
		{
			foreach (FormShadowElement sideShadow in shadows)
			{
				sideShadow.UpdateZOrder();
			}
		}

		private void UpdateFocus(bool isFocused)
		{
			foreach (FormShadowElement sideShadow in shadows)
			{
				sideShadow.ParentWindowIsFocused = isFocused;
			}
		}

		private void UpdateSizes(int width, int height)
		{
			foreach (FormShadowElement sideShadow in shadows)
			{
				sideShadow.SetSize(width, height);
			}
		}

		private void UpdateLocations(WINDOWPOS location)
		{
			foreach (FormShadowElement sideShadow in shadows)
			{
				sideShadow.SetLocation(location);
			}

			if ((location.flags & (int)SetWindowPosFlags.SWP_HIDEWINDOW) != 0)
			{
				ShowBorder(false);
			}
			else if ((location.flags & (int)SetWindowPosFlags.SWP_SHOWWINDOW) != 0)
			{
				ShowBorder(true);
				//UpdateZOrder();
			}
		}

		private void AlignSideShadowToTopMost()
		{
			if (shadows == null)
			{
				return;
			}

			foreach (FormShadowElement sideShadow in shadows)
			{
				sideShadow.IsTopMost = setTopMost;
				sideShadow.UpdateZOrder();
			}
		}


		public void SetFocus()
		{
			if (!isEnabled) return;
			UpdateFocus(true);


		}

		public void KillFocus()
		{
			if (!isEnabled) return;
			UpdateFocus(false);
		}

		private void WindowPosChanged(WINDOWPOS location)
		{
			if (!isEnabled) return;
			UpdateLocations(location);
		}

		public void Activate(bool isActive)
		{
			if (!isEnabled) return;
			UpdateZOrder();
		}

		private void Size(IntPtr wParam, IntPtr lParam)
		{
			int width = (int)User32.LoWord(lParam);
			int height = (int)User32.HiWord(lParam);

			if (!isEnabled) return;

			if ((int)wParam == 2 || (int)wParam == 1) // maximized/minimized
			{
				ShowBorder(false);

				if ((int)wParam == 1)
				{
					isWindowMinimized = true;
				}
			}
			else
			{
				UpdateSizes(width, height);
				ShowBorder(true);

			}
		}



		#region Dispose

		private bool _isDisposed;

		/// <summary>
		/// IsDisposed status
		/// </summary>
		public bool IsDisposed
		{
			get { return _isDisposed; }
		}

		/// <summary>
		/// Standard Dispose
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose
		/// </summary>
		/// <param name="disposing">True if disposing, false otherwise</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					// release unmanaged resources
				}

				_isDisposed = true;

				DestroyShadows();

				UnregisterEvents();

				this.ReleaseHandle();

				parentWindow = null;
			}
		}

		#endregion

	}
}
