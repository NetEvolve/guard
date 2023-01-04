﻿#if !NET7_0_OR_GREATER
namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if the <paramref name="value"/> corresponds to negative infinity or not.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <exception cref="ArgumentException">When <paramref name="value"/> is negative infinity, then a <see cref="ArgumentException"/> is raised.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<double> IsNotPositiveInfinity(
        in this SecureContext<double> value
    )
    {
        if (double.IsPositiveInfinity(value.Value))
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return ref value;
    }
}
#endif
