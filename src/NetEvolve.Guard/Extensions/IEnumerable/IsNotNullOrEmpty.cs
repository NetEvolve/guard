﻿namespace NetEvolve.Guard;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public partial class SecureContextExtensions
{
    [DebuggerStepThrough]
    [StackTraceHidden]
    public static SecureContext<IEnumerable<T>> IsNotNullOrEmpty<T>(
        in this SecureContext<IEnumerable<T>?> value
    )
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value.Value, value.ParameterName);
#else
        if (value.Value is null)
        {
            throw new ArgumentNullException(value.ParameterName);
        }
#endif

        if (!value.Value.Any())
        {
            throw new ArgumentException(null, value.ParameterName);
        }

        return new SecureContext<IEnumerable<T>>(value.Value!, value.ParameterName);
    }
}
