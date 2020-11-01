//
// This file manually written from cef/include/internal/cef_types.h.
// C API name: cef_json_parser_error_t.
//
namespace Xilium.CefGlue
{
    /// <summary>
    /// Error codes that can be returned from CefParseJSONAndReturnError.
    /// </summary>
    public enum CefJsonParserError
    {
        NoError = 0,
        InvalidEscape,
        SyntaxError,
        UnexpectedToken,
        TrailingComma,
        TooMuchNesting,
        UnexpectedDataAfterRoot,
        UnsupportedEncoding,
        UnquotedDictionaryKey,
        ParseErrorCount,
    }
}
