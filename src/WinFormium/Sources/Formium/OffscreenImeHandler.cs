// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium;
internal class OffscreenImeHandler
{
    internal static class ImeNative
    {
        internal const uint GCS_RESULTSTR = 0x0800;
        internal const uint GCS_COMPSTR = 0x0008;
        internal const uint GCS_COMPATTR = 0x0010;
        internal const uint GCS_CURSORPOS = 0x0080;
        internal const uint GCS_COMPCLAUSE = 0x0020;

        internal const uint CPS_COMPLETE = 0x0001;
        internal const uint CPS_CANCEL = 0x0004;

        internal const uint CS_NOMOVECARET = 0x4000;
        internal const uint NI_COMPOSITIONSTR = 0x0015;

        internal const uint ATTR_INPUT = 0x00;
        internal const uint ATTR_TARGET_CONVERTED = 0x01;
        internal const uint ATTR_TARGET_NOTCONVERTED = 0x03;

        internal const uint ISC_SHOWUICOMPOSITIONWINDOW = 0x80000000;

        internal const uint CFS_DEFAULT = 0x0000;
        internal const uint CFS_RECT = 0x0001;
        internal const uint CFS_POINT = 0x0002;
        internal const uint CFS_FORCE_POSITION = 0x0020;
        internal const uint CFS_CANDIDATEPOS = 0x0040;
        internal const uint CFS_EXCLUDE = 0x0080;

        internal const uint LANG_JAPANESE = 0x11;
        internal const uint LANG_CHINESE = 0x04;
        internal const uint LANG_KOREAN = 0x12;

        internal const uint IACE_CHILDREN = 0x0001;

        internal const uint IACE_DEFAULT = 0x0010;

        internal const uint IACE_IGNORENOCONTEXT = 0x0020;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMPOSITIONFORM
        {
            public int dwStyle;
            public POINT ptCurrentPos;
            public RECT rcArea;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CANDIDATEFORM
        {
            public int dwIndex;
            public int dwStyle;
            public POINT ptCurrentPos;
            public RECT rcArea;
        }

        [DllImport("Imm32.dll")]
        internal static extern IntPtr ImmCreateContext();

        [DllImport("Imm32.dll")]
        internal static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("Imm32.dll")]
        internal static extern IntPtr ImmAssociateContextEx(IntPtr hWnd, IntPtr hIMC, uint flag);

        [DllImport("Imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("Imm32.dll")]
        internal static extern bool ImmDestroyContext(IntPtr hIMC);

        [DllImport("Imm32.dll")]
        internal static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("Imm32.dll")]
        internal static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("Imm32.dll")]
        internal static extern bool ImmNotifyIME(IntPtr hIMC, uint action, uint index, uint value);

        [DllImport("Imm32.dll", CharSet = CharSet.Unicode)]
        internal static extern uint ImmGetCompositionString(IntPtr hIMC, uint dwIndex, byte[] lpBuf, uint dwBufLen);

        [DllImport("Imm32.dll")]
        internal static extern int ImmSetCompositionWindow(IntPtr hIMC, ref COMPOSITIONFORM lpCompForm);

        [DllImport("Imm32.dll")]
        public static extern int ImmSetCandidateWindow(IntPtr hIMC, [MarshalAs(UnmanagedType.Struct)] ref CANDIDATEFORM lpCandidateForm);
    }

    const int ATTR_TARGET_CONVERTED = 0x01;
    const int ATTR_TARGET_NOTCONVERTED = 0x03;

    const uint COLOR_UNDERLINE = 0xFF000000;
    const uint COLOR_BKCOLOR = 0x00000000;

    private int languageCodeId;
    private bool systemCaret;
    private int cursorIndex = -1;
    private bool isComposing = false;

    CefRange compositionRange = new CefRange();

    List<CefRectangle> compositionBounds = new List<CefRectangle>();


    internal HWND hWnd { get; set; }
    internal IntPtr Handle => hWnd.DangerousGetHandle();

    internal Formium Owner { get; }

    public OffscreenImeHandler(Formium owner)
    {
        Owner = owner;
    }

    private int PrimaryLangId(int lgid)
    {
        return lgid & 0x3ff;
    }

    internal void CreateImeWindow()
    {
        // Chinese/Japanese IMEs somehow ignore function calls to
        // ::ImmSetCandidateWindow(), and use the position of the current system
        // caret instead -::GetCaretPos().
        // Therefore, we create a temporary system caret for Chinese IMEs and use
        // it during this input context.
        // Since some third-party Japanese IME also uses ::GetCaretPos() to determine
        // their window position, we also create a caret for Japanese IMEs.


        languageCodeId = PrimaryLangId(InputLanguage.CurrentInputLanguage.Culture.KeyboardLayoutId);

        if (languageCodeId == ImeNative.LANG_JAPANESE || languageCodeId == ImeNative.LANG_CHINESE)
        {
            if (!systemCaret)
            {
                if (CreateCaret(hWnd, HBITMAP.NULL, 1, 3))
                {
                    systemCaret = true;

                    //System.Diagnostics.Debug.WriteLine("System caret created.");
                }
            }
        }
    }

    internal void DestroyImeWindow()
    {
        // Destroy the system caret if we have created for this IME input context.
        if (systemCaret)
        {
            DestroyCaret();
            systemCaret = false;

            //System.Diagnostics.Debug.WriteLine("System caret destroyed.");

        }
    }

    internal bool IsSelectionAttribute(byte attribute)
    {
        return (attribute == ATTR_TARGET_CONVERTED || attribute == ATTR_TARGET_NOTCONVERTED);
    }

    internal void GetCompositionSelectionRange(IntPtr imc, out int targetStart, out int targetEnd)
    {
        var attributeSize = ImeNative.ImmGetCompositionString(imc, ImeNative.GCS_COMPATTR, null, 0);

        if (attributeSize > 0)
        {

            var buff = new byte[attributeSize];

            ImeNative.ImmGetCompositionString(imc, ImeNative.GCS_COMPATTR, buff, attributeSize);

            int start, end;
            for (start = 0; start < attributeSize; ++start)
            {
                if (IsSelectionAttribute(buff[start]))
                    break;
            }

            for (end = start; end < attributeSize; ++end)
            {
                if (!IsSelectionAttribute(buff[end]))
                    break;
            }

            targetStart = start;
            targetEnd = end;

        }
        else
        {
            targetStart = 0;
            targetEnd = 0;

        }
    }

    internal IEnumerable<CefCompositionUnderline> GetCompositionUnderlines(IntPtr imc, int start, int end)
    {
        var clauseSize = ImeNative.ImmGetCompositionString(imc, ImeNative.GCS_COMPCLAUSE, null, 0);

        var clauseLength = (int)clauseSize / sizeof(int);

        var result = new List<CefCompositionUnderline>();

        if (clauseLength > 0)
        {
            var clauseData = new byte[(int)clauseSize];

            ImeNative.ImmGetCompositionString(imc, ImeNative.GCS_COMPCLAUSE, clauseData, clauseSize);

            for (var i = 0; i < clauseLength - 1; i++)
            {
                var from = BitConverter.ToInt32(clauseData, i * sizeof(int));
                var to = BitConverter.ToInt32(clauseData, (i + 1) * sizeof(int));

                var range = new CefRange(from, to);

                var think = range.From >= start && range.To <= end;

                var underline = new CefCompositionUnderline
                {
                    Range = range,
                    Color = new CefColor(COLOR_UNDERLINE),
                    BackgroundColor = new CefColor(COLOR_BKCOLOR),
                    Thick = think,
                };

                result.Add(underline);
            }
        }

        return result;

    }


    internal void MoveImeWindow()
    {
        const int kCaretMargin = 1;


        if (GetFocus() != hWnd)
        {
            return;
        }

        if (compositionBounds.Count == 0)
        {
            return;
        }

        CefRectangle rc;

        var location = cursorIndex;

        if (location == -1)
        {
            location = compositionRange.From;
        }

        if (location >= compositionRange.From)
        {
            location -= compositionRange.From;
        }

        if (location < compositionBounds.Count)
        {
            rc = compositionBounds[location];
        }
        else
        {
            return;
        }





        var x = rc.X + rc.Width;
        var y = rc.Y + rc.Height;

        //System.Diagnostics.Debug.WriteLine($"[MoveImeWindow] -> caret:{systemCaret} {x}:{y}");


        if (systemCaret)
        {
            if (languageCodeId == ImeNative.LANG_JAPANESE)
            {
                SetCaretPos(rc.X, rc.Y + rc.Height);
            }
            else
            {
                SetCaretPos(rc.X, rc.Y);
            }
        }

        var imc = ImeNative.ImmGetContext(Handle);


        var candidatePosition = new ImeNative.CANDIDATEFORM
        {
            dwIndex = 0,
            dwStyle = (int)ImeNative.CFS_CANDIDATEPOS,
            ptCurrentPos = new ImeNative.POINT(x, y),
            rcArea = new ImeNative.RECT(0, 0, 0, 0)
        };


        ImeNative.ImmSetCandidateWindow(imc, ref candidatePosition);


        if (languageCodeId == ImeNative.LANG_CHINESE)
        {
            // Chinese IMEs ignore function calls to ::ImmSetCandidateWindow()
            // when a user disables TSF (Text Service Framework) and CUAS (Cicero
            // Unaware Application Support).
            // On the other hand, when a user enables TSF and CUAS, Chinese IMEs
            // ignore the position of the current system caret and use the
            // parameters given to ::ImmSetCandidateWindow() with its 'dwStyle'
            // parameter CFS_CANDIDATEPOS.
            // Therefore, we do not only call ::ImmSetCandidateWindow() but also
            // set the positions of the temporary system caret if it exists.

            var candidatePotision = new ImeNative.COMPOSITIONFORM
            {
                dwStyle = (int)ImeNative.CFS_CANDIDATEPOS,
                ptCurrentPos = new ImeNative.POINT(rc.X, rc.Y),
                rcArea = new ImeNative.RECT(0, 0, 0, 0)
            };

            ImeNative.ImmSetCompositionWindow(imc, ref candidatePotision);
        }



        if (languageCodeId == ImeNative.LANG_KOREAN)
        {
            // Korean IMEs require the lower-left corner of the caret to move their
            // candidate windows.
            rc.Y += kCaretMargin;
        }

        // Japanese IMEs and Korean IMEs also use the rectangle given to
        // ::ImmSetCandidateWindow() with its 'dwStyle' parameter CFS_EXCLUDE
        // Therefore, we also set this parameter here.

        var excludeRectangle = new ImeNative.CANDIDATEFORM
        {
            dwIndex = 0,
            dwStyle = (int)ImeNative.CFS_EXCLUDE,
            ptCurrentPos = new ImeNative.POINT(rc.X, rc.Y),
            rcArea = new ImeNative.RECT(rc.X, rc.Y, rc.X + rc.Width, rc.Y + rc.Height)
        };

        ImeNative.ImmSetCandidateWindow(imc, ref excludeRectangle);

        ImeNative.ImmReleaseContext(Handle, imc);
    }

    internal void CleanupComposition()
    {
        if (isComposing)
        {
            var imc = ImeNative.ImmGetContext(Handle);
            if (imc != IntPtr.Zero)
            {
                ImeNative.ImmNotifyIME(imc, ImeNative.NI_COMPOSITIONSTR, ImeNative.CPS_COMPLETE, 0);
                ImeNative.ImmReleaseContext(Handle, imc);
            }

            ResetComposition();
        }
    }

    internal void ResetComposition()
    {
        // Reset the composition status.
        isComposing = false;
        cursorIndex = -1;
    }

    internal List<CefCompositionUnderline> GetCompositionInfo(IntPtr imc, uint lparam, string compositionText, out int compositionStart)
    {
        var underlines = new List<CefCompositionUnderline>();
        var length = compositionText.Length;

        var targetStart = length;
        var targetEnd = length;

        if ((lparam & ImeNative.GCS_COMPATTR) == ImeNative.GCS_COMPATTR)
        {
            GetCompositionSelectionRange(imc, out targetStart, out targetEnd);
        }

        if (((lparam & ImeNative.CS_NOMOVECARET) != ImeNative.CS_NOMOVECARET) && ((lparam & ImeNative.GCS_CURSORPOS) == ImeNative.GCS_CURSORPOS))
        {
            var cursor = (int)ImeNative.ImmGetCompositionString(imc, ImeNative.GCS_CURSORPOS, null, 0);
            compositionStart = cursor;
        }
        else
        {
            compositionStart = 0;
        }


        if ((lparam & ImeNative.GCS_COMPCLAUSE) == ImeNative.GCS_COMPCLAUSE)
        {
            underlines = GetCompositionUnderlines(imc, targetStart, targetEnd).ToList();
        }

        if (underlines.Count == 0)
        {
            var underline = new CefCompositionUnderline();
            underline.Color = new CefColor(COLOR_UNDERLINE);
            underline.BackgroundColor = new CefColor(COLOR_BKCOLOR);

            if (targetStart > 0)
            {
                underline.Range = new CefRange(targetStart, targetEnd);
                underline.Thick = true;
                underlines.Add(underline);
            }

            if (targetEnd < length)
            {
                underline.Range = new CefRange(targetEnd, length);
                underline.Thick = false;
                underlines.Add(underline);
            }
        }

        return underlines;

    }

    internal bool GetString(IntPtr imc, uint lparam, uint type, out string result)
    {
        if (((int)lparam & type) != type)
        {
            result = null;
            return false;
        }

        var strlen = ImeNative.ImmGetCompositionString(imc, type, null, 0);

        if (strlen <= 0)
        {
            result = null;
            return false;
        }

        var buff = new byte[strlen];

        ImeNative.ImmGetCompositionString(imc, type, buff, strlen);

        result = Encoding.Unicode.GetString(buff);

        return true;
    }

    internal bool GetResult(uint lparam, out string? result)
    {
        var ret = false;

        var imc = ImeNative.ImmGetContext(Handle);

        if (imc != IntPtr.Zero)
        {
            ret = GetString(imc, lparam, ImeNative.GCS_RESULTSTR, out result);

            ImeNative.ImmReleaseContext(Handle, imc);
        }
        else
        {
            result = null;
        }

        return ret;
    }

    internal bool GetComposition(uint lparam, out string compositionText, out int compostionStart, ref List<CefCompositionUnderline> underlines)
    {
        var imc = ImeNative.ImmGetContext(Handle);

        var ret = GetString(imc, lparam, ImeNative.GCS_COMPSTR, out compositionText);

        if (ret)
        {
            underlines = GetCompositionInfo(imc, lparam, compositionText, out compostionStart);

            isComposing = true;
        }
        else
        {
            compostionStart = 0;
        }

        ImeNative.ImmReleaseContext(Handle, imc);

        return ret;

    }

    internal void UpdateCaretPosition(int index)
    {
        // Save the caret position.
        cursorIndex = index;
        // Move the IME window.
        MoveImeWindow();
    }




    #region IME Control
    public void DisableIME()
    {
        CleanupComposition();
        ImeNative.ImmAssociateContextEx(Handle, IntPtr.Zero, 0);
    }

    public void CancelIME()
    {
        if (isComposing)
        {
            var imc = ImeNative.ImmGetContext(Handle);
            if (imc != IntPtr.Zero)
            {
                ImeNative.ImmNotifyIME(imc, ImeNative.NI_COMPOSITIONSTR, ImeNative.CPS_CANCEL, 0);
                ImeNative.ImmReleaseContext(Handle, imc);
            }
            ResetComposition();
        }
    }

    public void EnableIME()
    {
        // Load the default IME context.
        ImeNative.ImmAssociateContextEx(Handle, IntPtr.Zero, ImeNative.IACE_DEFAULT);
    }

    #endregion

    public void ChangeCompositionRange(CefRange selectRange, IEnumerable<CefRectangle> bounds)
    {
        var scaleFactor = SystemDpiManager.GetScaleFactorForWindow(hWnd);

        compositionRange = selectRange;

        var rects = new List<CefRectangle>();

        foreach (var rect in bounds)
        {
            var scaledBounds = new CefRectangle((int)(rect.X * scaleFactor), (int)(rect.Y * scaleFactor), (int)(rect.Width * scaleFactor), (int)(rect.Height * scaleFactor));
            rects.Add(scaledBounds);

        }

        compositionBounds = rects;

        MoveImeWindow();

    }

    public void OnIMESetContext(ref Message m)
    {
        hWnd = Owner.WindowHandle;

        var retval = (ulong)m.LParam;

        retval &= ~ImeNative.ISC_SHOWUICOMPOSITIONWINDOW;

        var lParam = (IntPtr)retval;

        DefWindowProc(hWnd, (uint)m.Msg, m.WParam, lParam);

    }

    public void OnImeStartComposition()
    {


        ResetComposition();

        CreateImeWindow();
    }

    public void OnImeComposition(WindowMessage message, IntPtr wParam, IntPtr lParam)
    {
        var browserHost = Owner.WebView?.BrowserHost;

        if (browserHost == null) return;

        if (GetResult((uint)lParam, out var textStr))
        {
            browserHost.ImeCommitText(textStr, new CefRange(int.MaxValue, int.MaxValue), 0);

            browserHost.ImeSetComposition(textStr, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));

            browserHost.ImeFinishComposingText(false);

            ResetComposition();

        }
        else
        {
            var underlines = new List<CefCompositionUnderline>();

            if (GetComposition((uint)lParam, out textStr, out var compostionStart, ref underlines))
            {

                browserHost.ImeSetComposition(textStr, underlines.Count, underlines[0], new CefRange(int.MaxValue, int.MaxValue), new CefRange(compostionStart, compostionStart + textStr.Length));

                UpdateCaretPosition(compostionStart - 1);
            }
            else
            {
                browserHost.ImeSetComposition(string.Empty, 1, new CefCompositionUnderline { }, new CefRange(0, 1), new CefRange(0, 1));

                OnImeCancelComposition();
            }
        }





    }

    public void OnImeCancelComposition()
    {
        var browserHost = Owner.WebView?.BrowserHost;

        if (browserHost == null) return;

        browserHost?.ImeSetComposition(string.Empty, 0, new CefCompositionUnderline(), new CefRange(int.MaxValue, int.MaxValue), new CefRange(0, 0));

        browserHost?.ImeCommitText(string.Empty, new CefRange(int.MaxValue, int.MaxValue), 0);



        if (languageCodeId != ImeNative.LANG_KOREAN)
        {
            browserHost?.ImeFinishComposingText(false);
        }




        browserHost?.ImeCancelComposition();
        ResetComposition();
        DestroyImeWindow();
    }

}
