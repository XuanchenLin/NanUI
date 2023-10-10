// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Options that can be passed to CefWriteJSON.
/// </summary>
[Flags]
public enum CefJsonWriterOptions
{
    /// <summary>
    /// Default behavior.
    /// </summary>
    Default = 0,

    /// <summary>
    /// This option instructs the writer that if a Binary value is encountered,
    /// the value (and key if within a dictionary) will be omitted from the
    /// output, and success will be returned. Otherwise, if a binary value is
    /// encountered, failure will be returned.
    /// </summary>
    OmitBinaryValues = 1 << 0,

    /// <summary>
    /// This option instructs the writer to write doubles that have no fractional
    /// part as a normal integer (i.e., without using exponential notation
    /// or appending a '.0') as long as the value is within the range of a
    /// 64-bit int.
    /// </summary>
    OmitDoubleTypePreservation = 1 << 1,

    /// <summary>
    /// Return a slightly nicer formatted json string (pads with whitespace to
    /// help with readability).
    /// </summary>
    PrettyPrint = 1 << 2,
}
