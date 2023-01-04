﻿namespace NetEvolve.Guard;

using System;
using System.Diagnostics;

public partial class SecureContextExtensions
{
    /// <summary>
    /// Determines if <paramref name="value"/> is greater than <paramref name="compareValue"/>.
    /// </summary>
    /// <param name="value">Value to be verified.</param>
    /// <param name="compareValue">The value to be used for comparison.</param>
    /// <returns>Returns <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">When <paramref name="value"/> is greater than <paramref name="compareValue"/>.</exception>
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static ref readonly SecureContext<DateTime> IsGreaterThan(
        in this SecureContext<DateTime> value,
        DateTime compareValue
    )
    {
        if (value.Value <= compareValue)
        {
            throw new ArgumentOutOfRangeException(value.ParameterName, value.Value, null);
        }

        return ref value;
    }
}
