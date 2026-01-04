namespace FashionFace.Repositories.Context.Interfaces;

public interface IOutbox :
    IWithOutboxStatus,
    IWithAttemptCount,
    IWithProcessingStartedAt;