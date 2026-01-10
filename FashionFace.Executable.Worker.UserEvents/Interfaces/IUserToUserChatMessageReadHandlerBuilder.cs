using FashionFace.Executable.Worker.UserEvents.Args;

using RabbitMQ.Client.Events;

namespace FashionFace.Executable.Worker.UserEvents.Interfaces;

public interface IUserToUserChatMessageReadHandlerBuilder
{
    AsyncEventHandler<BasicDeliverEventArgs> Build(
        EventHandlerBuilderArgs args
    );
}