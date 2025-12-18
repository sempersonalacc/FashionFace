
namespace FashionFace.Dependencies.SignalR.Models;

public sealed record ErrorsContainerResponse(
    string TraceId,
    ErrorResponse Error
);