using System;

namespace FashionFace.Common.Extensions.Implementations;

public static class EnumExtensions
{
    public static string ToStringOrEmpty(
        this Enum? value
    ) =>
        value is null
        || value.ToString() == "Undefined"
            ? string.Empty
            : value.ToString();
}