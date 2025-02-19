namespace DotPulsar.Internal.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

public static class TypeExtensions
{
    public static bool ImplementsBaseTypeFullName(this Type typeToCheck, string fullNameToCheckAgainst)
    {
        Type? tempType = typeToCheck;
        while (true)
        {
            if (tempType is null)
                break;
            if (string.IsNullOrEmpty(tempType.FullName))
                continue;
            if (tempType.FullName.Equals(fullNameToCheckAgainst))
                return true;
            tempType = tempType.BaseType;
        }
        return false;
    }
}
