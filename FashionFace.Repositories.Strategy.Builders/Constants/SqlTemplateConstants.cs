namespace FashionFace.Repositories.Strategy.Builders.Constants;

public static class SqlTemplateConstants
{
    public const string SelectByStatus =
        """
            SELECT *
            FROM "{0}"
            WHERE "Status" = @Status
            ORDER BY "MessageCreatedAt"
            FOR UPDATE SKIP LOCKED
            LIMIT @BatchCount
        """;

    public const string SelectByStatusAndProcessingStartedAt =
        """
            SELECT *
            FROM "{0}"
            WHERE "Status" = @Status and "ProcessingStartedAt" < @ProcessingStartedAt
            ORDER BY "MessageCreatedAt"
            FOR UPDATE SKIP LOCKED
            LIMIT @BatchCount
        """;

}