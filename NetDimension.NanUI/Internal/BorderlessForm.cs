using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDimension.NanUI.Internal
{

	using System.Windows.Forms;
	using System.Drawing;
	using System.ComponentModel;
	using NetDimension.NanUI.Internal.Imports;
	using System.Diagnostics;

	public abstract class BorderlessForm : Form
	{
		internal static readonly IntPtr TRUE = new IntPtr(1);
		internal static readonly IntPtr FALSE = new IntPtr(0);

		internal static readonly IntPtr MESSAGE_HANDLED = new IntPtr(1);
		internal static readonly IntPtr MESSAGE_PROCESS = new IntPtr(0);

		private bool isBorderless = true;
		private Size? windowOriginalSize = null;

		private int borderSize = 10;

		public bool EnableFormSkin
		{
			get
			{
				return isBorderless;
			}

		}




		private int CornerAreaSize
		{
			get
			{
				return borderSize < 2 ? 2 : borderSize;
			}
		}

		private FormNCAreaDecorator formNCAreaDecorator = null;
		private FormShadowDecorator formShadowDecorator = null;

		protected FormNCAreaDecorator FormNonclientAreaDecorator
		{
			get
			{
				return formNCAreaDecorator;
			}
		}

		protected FormShadowDecorator FormShadowDecorator
		{
			get
			{
				return formShadowDecorator;
			}
		}

		private bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (windowOriginalSize.HasValue && !IsDesignMode)
			{
				base.SetBoundsCore(x, y, windowOriginalSize.Value.Width, windowOriginalSize.Value.Height, specified);
			}
			else
			{
				base.SetBoundsCore(x, y, width, height, specified);
			}
		}

		public BorderlessForm()
		{
			isBorderless = true;

			InitForm();


		}
		public BorderlessForm(bool enableBorderlessForm = true)
		{

			isBorderless = enableBorderlessForm;
			InitForm();
		}

		private void InitForm()
		{
			if (isBorderless && !IsDesignMode)
			{
				formNCAreaDecorator = new FormNCAreaDecorator(this);
				formShadowDecorator = new FormShadowDecorator(this);
			}

			BackColor = Color.White;

		}

		protected override void OnHandleCreated(EventArgs e)
		{
			if (!IsDesignMode)
			{
				UxTheme.SetWindowTheme(this.Handle, string.Empty, string.Empty);
				User32.DisableProcessWindowsGhosting();
			}
			base.OnHandleCreated(e);
		}

		protected override void WndProc(ref Message m)
		{
			if (!IsDesignMode && isBorderless)
			{
				switch (m.Msg)
				{
					case (int)WindowsMessages.WM_NCHITTEST:
						if (m.Result == FALSE)
						{
							// 这里从CEF取得了NCHITTEST，所以窗口身就不参与HITTEST了吧
							// The NCHITTEST is sent by CEF, so the window does not handle this message.

							//if (borderSize > 0)
							//{
							//	var pos = new POINT((int)User32.LoWord(m.LParam), (int)User32.HiWord(m.LParam));

							//	User32.ScreenToClient(Handle, ref pos);
							//	var mode = GetSizeMode(pos);
							//	SetCursor(mode);
							//	m.Result = (IntPtr)mode;
							//}



							m.Result = (IntPtr)HitTest.HTCLIENT;


						}
						else
						{
							base.WndProc(ref m);
						}
						break;
					case (int)WindowsMessages.WM_SYSCOMMAND:
						{
							if ((m.WParam == (IntPtr)SystemCommandFlags.SC_MINIMIZE || m.WParam == (IntPtr)SystemCommandFlags.SC_MAXIMIZE) &&
								(WindowState != FormWindowState.Minimized && WindowState != FormWindowState.Maximized))
							{
								// 天晓得.NET处理这个怎么弄得，只要最小化然后恢复，窗口就越来越大。所以这里在最大化最小化得时候先把窗口得大小位置信息存了，在恢复窗口时使用SetBoundsCore恢复窗口得这些数据。
								windowOriginalSize = ClientSize;


							}



							base.WndProc(ref m);
						}

						break;

					default:
						base.WndProc(ref m);
						break;
				}
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		private HitTest GetSizeMode(POINT point)
		{
			HitTest mode = HitTest.HTCLIENT;

			int x = point.x, y = point.y;

			if (WindowState == FormWindowState.Normal)
			{
				if (x < CornerAreaSize & y < CornerAreaSize)
				{
					mode = HitTest.HTTOPLEFT;
				}
				else if (x < CornerAreaSize & y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOMLEFT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize & y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOMRIGHT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize & y < CornerAreaSize)
				{
					mode = HitTest.HTTOPRIGHT;

				}
				else if (x < CornerAreaSize)
				{
					mode = HitTest.HTLEFT;

				}
				else if (x + CornerAreaSize > this.Width - CornerAreaSize)
				{
					mode = HitTest.HTRIGHT;

				}
				else if (y < CornerAreaSize)
				{
					mode = HitTest.HTTOP;

				}
				else if (y + CornerAreaSize > this.Height - CornerAreaSize)
				{
					mode = HitTest.HTBOTTOM;

				}

			}


			return mode;
		}

		private void SetCursor(HitTest mode)
		{


			IntPtr handle = IntPtr.Zero;

			switch (mode)
			{
				case HitTest.HTTOP:
				case HitTest.HTBOTTOM:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENS);
					break;
				case HitTest.HTLEFT:
				case HitTest.HTRIGHT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZEWE);
					break;
				case HitTest.HTTOPLEFT:
				case HitTest.HTBOTTOMRIGHT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENWSE);
					break;
				case HitTest.HTTOPRIGHT:
				case HitTest.HTBOTTOMLEFT:
					handle = User32.LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_SIZENESW);
					break;
			}

			if (handle != IntPtr.Zero)
			{
				User32.SetCursor(handle);
			}
		}
	}
}
