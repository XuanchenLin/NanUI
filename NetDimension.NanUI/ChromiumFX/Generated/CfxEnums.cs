// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	/// <summary>
	/// Supported certificate status code values. See net\cert\cert_status_flags.h
	/// for more information. CERT_STATUS_NONE is new in CEF because we use an
	/// enum while cert_status_flags.h uses a typedef and static const variables.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
	/// </remarks>
	public enum CfxCertStatus {
        None = unchecked((int)0),
        CommonNameInvalid = unchecked((int)1 << 0),
        DateInvalid = unchecked((int)1 << 1),
        AuthorityInvalid = unchecked((int)1 << 2),
        NoRevocationMechanism = unchecked((int)1 << 4),
        UnableToCheckRevocation = unchecked((int)1 << 5),
        Revoked = unchecked((int)1 << 6),
        Invalid = unchecked((int)1 << 7),
        WeakSignatureAlgorithm = unchecked((int)1 << 8),
        NonUniqueName = unchecked((int)1 << 10),
        WeakKey = unchecked((int)1 << 11),
        PinnedKeyMissing = unchecked((int)1 << 13),
        NameConstraintViolation = unchecked((int)1 << 14),
        ValidityTooLong = unchecked((int)1 << 15),
        IsEv = unchecked((int)1 << 16),
        RevCheckingEnabled = unchecked((int)1 << 17),
        Sha1SignaturePresent = unchecked((int)1 << 19),
        CtComplianceFailed = unchecked((int)1 << 20)
    }
    /// <summary>
    /// Print job color mode values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxColorModel {
        Unknown,
        Gray,
        Color,
        Cmyk,
        Cmy,
        Kcmy,
        CmyK,
        Black,
        Grayscale,
        Rgb,
        Rgb16,
        Rgba,
        ColorModeColor,
        ColorModeMonochrome,
        HpColorColor,
        HpColorBlack,
        PrintoutModeNormal,
        PrintoutModeNormalGray,
        ProcessColorModelCmyk,
        ProcessColorModelGreyscale,
        ProcessColorModelRgb
    }
    /// <summary>
    /// Supported context menu edit state bit flags.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxContextMenuEditStateFlags {
        None = unchecked((int)0),
        CanUndo = unchecked((int)1 << 0),
        CanRedo = unchecked((int)1 << 1),
        CanCut = unchecked((int)1 << 2),
        CanCopy = unchecked((int)1 << 3),
        CanPaste = unchecked((int)1 << 4),
        CanDelete = unchecked((int)1 << 5),
        CanSelectAll = unchecked((int)1 << 6),
        CanTranslate = unchecked((int)1 << 7)
    }
    /// <summary>
    /// Supported context menu media state bit flags.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxContextMenuMediaStateFlags {
        None = unchecked((int)0),
        Error = unchecked((int)1 << 0),
        Paused = unchecked((int)1 << 1),
        Muted = unchecked((int)1 << 2),
        Loop = unchecked((int)1 << 3),
        CanSave = unchecked((int)1 << 4),
        HasAudio = unchecked((int)1 << 5),
        HasVideo = unchecked((int)1 << 6),
        ControlRootElement = unchecked((int)1 << 7),
        CanPrint = unchecked((int)1 << 8),
        CanRotate = unchecked((int)1 << 9)
    }
    /// <summary>
    /// Supported context menu media types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxContextMenuMediaType {
        /// <summary>
        /// No special node is in context.
        /// </summary>
        None,
        /// <summary>
        /// An image node is selected.
        /// </summary>
        Image,
        /// <summary>
        /// A video node is selected.
        /// </summary>
        Video,
        /// <summary>
        /// An audio node is selected.
        /// </summary>
        Audio,
        /// <summary>
        /// A file node is selected.
        /// </summary>
        File,
        /// <summary>
        /// A plugin node is selected.
        /// </summary>
        Plugin
    }
    /// <summary>
    /// Supported context menu type flags.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxContextMenuTypeFlags {
        /// <summary>
        /// No node is selected.
        /// </summary>
        None = unchecked((int)0),
        Page = unchecked((int)1 << 0),
        Frame = unchecked((int)1 << 1),
        Link = unchecked((int)1 << 2),
        Media = unchecked((int)1 << 3),
        Selection = unchecked((int)1 << 4),
        Editable = unchecked((int)1 << 5)
    }
    /// <summary>
    /// Cursor type values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxCursorType {
        Pointer = unchecked((int)0),
        Cross,
        Hand,
        Ibeam,
        Wait,
        Help,
        EastResize,
        NorthResize,
        NortheastResize,
        NorthwestResize,
        SouthResize,
        SoutheastResize,
        SouthwestResize,
        WestResize,
        NorthSouthResize,
        EastWestResize,
        NortheastSouthwestResize,
        NorthwestSoutheastResize,
        ColumnResize,
        RowResize,
        MiddlePanning,
        EastPanning,
        NorthPanning,
        NortheastPanning,
        NorthwestPanning,
        SouthPanning,
        SoutheastPanning,
        SouthwestPanning,
        WestPanning,
        Move,
        VerticalText,
        Cell,
        ContextMenu,
        Alias,
        Progress,
        NoDrop,
        Copy,
        None,
        NotAllowed,
        ZoomIn,
        ZoomOut,
        Grab,
        Grabbing,
        Custom
    }
    /// <summary>
    /// DOM document types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxDomDocumentType {
        Unknown = unchecked((int)0),
        Html,
        Xhtml,
        Plugin
    }
    /// <summary>
    /// DOM event category flags.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxDomEventCategory {
        Unknown = unchecked((int)0x0),
        Ui = unchecked((int)0x1),
        Mouse = unchecked((int)0x2),
        Mutation = unchecked((int)0x4),
        Keyboard = unchecked((int)0x8),
        Text = unchecked((int)0x10),
        Composition = unchecked((int)0x20),
        Drag = unchecked((int)0x40),
        Clipboard = unchecked((int)0x80),
        Message = unchecked((int)0x100),
        Wheel = unchecked((int)0x200),
        BeforeTextInserted = unchecked((int)0x400),
        Overflow = unchecked((int)0x800),
        PageTransition = unchecked((int)0x1000),
        Popstate = unchecked((int)0x2000),
        Progress = unchecked((int)0x4000),
        XmlhttpRequestProgress = unchecked((int)0x8000)
    }
    /// <summary>
    /// DOM event processing phases.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxDomEventPhase {
        Unknown = unchecked((int)0),
        Capturing,
        AtTarget,
        Bubbling
    }
    /// <summary>
    /// DOM node types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxDomNodeType {
        Unsupported = unchecked((int)0),
        Element,
        Attribute,
        Text,
        CdataSection,
        ProcessingInstructions,
        Comment,
        Document,
        DocumentType,
        DocumentFragment
    }
    /// <summary>
    /// "Verb" of a drag-and-drop operation as negotiated between the source and
    /// destination. These constants match their equivalents in WebCore's
    /// DragActions.h and should not be renumbered.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxDragOperationsMask {
        None = unchecked((int)0),
        Copy = unchecked((int)1),
        Link = unchecked((int)2),
        Generic = unchecked((int)4),
        Private = unchecked((int)8),
        Move = unchecked((int)16),
        Delete = unchecked((int)32),
        Every = unchecked((int)UInt32.MaxValue)
    }
    /// <summary>
    /// Print job duplex mode values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxDuplexMode {
        Unknown = unchecked((int)-1),
        Simplex,
        LongEdge,
        ShortEdge
    }
    /// <summary>
    /// Supported error code values. See net\base\net_error_list.h for complete
    /// descriptions of the error codes.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxErrorCode {
        None = unchecked((int)0),
        Failed = unchecked((int)-2),
        Aborted = unchecked((int)-3),
        InvalidArgument = unchecked((int)-4),
        InvalidHandle = unchecked((int)-5),
        FileNotFound = unchecked((int)-6),
        TimedOut = unchecked((int)-7),
        FileTooBig = unchecked((int)-8),
        Unexpected = unchecked((int)-9),
        AccessDenied = unchecked((int)-10),
        NotImplemented = unchecked((int)-11),
        ConnectionClosed = unchecked((int)-100),
        ConnectionReset = unchecked((int)-101),
        ConnectionRefused = unchecked((int)-102),
        ConnectionAborted = unchecked((int)-103),
        ConnectionFailed = unchecked((int)-104),
        NameNotResolved = unchecked((int)-105),
        InternetDisconnected = unchecked((int)-106),
        SslProtocolError = unchecked((int)-107),
        AddressInvalid = unchecked((int)-108),
        AddressUnreachable = unchecked((int)-109),
        SslClientAuthCertNeeded = unchecked((int)-110),
        TunnelConnectionFailed = unchecked((int)-111),
        NoSslVersionsEnabled = unchecked((int)-112),
        SslVersionOrCipherMismatch = unchecked((int)-113),
        SslRenegotiationRequested = unchecked((int)-114),
        CertCommonNameInvalid = unchecked((int)-200),
        CertBegin = CertCommonNameInvalid,
        CertDateInvalid = unchecked((int)-201),
        CertAuthorityInvalid = unchecked((int)-202),
        CertContainsErrors = unchecked((int)-203),
        CertNoRevocationMechanism = unchecked((int)-204),
        CertUnableToCheckRevocation = unchecked((int)-205),
        CertRevoked = unchecked((int)-206),
        CertInvalid = unchecked((int)-207),
        CertWeakSignatureAlgorithm = unchecked((int)-208),
        CertNonUniqueName = unchecked((int)-210),
        CertWeakKey = unchecked((int)-211),
        CertNameConstraintViolation = unchecked((int)-212),
        CertValidityTooLong = unchecked((int)-213),
        CertEnd = CertValidityTooLong,
        InvalidUrl = unchecked((int)-300),
        DisallowedUrlScheme = unchecked((int)-301),
        UnknownUrlScheme = unchecked((int)-302),
        TooManyRedirects = unchecked((int)-310),
        UnsafeRedirect = unchecked((int)-311),
        UnsafePort = unchecked((int)-312),
        InvalidResponse = unchecked((int)-320),
        InvalidChunkedEncoding = unchecked((int)-321),
        MethodNotSupported = unchecked((int)-322),
        UnexpectedProxyAuth = unchecked((int)-323),
        EmptyResponse = unchecked((int)-324),
        ResponseHeadersTooBig = unchecked((int)-325),
        CacheMiss = unchecked((int)-400),
        InsecureResponse = unchecked((int)-501)
    }
    /// <summary>
    /// Supported event bit flags.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxEventFlags {
        None = unchecked((int)0),
        CapsLockOn = unchecked((int)1 << 0),
        ShiftDown = unchecked((int)1 << 1),
        ControlDown = unchecked((int)1 << 2),
        AltDown = unchecked((int)1 << 3),
        LeftMouseButton = unchecked((int)1 << 4),
        MiddleMouseButton = unchecked((int)1 << 5),
        RightMouseButton = unchecked((int)1 << 6),
        CommandDown = unchecked((int)1 << 7),
        NumLockOn = unchecked((int)1 << 8),
        IsKeyPad = unchecked((int)1 << 9),
        IsLeft = unchecked((int)1 << 10),
        IsRight = unchecked((int)1 << 11)
    }
    /// <summary>
    /// Supported file dialog modes.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxFileDialogMode {
        /// <summary>
        /// Requires that the file exists before allowing the user to pick it.
        /// </summary>
        Open = unchecked((int)0),
        /// <summary>
        /// Like Open, but allows picking multiple files to open.
        /// </summary>
        OpenMultiple,
        /// <summary>
        /// Like Open, but selects a folder to open.
        /// </summary>
        OpenFolder,
        /// <summary>
        /// Allows picking a nonexistent file, and prompts to overwrite if the file
        /// already exists.
        /// </summary>
        Save,
        /// <summary>
        /// General mask defining the bits used for the type values.
        /// </summary>
        TypeMask = unchecked((int)0xFF),
        /// <summary>
        /// Qualifiers.
        /// Any of the type values above can be augmented by one or more qualifiers.
        /// These qualifiers further define the dialog behavior.
        /// Prompt to overwrite if the user selects an existing file with the Save
        /// dialog.
        /// </summary>
        OverwritePromptFlag = unchecked((int)0x01000000),
        /// <summary>
        /// Do not display read-only files.
        /// </summary>
        HideReadOnlyFlag = unchecked((int)0x02000000)
    }
    /// <summary>
    /// Focus sources.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxFocusSource {
        /// <summary>
        /// The source is explicit navigation via the API (LoadURL(), etc).
        /// </summary>
        Navigation = unchecked((int)0),
        /// <summary>
        /// The source is a system-generated focus event.
        /// </summary>
        System
    }
    /// <summary>
    /// Geoposition error codes.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxGeopositionErrorCode {
        None = unchecked((int)0),
        PermissionDenied,
        PositionUnavailable,
        Timeout
    }
    /// <summary>
    /// Supported JavaScript dialog types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxJsDialogType {
        Alert = unchecked((int)0),
        Confirm,
        Prompt
    }
    /// <summary>
    /// Error codes that can be returned from CfxParseJSONAndReturnError.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxJsonParserError {
        NoError = unchecked((int)0),
        InvalidEscape,
        SyntaxError,
        UnexpectedToken,
        TrailingComma,
        TooMuchNesting,
        UnexpectedDataAfterRoot,
        UnsupportedEncoding,
        UnquotedDictionaryKey,
        ParseErrorCount
    }
    /// <summary>
    /// Options that can be passed to CfxParseJSON.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxJsonParserOptions {
        /// <summary>
        /// Parses the input strictly according to RFC 4627. See comments in Chromium's
        /// base/json/json_reader.h file for known limitations/deviations from the RFC.
        /// </summary>
        Rfc = unchecked((int)0),
        AllowTrailingCommas = unchecked((int)1 << 0)
    }
    /// <summary>
    /// Options that can be passed to CfxWriteJSON.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxJsonWriterOptions {
        /// <summary>
        /// Default behavior.
        /// </summary>
        Default = unchecked((int)0),
        OmitBinaryValues = unchecked((int)1 << 0),
        OmitDoubleTypePreservation = unchecked((int)1 << 1),
        PrettyPrint = unchecked((int)1 << 2)
    }
    /// <summary>
    /// Key event types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxKeyEventType {
        /// <summary>
        /// Notification that a key transitioned from "up" to "down".
        /// </summary>
        RawKeydown = unchecked((int)0),
        /// <summary>
        /// Notification that a key was pressed. This does not necessarily correspond
        /// to a character depending on the key and language. Use KEYEVENT_CHAR for
        /// character input.
        /// </summary>
        Keydown,
        /// <summary>
        /// Notification that a key was released.
        /// </summary>
        Keyup,
        /// <summary>
        /// Notification that a character was typed. Use this for text input. Key
        /// down events may generate 0, 1, or more than one character event depending
        /// on the key, locale, and operating system.
        /// </summary>
        Char
    }
    /// <summary>
    /// Log severity levels.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxLogSeverity {
        /// <summary>
        /// Default logging (currently INFO logging).
        /// </summary>
        Default,
        /// <summary>
        /// Verbose logging.
        /// </summary>
        Verbose,
        /// <summary>
        /// INFO logging.
        /// </summary>
        Info,
        /// <summary>
        /// WARNING logging.
        /// </summary>
        Warning,
        /// <summary>
        /// ERROR logging.
        /// </summary>
        Error,
        /// <summary>
        /// Completely disable logging.
        /// </summary>
        Disable = unchecked((int)99)
    }
    /// <summary>
    /// Supported menu IDs. Non-English translations can be provided for the
    /// IDS_MENU_* strings in CfxResourceBundleHandler.GetLocalizedString().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMenuId {
        /// <summary>
        /// Navigation.
        /// </summary>
        Back = unchecked((int)100),
        Forward = unchecked((int)101),
        Reload = unchecked((int)102),
        ReloadNocache = unchecked((int)103),
        Stopload = unchecked((int)104),
        /// <summary>
        /// Editing.
        /// </summary>
        Undo = unchecked((int)110),
        Redo = unchecked((int)111),
        Cut = unchecked((int)112),
        Copy = unchecked((int)113),
        Paste = unchecked((int)114),
        Delete = unchecked((int)115),
        SelectAll = unchecked((int)116),
        /// <summary>
        /// Miscellaneous.
        /// </summary>
        Find = unchecked((int)130),
        Print = unchecked((int)131),
        ViewSource = unchecked((int)132),
        /// <summary>
        /// Spell checking word correction suggestions.
        /// </summary>
        SpellcheckSuggestion0 = unchecked((int)200),
        SpellcheckSuggestion1 = unchecked((int)201),
        SpellcheckSuggestion2 = unchecked((int)202),
        SpellcheckSuggestion3 = unchecked((int)203),
        SpellcheckSuggestion4 = unchecked((int)204),
        SpellcheckSuggestionLast = unchecked((int)204),
        NoSpellingSuggestions = unchecked((int)205),
        AddToDictionary = unchecked((int)206),
        /// <summary>
        /// Custom menu items originating from the renderer process. For example,
        /// plugin placeholder menu items or Flash menu items.
        /// </summary>
        CustomFirst = unchecked((int)220),
        CustomLast = unchecked((int)250),
        /// <summary>
        /// All user-defined menu IDs should come between MENU_ID_USER_FIRST and
        /// MENU_ID_USER_LAST to avoid overlapping the Chromium and CEF ID ranges
        /// defined in the tools/gritsettings/resource_ids file.
        /// </summary>
        UserFirst = unchecked((int)26500),
        UserLast = unchecked((int)28500)
    }
    /// <summary>
    /// Supported menu item types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMenuItemType {
        None,
        Command,
        Check,
        Radio,
        Separator,
        Submenu
    }
    /// <summary>
    /// Mouse button types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMouseButtonType {
        Left = unchecked((int)0),
        Middle,
        Right
    }
    /// <summary>
    /// Navigation types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxNavigationType {
        LinkClicked = unchecked((int)0),
        FormSubmitted,
        BackForward,
        Reload,
        FormResubmitted,
        Other
    }
    /// <summary>
    /// Paint element types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPaintElementType {
        View = unchecked((int)0),
        Popup
    }
    /// <summary>
    /// Path key values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPathKey {
        /// <summary>
        /// Current directory.
        /// </summary>
        DirCurrent,
        /// <summary>
        /// Directory containing PK_FILE_EXE.
        /// </summary>
        DirExe,
        /// <summary>
        /// Directory containing PK_FILE_MODULE.
        /// </summary>
        DirModule,
        /// <summary>
        /// Temporary directory.
        /// </summary>
        DirTemp,
        /// <summary>
        /// Path and filename of the current executable.
        /// </summary>
        FileExe,
        /// <summary>
        /// Path and filename of the module containing the CEF code (usually the libcef
        /// module).
        /// </summary>
        FileModule,
        /// <summary>
        /// "Local Settings\Application Data" directory under the user profile
        /// directory on Windows.
        /// </summary>
        LocalAppData,
        /// <summary>
        /// "Application Data" directory under the user profile directory on Windows
        /// and "~/Library/Application Support" directory on Mac OS X.
        /// </summary>
        UserData
    }
    /// <summary>
    /// Margin type for PDF printing.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPdfPrintMarginType {
        /// <summary>
        /// Default margins.
        /// </summary>
        Default,
        /// <summary>
        /// No margins.
        /// </summary>
        None,
        /// <summary>
        /// Minimum margins.
        /// </summary>
        Minimum,
        /// <summary>
        /// Custom margins using the |margin_*| values from CfxPdfPrintSettings.
        /// </summary>
        Custom
    }
    /// <summary>
    /// Plugin policies supported by CfxRequestContextHandler.OnBeforePluginLoad.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPluginPolicy {
        /// <summary>
        /// Allow the content.
        /// </summary>
        Allow,
        /// <summary>
        /// Allow important content and block unimportant content based on heuristics.
        /// The user can manually load blocked content.
        /// </summary>
        DetectImportant,
        /// <summary>
        /// Block the content. The user can manually load blocked content.
        /// </summary>
        Block,
        /// <summary>
        /// Disable the content. The user cannot load disabled content.
        /// </summary>
        Disable
    }
    /// <summary>
    /// Post data elements may represent either bytes or files.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPostdataElementType {
        Empty = unchecked((int)0),
        Bytes,
        File
    }
    /// <summary>
    /// Existing process IDs.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxProcessId {
        /// <summary>
        /// Browser process.
        /// </summary>
        Browser,
        /// <summary>
        /// Renderer process.
        /// </summary>
        Renderer
    }
    /// <summary>
    /// Policy for how the Referrer HTTP header value will be sent during navigation.
    /// If the `--no-referrers` command-line flag is specified then the policy value
    /// will be ignored and the Referrer value will never be sent.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxReferrerPolicy {
        /// <summary>
        /// Always send the complete Referrer value.
        /// </summary>
        Always,
        /// <summary>
        /// Use the default policy. This is REFERRER_POLICY_ORIGIN_WHEN_CROSS_ORIGIN
        /// when the `--reduced-referrer-granularity` command-line flag is specified
        /// and REFERRER_POLICY_NO_REFERRER_WHEN_DOWNGRADE otherwise.
        /// </summary>
        Default,
        /// <summary>
        /// When navigating from HTTPS to HTTP do not send the Referrer value.
        /// Otherwise, send the complete Referrer value.
        /// </summary>
        NoReferrerWhenDowngrade,
        /// <summary>
        /// Never send the Referrer value.
        /// </summary>
        Never,
        /// <summary>
        /// Only send the origin component of the Referrer value.
        /// </summary>
        Origin,
        /// <summary>
        /// When navigating cross-origin only send the origin component of the Referrer
        /// value. Otherwise, send the complete Referrer value.
        /// </summary>
        OriginWhenCrossOrigin
    }
    /// <summary>
    /// Resource type for a request.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxResourceType {
        /// <summary>
        /// Top level page.
        /// </summary>
        MainFrame = unchecked((int)0),
        /// <summary>
        /// Frame or iframe.
        /// </summary>
        SubFrame,
        /// <summary>
        /// CSS stylesheet.
        /// </summary>
        Stylesheet,
        /// <summary>
        /// External script.
        /// </summary>
        Script,
        /// <summary>
        /// Image (jpg/gif/png/etc).
        /// </summary>
        Image,
        /// <summary>
        /// Font.
        /// </summary>
        FontResource,
        /// <summary>
        /// Some other subresource. This is the default type if the actual type is
        /// unknown.
        /// </summary>
        SubResource,
        /// <summary>
        /// Object (or embed) tag for a plugin, or a resource that a plugin requested.
        /// </summary>
        Object,
        /// <summary>
        /// Media resource.
        /// </summary>
        Media,
        /// <summary>
        /// Main resource of a dedicated worker.
        /// </summary>
        Worker,
        /// <summary>
        /// Main resource of a shared worker.
        /// </summary>
        SharedWorker,
        /// <summary>
        /// Explicitly requested prefetch.
        /// </summary>
        Prefetch,
        /// <summary>
        /// Favicon.
        /// </summary>
        Favicon,
        /// <summary>
        /// XMLHttpRequest.
        /// </summary>
        Xhr,
        /// <summary>
        /// A request for a &lt;ping>
        /// </summary>
        Ping,
        /// <summary>
        /// Main resource of a service worker.
        /// </summary>
        ServiceWorker,
        /// <summary>
        /// A report of Content Security Policy violations.
        /// </summary>
        CspReport,
        /// <summary>
        /// A resource that a plugin requested.
        /// </summary>
        PluginResource
    }
    /// <summary>
    /// Return values for CfxResponseFilter.Filter().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxResponseFilterStatus {
        /// <summary>
        /// Some or all of the pre-filter data was read successfully but more data is
        /// needed in order to continue filtering (filtered output is pending).
        /// </summary>
        NeedMoreData,
        /// <summary>
        /// Some or all of the pre-filter data was read successfully and all available
        /// filtered output has been written.
        /// </summary>
        Done,
        /// <summary>
        /// An error occurred during filtering.
        /// </summary>
        Error
    }
    /// <summary>
    /// Return value types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxReturnValue {
        /// <summary>
        /// Cancel immediately.
        /// </summary>
        Cancel = unchecked((int)0),
        /// <summary>
        /// Continue immediately.
        /// </summary>
        Continue,
        /// <summary>
        /// Continue asynchronously (usually via a callback).
        /// </summary>
        ContinueAsync
    }
    /// <summary>
    /// Supported UI scale factors for the platform. SCALE_FACTOR_NONE is used for
    /// density independent resources such as string, html/js files or an image that
    /// can be used for any scale factors (such as wallpapers).
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxScaleFactor {
        None = unchecked((int)0),
        ScaleFactor100p,
        ScaleFactor125p,
        ScaleFactor133p,
        ScaleFactor140p,
        ScaleFactor150p,
        ScaleFactor180p,
        ScaleFactor200p,
        ScaleFactor250p,
        ScaleFactor300p
    }
    /// <summary>
    /// Represents the state of a setting.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxState {
        /// <summary>
        /// Use the default state for the setting.
        /// </summary>
        Default = unchecked((int)0),
        /// <summary>
        /// Enable or allow the setting.
        /// </summary>
        Enabled,
        /// <summary>
        /// Disable or disallow the setting.
        /// </summary>
        Disabled
    }
    /// <summary>
    /// Storage types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxStorageType {
        LocalStorage = unchecked((int)0),
        SessionStorage
    }
    /// <summary>
    /// Process termination status values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxTerminationStatus {
        /// <summary>
        /// Non-zero exit status.
        /// </summary>
        AbnormalTermination,
        /// <summary>
        /// SIGKILL or task manager kill.
        /// </summary>
        ProcessWasKilled,
        /// <summary>
        /// Segmentation fault.
        /// </summary>
        ProcessCrashed
    }
    /// <summary>
    /// Existing thread IDs.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxThreadId {
        /// <summary>
        /// BROWSER PROCESS THREADS -- Only available in the browser process.
        /// The main thread in the browser. This will be the same as the main
        /// application thread if CfxInitialize() is called with a
        /// CfxSettings.MultiThreadedMessageLoop value of false.
        /// </summary>
        Ui,
        /// <summary>
        /// Used to interact with the database.
        /// </summary>
        Db,
        /// <summary>
        /// Used to interact with the file system.
        /// </summary>
        File,
        /// <summary>
        /// Used for file system operations that block user interactions.
        /// Responsiveness of this thread affects users.
        /// </summary>
        FileUserBlocking,
        /// <summary>
        /// Used to launch and terminate browser processes.
        /// </summary>
        ProcessLauncher,
        /// <summary>
        /// Used to handle slow HTTP cache operations.
        /// </summary>
        Cache,
        /// <summary>
        /// Used to process IPC and network messages.
        /// </summary>
        Io,
        /// <summary>
        /// RENDER PROCESS THREADS -- Only available in the render process.
        /// The main thread in the renderer. Used for all WebKit and V8 interaction.
        /// </summary>
        Renderer
    }
    /// <summary>
    /// Transition type for a request. Made up of one source value and 0 or more
    /// qualifiers.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxTransitionType {
        /// <summary>
        /// Source is a link click or the JavaScript window.open function. This is
        /// also the default value for requests like sub-resource loads that are not
        /// navigations.
        /// </summary>
        Link = unchecked((int)0),
        /// <summary>
        /// Source is some other "explicit" navigation action such as creating a new
        /// browser or using the LoadURL function. This is also the default value
        /// for navigations where the actual type is unknown.
        /// </summary>
        Explicit = unchecked((int)1),
        /// <summary>
        /// Source is a subframe navigation. This is any content that is automatically
        /// loaded in a non-toplevel frame. For example, if a page consists of several
        /// frames containing ads, those ad URLs will have this transition type.
        /// The user may not even realize the content in these pages is a separate
        /// frame, so may not care about the URL.
        /// </summary>
        AutoSubframe = unchecked((int)3),
        /// <summary>
        /// Source is a subframe navigation explicitly requested by the user that will
        /// generate new navigation entries in the back/forward list. These are
        /// probably more important than frames that were automatically loaded in
        /// the background because the user probably cares about the fact that this
        /// link was loaded.
        /// </summary>
        ManualSubframe = unchecked((int)4),
        /// <summary>
        /// Source is a form submission by the user. NOTE: In some situations
        /// submitting a form does not result in this transition type. This can happen
        /// if the form uses a script to submit the contents.
        /// </summary>
        FormSubmit = unchecked((int)7),
        /// <summary>
        /// Source is a "reload" of the page via the Reload function or by re-visiting
        /// the same URL. NOTE: This is distinct from the concept of whether a
        /// particular load uses "reload semantics" (i.e. bypasses cached data).
        /// </summary>
        Reload = unchecked((int)8),
        /// <summary>
        /// General mask defining the bits used for the source values.
        /// </summary>
        SourceMask = unchecked((int)0xFF),
        /// <summary>
        /// Qualifiers.
        /// Any of the core values above can be augmented by one or more qualifiers.
        /// These qualifiers further define the transition.
        /// Attempted to visit a URL but was blocked.
        /// </summary>
        BlockedFlag = unchecked((int)0x00800000),
        /// <summary>
        /// Used the Forward or Back function to navigate among browsing history.
        /// </summary>
        ForwardBackFlag = unchecked((int)0x01000000),
        /// <summary>
        /// The beginning of a navigation chain.
        /// </summary>
        ChainStartFlag = unchecked((int)0x10000000),
        /// <summary>
        /// The last transition in a redirect chain.
        /// </summary>
        ChainEndFlag = unchecked((int)0x20000000),
        /// <summary>
        /// Redirects caused by JavaScript or a meta refresh tag on the page.
        /// </summary>
        ClientRedirectFlag = unchecked((int)0x40000000),
        /// <summary>
        /// Redirects sent from the server by HTTP headers.
        /// </summary>
        ServerRedirectFlag = unchecked((int)0x80000000),
        /// <summary>
        /// Used to test whether a transition involves a redirect.
        /// </summary>
        IsRedirectMask = unchecked((int)0xC0000000),
        /// <summary>
        /// General mask defining the bits used for the qualifiers.
        /// </summary>
        QualifierMask = unchecked((int)0xFFFFFF00)
    }
    /// <summary>
    /// URI unescape rules passed to CfxURIDecode().
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxUriUnescapeRule {
        /// <summary>
        /// Don't unescape anything at all.
        /// </summary>
        None = unchecked((int)0),
        /// <summary>
        /// Don't unescape anything special, but all normal unescaping will happen.
        /// This is a placeholder and can't be combined with other flags (since it's
        /// just the absence of them). All other unescape rules imply "normal" in
        /// addition to their special meaning. Things like escaped letters, digits,
        /// and most symbols will get unescaped with this mode.
        /// </summary>
        Normal = unchecked((int)1),
        /// <summary>
        /// Convert %20 to spaces. In some places where we're showing URLs, we may
        /// want this. In places where the URL may be copied and pasted out, then
        /// you wouldn't want this since it might not be interpreted in one piece
        /// by other applications.
        /// </summary>
        Spaces = unchecked((int)2),
        /// <summary>
        /// Unescapes various characters that will change the meaning of URLs,
        /// including '%', '+', '&amp;', '/', '#'. If we unescaped these characters, the
        /// resulting URL won't be the same as the source one. This flag is used when
        /// generating final output like filenames for URLs where we won't be
        /// interpreting as a URL and want to do as much unescaping as possible.
        /// </summary>
        UrlSpecialChars = unchecked((int)4),
        /// <summary>
        /// Unescapes control characters such as %01. This INCLUDES NULLs. This is
        /// used for rare cases such as data: URL decoding where the result is binary
        /// data. This flag also unescapes BiDi control characters.
        /// DO NOT use CONTROL_CHARS if the URL is going to be displayed in the UI
        /// for security reasons.
        /// </summary>
        ControlChars = unchecked((int)8),
        /// <summary>
        /// URL queries use "+" for space. This flag controls that replacement.
        /// </summary>
        ReplacePlusWithSpace = unchecked((int)16)
    }
    /// <summary>
    /// Flags used to customize the behavior of CfxURLRequest.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxUrlRequestFlags {
        /// <summary>
        /// Default behavior.
        /// </summary>
        None = unchecked((int)0),
        SkipCache = unchecked((int)1 << 0),
        AllowCachedCredentials = unchecked((int)1 << 1),
        ReportUploadProgress = unchecked((int)1 << 3),
        NoDownloadData = unchecked((int)1 << 6),
        NoRetryOn5xx = unchecked((int)1 << 7)
    }
    /// <summary>
    /// Flags that represent CfxURLRequest status.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxUrlRequestStatus {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = unchecked((int)0),
        /// <summary>
        /// Request succeeded.
        /// </summary>
        Success,
        /// <summary>
        /// An IO request is pending, and the caller will be informed when it is
        /// completed.
        /// </summary>
        IoPending,
        /// <summary>
        /// Request was canceled programatically.
        /// </summary>
        Canceled,
        /// <summary>
        /// Request failed for some reason.
        /// </summary>
        Failed
    }
    /// <summary>
    /// V8 access control values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxV8AccessControl {
        Default = unchecked((int)0),
        AllCanRead = unchecked((int)1),
        AllCanWrite = unchecked((int)1 << 1),
        ProhibitsOverwriting = unchecked((int)1 << 2)
    }
    /// <summary>
    /// V8 property attribute values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxV8PropertyAttribute {
        None = unchecked((int)0),
        ReadOnly = unchecked((int)1 << 0),
        DontEnum = unchecked((int)1 << 1),
        DontDelete = unchecked((int)1 << 2)
    }
    /// <summary>
    /// Supported value types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxValueType {
        Invalid = unchecked((int)0),
        Null,
        Bool,
        Int,
        Double,
        String,
        Binary,
        Dictionary,
        List
    }
    /// <summary>
    /// The manner in which a link click should be opened.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxWindowOpenDisposition {
        Unknown,
        SuppressOpen,
        CurrentTab,
        SingletonTab,
        NewForegroundTab,
        NewBackgroundTab,
        NewPopup,
        NewWindow,
        SaveToDisk,
        OffTheRecord,
        IgnoreAction
    }
    /// <summary>
    /// Supported XML encoding types. The parser supports ASCII, ISO-8859-1, and
    /// UTF16 (LE and BE) by default. All other types must be translated to UTF8
    /// before being passed to the parser. If a BOM is detected and the correct
    /// decoder is available then that decoder will be used automatically.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxXmlEncodingType {
        None = unchecked((int)0),
        Utf8,
        Utf16le,
        Utf16be,
        Ascii
    }
    /// <summary>
    /// XML node types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxXmlNodeType {
        Unsupported = unchecked((int)0),
        ProcessingInstruction,
        DocumentType,
        ElementStart,
        ElementEnd,
        Attribute,
        Text,
        Cdata,
        EntityReference,
        Whitespace,
        Comment
    }
}
