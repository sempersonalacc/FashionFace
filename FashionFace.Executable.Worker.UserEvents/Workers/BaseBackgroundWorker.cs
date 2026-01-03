using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FashionFace.Executable.Worker.UserEvents.Workers;

public abstract class BaseBackgroundWorker<TWorker>(
    ILogger<TWorker> logger
) : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken cancellationToken
    )
    {
        var workerName =
            typeof(TWorker).Name;

        logger
            .LogInformation(
                $"{workerName} started"
            );

        while (!cancellationToken.IsCancellationRequested)
        {
            logger
                .LogInformation(
                    $"{workerName} cycle started"
                );

            try
            {
                await
                    DoWorkAsync(
                        cancellationToken
                    );
            }
            catch (Exception exception)
            {
                logger
                    .LogError(
                    exception,
                    $"{workerName} encountered an error during cycle"
                );
            }

            logger
                .LogInformation(
                    $"{workerName} cycle ended"
                );

            var jitter =
                GetJitter();

            var totalDelay =
                GetDelay() + jitter;

            await
                Task
                    .Delay(
                        totalDelay,
                        cancellationToken
                    );
        }

        logger
            .LogInformation(
                $"{workerName} stopped"
            );
    }

    private static TimeSpan GetJitter()
    {
        var random =
            new Random();

        var milliseconds =
            random
                .Next(
                    0,
                    500
                );

        var timeSpan =
            TimeSpan
                .FromMilliseconds(
                    milliseconds
                );

        return
            timeSpan;
    }

    protected abstract Task DoWorkAsync(CancellationToken cancellationToken);

    protected abstract TimeSpan GetDelay();
}