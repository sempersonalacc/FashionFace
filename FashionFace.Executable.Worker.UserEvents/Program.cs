using System;
using System.Threading.Tasks;

using FashionFace.Common.Extensions.Dependencies.Implementations;
using FashionFace.Dependencies.RabbitMq.Facades.Interfaces;
using FashionFace.Dependencies.RabbitMq.Interfaces;
using FashionFace.Dependencies.SignalR.Implementations;
using FashionFace.Executable.Worker.UserEvents.Args;
using FashionFace.Executable.Worker.UserEvents.Interfaces;
using FashionFace.Executable.Worker.UserEvents.Workers;
using FashionFace.Repositories.Context;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Services.ConfigurationSettings.Models;

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using RabbitMQ.Client;

using Serilog;

var builder =
    Host
        .CreateApplicationBuilder(
            args
        );

var builderConfiguration =
    builder.Configuration;

var serviceCollection =
    builder.Services;

Log.Logger =
    new LoggerConfiguration()
        .ReadFrom
        .Configuration(
            builderConfiguration
        )
        .Enrich
        .FromLogContext()
        .CreateLogger();

var redisSection = builderConfiguration.GetSection(
    "Redis"
);
serviceCollection.Configure<RedisSettings>(
    redisSection
);

var applicationSection = builderConfiguration.GetSection(
    "Application"
);
serviceCollection.Configure<ApplicationSettings>(
    applicationSection
);

var rabbitMqSection = builderConfiguration.GetSection(
    "RabbitMq"
);
serviceCollection.Configure<RabbitMqSettings>(
    rabbitMqSection
);

serviceCollection.AddLogging(
    loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog();
    }
);

serviceCollection
    .AddDbContext<ApplicationDatabaseContext>(
        options =>
            options.UseNpgsql(
                "name=Database:ConnectionString",
                serverOptions =>
                {
                    serverOptions
                        .MigrationsAssembly(
                            typeof(ApplicationDatabaseContext).Assembly.FullName
                        );
                }
            )
    );

serviceCollection.AddStackExchangeRedisCache(
    options =>
    {
        options.Configuration = redisSection["Configuration"];
        options.InstanceName = redisSection["InstanceName"];
    }
);

serviceCollection.SetupDependencies();

builder.Services.AddHostedService<UserToUserChatMessageSendOutboxPendingWorker>();
builder.Services.AddHostedService<UserToUserChatMessageSendOutboxClaimedRetryWorker>();

builder.Services.AddHostedService<UserToUserChatMessageReadOutboxPendingWorker>();
builder.Services.AddHostedService<UserToUserChatMessageReadOutboxClaimedRetryWorker>();

builder.Services.AddHostedService<UserToUserChatMessageSendNotificationOutboxPendingWorker>();
builder.Services.AddHostedService<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker>();

builder.Services.AddHostedService<UserToUserChatMessageReadNotificationOutboxPendingWorker>();
builder.Services.AddHostedService<UserToUserChatMessageReadNotificationOutboxClaimedRetryWorker>();

var host =
    builder.Build();

serviceCollection
    .AddSignalR(
        options => { options.AddFilter<HubExceptionsFilter>(); }
    )
    .AddRedis(
        redisSection["Configuration"],
        options =>
        {
            options.Configuration.ChannelPrefix =
                $"signalr:{builder.Environment.EnvironmentName}";
        }
    );

var serviceProvider =
    host.Services;

var queueConnectionCreateDomainFacadeBuilder =
    serviceProvider.GetRequiredService<IQueueConnectionCreateDomainFacadeBuilder>();

var publishSubscribeChannelService =
    serviceProvider.GetRequiredService<IPublishSubscribeChannelService>();

var channelSubscribeService =
    serviceProvider.GetRequiredService<IChannelSubscribeService>();

var queueConnectionCreateDomainFacade =
    queueConnectionCreateDomainFacadeBuilder.Build();

var connection =
    await
        queueConnectionCreateDomainFacade.CreateAsync();

await
    SubscribeToUserToUserChatMessageRead(
    publishSubscribeChannelService,
    connection,
    serviceProvider,
    channelSubscribeService
);

host.Run();

return;

static async Task SubscribeToUserToUserChatMessageRead(
    IPublishSubscribeChannelService publishSubscribeChannelService,
    IConnection connection,
    IServiceProvider serviceProvider,
    IChannelSubscribeService channelSubscribeService
)
{
    var channel =
        await
            publishSubscribeChannelService
                .CreateDirect(
                    connection,
                    $"{typeof(UserToUserChatMessageReadOutbox).FullName}.exchange",
                    $"{typeof(UserToUserChatMessageReadOutbox).FullName}.queue"
                );

    var eventHandlerBuilderArgs =
        new EventHandlerBuilderArgs(
            serviceProvider
        );

    var eventHandlerBuilder =
        serviceProvider.GetRequiredService<IUserToUserChatMessageReadHandlerBuilder>();

    var eventHandler =
        eventHandlerBuilder
            .Build(
                eventHandlerBuilderArgs
            );

    await
        channelSubscribeService
            .Subscribe(
                channel,
                eventHandler
            );
}