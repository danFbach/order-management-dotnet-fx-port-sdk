#if !NET6_0_OR_GREATER
using System.Text;

namespace System;

internal static class StringPolyfillExtensions
{
    /// <summary>
    /// Replaces line endings (CRLF, LF, CR, FF, NEL, LS, PS) with <paramref name="replacementText"/>,
    /// matching the behavior of string.ReplaceLineEndings on modern .NET.
    /// </summary>
    internal static string ReplaceLineEndings(this string text, string? replacementText = null)
    {
        if (text is null) throw new ArgumentNullException(nameof(text));
        replacementText ??= Environment.NewLine;

        var sb = new StringBuilder(text.Length);
        for (var i = 0; i < text.Length; i++)
        {
            var c = text[i];
            switch (c)
            {
                case '\r':
                    if (i + 1 < text.Length && text[i + 1] == '\n') i++;
                    sb.Append(replacementText);
                    break;
                case '\n':
                case '\f':
                case '\u0085':
                case '\u2028':
                case '\u2029':
                    sb.Append(replacementText);
                    break;
                default:
                    sb.Append(c);
                    break;
            }
        }

        return sb.ToString();
    }
}
#endif
