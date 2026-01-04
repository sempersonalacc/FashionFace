using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FashionFace.Common.Constants.Constants;
using FashionFace.Common.Exceptions.Model;
using FashionFace.Dependencies.Serialization.Interfaces;
using FashionFace.Dependencies.SignalR.Interfaces;
using FashionFace.Dependencies.SignalR.Models;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FashionFace.Dependencies.SignalR.Implementations;

public sealed class HubExceptionsFilter(
    ILogger<HubExceptionsFilter> logger,
    ISerializationDecorator serializationDecorator
) : IHubFilterBase
{
    public async ValueTask<object?> InvokeMethodAsync(
        HubInvocationContext invocationContext,
        Func<HubInvocationContext, ValueTask<object?>> next
    )
    {
        try
        {
            return
                await
                    next(
                        invocationContext
                    );
        }
        catch (Exception exception)
        {
            var traceId =
                Guid
                    .NewGuid()
                    .ToString();

            var errorData =
                GetErrorData(
                    invocationContext,
                    traceId
                );

            logger
                .LogError(
                    "An error occured in hub.\nData : {errorData}",
                    errorData
                );

            var errorContainer =
                    GetErrorsContainer(
                        exception,
                        traceId
                    );

            var errorMessage =
                serializationDecorator
                    .Serialize(
                        errorContainer
                    );
            throw
                new HubException(
                    errorMessage
                );
        }
    }

    private static ErrorsContainerResponse GetErrorsContainer(
        Exception exception,
        string traceId
    )
    {
        var error =
            GetError(
                exception
            );

        return
            new(
                traceId,
                error
            );
    }

    private static ErrorResponse GetError(
        Exception exception
    )
    {
        switch (exception)
        {
            case BusinessLogicException logicException:
            {
                var errorResponse =
                    new ErrorResponse(
                        logicException.Code,
                        logicException.Data
                    );

                return
                    errorResponse;
            }
            default:
            {
                var data =
                    new Dictionary<string, object>();

                var error =
                    new ErrorResponse(
                        ErrorCodeConstants.ServerError,
                        data
                    );

                return
                    error;
            }
        }
    }

    private static Dictionary<string, object> GetErrorData(
        HubInvocationContext context,
        string traceId
    )
    {
        var method =
            context.HubMethodName;

        var args =
            context.HubMethodArguments;

        var userIdentifier =
            context
                .Context
                .UserIdentifier!;

        return
            new()
            {
                {
                    "TraceId", traceId
                },
                {
                    "UserIdentifier", userIdentifier
                },
                {
                    "MethodName", method
                },
                {
                    "MethodArgs", args
                },
            };
    }
}