using FashionFace.Repositories.Context.Configurations.Base;
using FashionFace.Repositories.Context.Models.UserToUserChats;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionFace.Repositories.Context.Configurations.UserToUserChats;

public sealed class UserToUserChatConfiguration : EntityBaseConfiguration<UserToUserChat>
{
    public override void Configure(EntityTypeBuilder<UserToUserChat> builder)
    {
        base.Configure(
            builder
        );
    }
}