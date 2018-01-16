using NetDimension.Windows.Imports;
using NetDimension.WinForm.FormShadow;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.WinForm
{
	struct FormFrameSize
	{
		public int Width;
		public int Height;
		public int Caption;
	}

	public partial class ModernUIForm : Form
	{
		private static bool? isDesingerProcess = null;
		private static readonly IntPtr WVR_VALIDRECTS = new IntPtr(0x400);
		private bool isShadowEnabled = true;
		private Rectangle regionRect = Rectangle.Empty;
		private bool isFrameSizeStored;
		private int isInitializing = 0;
		private bool forceInitialized = false;
		private Size minimumClientSize;
		private Size maximumClientSize;
		private Size? minimumSize = null, maximumSize = null;
		private bool isWindowActive = false;
		private bool isCustomFrameEnabled = false;

		internal bool creatingHandle = false;

		protected FormShadowDecorator shadowDecorator;

		private static FormFrameSize savedFrameSize = new FormFrameSize
		{
			Caption = SystemInformation.CaptionHeight + 8,
			Height = 8,
			Width = 8
		};
		private bool IsModernUIEnabled
		{
			get => isCustomFrameEnabled && FormBorderStyle != FormBorderStyle.None && !IsDesignMode;
			set => isCustomFrameEnabled = value;
		}




		protected static int CornerAreaSize => SystemInformation.FrameBorderSize.Width;
		protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime || IsDesingerProcess;
		protected bool CanResize => FormBorderStyle == FormBorderStyle.SizableToolWindow || FormBorderStyle == FormBorderStyle.Sizable;

		protected static bool IsDesingerProcess
		{
			get
			{
				if (isDesingerProcess == null)
				{
					isDesingerProcess = Process.GetCurrentProcess().ProcessName == "devenv";
				}

				return isDesingerProcess.Value;
			}
		}

		protected Rectangle FormBounds
		{
			get
			{
				if (Handle == IntPtr.Zero) return new Rectangle(0, 0, Bounds.Width, Bounds.Height);
				var r = new RECT();
				User32.GetWindowRect(Handle, ref r);
				return r.ToRectangle();
			}
		}

		/// <summary>
		/// 设置或获取NanUI在Nonclient模式下是否显示投影
		/// </summary>
		[Category("NanUI")]
		public bool EnableFormShadow
		{
			get
			{
				if (IsDesignMode)
				{
					return isShadowEnabled;
				}
				else
				{
					return isShadowEnabled && IsModernUIEnabled;
				}
			}
			set
			{
				isShadowEnabled = value;

				shadowDecorator.Enable(EnableFormShadow);
			}
		}
		/// <summary>
		/// 设置或获取NanUI窗口边框线条粗细
		/// </summary>
		[Category("NanUI")]
		public int BorderSize
		{
			get; set;
		} = 1;

		/// <summary>
		/// 设置或获取非活动状态窗口边框颜色
		/// </summary>
		[Category("NanUI")]
		public Color InactiveBorderColor
		{
			get;
			set;
		} = ColorTranslator.FromHtml("#AAAAAA");

		/// <summary>
		/// 设置或获取活动状态窗口边框颜色
		/// </summary>
		[Category("NanUI")]
		public Color ActiveBorderColor
		{
			get;
			set;
		} = ColorTranslator.FromHtml("#1883D7");

		/// <summary>
		/// 设置或获取活动状态窗口投影颜色
		/// </summary>
		[Category("NanUI")]
		public Color ActiveShadowColor
		{
			get => shadowDecorator.ActiveColor;
			set => shadowDecorator.ActiveColor = value;
		}
		/// <summary>
		/// 设置或获取非活动状态窗口投影颜色
		/// </summary>
		[Category("NanUI")]
		public Color InactiveShadowColor
		{
			get => shadowDecorator.InactiveColor;
			set => shadowDecorator.InactiveColor = value;
		}



		public new bool TopMost
		{
			get
			{
				return base.TopMost;
			}
			set
			{
				base.TopMost = value;
				shadowDecorator.TopMost = value;
			}
		}

		public ModernUIForm() :
			this(true)
		{

		}

		public ModernUIForm(bool enableModernUI)
		{

			isCustomFrameEnabled = enableModernUI;

			shadowDecorator = new FormShadowDecorator(this, false);
			
			

			this.BackColor = Color.White;
			if (!IsDesignMode)
			{
				this.minimumClientSize = Size.Empty;
				this.maximumClientSize = Size.Empty;

			}


		}

		#region OVERRIDES
		protected override void CreateHandle()
		{

			if (!isCustomFrameEnabled)
			{
				base.CreateHandle();
				return;
			}

			var shouldPatchSize = !creatingHandle;
			creatingHandle = true;
			if (shouldPatchSize)
				if (WindowState != FormWindowState.Minimized && !IsDesignMode)
					Size = SizeFromClientSize(ClientSize);
			if (!IsHandleCreated)
				base.CreateHandle();
			this.creatingHandle = false;
		}

		protected override void OnHandleCreated(EventArgs e)
		{

			if (isCustomFrameEnabled)
			{
				UxTheme.SetWindowTheme(Handle, string.Empty, string.Empty);
				User32.DisableProcessWindowsGhosting();

				shadowDecorator.InitializeShadows();

			}

			base.OnHandleCreated(e);
		}

		bool? isEnterSizeMoveMode = null;
		protected override void WndProc(ref Message m)
		{
			if (!isCustomFrameEnabled)
			{
				base.WndProc(ref m);
				return;
			}

			var msg = (WindowsMessages)m.Msg;



			switch (msg)
			{
				//case WindowsMessages.WM_ENTERSIZEMOVE:
				//	{
				//		isEnterSizeMoveMode = true;
				//		base.WndProc(ref m);
				//	}
				//	break;
				//case WindowsMessages.WM_EXITSIZEMOVE:
				//	{
				//		isEnterSizeMoveMode = false;

				//		if (shadowDecorator != null && EnableFormShadow && !shadowDecorator.IsEnabled)
				//		{
				//			shadowDecorator.Enable(true);
				//		}

				//		base.WndProc(ref m);
				//	}
				//	break;
				//case WindowsMessages.WM_SIZING:
				//	{
				//		if (IsHandleCreated && isEnterSizeMoveMode == true && shadowDecorator.IsEnabled)
				//		{
				//			shadowDecorator.Enable(false);
				//		}
				//		base.WndProc(ref m);
				//	}
				//	break;
				case WindowsMessages.WM_SHOWWINDOW:
					{
						BringToFront();
						Focus();
						base.WndProc(ref m);
					}
					break;
				case WindowsMessages.WM_SIZE:
					if (IsHandleCreated)
					{
						WmSize(ref m);
					}
					base.WndProc(ref m);

					break;
				case WindowsMessages.WM_ACTIVATEAPP:
				case WindowsMessages.WM_MOVE:
				case WindowsMessages.WM_ACTIVATE:
					base.WndProc(ref m);
					User32.InvalidateWindow(Handle);

					break;

				case WindowsMessages.WM_NCACTIVATE:

					if (m.WParam == Win32.FALSE)
					{
						m.Result = Win32.MESSAGE_HANDLED;
						isWindowActive = false;
					}
					else
					{
						isWindowActive = true;
					}


					User32.SendFrameChanged(Handle);

					break;
				case WindowsMessages.WM_NCCALCSIZE:
					NCCalcSize(ref m);
					base.WndProc(ref m);

					break;
				case WindowsMessages.WM_NCPAINT:
					if (User32.IsWindowVisible(Handle) && IsHandleCreated)
					{
						NCPaint(ref m);
						m.Result = Win32.MESSAGE_PROCESS;
					}
					break;
				case WindowsMessages.WM_NCHITTEST:
					if (NCHitTest(ref m) == false)
					{
						base.WndProc(ref m);
					}
					break;
				case WindowsMessages.WM_NCUAHDRAWCAPTION:
				case WindowsMessages.WM_NCUAHDRAWFRAME:
					User32.SendFrameChanged(Handle);
					break;
				case WindowsMessages.WM_NCMOUSEMOVE:
					User32.SendFrameChanged(Handle);
					base.WndProc(ref m);

					break;
				default:
					base.WndProc(ref m);
					break;
			}


		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (!IsDesignMode)
			{
				if (StartPosition == FormStartPosition.CenterParent && Owner != null)
				{
					Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
					Owner.Location.Y + Owner.Height / 2 - Height / 2);


				}
				else if (StartPosition == FormStartPosition.CenterScreen || (StartPosition == FormStartPosition.CenterParent && Owner == null))
				{
					var currentScreen = Screen.FromPoint(MousePosition);
					Location = new Point(currentScreen.WorkingArea.Left + (currentScreen.WorkingArea.Width / 2 - this.Width / 2), currentScreen.WorkingArea.Top + (currentScreen.WorkingArea.Height / 2 - this.Height / 2));

				}
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (IsDesignMode) return;

			var action = new Action(() =>
			{
				shadowDecorator.Enable(EnableFormShadow);

				if (isWindowActive)
				{
					shadowDecorator.SetFocus();
				}
			});
			
			Task.Factory.StartNew(() =>
			{
				System.Threading.Thread.Sleep(300);

				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(action));
				}
				else
				{
					action.Invoke();
				}
			});



		}

		#endregion

		#region SIZE PATHCHER
		PropertyInfo piLayout = null;
		protected bool IsLayoutSuspendedNonPublic
		{
			get
			{
				if (piLayout == null) piLayout = typeof(Control).GetProperty("IsLayoutSuspended", BindingFlags.Instance | BindingFlags.NonPublic);
				if (piLayout != null) return (bool)piLayout.GetValue(this, null);
				return false;
			}
		}
		FieldInfo fiLayoutSuspendCount = null;
		[Browsable(false)]
		protected internal byte LayoutSuspendCountNonPublic
		{
			get
			{
				if (fiLayoutSuspendCount == null) fiLayoutSuspendCount = typeof(Control).GetField("layoutSuspendCount", BindingFlags.Instance | BindingFlags.NonPublic);
				if (fiLayoutSuspendCount != null) return (byte)fiLayoutSuspendCount.GetValue(this);
				return 1;
			}
		}
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (IsDesignMode)
			{
				base.SetBoundsCore(x, y, width, height, specified);

				return;

			}

			Size size = new Size(width, height);
			if (IsModernUIEnabled)
			{
				size = PatchFormSizeInRestoreWindowBoundsIfNecessary(width, height);
				size = CalcPreferredSizeCore(size);
			}
			
			base.SetBoundsCore(x, y, size.Width, size.Height, specified);
		}
		protected virtual Size CalcPreferredSizeCore(Size size)
		{
			return size;
		}
		protected virtual Size PatchFormSizeInRestoreWindowBoundsIfNecessary(int width, int height)
		{
			if (WindowState == FormWindowState.Normal && !IsDesignMode)
			{
				try
				{
					FieldInfo fiRestoredBoundsSpecified = typeof(Form).GetField("restoredWindowBoundsSpecified", BindingFlags.NonPublic | BindingFlags.Instance);
					BoundsSpecified restoredSpecified = (BoundsSpecified)fiRestoredBoundsSpecified.GetValue(this);
					if ((restoredSpecified & BoundsSpecified.Size) != BoundsSpecified.None)
					{
						FieldInfo fi1 = typeof(Form).GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static),
						fiFormState = typeof(Form).GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance),
						fiBounds = typeof(Form).GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);
						if (fi1 != null && fiFormState != null && fiBounds != null)
						{
							Rectangle restoredWindowBounds = (Rectangle)fiBounds.GetValue(this);
							BitVector32.Section bi1 = (BitVector32.Section)fi1.GetValue(this);
							BitVector32 state = (BitVector32)fiFormState.GetValue(this);
							if (state[bi1] == 1)
							{
								width = restoredWindowBounds.Width + BorderSize * 2;
								height = restoredWindowBounds.Height + BorderSize * 2;
							}
						}
					}
				}
				catch
				{
				}
			}
			return new Size(width, height);
		}



		protected bool IsInitializing { get { return !forceInitialized && (this.isInitializing != 0 || IsLayoutSuspendedNonPublic); } }
		public new void SuspendLayout()
		{
			
			base.SuspendLayout();

			if (IsDesignMode) return;

			isInitializing++;
		}
		public new void ResumeLayout() { ResumeLayout(true); }
		public new void ResumeLayout(bool performLayout)
		{
			if (IsDesignMode) {
				base.ResumeLayout(performLayout);
				return;
			}

			if (this.isInitializing > 0)
				this.isInitializing--;
			if (this.isInitializing == 0)
			{
				CheckMinimumSize();
				CheckMaximumSize();
			}

			base.ResumeLayout(performLayout);

			if (!IsInitializing)
			{
				CheckMinimumSize();
				CheckMaximumSize();
			}
		}
		private void SetRegion(Region region, Rectangle rect)
		{
			if (this.regionRect == rect)
			{
				if (region != null)
					region.Dispose();
				return;
			}
			if (Region != null)
			{
				Region.Dispose();
			}
			Region = region;
			if (object.Equals(region, Region))
				this.regionRect = rect;
		}
		private void CheckMaximumSize()
		{
			if (this.maximumSize == null) return;
			Size msize = (Size)maximumSize;
			if (!msize.IsEmpty)
			{
				if (msize.Width > 0) msize.Width = Math.Max(msize.Width, Size.Width);
				if (msize.Height > 0) msize.Height = Math.Max(msize.Height, Size.Height);
				if (this.minimumSize != null && !this.minimumSize.Value.IsEmpty)
				{
					if (this.maximumSize.Value.Width == this.minimumSize.Value.Width)
						msize.Width = Size.Width;
					if (this.maximumSize.Value.Height == this.minimumSize.Value.Height)
						msize.Height = Size.Height;
				}
			}
			this.maximumSize = null;
			base.MaximumSize = msize;
		}
		private void CheckMinimumSize()
		{
			if (this.minimumSize == null) return;
			Size msize = (Size)minimumSize;
			if (!msize.IsEmpty)
			{
				if (msize.Width > 0) msize.Width = Math.Min(msize.Width, Size.Width);
				if (msize.Height > 0) msize.Height = Math.Min(msize.Height, Size.Height);
				if (this.maximumSize != null && !this.maximumSize.Value.IsEmpty)
				{
					if (this.maximumSize.Value.Width == this.minimumSize.Value.Width)
						msize.Width = Size.Width;
					if (this.maximumSize.Value.Height == this.minimumSize.Value.Height)
						msize.Height = Size.Height;
				}
			}
			this.minimumSize = null;
			base.MinimumSize = msize;
		}

		protected Size ConstrainMinimumClientSize(Size value)
		{
			value.Width = Math.Max(0, value.Width);
			value.Height = Math.Max(0, value.Height);
			return value;
		}

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size MinimumClientSize
		{
			get { return minimumClientSize; }
			set
			{
				value = ConstrainMinimumClientSize(value);
				if (MinimumClientSize == value) return;
				minimumClientSize = value;
				OnMinimumClientSizeChanged();
			}
		}
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size MaximumClientSize
		{
			get { return maximumClientSize; }
			set
			{
				if (MaximumClientSize == value) return;
				maximumClientSize = value;
				OnMaximumClientSizeChanged();
			}
		}


		protected virtual void OnMinimumClientSizeChanged()
		{
			if (IsInitializing) return;
			MinimumSize = GetConstrainSize(MinimumClientSize);
		}
		protected virtual void OnMaximumClientSizeChanged()
		{
			if (IsInitializing) return;
			MaximumSize = GetConstrainSize(MaximumClientSize);
		}
		protected virtual Size GetConstrainSize(Size clientSize)
		{
			if (clientSize == Size.Empty) return Size.Empty;
			return SizeFromClientSize(clientSize);
		}

		protected override Size SizeFromClientSize(Size clientSize)
		{

			if (IsDesignMode)
			{
				return base.SizeFromClientSize(clientSize);
			}

			return CalcSizeFromClientSize(clientSize);
		}

		protected internal virtual Size CalcSizeFromClientSize(Size client)
		{
			client.Width += (BorderSize * 2);
			client.Height += (BorderSize * 2);
			return client;
		}

		internal bool IsMaximizedBoundsSet
		{
			get { return !MaximumSize.IsEmpty || !MaximizedBounds.IsEmpty; }
		}

		protected bool IsZoomedBorder
		{
			get
			{
				if (!IsZoomed) return false;

				return IsMaximizedBoundsSet;
			}
		}
		protected bool IsZoomed
		{
			get
			{
				return Handle == IntPtr.Zero ? WindowState == FormWindowState.Maximized : User32.IsZoomed(Handle);
			}
		}
		FieldInfo formStateCoreField;
		FieldInfo FormStateCoreField
		{
			get
			{
				if (formStateCoreField == null)
					formStateCoreField = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);
				return formStateCoreField;
			}
		}
		private bool IsFormStateClientSizeSet()
		{
			FieldInfo fi1 = typeof(Form).GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
			BitVector32.Section bi1 = (BitVector32.Section)fi1.GetValue(this);
			BitVector32 state = (BitVector32)FormStateCoreField.GetValue(this);
			return state[bi1] == 1;
		}
		protected override void ScaleCore(float x, float y)
		{
			if (IsDesignMode || !IsModernUIEnabled)
			{
				base.ScaleCore(x, y);
				return;

			}

			MaximumClientSize = new Size((int)Math.Round(MaximumClientSize.Width * x), (int)Math.Round(MaximumClientSize.Height * y));
			base.ScaleCore(x, y);
			MinimumClientSize = new Size((int)Math.Round(MinimumClientSize.Width * x), (int)Math.Round(MinimumClientSize.Height * y));
		}


		bool clientSizeSet = false;

		protected override void SetClientSizeCore(int x, int y)
		{
			this.clientSizeSet = false;
			FieldInfo fiWidth = typeof(Control).GetField("clientWidth", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo fiHeight = typeof(Control).GetField("clientHeight", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo fi1 = typeof(Form).GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static),
				fiFormState = typeof(Form).GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);

			if (isCustomFrameEnabled && fiWidth != null && fiHeight != null && fiFormState != null && fi1 != null)
			{
				this.clientSizeSet = true;
				this.Size = SizeFromClientSize(new Size(x, y));
				fiWidth.SetValue(this, x);
				fiHeight.SetValue(this, y);
				BitVector32.Section bi1 = (BitVector32.Section)fi1.GetValue(this);
				BitVector32 state = (BitVector32)fiFormState.GetValue(this);
				state[bi1] = 1;
				fiFormState.SetValue(this, state);
				this.OnClientSizeChanged(EventArgs.Empty);
				state[bi1] = 0;
				fiFormState.SetValue(this, state);
			}
			else
			{
				base.SetClientSizeCore(x, y);
			}
		}
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;

				if (!IsModernUIEnabled || IsDesignMode)
				{
					return cp;

				}

				if (IsFormStateClientSizeSet())
				{
					cp.Width = Width;
					cp.Height = Height;
				}

				return cp;
			}
		}
		protected virtual Region GetDefaultFormRegion(ref Rectangle rect)
		{
			rect = Rectangle.Empty;
			return null;
		}

		#endregion

		#region WindowsMessages

		private void WmSize(ref Message m)
		{
			if (WindowState == FormWindowState.Maximized)
			{
				Screen screen = Screen.FromHandle(Handle);
				if (screen == null) return;
				Rectangle bounds = FormBorderStyle == FormBorderStyle.None ? screen.Bounds : screen.WorkingArea;
				Rectangle formBounds = FormBounds;
				if (formBounds.X == -10000 || formBounds.Y == -10000)
					return;
				Rectangle r = new Rectangle(bounds.X - formBounds.X, bounds.Y - formBounds.Y, formBounds.Width - (formBounds.Width - bounds.Width), formBounds.Height - (formBounds.Height - bounds.Height));

				SetRegion(new Region(r), r);
			}
			else if (WindowState == FormWindowState.Minimized)
			{
				SetRegion(null, Rectangle.Empty);
				return;
			}
			else
			{
				Rectangle rect = new Rectangle();
				Region region = GetDefaultFormRegion(ref rect);
				SetRegion(region, rect);
			}
		}

		private void NCPaint(ref Message m)
		{
			var hdc = GetDC(m);

			if (hdc == IntPtr.Zero)
			{
				return;
			}

			using (var g = Graphics.FromHdc(hdc))
			{
				RECT windowRect = new RECT();

				User32.GetWindowRect(Handle, ref windowRect);

				User32.OffsetRect(ref windowRect, -windowRect.left, -windowRect.top);

				RECT clientRect = new RECT();
				User32.GetClientRect(Handle, ref clientRect);
				User32.OffsetRect(ref clientRect, -clientRect.left, -clientRect.top);

				User32.OffsetRect(ref clientRect, BorderSize, BorderSize);

				//Console.WriteLine($"{windowRect} {clientRect}");


				var frameRegion = new Region(windowRect.ToRectangle());

				if (WindowState == FormWindowState.Maximized)
				{
					frameRegion.Exclude(windowRect.ToRectangle());
				}
				else
				{

					frameRegion.Exclude(clientRect.ToRectangle());
				}



				g.FillRegion(new SolidBrush(isWindowActive ? ActiveBorderColor : InactiveBorderColor), frameRegion);
			}

			User32.ReleaseDC(Handle, hdc);
		}

		public IntPtr GetDC(Message msg)
		{
			IntPtr res = IntPtr.Zero;

			if (msg.Msg == (int)WindowsMessages.WM_NCPAINT)
			{
				int flags = (int)DCX.DCX_CACHE | (int)DCX.DCX_CLIPSIBLINGS | (int)DCX.DCX_WINDOW | (int)DCX.DCX_VALIDATE;

				IntPtr hrgnCopy = IntPtr.Zero;

				if (msg.WParam != Win32.TRUE)
				{
					flags |= (int)DCX.DCX_INTERSECTRGN;
					hrgnCopy = Gdi32.CreateRectRgn(0, 0, 1, 1);
					Gdi32.CombineRgn(hrgnCopy, msg.WParam, IntPtr.Zero, Gdi32.RGN_COPY);
				}

				res = User32.GetDCEx(Handle, hrgnCopy, flags);

				return res;
			}

			return User32.GetWindowDC(Handle);
		}

		private void RecalculateSize()
		{
			User32.SetWindowPos(Handle, IntPtr.Zero,
				0, 0, 0, 0,
				SetWindowPosFlags.SWP_FRAMECHANGED | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOZORDER);
		}

		private bool NCHitTest(ref Message m)
		{
			if (m.Result == Win32.FALSE)
			{
				var pos = new POINT((int)User32.LoWord(m.LParam), (int)User32.HiWord(m.LParam));
				User32.ScreenToClient(Handle, ref pos);

				var mode = GetSizeMode(pos);


				SetCursor(mode);
				m.Result = (IntPtr)mode;


				return true;
			}

			return false;
		}

		protected HitTest GetSizeMode(POINT point)
		{
			HitTest mode = HitTest.HTNOWHERE;



			int x = point.x, y = point.y;

			if (WindowState == FormWindowState.Normal && CanResize)
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
		protected void SetCursor(HitTest mode)
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

		private void NCCalcSize(ref Message m)
		{


			if (m.WParam != Win32.FALSE)
			{
				var ncsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
				var wp = (WINDOWPOS)Marshal.PtrToStructure(ncsize.lppos, typeof(WINDOWPOS));

				if (!isFrameSizeStored)
				{
					isFrameSizeStored = true;

					savedFrameSize.Caption = ncsize.rectClientBeforeMove.top - ncsize.rectProposed.top;
					savedFrameSize.Width = ncsize.rectClientBeforeMove.left - ncsize.rectProposed.left;
					savedFrameSize.Height = ncsize.rectBeforeMove.bottom - ncsize.rectClientBeforeMove.bottom;

				}

				ncsize.rectBeforeMove = ncsize.rectProposed;

				ncsize.rectProposed.top -= savedFrameSize.Caption;

				if (WindowState != FormWindowState.Maximized)
				{
					ncsize.rectProposed.right += savedFrameSize.Width;
					ncsize.rectProposed.bottom += savedFrameSize.Height;
					ncsize.rectProposed.left -= savedFrameSize.Width;

					ncsize.rectProposed.top += BorderSize;
					ncsize.rectProposed.right -= BorderSize;
					ncsize.rectProposed.bottom -= BorderSize;
					ncsize.rectProposed.left += BorderSize;
				}
				else
				{
					ncsize.rectProposed.top += savedFrameSize.Height;
				}




				Marshal.StructureToPtr(ncsize, m.LParam, false);
				m.Result = WVR_VALIDRECTS;

				User32.InvalidateWindow(Handle);

			}

		}

		private RECT CalculateFrameSize(int x, int y, int cx, int cy)
		{
			var windowRect = new RECT(x, y, cx, cy);

			windowRect.top -= savedFrameSize.Caption;
			windowRect.right += savedFrameSize.Width;
			windowRect.bottom += savedFrameSize.Height;
			windowRect.left -= savedFrameSize.Width;

			windowRect.top += BorderSize;
			windowRect.right -= BorderSize;
			windowRect.bottom -= BorderSize;
			windowRect.left += BorderSize;



			return windowRect;
		}
		#endregion
	}
}
