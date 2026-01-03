namespace FashionFace.Repositories.Strategy.Builders.Args;

public sealed record SelectClaimedRetryStrategyBuilderArgs(
    int BatchCount,
    int RetryDelayMinutes
);