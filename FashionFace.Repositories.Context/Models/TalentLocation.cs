using System;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models;

public sealed class TalentLocation : EntityBase, IWithIsDeleted
{
    public required Guid TalentId { get; set; }
    public required Guid CityId { get; set; }
    public required Guid PlaceId { get; set; }

    public required bool IsDeleted { get; set; }
    public required LocationType LocationType { get; set; }

    public City? City { get; set; }
    public Place? Place { get; set; }
    public Talent? Talent { get; set; }
}