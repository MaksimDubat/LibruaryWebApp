using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibruaryAPI.WebAPI.ExceptionFilter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode;
            string errorMessage;

            switch (context.Exception)
            {
                case ArgumentException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = context.Exception.Message;
                    break;
                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errorMessage = "not found";
                    break;
                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessage = "Access is denied";
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = "unexpected error";
                    break;
            }
            context.Result = new JsonResult(new { StatusCode = statusCode, Error = errorMessage })
            {
                StatusCode = statusCode
            };
            context.ExceptionHandled = true;
        }

    }
}

