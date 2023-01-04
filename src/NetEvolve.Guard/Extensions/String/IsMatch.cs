﻿namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> matches the regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> doesn't match the regex <paramref name="pattern"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<string> IsMatch(
        in this SecureContext<string> value,
        [StringSyntax(StringSyntaxAttribute.Regex)] string pattern
    )
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(pattern);
#else
        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }
#endif

        if (!Regex.IsMatch(value.Value, pattern))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }

    /// <summary>
    /// Determines if the <paramref name="value"/> matches the regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException"><paramref name="value"/> doesn't match the regex <paramref name="pattern"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<string> IsMatch(
        in this SecureContext<string> value,
        [StringSyntax(StringSyntaxAttribute.Regex, nameof(options))] string pattern,
        RegexOptions options
    )
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(pattern);
#else
        if (pattern is null)
        {
            throw new ArgumentNullException(nameof(pattern));
        }
#endif

        if (!Regex.IsMatch(value.Value, pattern, options))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
