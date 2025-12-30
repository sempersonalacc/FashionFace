using System;
using System.Linq;
using System.Threading.Tasks;

using FashionFace.Common.Constants.Constants;
using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;
using FashionFace.Facades.Users.Models.UserToUserChats;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserChats;

public sealed class UserToUserChatMessageSendFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    ICreateRepository createRepository
) : IUserToUserChatMessageSendFacade
{
    public async Task<UserToUserChatMessageSendResult> Execute(
        UserToUserChatMessageSendArgs args
    )
    {
        var (userId, chatId, message) = args;

        var userToUserChatCollection =
            genericReadRepository.GetCollection<UserToUserChat>();

        var userToUserChat =
            await
                userToUserChatCollection

                    .Include(
                        entity => entity.ProfileCollection
                    )
                    .ThenInclude(
                        entity => entity.Profile
                    )

                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == chatId
                            && entity
                                .ProfileCollection
                                .Any(
                                    profile =>
                                        profile
                                            .Profile!
                                            .ApplicationUserId
                                        == userId
                                )
                    );

        if (userToUserChat is null)
        {
            throw exceptionDescriptor.NotFound<UserToUserChat>();
        }

        var userToUserChatMessageCollection =
            genericReadRepository.GetCollection<UserToUserChatMessage>();

        var lastMessagePositionIndex =
            await
                userToUserChatMessageCollection
                    .Where(
                        entity =>
                            entity.ChatId == chatId
                    )
                    .OrderByDescending(
                        entity => entity.PositionIndex
                    )
                    .FirstOrDefaultAsync();

        var lastPositionIndex =
            lastMessagePositionIndex?.PositionIndex
            ?? PositionIndexConstants.DefaultPositionIndex;

        var positionIndex =
            lastPositionIndex
            + PositionIndexConstants.PositionIndexShift;

        var messageId =
            Guid.NewGuid();

        var userToUserMessage =
            new UserToUserMessage
            {
                Id = messageId,
                UserId = userId,
                Value =  message,
            };

        var userToUserChatMessage =
            new UserToUserChatMessage
            {
                Id = Guid.NewGuid(),
                ChatId = chatId,
                CreatedAt =  DateTime.UtcNow,
                PositionIndex = positionIndex,
                MessageId = messageId,
                Message = userToUserMessage,
            };

        await
            createRepository
                .CreateAsync(
                    userToUserChatMessage
                );

        var result =
            new UserToUserChatMessageSendResult(
                userToUserChatMessage.MessageId
            );

        return
            result;
    }
}