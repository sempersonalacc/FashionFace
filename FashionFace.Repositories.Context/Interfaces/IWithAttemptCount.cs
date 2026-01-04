namespace FashionFace.Repositories.Context.Interfaces;

public interface IWithAttemptCount
{
    int AttemptCount { get; set; }
}