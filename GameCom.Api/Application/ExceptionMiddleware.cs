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

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
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
                await HandleInvalidVersionExceptionAsync(httpContext, ex);
            }
            catch (ModelException ex)
            {
                await HandleModelExceptionAsync(httpContext, ex);
            }
            catch (RepositoryException ex)
            {
                await HandleRepositoryExceptionAsync(httpContext, ex);
            }
            catch (AspectInvocationException ex) when (ex.InnerException is StaleObjectStateException)
            {
                await HandleInvalidVersionExceptionAsync(httpContext, new InvalidVersionException(Mensajes._2));
            }
            catch (AspectInvocationException ex) when (ex.InnerException is ModelException)
            {
                await HandleModelExceptionAsync(httpContext, new ModelException(ex.InnerException.Message));
            }
            catch (AspectInvocationException ex) when (ex.InnerException is RepositoryException)
            {
                await HandleRepositoryExceptionAsync(httpContext, new RepositoryException(ex.InnerException.Message));
            }
            catch (Exception ex)
            {
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
