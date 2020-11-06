using AspectCore.DynamicProxy;
using GameCom.Common.Resources;
using GameCom.Model.Exceptions;
using GameCom.Repository.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GameCom.Api.Application
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }            
            catch (InvalidVersionException ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleInvalidVersionExceptionAsync(httpContext, ex);
            }
            catch (ModelException ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleModelExceptionAsync(httpContext, ex);
            }
            catch (RepositoryException ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleRepositoryExceptionAsync(httpContext, ex);
            }
            catch (AspectInvocationException ex) when (ex.InnerException is StaleObjectStateException)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleInvalidVersionExceptionAsync(httpContext, new InvalidVersionException(Mensajes._2));
            }
            catch (AspectInvocationException ex) when (ex.InnerException is ModelException)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleModelExceptionAsync(httpContext, new ModelException(ex.InnerException.Message));
            }
            catch (AspectInvocationException ex) when (ex.InnerException is RepositoryException)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleRepositoryExceptionAsync(httpContext, new RepositoryException(ex.InnerException.Message));
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleInvalidVersionExceptionAsync(HttpContext context, InvalidVersionException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToJson());
        }

        private static Task HandleModelExceptionAsync(HttpContext context, ModelException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToJson());
        }

        private static Task HandleRepositoryExceptionAsync(HttpContext context, RepositoryException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToJson());
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error"
                }.ToJson());
        }
    }
}
