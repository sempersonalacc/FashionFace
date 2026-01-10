namespace FashionFace.Repositories.Strategy.Builders.Args;

public sealed record GenericSelectClaimedRetryStrategyBuilderArgs(
    int BatchCount,
    int RetryDelayMinutes
);