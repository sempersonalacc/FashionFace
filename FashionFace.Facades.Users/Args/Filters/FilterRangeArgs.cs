namespace FashionFace.Facades.Users.Args.Filters;

public sealed record FilterRangeArgs(
    int? Min,
    int? Max
);