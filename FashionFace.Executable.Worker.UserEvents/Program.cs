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
using FashionFace.Repositories.Context.Interfaces;
using FashionFace.Repositories.Context.Models.IdentityEntities;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Services.ConfigurationSettings.Models;

using Microsoft.AspNetCore.Identity;
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

serviceCollection
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDatabaseContext>()
    .AddRoles<ApplicationRole>();

serviceCollection.AddStackExchangeRedisCache(
    options =>
    {
        options.Configuration = redisSection["Configuration"];
        options.InstanceName = redisSection["InstanceName"];
    }
);

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

serviceCollection.SetupDependencies();

serviceCollection.AddScoped<UserToUserChatMessageSendOutboxPendingWorker,UserToUserChatMessageSendOutboxPendingWorker>();
serviceCollection.AddScoped<UserToUserChatMessageSendOutboxClaimedRetryWorker,UserToUserChatMessageSendOutboxClaimedRetryWorker>();
serviceCollection.AddScoped<UserToUserChatMessageReadOutboxPendingWorker,UserToUserChatMessageReadOutboxPendingWorker>();
serviceCollection.AddScoped<UserToUserChatMessageReadOutboxClaimedRetryWorker,UserToUserChatMessageReadOutboxClaimedRetryWorker>();
serviceCollection.AddScoped<UserToUserChatMessageSendNotificationOutboxPendingWorker,UserToUserChatMessageSendNotificationOutboxPendingWorker>();
serviceCollection.AddScoped<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker,UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker>();
serviceCollection.AddScoped<UserToUserChatMessageReadNotificationOutboxPendingWorker,UserToUserChatMessageReadNotificationOutboxPendingWorker>();
serviceCollection.AddScoped<UserToUserChatMessageReadNotificationOutboxClaimedRetryWorker,UserToUserChatMessageReadNotificationOutboxClaimedRetryWorker>();

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

var serviceProvider =
    host.Services;

var publishSubscribeChannelService =
    serviceProvider.GetRequiredService<IPublishSubscribeChannelService>();

var channelSubscribeService =
    serviceProvider.GetRequiredService<IChannelSubscribeService>();

var queueConnectionCreateDomainFacade =
    serviceProvider.GetRequiredService<IQueueConnectionCreateDomainFacade>();

var connection =
    await
        queueConnectionCreateDomainFacade.CreateAsync();

await
    Subscribe<IUserToUserChatInvitationAcceptedNotificationHandlerBuilder, UserToUserChatInvitationAcceptedOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatInvitationCanceledNotificationHandlerBuilder, UserToUserChatInvitationCanceledOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatInvitationCreatedNotificationHandlerBuilder, UserToUserChatInvitationCreatedOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatInvitationRejectedNotificationHandlerBuilder, UserToUserChatInvitationRejectedOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatMessageReadHandlerBuilder, UserToUserChatMessageReadOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatMessageReadNotificationHandlerBuilder, UserToUserChatMessageReadNotificationOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatMessageSendHandlerBuilder, UserToUserChatMessageSendOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

await
    Subscribe<IUserToUserChatMessageSendNotificationHandlerBuilder, UserToUserChatMessageSendNotificationOutbox>(
        publishSubscribeChannelService,
        connection,
        serviceProvider,
        channelSubscribeService
    );

host.Run();

return;

static async Task Subscribe<TService, TOutbox>(
    IPublishSubscribeChannelService publishSubscribeChannelService,
    IConnection connection,
    IServiceProvider serviceProvider,
    IChannelSubscribeService channelSubscribeService
)
    where TService : class, IHandlerBuilderBase
    where TOutbox : class, IOutbox
{
    var channel =
        await
            publishSubscribeChannelService
                .CreateDirect(
                    connection,
                    $"{typeof(TOutbox).FullName}.exchange",
                    $"{typeof(TOutbox).FullName}.queue"
                );

    var eventHandlerBuilderArgs =
        new EventHandlerBuilderArgs(
            serviceProvider
        );

    var eventHandlerBuilder =
        serviceProvider.GetRequiredService<TService>();

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