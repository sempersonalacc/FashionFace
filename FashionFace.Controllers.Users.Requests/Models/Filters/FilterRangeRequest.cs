namespace FashionFace.Controllers.Users.Requests.Models.Filters;

public sealed record FilterRangeRequest(
    int? Min,
    int? Max
);