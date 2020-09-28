using System;
using System.Net;
using System.Threading.Tasks;
using Battleships.Application.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Battleships.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {

            var code = HttpStatusCode.InternalServerError;

            switch (context.Exception)
            {
                case AlreadyFiredCoordinateException _:
                    code = HttpStatusCode.BadRequest;
                    break;

            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new { message = context.Exception.Message });
            return base.OnExceptionAsync(context);
        }
    }
}
