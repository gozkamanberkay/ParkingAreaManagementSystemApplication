using System.Net;
using Business.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters;

public class HttpStatusCodeAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult { Value: Result result } objectResult)
            objectResult.StatusCode = result.Status switch
            {
                ResultStatus.Ok => (int)HttpStatusCode.OK, // 200 OK
                ResultStatus.Error => (int)HttpStatusCode.BadRequest, // 400 Bad Request
                _ => (int)HttpStatusCode.InternalServerError // 500 Internal Server Error
            };
    }
}