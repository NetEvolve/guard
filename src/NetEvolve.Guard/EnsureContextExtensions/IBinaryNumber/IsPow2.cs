﻿#if NET7_0_OR_GREATER

namespace NetEvolve.Guard;

using System;
using System.Diagnostics;
using System.Numerics;

public partial class EnsureContextExtensions
{
    /// <summary>
    /// Determines if a <paramref name="value"/> is a power of two.
    /// </summary>
    /// <typeparam name="TBinaryNumber">The type that implements the <see cref="IBinaryNumber{TSelf}"/>.</typeparam>
    /// <param name="value">Value to be verified.</param>
    /// <returns>Returns <paramref name="value"/>, if a power of two.</returns>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is not a power of two.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly EnsureContext<TBinaryNumber> IsPow2<TBinaryNumber>(
        in this EnsureContext<TBinaryNumber> value
    )
        where TBinaryNumber : IBinaryNumber<TBinaryNumber>
    {
        if (!TBinaryNumber.IsPow2(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
