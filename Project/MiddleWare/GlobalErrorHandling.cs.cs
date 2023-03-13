using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Project.MiddleWare
{
    public class GlobalErrorHandling : IMiddleware
    {
        private readonly ILogger _logger;
        public GlobalErrorHandling(ILogger loger)
        {
            this._logger = loger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails prob = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "sever error",
                    Title = "server error",
                    Detail = "an internal server error"




                };
                string json = JsonSerializer.Serialize(prob);
                await context.Response.WriteAsync(json);
                context.Response.ContentType = ("application/json");
            }


        }
    }
    }
