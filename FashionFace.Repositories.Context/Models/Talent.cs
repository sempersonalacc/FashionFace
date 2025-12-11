using System.Collections.Generic;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.Base;

namespace FashionFace.Repositories.Context.Models;

public sealed class Talent : EntityBase, IWithIsDeleted
{
    public required bool IsDeleted { get; set; }
    public required string Description { get; set; }
    public required TalentType TalentType { get; set; }

    public Portfolio? Portfolio { get; set; }
    public ProfileTalent? ProfileTalent { get; set; }
    public ICollection<TalentLocation> TalentLocationCollection { get; set; }
}