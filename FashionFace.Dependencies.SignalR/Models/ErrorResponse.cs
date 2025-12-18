using System.Collections.Generic;

namespace FashionFace.Dependencies.SignalR.Models;

public sealed record ErrorResponse(
    string Code,
    IDictionary<string, object> Details
);