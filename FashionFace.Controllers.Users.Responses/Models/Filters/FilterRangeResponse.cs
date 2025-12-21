namespace FashionFace.Controllers.Users.Requests.Models.Filters
{
    public sealed record FilterRangeResponse(
        int? Min,
        int? Max
    );
}