// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Describes how to interpret the alpha component of a pixel.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxAlphaType {
        /// <summary>
        /// No transparency. The alpha component is ignored.
        /// </summary>
        Opaque,
        /// <summary>
        /// Transparency with pre-multiplied alpha component.
        /// </summary>
        Premultiplied,
        /// <summary>
        /// Transparency with post-multiplied alpha component.
        /// </summary>
        Postmultiplied
    }
    /// <summary>
    /// Specifies the button display state.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxButtonState {
        Normal,
        Hovered,
        Pressed,
        Disabled
    }
    /// <summary>
    /// Error codes for CDM registration. See cef_web_plugin.h for details.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxCdmRegistrationError {
        /// <summary>
        /// No error. Registration completed successfully.
        /// </summary>
        None,
        /// <summary>
        /// Required files or manifest contents are missing.
        /// </summary>
        IncorrectContents,
        /// <summary>
        /// The CDM is incompatible with the current Chromium version.
        /// </summary>
        Incompatible,
        /// <summary>
        /// CDM registration is not supported at this time.
        /// </summary>
        NotSupported
    }
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
    /// Describes how to interpret the components of a pixel.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxColorType {
        /// <summary>
        /// RGBA with 8 bits per pixel (32bits total).
        /// </summary>
        Rgba8888,
        /// <summary>
        /// BGRA with 8 bits per pixel (32bits total).
        /// </summary>
        Bgra8888
    }
    /// <summary>
    /// Windows COM initialization mode. Specifies how COM will be initialized for a
    /// new thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxComInitMode {
        /// <summary>
        /// No COM initialization.
        /// </summary>
        None,
        /// <summary>
        /// Initialize COM using single-threaded apartments.
        /// </summary>
        Sta,
        /// <summary>
        /// Initialize COM using multi-threaded apartments.
        /// </summary>
        Mta
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
        /// <summary>
        /// The top page is selected.
        /// </summary>
        Page = unchecked((int)1 << 0),
        /// <summary>
        /// A subframe page is selected.
        /// </summary>
        Frame = unchecked((int)1 << 1),
        /// <summary>
        /// A link is selected.
        /// </summary>
        Link = unchecked((int)1 << 2),
        /// <summary>
        /// A media node is selected.
        /// </summary>
        Media = unchecked((int)1 << 3),
        /// <summary>
        /// There is a textual or mixed selection that is selected.
        /// </summary>
        Selection = unchecked((int)1 << 4),
        /// <summary>
        /// An editable element is selected.
        /// </summary>
        Editable = unchecked((int)1 << 5)
    }
    /// <summary>
    /// Specifies where along the cross axis the CfxBoxLayout child views should be
    /// laid out.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxCrossAxisAlignment {
        /// <summary>
        /// Child views will be stretched to fit.
        /// </summary>
        Stretch,
        /// <summary>
        /// Child views will be left-aligned.
        /// </summary>
        Start,
        /// <summary>
        /// Child views will be center-aligned.
        /// </summary>
        Center,
        /// <summary>
        /// Child views will be right-aligned.
        /// </summary>
        End
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
    /// Supported error code values.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxErrorCode {
        ErrNone = unchecked((int)0),
        /// <summary>
        /// An asynchronous IO operation is not yet complete.  This usually does not
        /// indicate a fatal error.  Typically this error will be generated as a
        /// notification to wait for some external notification that the IO operation
        /// finally completed.
        /// </summary>
        IoPending = unchecked((int)-1),
        /// <summary>
        /// A generic failure occurred.
        /// </summary>
        Failed = unchecked((int)-2),
        /// <summary>
        /// An operation was aborted (due to user action).
        /// </summary>
        Aborted = unchecked((int)-3),
        /// <summary>
        /// An argument to the function is incorrect.
        /// </summary>
        InvalidArgument = unchecked((int)-4),
        /// <summary>
        /// The handle or file descriptor is invalid.
        /// </summary>
        InvalidHandle = unchecked((int)-5),
        /// <summary>
        /// The file or directory cannot be found.
        /// </summary>
        FileNotFound = unchecked((int)-6),
        /// <summary>
        /// An operation timed out.
        /// </summary>
        TimedOut = unchecked((int)-7),
        /// <summary>
        /// The file is too large.
        /// </summary>
        FileTooBig = unchecked((int)-8),
        /// <summary>
        /// An unexpected error.  This may be caused by a programming mistake or an
        /// invalid assumption.
        /// </summary>
        Unexpected = unchecked((int)-9),
        /// <summary>
        /// Permission to access a resource, other than the network, was denied.
        /// </summary>
        AccessDenied = unchecked((int)-10),
        /// <summary>
        /// The operation failed because of unimplemented functionality.
        /// </summary>
        NotImplemented = unchecked((int)-11),
        /// <summary>
        /// There were not enough resources to complete the operation.
        /// </summary>
        InsufficientResources = unchecked((int)-12),
        /// <summary>
        /// Memory allocation failed.
        /// </summary>
        OutOfMemory = unchecked((int)-13),
        /// <summary>
        /// The file upload failed because the file's modification time was different
        /// from the expectation.
        /// </summary>
        UploadFileChanged = unchecked((int)-14),
        /// <summary>
        /// The socket is not connected.
        /// </summary>
        SocketNotConnected = unchecked((int)-15),
        /// <summary>
        /// The file already exists.
        /// </summary>
        FileExists = unchecked((int)-16),
        /// <summary>
        /// The path or file name is too long.
        /// </summary>
        FilePathTooLong = unchecked((int)-17),
        /// <summary>
        /// Not enough room left on the disk.
        /// </summary>
        FileNoSpace = unchecked((int)-18),
        /// <summary>
        /// The file has a virus.
        /// </summary>
        FileVirusInfected = unchecked((int)-19),
        /// <summary>
        /// The client chose to block the request.
        /// </summary>
        BlockedByClient = unchecked((int)-20),
        /// <summary>
        /// The network changed.
        /// </summary>
        NetworkChanged = unchecked((int)-21),
        /// <summary>
        /// The request was blocked by the URL blacklist configured by the domain
        /// administrator.
        /// </summary>
        BlockedByAdministrator = unchecked((int)-22),
        /// <summary>
        /// The socket is already connected.
        /// </summary>
        SocketIsConnected = unchecked((int)-23),
        /// <summary>
        /// The request was blocked because the forced reenrollment check is still
        /// pending. This error can only occur on ChromeOS.
        /// The error can be emitted by code in chrome/browser/policy/policy_helpers.cc.
        /// </summary>
        BlockedEnrollmentCheckPending = unchecked((int)-24),
        /// <summary>
        /// The upload failed because the upload stream needed to be re-read, due to a
        /// retry or a redirect, but the upload stream doesn't support that operation.
        /// </summary>
        UploadStreamRewindNotSupported = unchecked((int)-25),
        /// <summary>
        /// The request failed because the URLRequestContext is shutting down, or has
        /// been shut down.
        /// </summary>
        ContextShutDown = unchecked((int)-26),
        /// <summary>
        /// The request failed because the response was delivered along with requirements
        /// which are not met ('X-Frame-Options' and 'Content-Security-Policy' ancestor
        /// checks and 'Cross-Origin-Resource-Policy', for instance).
        /// </summary>
        BlockedByResponse = unchecked((int)-27),
        /// <summary>
        /// The request failed after the response was received, based on client-side
        /// heuristics that point to the possiblility of a cross-site scripting attack.
        /// </summary>
        BlockedByXssAuditor = unchecked((int)-28),
        /// <summary>
        /// The request was blocked by system policy disallowing some or all cleartext
        /// requests. Used for NetworkSecurityPolicy on Android.
        /// </summary>
        ClearTextNotPermitted = unchecked((int)-29),
        /// <summary>
        /// A connection was closed (corresponding to a TCP FIN).
        /// </summary>
        ConnectionClosed = unchecked((int)-100),
        /// <summary>
        /// A connection was reset (corresponding to a TCP RST).
        /// </summary>
        ConnectionReset = unchecked((int)-101),
        /// <summary>
        /// A connection attempt was refused.
        /// </summary>
        ConnectionRefused = unchecked((int)-102),
        /// <summary>
        /// A connection timed out as a result of not receiving an ACK for data sent.
        /// This can include a FIN packet that did not get ACK'd.
        /// </summary>
        ConnectionAborted = unchecked((int)-103),
        /// <summary>
        /// A connection attempt failed.
        /// </summary>
        ConnectionFailed = unchecked((int)-104),
        /// <summary>
        /// The host name could not be resolved.
        /// </summary>
        NameNotResolved = unchecked((int)-105),
        /// <summary>
        /// The Internet connection has been lost.
        /// </summary>
        InternetDisconnected = unchecked((int)-106),
        /// <summary>
        /// An SSL protocol error occurred.
        /// </summary>
        SslProtocolError = unchecked((int)-107),
        /// <summary>
        /// The IP address or port number is invalid (e.g., cannot connect to the IP
        /// address 0 or the port 0).
        /// </summary>
        AddressInvalid = unchecked((int)-108),
        /// <summary>
        /// The IP address is unreachable.  This usually means that there is no route to
        /// the specified host or network.
        /// </summary>
        AddressUnreachable = unchecked((int)-109),
        /// <summary>
        /// The server requested a client certificate for SSL client authentication.
        /// </summary>
        SslClientAuthCertNeeded = unchecked((int)-110),
        /// <summary>
        /// A tunnel connection through the proxy could not be established.
        /// </summary>
        TunnelConnectionFailed = unchecked((int)-111),
        /// <summary>
        /// No SSL protocol versions are enabled.
        /// </summary>
        NoSslVersionsEnabled = unchecked((int)-112),
        /// <summary>
        /// The client and server don't support a common SSL protocol version or
        /// cipher suite.
        /// </summary>
        SslVersionOrCipherMismatch = unchecked((int)-113),
        /// <summary>
        /// The server requested a renegotiation (rehandshake).
        /// </summary>
        SslRenegotiationRequested = unchecked((int)-114),
        /// <summary>
        /// The proxy requested authentication (for tunnel establishment) with an
        /// unsupported method.
        /// </summary>
        ProxyAuthUnsupported = unchecked((int)-115),
        /// <summary>
        /// During SSL renegotiation (rehandshake), the server sent a certificate with
        /// an error.
        /// 
        /// Note: this error is not in the -2xx range so that it won't be handled as a
        /// certificate error.
        /// </summary>
        CertErrorInSslRenegotiation = unchecked((int)-116),
        /// <summary>
        /// The SSL handshake failed because of a bad or missing client certificate.
        /// </summary>
        BadSslClientAuthCert = unchecked((int)-117),
        /// <summary>
        /// A connection attempt timed out.
        /// </summary>
        ConnectionTimedOut = unchecked((int)-118),
        /// <summary>
        /// There are too many pending DNS resolves, so a request in the queue was
        /// aborted.
        /// </summary>
        HostResolverQueueTooLarge = unchecked((int)-119),
        /// <summary>
        /// Failed establishing a connection to the SOCKS proxy server for a target host.
        /// </summary>
        SocksConnectionFailed = unchecked((int)-120),
        /// <summary>
        /// The SOCKS proxy server failed establishing connection to the target host
        /// because that host is unreachable.
        /// </summary>
        SocksConnectionHostUnreachable = unchecked((int)-121),
        /// <summary>
        /// The request to negotiate an alternate protocol failed.
        /// </summary>
        AlpnNegotiationFailed = unchecked((int)-122),
        /// <summary>
        /// The peer sent an SSL no_renegotiation alert message.
        /// </summary>
        SslNoRenegotiation = unchecked((int)-123),
        /// <summary>
        /// Winsock sometimes reports more data written than passed.  This is probably
        /// due to a broken LSP.
        /// </summary>
        WinsockUnexpectedWrittenBytes = unchecked((int)-124),
        /// <summary>
        /// An SSL peer sent us a fatal decompression_failure alert. This typically
        /// occurs when a peer selects DEFLATE compression in the mistaken belief that
        /// it supports it.
        /// </summary>
        SslDecompressionFailureAlert = unchecked((int)-125),
        /// <summary>
        /// An SSL peer sent us a fatal bad_record_mac alert. This has been observed
        /// from servers with buggy DEFLATE support.
        /// </summary>
        SslBadRecordMacAlert = unchecked((int)-126),
        /// <summary>
        /// The proxy requested authentication (for tunnel establishment).
        /// </summary>
        ProxyAuthRequested = unchecked((int)-127),
        /// <summary>
        /// The SSL server attempted to use a weak ephemeral Diffie-Hellman key.
        /// </summary>
        SslWeakServerEphemeralDhKey = unchecked((int)-129),
        /// <summary>
        /// Could not create a connection to the proxy server. An error occurred
        /// either in resolving its name, or in connecting a socket to it.
        /// Note that this does NOT include failures during the actual "CONNECT" method
        /// of an HTTP proxy.
        /// </summary>
        ProxyConnectionFailed = unchecked((int)-130),
        /// <summary>
        /// A mandatory proxy configuration could not be used. Currently this means
        /// that a mandatory PAC script could not be fetched, parsed or executed.
        /// </summary>
        MandatoryProxyConfigurationFailed = unchecked((int)-131),
        /// <summary>
        /// -132 was formerly ERR_ESET_ANTI_VIRUS_SSL_INTERCEPTION
        /// We've hit the max socket limit for the socket pool while preconnecting.  We
        /// don't bother trying to preconnect more sockets.
        /// </summary>
        PreconnectMaxSocketLimit = unchecked((int)-133),
        /// <summary>
        /// The permission to use the SSL client certificate's private key was denied.
        /// </summary>
        SslClientAuthPrivateKeyAccessDenied = unchecked((int)-134),
        /// <summary>
        /// The SSL client certificate has no private key.
        /// </summary>
        SslClientAuthCertNoPrivateKey = unchecked((int)-135),
        /// <summary>
        /// The certificate presented by the HTTPS Proxy was invalid.
        /// </summary>
        ProxyCertificateInvalid = unchecked((int)-136),
        /// <summary>
        /// An error occurred when trying to do a name resolution (DNS).
        /// </summary>
        NameResolutionFailed = unchecked((int)-137),
        /// <summary>
        /// Permission to access the network was denied. This is used to distinguish
        /// errors that were most likely caused by a firewall from other access denied
        /// errors. See also ERR_ACCESS_DENIED.
        /// </summary>
        NetworkAccessDenied = unchecked((int)-138),
        /// <summary>
        /// The request throttler module cancelled this request to avoid DDOS.
        /// </summary>
        TemporarilyThrottled = unchecked((int)-139),
        /// <summary>
        /// A request to create an SSL tunnel connection through the HTTPS proxy
        /// received a 302 (temporary redirect) response.  The response body might
        /// include a description of why the request failed.
        /// 
        /// TODO(https://crbug.com/928551): This is deprecated and should not be used by
        /// new code.
        /// </summary>
        HttpsProxyTunnelResponseRedirect = unchecked((int)-140),
        /// <summary>
        /// We were unable to sign the CertificateVerify data of an SSL client auth
        /// handshake with the client certificate's private key.
        /// 
        /// Possible causes for this include the user implicitly or explicitly
        /// denying access to the private key, the private key may not be valid for
        /// signing, the key may be relying on a cached handle which is no longer
        /// valid, or the CSP won't allow arbitrary data to be signed.
        /// </summary>
        SslClientAuthSignatureFailed = unchecked((int)-141),
        /// <summary>
        /// The message was too large for the transport.  (for example a UDP message
        /// which exceeds size threshold).
        /// </summary>
        MsgTooBig = unchecked((int)-142),
        /// <summary>
        /// Error -143 was removed (SPDY_SESSION_ALREADY_EXISTS)
        /// Error -144 was removed (LIMIT_VIOLATION).
        /// Websocket protocol error. Indicates that we are terminating the connection
        /// due to a malformed frame or other protocol violation.
        /// </summary>
        WsProtocolError = unchecked((int)-145),
        /// <summary>
        /// Error -146 was removed (PROTOCOL_SWITCHED)
        /// Returned when attempting to bind an address that is already in use.
        /// </summary>
        AddressInUse = unchecked((int)-147),
        /// <summary>
        /// An operation failed because the SSL handshake has not completed.
        /// </summary>
        SslHandshakeNotCompleted = unchecked((int)-148),
        /// <summary>
        /// SSL peer's public key is invalid.
        /// </summary>
        SslBadPeerPublicKey = unchecked((int)-149),
        /// <summary>
        /// The certificate didn't match the built-in public key pins for the host name.
        /// The pins are set in net/http/transport_security_state.cc and require that
        /// one of a set of public keys exist on the path from the leaf to the root.
        /// </summary>
        SslPinnedKeyNotInCertChain = unchecked((int)-150),
        /// <summary>
        /// Server request for client certificate did not contain any types we support.
        /// </summary>
        ClientAuthCertTypeUnsupported = unchecked((int)-151),
        /// <summary>
        /// Error -152 was removed (ORIGIN_BOUND_CERT_GENERATION_TYPE_MISMATCH)
        /// An SSL peer sent us a fatal decrypt_error alert. This typically occurs when
        /// a peer could not correctly verify a signature (in CertificateVerify or
        /// ServerKeyExchange) or validate a Finished message.
        /// </summary>
        SslDecryptErrorAlert = unchecked((int)-153),
        /// <summary>
        /// There are too many pending WebSocketJob instances, so the new job was not
        /// pushed to the queue.
        /// </summary>
        WsThrottleQueueTooLarge = unchecked((int)-154),
        /// <summary>
        /// Error -155 was removed (TOO_MANY_SOCKET_STREAMS)
        /// The SSL server certificate changed in a renegotiation.
        /// </summary>
        SslServerCertChanged = unchecked((int)-156),
        /// <summary>
        /// Error -157 was removed (SSL_INAPPROPRIATE_FALLBACK).
        /// Error -158 was removed (CT_NO_SCTS_VERIFIED_OK).
        /// The SSL server sent us a fatal unrecognized_name alert.
        /// </summary>
        SslUnrecognizedNameAlert = unchecked((int)-159),
        /// <summary>
        /// Failed to set the socket's receive buffer size as requested.
        /// </summary>
        SocketSetReceiveBufferSizeError = unchecked((int)-160),
        /// <summary>
        /// Failed to set the socket's send buffer size as requested.
        /// </summary>
        SocketSetSendBufferSizeError = unchecked((int)-161),
        /// <summary>
        /// Failed to set the socket's receive buffer size as requested, despite success
        /// return code from setsockopt.
        /// </summary>
        SocketReceiveBufferSizeUnchangeable = unchecked((int)-162),
        /// <summary>
        /// Failed to set the socket's send buffer size as requested, despite success
        /// return code from setsockopt.
        /// </summary>
        SocketSendBufferSizeUnchangeable = unchecked((int)-163),
        /// <summary>
        /// Failed to import a client certificate from the platform store into the SSL
        /// library.
        /// </summary>
        SslClientAuthCertBadFormat = unchecked((int)-164),
        /// <summary>
        /// Error -165 was removed (SSL_FALLBACK_BEYOND_MINIMUM_VERSION).
        /// Resolving a hostname to an IP address list included the IPv4 address
        /// "127.0.53.53". This is a special IP address which ICANN has recommended to
        /// indicate there was a name collision, and alert admins to a potential
        /// problem.
        /// </summary>
        IcannNameCollision = unchecked((int)-166),
        /// <summary>
        /// The SSL server presented a certificate which could not be decoded. This is
        /// not a certificate error code as no X509Certificate object is available. This
        /// error is fatal.
        /// </summary>
        SslServerCertBadFormat = unchecked((int)-167),
        /// <summary>
        /// Certificate Transparency: Received a signed tree head that failed to parse.
        /// </summary>
        CtSthParsingFailed = unchecked((int)-168),
        /// <summary>
        /// Certificate Transparency: Received a signed tree head whose JSON parsing was
        /// OK but was missing some of the fields.
        /// </summary>
        CtSthIncomplete = unchecked((int)-169),
        /// <summary>
        /// The attempt to reuse a connection to send proxy auth credentials failed
        /// before the AuthController was used to generate credentials. The caller should
        /// reuse the controller with a new connection. This error is only used
        /// internally by the network stack.
        /// </summary>
        UnableToReuseConnectionForProxyAuth = unchecked((int)-170),
        /// <summary>
        /// Certificate Transparency: Failed to parse the received consistency proof.
        /// </summary>
        CtConsistencyProofParsingFailed = unchecked((int)-171),
        /// <summary>
        /// The SSL server required an unsupported cipher suite that has since been
        /// removed. This error will temporarily be signaled on a fallback for one or two
        /// releases immediately following a cipher suite's removal, after which the
        /// fallback will be removed.
        /// </summary>
        SslObsoleteCipher = unchecked((int)-172),
        /// <summary>
        /// When a WebSocket handshake is done successfully and the connection has been
        /// upgraded, the URLRequest is cancelled with this error code.
        /// </summary>
        WsUpgrade = unchecked((int)-173),
        /// <summary>
        /// Socket ReadIfReady support is not implemented. This error should not be user
        /// visible, because the normal Read() method is used as a fallback.
        /// </summary>
        ReadIfReadyNotImplemented = unchecked((int)-174),
        /// <summary>
        /// Error -175 was removed (SSL_VERSION_INTERFERENCE).
        /// No socket buffer space is available.
        /// </summary>
        NoBufferSpace = unchecked((int)-176),
        /// <summary>
        /// There were no common signature algorithms between our client certificate
        /// private key and the server's preferences.
        /// </summary>
        SslClientAuthNoCommonAlgorithms = unchecked((int)-177),
        /// <summary>
        /// TLS 1.3 early data was rejected by the server. This will be received before
        /// any data is returned from the socket. The request should be retried with
        /// early data disabled.
        /// </summary>
        EarlyDataRejected = unchecked((int)-178),
        /// <summary>
        /// TLS 1.3 early data was offered, but the server responded with TLS 1.2 or
        /// earlier. This is an internal error code to account for a
        /// backwards-compatibility issue with early data and TLS 1.2. It will be
        /// received before any data is returned from the socket. The request should be
        /// retried with early data disabled.
        /// 
        /// See https://tools.ietf.org/html/rfc8446#appendix-D.3 for details.
        /// </summary>
        WrongVersionOnEarlyData = unchecked((int)-179),
        /// <summary>
        /// TLS 1.3 was enabled, but a lower version was negotiated and the server
        /// returned a value indicating it supported TLS 1.3. This is part of a security
        /// check in TLS 1.3, but it may also indicate the user is behind a buggy
        /// TLS-terminating proxy which implemented TLS 1.2 incorrectly. (See
        /// https://crbug.com/boringssl/226.)
        /// </summary>
        Tls13DowngradeDetected = unchecked((int)-180),
        /// <summary>
        /// The server's certificate has a keyUsage extension incompatible with the
        /// negotiated TLS key exchange method.
        /// </summary>
        SslKeyUsageIncompatible = unchecked((int)-181),
        /// <summary>
        /// Certificate error codes
        /// 
        /// The values of certificate error codes must be consecutive.
        /// The server responded with a certificate whose common name did not match
        /// the host name.  This could mean:
        /// 
        /// 1. An attacker has redirected our traffic to their server and is
        ///    presenting a certificate for which they know the private key.
        /// 
        /// 2. The server is misconfigured and responding with the wrong cert.
        /// 
        /// 3. The user is on a wireless network and is being redirected to the
        ///    network's login page.
        /// 
        /// 4. The OS has used a DNS search suffix and the server doesn't have
        ///    a certificate for the abbreviated name in the address bar.
        /// </summary>
        CertCommonNameInvalid = unchecked((int)-200),
        /// <summary>
        /// The server responded with a certificate that, by our clock, appears to
        /// either not yet be valid or to have expired.  This could mean:
        /// 
        /// 1. An attacker is presenting an old certificate for which they have
        ///    managed to obtain the private key.
        /// 
        /// 2. The server is misconfigured and is not presenting a valid cert.
        /// 
        /// 3. Our clock is wrong.
        /// </summary>
        CertDateInvalid = unchecked((int)-201),
        /// <summary>
        /// The server responded with a certificate that is signed by an authority
        /// we don't trust.  The could mean:
        /// 
        /// 1. An attacker has substituted the real certificate for a cert that
        ///    contains their public key and is signed by their cousin.
        /// 
        /// 2. The server operator has a legitimate certificate from a CA we don't
        ///    know about, but should trust.
        /// 
        /// 3. The server is presenting a self-signed certificate, providing no
        ///    defense against active attackers (but foiling passive attackers).
        /// </summary>
        CertAuthorityInvalid = unchecked((int)-202),
        /// <summary>
        /// The server responded with a certificate that contains errors.
        /// This error is not recoverable.
        /// 
        /// MSDN describes this error as follows:
        ///   "The SSL certificate contains errors."
        /// NOTE: It's unclear how this differs from ERR_CERT_INVALID. For consistency,
        /// use that code instead of this one from now on.
        /// </summary>
        CertContainsErrors = unchecked((int)-203),
        /// <summary>
        /// The certificate has no mechanism for determining if it is revoked.  In
        /// effect, this certificate cannot be revoked.
        /// </summary>
        CertNoRevocationMechanism = unchecked((int)-204),
        /// <summary>
        /// Revocation information for the security certificate for this site is not
        /// available.  This could mean:
        /// 
        /// 1. An attacker has compromised the private key in the certificate and is
        ///    blocking our attempt to find out that the cert was revoked.
        /// 
        /// 2. The certificate is unrevoked, but the revocation server is busy or
        ///    unavailable.
        /// </summary>
        CertUnableToCheckRevocation = unchecked((int)-205),
        /// <summary>
        /// The server responded with a certificate has been revoked.
        /// We have the capability to ignore this error, but it is probably not the
        /// thing to do.
        /// </summary>
        CertRevoked = unchecked((int)-206),
        /// <summary>
        /// The server responded with a certificate that is invalid.
        /// This error is not recoverable.
        /// 
        /// MSDN describes this error as follows:
        ///   "The SSL certificate is invalid."
        /// </summary>
        CertInvalid = unchecked((int)-207),
        /// <summary>
        /// The server responded with a certificate that is signed using a weak
        /// signature algorithm.
        /// </summary>
        CertWeakSignatureAlgorithm = unchecked((int)-208),
        /// <summary>
        /// -209 is availible: was CERT_NOT_IN_DNS.
        /// The host name specified in the certificate is not unique.
        /// </summary>
        CertNonUniqueName = unchecked((int)-210),
        /// <summary>
        /// The server responded with a certificate that contains a weak key (e.g.
        /// a too-small RSA key).
        /// </summary>
        CertWeakKey = unchecked((int)-211),
        /// <summary>
        /// The certificate claimed DNS names that are in violation of name constraints.
        /// </summary>
        CertNameConstraintViolation = unchecked((int)-212),
        /// <summary>
        /// The certificate's validity period is too long.
        /// </summary>
        CertValidityTooLong = unchecked((int)-213),
        /// <summary>
        /// Certificate Transparency was required for this connection, but the server
        /// did not provide CT information that complied with the policy.
        /// </summary>
        CertificateTransparencyRequired = unchecked((int)-214),
        /// <summary>
        /// The certificate chained to a legacy Symantec root that is no longer trusted.
        /// https://g.co/chrome/symantecpkicerts
        /// </summary>
        CertSymantecLegacy = unchecked((int)-215),
        /// <summary>
        /// Add new certificate error codes here.
        /// 
        /// Update the value of CERT_END whenever you add a new certificate error
        /// code.
        /// The value immediately past the last certificate error code.
        /// </summary>
        CertEnd = unchecked((int)-216),
        /// <summary>
        /// The URL is invalid.
        /// </summary>
        InvalidUrl = unchecked((int)-300),
        /// <summary>
        /// The scheme of the URL is disallowed.
        /// </summary>
        DisallowedUrlScheme = unchecked((int)-301),
        /// <summary>
        /// The scheme of the URL is unknown.
        /// </summary>
        UnknownUrlScheme = unchecked((int)-302),
        /// <summary>
        /// Attempting to load an URL resulted in a redirect to an invalid URL.
        /// </summary>
        InvalidRedirect = unchecked((int)-303),
        /// <summary>
        /// Attempting to load an URL resulted in too many redirects.
        /// </summary>
        TooManyRedirects = unchecked((int)-310),
        /// <summary>
        /// Attempting to load an URL resulted in an unsafe redirect (e.g., a redirect
        /// to file:// is considered unsafe).
        /// </summary>
        UnsafeRedirect = unchecked((int)-311),
        /// <summary>
        /// Attempting to load an URL with an unsafe port number.  These are port
        /// numbers that correspond to services, which are not robust to spurious input
        /// that may be constructed as a result of an allowed web construct (e.g., HTTP
        /// looks a lot like SMTP, so form submission to port 25 is denied).
        /// </summary>
        UnsafePort = unchecked((int)-312),
        /// <summary>
        /// The server's response was invalid.
        /// </summary>
        InvalidResponse = unchecked((int)-320),
        /// <summary>
        /// Error in chunked transfer encoding.
        /// </summary>
        InvalidChunkedEncoding = unchecked((int)-321),
        /// <summary>
        /// The server did not support the request method.
        /// </summary>
        MethodNotSupported = unchecked((int)-322),
        /// <summary>
        /// The response was 407 (Proxy Authentication Required), yet we did not send
        /// the request to a proxy.
        /// </summary>
        UnexpectedProxyAuth = unchecked((int)-323),
        /// <summary>
        /// The server closed the connection without sending any data.
        /// </summary>
        EmptyResponse = unchecked((int)-324),
        /// <summary>
        /// The headers section of the response is too large.
        /// </summary>
        ResponseHeadersTooBig = unchecked((int)-325),
        /// <summary>
        /// The PAC requested by HTTP did not have a valid status code (non-200).
        /// </summary>
        PacStatusNotOk = unchecked((int)-326),
        /// <summary>
        /// The evaluation of the PAC script failed.
        /// </summary>
        PacScriptFailed = unchecked((int)-327),
        /// <summary>
        /// The response was 416 (Requested range not satisfiable) and the server cannot
        /// satisfy the range requested.
        /// </summary>
        RequestRangeNotSatisfiable = unchecked((int)-328),
        /// <summary>
        /// The identity used for authentication is invalid.
        /// </summary>
        MalformedIdentity = unchecked((int)-329),
        /// <summary>
        /// Content decoding of the response body failed.
        /// </summary>
        ContentDecodingFailed = unchecked((int)-330),
        /// <summary>
        /// An operation could not be completed because all network IO
        /// is suspended.
        /// </summary>
        NetworkIoSuspended = unchecked((int)-331),
        /// <summary>
        /// FLIP data received without receiving a SYN_REPLY on the stream.
        /// </summary>
        SynReplyNotReceived = unchecked((int)-332),
        /// <summary>
        /// Converting the response to target encoding failed.
        /// </summary>
        EncodingConVersionFailed = unchecked((int)-333),
        /// <summary>
        /// The server sent an FTP directory listing in a format we do not understand.
        /// </summary>
        UnrecognizedFtpDirectoryListingFormat = unchecked((int)-334),
        /// <summary>
        /// Obsolete.  Was only logged in NetLog when an HTTP/2 pushed stream expired.
        /// NET_ERROR(INVALID_SPDY_STREAM, -335)
        /// There are no supported proxies in the provided list.
        /// </summary>
        NoSupportedProxies = unchecked((int)-336),
        /// <summary>
        /// There is an HTTP/2 protocol error.
        /// </summary>
        Http2ProtocolError = unchecked((int)-337),
        /// <summary>
        /// Credentials could not be established during HTTP Authentication.
        /// </summary>
        InvalidAuthCredentials = unchecked((int)-338),
        /// <summary>
        /// An HTTP Authentication scheme was tried which is not supported on this
        /// machine.
        /// </summary>
        UnsupportedAuthScheme = unchecked((int)-339),
        /// <summary>
        /// Detecting the encoding of the response failed.
        /// </summary>
        EncodingDetectionFailed = unchecked((int)-340),
        /// <summary>
        /// (GSSAPI) No Kerberos credentials were available during HTTP Authentication.
        /// </summary>
        MissingAuthCredentials = unchecked((int)-341),
        /// <summary>
        /// An unexpected, but documented, SSPI or GSSAPI status code was returned.
        /// </summary>
        UnexpectedSecurityLibraryStatus = unchecked((int)-342),
        /// <summary>
        /// The environment was not set up correctly for authentication (for
        /// example, no KDC could be found or the principal is unknown.
        /// </summary>
        MisconfiguredAuthEnvironment = unchecked((int)-343),
        /// <summary>
        /// An undocumented SSPI or GSSAPI status code was returned.
        /// </summary>
        UnDocumentedSecurityLibraryStatus = unchecked((int)-344),
        /// <summary>
        /// The HTTP response was too big to drain.
        /// </summary>
        ResponseBodyTooBigToDrain = unchecked((int)-345),
        /// <summary>
        /// The HTTP response contained multiple distinct Content-Length headers.
        /// </summary>
        ResponseHeadersMultipleContentLength = unchecked((int)-346),
        /// <summary>
        /// HTTP/2 headers have been received, but not all of them - status or version
        /// headers are missing, so we're expecting additional frames to complete them.
        /// </summary>
        IncompleteHttp2Headers = unchecked((int)-347),
        /// <summary>
        /// No PAC URL configuration could be retrieved from DHCP. This can indicate
        /// either a failure to retrieve the DHCP configuration, or that there was no
        /// PAC URL configured in DHCP.
        /// </summary>
        PacNotInDhcp = unchecked((int)-348),
        /// <summary>
        /// The HTTP response contained multiple Content-Disposition headers.
        /// </summary>
        ResponseHeadersMultipleContentDisposition = unchecked((int)-349),
        /// <summary>
        /// The HTTP response contained multiple Location headers.
        /// </summary>
        ResponseHeadersMultipleLocation = unchecked((int)-350),
        /// <summary>
        /// HTTP/2 server refused the request without processing, and sent either a
        /// GOAWAY frame with error code NO_ERROR and Last-Stream-ID lower than the
        /// stream id corresponding to the request indicating that this request has not
        /// been processed yet, or a RST_STREAM frame with error code REFUSED_STREAM.
        /// Client MAY retry (on a different connection).  See RFC7540 Section 8.1.4.
        /// </summary>
        Http2ServerRefusedStream = unchecked((int)-351),
        /// <summary>
        /// HTTP/2 server didn't respond to the PING message.
        /// </summary>
        Http2PingFailed = unchecked((int)-352),
        /// <summary>
        /// Obsolete.  Kept here to avoid reuse, as the old error can still appear on
        /// histograms.
        /// NET_ERROR(PIPELINE_EVICTION, -353)
        /// The HTTP response body transferred fewer bytes than were advertised by the
        /// Content-Length header when the connection is closed.
        /// </summary>
        ContentLengthMismatch = unchecked((int)-354),
        /// <summary>
        /// The HTTP response body is transferred with Chunked-Encoding, but the
        /// terminating zero-length chunk was never sent when the connection is closed.
        /// </summary>
        IncompleteChunkedEncoding = unchecked((int)-355),
        /// <summary>
        /// There is a QUIC protocol error.
        /// </summary>
        QuicProtocolError = unchecked((int)-356),
        /// <summary>
        /// The HTTP headers were truncated by an EOF.
        /// </summary>
        ResponseHeadersTruncated = unchecked((int)-357),
        /// <summary>
        /// The QUIC crytpo handshake failed.  This means that the server was unable
        /// to read any requests sent, so they may be resent.
        /// </summary>
        QuicHandshakeFailed = unchecked((int)-358),
        /// <summary>
        /// Obsolete.  Kept here to avoid reuse, as the old error can still appear on
        /// histograms.
        /// NET_ERROR(REQUEST_FOR_SECURE_RESOURCE_OVER_INSECURE_QUIC, -359)
        /// Transport security is inadequate for the HTTP/2 version.
        /// </summary>
        Http2InadequateTransportSecurity = unchecked((int)-360),
        /// <summary>
        /// The peer violated HTTP/2 flow control.
        /// </summary>
        Http2FlowControlError = unchecked((int)-361),
        /// <summary>
        /// The peer sent an improperly sized HTTP/2 frame.
        /// </summary>
        Http2FrameSizeError = unchecked((int)-362),
        /// <summary>
        /// Decoding or encoding of compressed HTTP/2 headers failed.
        /// </summary>
        Http2CompressionError = unchecked((int)-363),
        /// <summary>
        /// Proxy Auth Requested without a valid Client Socket Handle.
        /// </summary>
        ProxyAuthRequestedWithNoConnection = unchecked((int)-364),
        /// <summary>
        /// HTTP_1_1_REQUIRED error code received on HTTP/2 session.
        /// </summary>
        Http11Required = unchecked((int)-365),
        /// <summary>
        /// HTTP_1_1_REQUIRED error code received on HTTP/2 session to proxy.
        /// </summary>
        ProxyHttp11Required = unchecked((int)-366),
        /// <summary>
        /// The PAC script terminated fatally and must be reloaded.
        /// </summary>
        PacScriptTerminated = unchecked((int)-367),
        /// <summary>
        /// Obsolete. Kept here to avoid reuse.
        /// Request is throttled because of a Backoff header.
        /// See: crbug.com/486891.
        /// NET_ERROR(TEMPORARY_BACKOFF, -369)
        /// The server was expected to return an HTTP/1.x response, but did not. Rather
        /// than treat it as HTTP/0.9, this error is returned.
        /// </summary>
        InvalidHttpResponse = unchecked((int)-370),
        /// <summary>
        /// Initializing content decoding failed.
        /// </summary>
        ContentDecodingInitFailed = unchecked((int)-371),
        /// <summary>
        /// Received HTTP/2 RST_STREAM frame with NO_ERROR error code.  This error should
        /// be handled internally by HTTP/2 code, and should not make it above the
        /// SpdyStream layer.
        /// </summary>
        Http2RstStreamNoErrorReceived = unchecked((int)-372),
        /// <summary>
        /// The pushed stream claimed by the request is no longer available.
        /// </summary>
        Http2PushedStreamNotAvailable = unchecked((int)-373),
        /// <summary>
        /// A pushed stream was claimed and later reset by the server. When this happens,
        /// the request should be retried.
        /// </summary>
        Http2ClaimedPushedStreamResetByServer = unchecked((int)-374),
        /// <summary>
        /// An HTTP transaction was retried too many times due for authentication or
        /// invalid certificates. This may be due to a bug in the net stack that would
        /// otherwise infinite loop, or if the server or proxy continually requests fresh
        /// credentials or presents a fresh invalid certificate.
        /// </summary>
        TooManyRetries = unchecked((int)-375),
        /// <summary>
        /// Received an HTTP/2 frame on a closed stream.
        /// </summary>
        Http2StreamClosed = unchecked((int)-376),
        /// <summary>
        /// Client is refusing an HTTP/2 stream.
        /// </summary>
        Http2ClientRefusedStream = unchecked((int)-377),
        /// <summary>
        /// A pushed HTTP/2 stream was claimed by a request based on matching URL and
        /// request headers, but the pushed response headers do not match the request.
        /// </summary>
        Http2PushedResponseDoesNotMatch = unchecked((int)-378),
        /// <summary>
        /// The cache does not have the requested entry.
        /// </summary>
        CacheMiss = unchecked((int)-400),
        /// <summary>
        /// Unable to read from the disk cache.
        /// </summary>
        CacheReadFailure = unchecked((int)-401),
        /// <summary>
        /// Unable to write to the disk cache.
        /// </summary>
        CacheWriteFailure = unchecked((int)-402),
        /// <summary>
        /// The operation is not supported for this entry.
        /// </summary>
        CacheOperationNotSupported = unchecked((int)-403),
        /// <summary>
        /// The disk cache is unable to open this entry.
        /// </summary>
        CacheOpenFailure = unchecked((int)-404),
        /// <summary>
        /// The disk cache is unable to create this entry.
        /// </summary>
        CacheCreateFailure = unchecked((int)-405),
        /// <summary>
        /// Multiple transactions are racing to create disk cache entries. This is an
        /// internal error returned from the HttpCache to the HttpCacheTransaction that
        /// tells the transaction to restart the entry-creation logic because the state
        /// of the cache has changed.
        /// </summary>
        CacheRace = unchecked((int)-406),
        /// <summary>
        /// The cache was unable to read a checksum record on an entry. This can be
        /// returned from attempts to read from the cache. It is an internal error,
        /// returned by the SimpleCache backend, but not by any URLRequest methods
        /// or members.
        /// </summary>
        CacheChecksumReadFailure = unchecked((int)-407),
        /// <summary>
        /// The cache found an entry with an invalid checksum. This can be returned from
        /// attempts to read from the cache. It is an internal error, returned by the
        /// SimpleCache backend, but not by any URLRequest methods or members.
        /// </summary>
        CacheChecksumMismatch = unchecked((int)-408),
        /// <summary>
        /// Internal error code for the HTTP cache. The cache lock timeout has fired.
        /// </summary>
        CacheLockTimeout = unchecked((int)-409),
        /// <summary>
        /// Received a challenge after the transaction has read some data, and the
        /// credentials aren't available.  There isn't a way to get them at that point.
        /// </summary>
        CacheAuthFailureAfterRead = unchecked((int)-410),
        /// <summary>
        /// Internal not-quite error code for the HTTP cache. In-memory hints suggest
        /// that the cache entry would not have been useable with the transaction's
        /// current configuration (e.g. load flags, mode, etc.)
        /// </summary>
        CacheEntryNotSuitable = unchecked((int)-411),
        /// <summary>
        /// The disk cache is unable to doom this entry.
        /// </summary>
        CacheDoomFailure = unchecked((int)-412),
        /// <summary>
        /// The disk cache is unable to open or create this entry.
        /// </summary>
        CacheOpenOrCreateFailure = unchecked((int)-413),
        /// <summary>
        /// The server's response was insecure (e.g. there was a cert error).
        /// </summary>
        InsecureResponse = unchecked((int)-501),
        /// <summary>
        /// An attempt to import a client certificate failed, as the user's key
        /// database lacked a corresponding private key.
        /// </summary>
        NoPrivateKeyForCert = unchecked((int)-502),
        /// <summary>
        /// An error adding a certificate to the OS certificate database.
        /// </summary>
        AddUserCertFailed = unchecked((int)-503),
        /// <summary>
        /// An error occurred while handling a signed exchange.
        /// </summary>
        InvalidSignedExchange = unchecked((int)-504),
        /// <summary>
        /// *** Code -600 is reserved (was FTP_PASV_COMMAND_FAILED). ***
        /// A generic error for failed FTP control connection command.
        /// If possible, please use or add a more specific error code.
        /// </summary>
        FtpFailed = unchecked((int)-601),
        /// <summary>
        /// The server cannot fulfill the request at this point. This is a temporary
        /// error.
        /// FTP response code 421.
        /// </summary>
        FtpServiceUnavailable = unchecked((int)-602),
        /// <summary>
        /// The server has aborted the transfer.
        /// FTP response code 426.
        /// </summary>
        FtpTransferAborted = unchecked((int)-603),
        /// <summary>
        /// The file is busy, or some other temporary error condition on opening
        /// the file.
        /// FTP response code 450.
        /// </summary>
        FtpFileBusy = unchecked((int)-604),
        /// <summary>
        /// Server rejected our command because of syntax errors.
        /// FTP response codes 500, 501.
        /// </summary>
        FtpSyntaxError = unchecked((int)-605),
        /// <summary>
        /// Server does not support the command we issued.
        /// FTP response codes 502, 504.
        /// </summary>
        FtpCommandNotSupported = unchecked((int)-606),
        /// <summary>
        /// Server rejected our command because we didn't issue the commands in right
        /// order.
        /// FTP response code 503.
        /// </summary>
        FtpBadCommandSequence = unchecked((int)-607),
        /// <summary>
        /// PKCS #12 import failed due to incorrect password.
        /// </summary>
        Pkcs12ImportBadPassword = unchecked((int)-701),
        /// <summary>
        /// PKCS #12 import failed due to other error.
        /// </summary>
        Pkcs12ImportFailed = unchecked((int)-702),
        /// <summary>
        /// CA import failed - not a CA cert.
        /// </summary>
        ImportCaCertNotCa = unchecked((int)-703),
        /// <summary>
        /// Import failed - certificate already exists in database.
        /// Note it's a little weird this is an error but reimporting a PKCS12 is ok
        /// (no-op).  That's how Mozilla does it, though.
        /// </summary>
        ImportCertAlreadyExists = unchecked((int)-704),
        /// <summary>
        /// CA import failed due to some other error.
        /// </summary>
        ImportCaCertFailed = unchecked((int)-705),
        /// <summary>
        /// Server certificate import failed due to some internal error.
        /// </summary>
        ImportServerCertFailed = unchecked((int)-706),
        /// <summary>
        /// PKCS #12 import failed due to invalid MAC.
        /// </summary>
        Pkcs12ImportInvalidMac = unchecked((int)-707),
        /// <summary>
        /// PKCS #12 import failed due to invalid/corrupt file.
        /// </summary>
        Pkcs12ImportInvalidFile = unchecked((int)-708),
        /// <summary>
        /// PKCS #12 import failed due to unsupported features.
        /// </summary>
        Pkcs12ImportUnsupported = unchecked((int)-709),
        /// <summary>
        /// Key generation failed.
        /// </summary>
        KeyGenerationFailed = unchecked((int)-710),
        /// <summary>
        /// Error -711 was removed (ORIGIN_BOUND_CERT_GENERATION_FAILED)
        /// Failure to export private key.
        /// </summary>
        PrivateKeyExportFailed = unchecked((int)-712),
        /// <summary>
        /// Self-signed certificate generation failed.
        /// </summary>
        SelfSignedCertGenerationFailed = unchecked((int)-713),
        /// <summary>
        /// The certificate database changed in some way.
        /// </summary>
        CertDatabaseChanged = unchecked((int)-714),
        /// <summary>
        /// Error -715 was removed (CHANNEL_ID_IMPORT_FAILED)
        /// DNS error codes.
        /// DNS resolver received a malformed response.
        /// </summary>
        DnsMalformedResponse = unchecked((int)-800),
        /// <summary>
        /// DNS server requires TCP
        /// </summary>
        DnsServerRequiresTcp = unchecked((int)-801),
        /// <summary>
        /// DNS server failed.  This error is returned for all of the following
        /// error conditions:
        /// 1 - Format error - The name server was unable to interpret the query.
        /// 2 - Server failure - The name server was unable to process this query
        ///     due to a problem with the name server.
        /// 4 - Not Implemented - The name server does not support the requested
        ///     kind of query.
        /// 5 - Refused - The name server refuses to perform the specified
        ///     operation for policy reasons.
        /// </summary>
        DnsServerFailed = unchecked((int)-802),
        /// <summary>
        /// DNS transaction timed out.
        /// </summary>
        DnsTimedOut = unchecked((int)-803),
        /// <summary>
        /// The entry was not found in cache, for cache-only lookups.
        /// </summary>
        DnsCacheMiss = unchecked((int)-804),
        /// <summary>
        /// Suffix search list rules prevent resolution of the given host name.
        /// </summary>
        DnsSearchEmpty = unchecked((int)-805),
        /// <summary>
        /// Failed to sort addresses according to RFC3484.
        /// </summary>
        DnsSortError = unchecked((int)-806),
        /// <summary>
        /// Failed to resolve over HTTP, fallback to legacy
        /// </summary>
        DnsHttpFailed = unchecked((int)-807)
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
    /// Specifies the horizontal text alignment mode.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxHorizontalAlignment {
        /// <summary>
        /// Align the text's left edge with that of its display area.
        /// </summary>
        Left,
        /// <summary>
        /// Align the text's center with that of its display area.
        /// </summary>
        Center,
        /// <summary>
        /// Align the text's right edge with that of its display area.
        /// </summary>
        Right
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
        /// <summary>
        /// Allows commas to exist after the last element in structures.
        /// </summary>
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
        /// <summary>
        /// This option instructs the writer that if a Binary value is encountered,
        /// the value (and key if within a dictionary) will be omitted from the
        /// output, and success will be returned. Otherwise, if a binary value is
        /// encountered, failure will be returned.
        /// </summary>
        OmitBinaryValues = unchecked((int)1 << 0),
        /// <summary>
        /// This option instructs the writer to write doubles that have no fractional
        /// part as a normal integer (i.e., without using exponential notation
        /// or appending a '.0') as long as the value is within the range of a
        /// 64-bit int.
        /// </summary>
        OmitDoubleTypePreservation = unchecked((int)1 << 1),
        /// <summary>
        /// Return a slightly nicer formatted json string (pads with whitespace to
        /// help with readability).
        /// </summary>
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
        /// DEBUG logging.
        /// </summary>
        Debug = Verbose,
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
        /// FATAL logging.
        /// </summary>
        Fatal,
        /// <summary>
        /// Disable logging to file for all messages, and to stderr for messages with
        /// severity less than FATAL.
        /// </summary>
        Disable = unchecked((int)99)
    }
    /// <summary>
    /// Specifies where along the main axis the CfxBoxLayout child views should be
    /// laid out.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMainAxisAlignment {
        /// <summary>
        /// Child views will be left-aligned.
        /// </summary>
        Start,
        /// <summary>
        /// Child views will be center-aligned.
        /// </summary>
        Center,
        /// <summary>
        /// Child views will be right-aligned.
        /// </summary>
        End
    }
    /// <summary>
    /// Specifies how a menu will be anchored for non-RTL languages. The opposite
    /// position will be used for RTL languages.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMenuAnchorPosition {
        Topleft,
        Topright,
        Bottomcenter
    }
    /// <summary>
    /// Supported color types for menu items.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMenuColorType {
        Text,
        TextHovered,
        TextAccelerator,
        TextAcceleratorHovered,
        Background,
        BackgroundHovered,
        Count
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
        Back = unchecked((int)100),
        Forward = unchecked((int)101),
        Reload = unchecked((int)102),
        ReloadNocache = unchecked((int)103),
        Stopload = unchecked((int)104),
        Undo = unchecked((int)110),
        Redo = unchecked((int)111),
        Cut = unchecked((int)112),
        Copy = unchecked((int)113),
        Paste = unchecked((int)114),
        Delete = unchecked((int)115),
        SelectAll = unchecked((int)116),
        Find = unchecked((int)130),
        Print = unchecked((int)131),
        ViewSource = unchecked((int)132),
        SpellcheckSuggestion0 = unchecked((int)200),
        SpellcheckSuggestion1 = unchecked((int)201),
        SpellcheckSuggestion2 = unchecked((int)202),
        SpellcheckSuggestion3 = unchecked((int)203),
        SpellcheckSuggestion4 = unchecked((int)204),
        SpellcheckSuggestionLast = unchecked((int)204),
        NoSpellingSuggestions = unchecked((int)205),
        AddToDictionary = unchecked((int)206),
        CustomFirst = unchecked((int)220),
        CustomLast = unchecked((int)250),
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
    /// Message loop types. Indicates the set of asynchronous events that a message
    /// loop can process.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxMessageLoopType {
        /// <summary>
        /// Supports tasks and timers.
        /// </summary>
        Default,
        /// <summary>
        /// Supports tasks, timers and native UI events (e.g. Windows messages).
        /// </summary>
        Ui,
        /// <summary>
        /// Supports tasks, timers and asynchronous IO events.
        /// </summary>
        Io
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
        UserData,
        /// <summary>
        /// Directory containing application resources. Can be configured via
        /// CfxSettings.ResourcesDirPath.
        /// </summary>
        DirResources
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
    /// The device type that caused the event.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxPointerType {
        Touch = unchecked((int)0),
        Mouse,
        Pen,
        Eraser,
        Unknown
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
    /// Must be kept synchronized with net::URLRequest::ReferrerPolicy from Chromium.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxReferrerPolicy {
        /// <summary>
        /// Clear the referrer header if the header value is HTTPS but the request
        /// destination is HTTP. This is the default behavior.
        /// </summary>
        ClearReferrerOnTransitionFromSecureToInsecure,
        Default = ClearReferrerOnTransitionFromSecureToInsecure,
        /// <summary>
        /// A slight variant on CLEAR_REFERRER_ON_TRANSITION_FROM_SECURE_TO_INSECURE:
        /// If the request destination is HTTP, an HTTPS referrer will be cleared. If
        /// the request's destination is cross-origin with the referrer (but does not
        /// downgrade), the referrer's granularity will be stripped down to an origin
        /// rather than a full URL. Same-origin requests will send the full referrer.
        /// </summary>
        ReduceReferrerGranularityOnTransitionCrossOrigin,
        /// <summary>
        /// Strip the referrer down to an origin when the origin of the referrer is
        /// different from the destination's origin.
        /// </summary>
        OriginOnlyOnTransitionCrossOrigin,
        /// <summary>
        /// Never change the referrer.
        /// </summary>
        NeverClearReferrer,
        /// <summary>
        /// Strip the referrer down to the origin regardless of the redirect location.
        /// </summary>
        Origin,
        /// <summary>
        /// Clear the referrer when the request's referrer is cross-origin with the
        /// request's destination.
        /// </summary>
        ClearReferrerOnTransitionCrossOrigin,
        /// <summary>
        /// Strip the referrer down to the origin, but clear it entirely if the
        /// referrer value is HTTPS and the destination is HTTP.
        /// </summary>
        OriginClearOnTransitionFromSecureToInsecure,
        /// <summary>
        /// Always clear the referrer regardless of the request destination.
        /// </summary>
        NoReferrer,
        LastValue = NoReferrer
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
    /// 
    /// Configuration options for registering a custom scheme.
    /// These values are used when calling AddCustomScheme.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxSchemeOptions {
        None = unchecked((int)0),
        /// <summary>
        /// If CEF_SCHEME_OPTION_STANDARD is set the scheme will be treated as a
        /// standard scheme. Standard schemes are subject to URL canonicalization and
        /// parsing rules as defined in the Common Internet Scheme Syntax RFC 1738
        /// Section 3.1 available at http://www.ietf.org/rfc/rfc1738.txt
        /// 
        /// In particular, the syntax for standard scheme URLs must be of the form:
        /// &lt;pre>
        ///  [scheme]://[username]:[password]@[host]:[port]/[url-path]
        /// &lt;/pre> Standard scheme URLs must have a host component that is a fully
        /// qualified domain name as defined in Section 3.5 of RFC 1034 [13] and
        /// Section 2.1 of RFC 1123. These URLs will be canonicalized to
        /// "scheme://host/path" in the simplest case and
        /// "scheme://username:password@host:port/path" in the most explicit case. For
        /// example, "scheme:host/path" and "scheme:///host/path" will both be
        /// canonicalized to "scheme://host/path". The origin of a standard scheme URL
        /// is the combination of scheme, host and port (i.e., "scheme://host:port" in
        /// the most explicit case).
        /// 
        /// For non-standard scheme URLs only the "scheme:" component is parsed and
        /// canonicalized. The remainder of the URL will be passed to the handler as-
        /// is. For example, "scheme:///some%20text" will remain the same. Non-standard
        /// scheme URLs cannot be used as a target for form submission.
        /// </summary>
        Standard = unchecked((int)1 << 0),
        /// <summary>
        /// If CEF_SCHEME_OPTION_LOCAL is set the scheme will be treated with the same
        /// security rules as those applied to "file" URLs. Normal pages cannot link to
        /// or access local URLs. Also, by default, local URLs can only perform
        /// XMLHttpRequest calls to the same URL (origin + path) that originated the
        /// request. To allow XMLHttpRequest calls from a local URL to other URLs with
        /// the same origin set the CfxSettings.FileAccessFromFileUrlsAllowed
        /// value to true (1). To allow XMLHttpRequest calls from a local URL to all
        /// origins set the CfxSettings.UniversalAccessFromFileUrlsAllowed value
        /// to true (1).
        /// </summary>
        Local = unchecked((int)1 << 1),
        /// <summary>
        /// If CEF_SCHEME_OPTION_DISPLAY_ISOLATED is set the scheme can only be
        /// displayed from other content hosted with the same scheme. For example,
        /// pages in other origins cannot create iframes or hyperlinks to URLs with the
        /// scheme. For schemes that must be accessible from other schemes don't set
        /// this, set CEF_SCHEME_OPTION_CORS_ENABLED, and use CORS
        /// "Access-Control-Allow-Origin" headers to further restrict access.
        /// </summary>
        DisplayIsolated = unchecked((int)1 << 2),
        /// <summary>
        /// If CEF_SCHEME_OPTION_SECURE is set the scheme will be treated with the same
        /// security rules as those applied to "https" URLs. For example, loading this
        /// scheme from other secure schemes will not trigger mixed content warnings.
        /// </summary>
        Secure = unchecked((int)1 << 3),
        /// <summary>
        /// If CEF_SCHEME_OPTION_CORS_ENABLED is set the scheme can be sent CORS
        /// requests. This value should be set in most cases where
        /// CEF_SCHEME_OPTION_STANDARD is set.
        /// </summary>
        CorsEnabled = unchecked((int)1 << 4),
        /// <summary>
        /// If CEF_SCHEME_OPTION_CSP_BYPASSING is set the scheme can bypass Content-
        /// Security-Policy (CSP) checks. This value should not be set in most cases
        /// where CEF_SCHEME_OPTION_STANDARD is set.
        /// </summary>
        CspBypassing = unchecked((int)1 << 5),
        /// <summary>
        /// If CEF_SCHEME_OPTION_FETCH_ENABLED is set the scheme can perform Fetch API
        /// requests.
        /// </summary>
        FetchEnabled = unchecked((int)1 << 6)
    }
    /// <summary>
    /// Supported SSL content status flags. See content/public/common/ssl_status.h
    /// for more information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    [Flags()]
    public enum CfxSslContentStatus {
        NormalContent = unchecked((int)0),
        DisplayedInsecureContent = unchecked((int)1 << 0),
        RanInsecureContent = unchecked((int)1 << 1)
    }
    /// <summary>
    /// Supported SSL version values. See net/ssl/ssl_connection_status_flags.h
    /// for more information.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxSslVersion {
        Unknown = unchecked((int)0),
        Ssl2 = unchecked((int)1),
        Ssl3 = unchecked((int)2),
        Tls1 = unchecked((int)3),
        Tls11 = unchecked((int)4),
        Tls12 = unchecked((int)5),
        Tls13 = unchecked((int)6),
        Quic = unchecked((int)7)
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
        ProcessCrashed,
        /// <summary>
        /// Out of memory. Some platforms may use TS_PROCESS_CRASHED instead.
        /// </summary>
        ProcessOOM
    }
    /// <summary>
    /// Input mode of a virtual keyboard. These constants match their equivalents
    /// in Chromium's text_input_mode.h and should not be renumbered.
    /// See https://html.spec.whatwg.org/#input-modalities:-the-inputmode-attribute
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxTextInputMode {
        Default,
        None,
        Text,
        Tel,
        Url,
        Email,
        Numeric,
        Decimal,
        Search,
        Max = Search
    }
    /// <summary>
    /// Text style types. Should be kepy in sync with gfx::TextStyle.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxTextStyle {
        Bold,
        Italic,
        Strike,
        DiagonalStrike,
        Underline
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
        /// The main thread in the browser. This will be the same as the main
        /// application thread if CfxInitialize() is called with a
        /// CfxSettings.MultiThreadedMessageLoop value of false. Do not perform
        /// blocking tasks on this thread. All tasks posted after
        /// CfxBrowserProcessHandler.OnContextInitialized() and before CfxShutdown()
        /// are guaranteed to run. This thread will outlive all other CEF threads.
        /// </summary>
        Ui,
        /// <summary>
        /// Used for blocking tasks (e.g. file system access) where the user won't
        /// notice if the task takes an arbitrarily long time to complete. All tasks
        /// posted after CfxBrowserProcessHandler.OnContextInitialized() and before
        /// CfxShutdown() are guaranteed to run.
        /// </summary>
        FileBackground,
        File = FileBackground,
        /// <summary>
        /// Used for blocking tasks (e.g. file system access) that affect UI or
        /// responsiveness of future user interactions. Do not use if an immediate
        /// response to a user interaction is expected. All tasks posted after
        /// CfxBrowserProcessHandler.OnContextInitialized() and before CfxShutdown()
        /// are guaranteed to run.
        /// Examples:
        /// - Updating the UI to reflect progress on a long task.
        /// - Loading data that might be shown in the UI after a future user
        ///   interaction.
        /// </summary>
        FileUserVisible,
        /// <summary>
        /// Used for blocking tasks (e.g. file system access) that affect UI
        /// immediately after a user interaction. All tasks posted after
        /// CfxBrowserProcessHandler.OnContextInitialized() and before CfxShutdown()
        /// are guaranteed to run.
        /// Example: Generating data shown in the UI immediately after a click.
        /// </summary>
        FileUserBlocking,
        /// <summary>
        /// Used to launch and terminate browser processes.
        /// </summary>
        ProcessLauncher,
        /// <summary>
        /// Used to process IPC and network messages. Do not perform blocking tasks on
        /// this thread. All tasks posted after
        /// CfxBrowserProcessHandler.OnContextInitialized() and before CfxShutdown()
        /// are guaranteed to run.
        /// </summary>
        Io,
        /// <summary>
        /// The main thread in the renderer. Used for all WebKit and V8 interaction.
        /// Tasks may be posted to this thread after
        /// CfxRenderProcessHandler.OnRenderThreadCreated but are not guaranteed to
        /// run before sub-process termination (sub-processes may be killed at any time
        /// without warning).
        /// </summary>
        Renderer
    }
    /// <summary>
    /// Thread priority values listed in increasing order of importance.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxThreadPriority {
        /// <summary>
        /// Suitable for threads that shouldn't disrupt high priority work.
        /// </summary>
        Background,
        /// <summary>
        /// Default priority level.
        /// </summary>
        Normal,
        /// <summary>
        /// Suitable for threads which generate data for the display (at ~60Hz).
        /// </summary>
        Display,
        /// <summary>
        /// Suitable for low-latency, glitch-resistant audio.
        /// </summary>
        RealtimeAudio
    }
    /// <summary>
    /// Touch points states types.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxTouchEventType {
        Released = unchecked((int)0),
        Pressed,
        Moved,
        Cancelled
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
        Normal = unchecked((int)1 << 0),
        /// <summary>
        /// Convert %20 to spaces. In some places where we're showing URLs, we may
        /// want this. In places where the URL may be copied and pasted out, then
        /// you wouldn't want this since it might not be interpreted in one piece
        /// by other applications.
        /// </summary>
        Spaces = unchecked((int)1 << 1),
        /// <summary>
        /// Unescapes '/' and '\\'. If these characters were unescaped, the resulting
        /// URL won't be the same as the source one. Moreover, they are dangerous to
        /// unescape in strings that will be used as file paths or names. This value
        /// should only be used when slashes don't have special meaning, like data
        /// URLs.
        /// </summary>
        PathSeparators = unchecked((int)1 << 2),
        /// <summary>
        /// Unescapes various characters that will change the meaning of URLs,
        /// including '%', '+', '&amp;', '#'. Does not unescape path separators.
        /// If these characters were unescaped, the resulting URL won't be the same
        /// as the source one. This flag is used when generating final output like
        /// filenames for URLs where we won't be interpreting as a URL and want to do
        /// as much unescaping as possible.
        /// </summary>
        UrlSpecialCharsExceptPathSeparators = unchecked((int)1 << 3),
        /// <summary>
        /// Unescapes characters that can be used in spoofing attempts (such as LOCK)
        /// and control characters (such as BiDi control characters and %01).  This
        /// INCLUDES NULLs.  This is used for rare cases such as data: URL decoding
        /// where the result is binary data.
        /// 
        /// DO NOT use UU_SPOOFING_AND_CONTROL_CHARS if the URL is going to be
        /// displayed in the UI for security reasons.
        /// </summary>
        SpoofingAndControlChars = unchecked((int)1 << 4),
        /// <summary>
        /// URL queries use "+" for space. This flag controls that replacement.
        /// </summary>
        ReplacePlusWithSpace = unchecked((int)1 << 5)
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
        /// <summary>
        /// If set the cache will be skipped when handling the request. Setting this
        /// value is equivalent to specifying the "Cache-Control: no-cache" request
        /// header. Setting this value in combination with UR_FLAG_ONLY_FROM_CACHE will
        /// cause the request to fail.
        /// </summary>
        SkipCache = unchecked((int)1 << 0),
        /// <summary>
        /// If set the request will fail if it cannot be served from the cache (or some
        /// equivalent local store). Setting this value is equivalent to specifying the
        /// "Cache-Control: only-if-cached" request header. Setting this value in
        /// combination with UR_FLAG_SKIP_CACHE or UR_FLAG_DISABLE_CACHE will cause the
        /// request to fail.
        /// </summary>
        OnlyFromCache = unchecked((int)1 << 1),
        /// <summary>
        /// If set the cache will not be used at all. Setting this value is equivalent
        /// to specifying the "Cache-Control: no-store" request header. Setting this
        /// value in combination with UR_FLAG_ONLY_FROM_CACHE will cause the request to
        /// fail.
        /// </summary>
        DisableCache = unchecked((int)1 << 2),
        /// <summary>
        /// If set user name, password, and cookies may be sent with the request, and
        /// cookies may be saved from the response.
        /// </summary>
        AllowStoredCredentials = unchecked((int)1 << 3),
        /// <summary>
        /// If set upload progress events will be generated when a request has a body.
        /// </summary>
        ReportUploadProgress = unchecked((int)1 << 4),
        /// <summary>
        /// If set the CfxURLRequestClient.OnDownloadData method will not be called.
        /// </summary>
        NoDownloadData = unchecked((int)1 << 5),
        /// <summary>
        /// If set 5XX redirect errors will be propagated to the observer instead of
        /// automatically re-tried. This currently only applies for requests
        /// originated in the browser process.
        /// </summary>
        NoRetryOn5xx = unchecked((int)1 << 6),
        /// <summary>
        /// If set 3XX responses will cause the fetch to halt immediately rather than
        /// continue through the redirect.
        /// </summary>
        StopOnRedirect = unchecked((int)1 << 7)
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
    /// The manner in which a link click should be opened. These constants match
    /// their equivalents in Chromium's window_open_disposition.h and should not be
    /// renumbered.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public enum CfxWindowOpenDisposition {
        Unknown,
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
