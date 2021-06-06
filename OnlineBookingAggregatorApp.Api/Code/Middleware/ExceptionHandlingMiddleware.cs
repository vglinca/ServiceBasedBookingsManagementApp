using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineBookingAggregatorApp.Core.Exceptions;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next.Invoke(ctx);
            }
            catch (EntityNotFoundException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.NotFound);
            }
            catch (BadRequestException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.BadRequest);
            }
            catch (InfrastructureArgumentNullException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.BadRequest);
            }
            catch (InfrastructureInvalidOperationException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.BadRequest);
            }
            catch (UnauthorizedException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.Unauthorized);
            }
            catch (OperationCanceledException e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, ctx, HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(Exception ex, HttpContext ctx, HttpStatusCode statusCode)
        {
            var response = ctx.Response;
            response.ContentType = AppConstants.TextMessages.ErrorMessageContentType;
            response.StatusCode = (int) statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                StatusCode = (int) statusCode,
                Error = ex.Message
            }));
        }
    }
}