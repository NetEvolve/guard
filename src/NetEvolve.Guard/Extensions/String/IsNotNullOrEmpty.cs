﻿namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is not <see langword="null"/> or <see cref="string.Empty"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <returns>A non-<see langword="null"/> <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is <see cref="string.Empty"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<string> IsNotNullOrEmpty(in this SecureContext<string?> value)
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
        if (0u == (uint)value.Value.Length)
        {
            throw new ArgumentException(null, value.ParameterName);
        }
#endif

        return new SecureContext<string>(value.Value, value.ParameterName);
    }
}
