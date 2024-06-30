using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CompanyEmployees.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILogger logger)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    ErrorDetails errorDetails = new();

                    switch (contextFeature.Error)
                    {
                        case NotFoundException:
                            errorDetails.Message = contextFeature.Error.Message;
                            errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                            break;

                        default:
                            errorDetails.StatusCode = (int)(HttpStatusCode.InternalServerError);
                            errorDetails.Message = "Internal Server Error";
                            break;
                    }

                    context.Response.StatusCode = errorDetails.StatusCode;
                    await context.Response.WriteAsync(errorDetails.ToString());
                }
            });
        });
    }
}
