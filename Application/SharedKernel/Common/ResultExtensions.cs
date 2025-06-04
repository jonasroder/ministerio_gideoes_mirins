using Application.SharedKernel.Common;
using Microsoft.AspNetCore.Mvc;

namespace Application.SharedKernel.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        var response = new
        {
            success = result.IsSuccess,
            data = result.IsSuccess ? result.Data : default,
            message = result.Message,
            errorCode = result.ErrorCode
        };

        if (result.IsSuccess)
            return new OkObjectResult(response);

        return result.ErrorCode switch
        {
            "NOT_FOUND" => new NotFoundObjectResult(response),
            "UNAUTHORIZED" => new UnauthorizedObjectResult(response),
            "FORBIDDEN" => new ObjectResult(response) { StatusCode = 403 },
            "CONFLICT" => new ConflictObjectResult(response),
            "UNPROCESSABLE_ENTITY" => new ObjectResult(response) { StatusCode = 422 },
            "INTERNAL_SERVER_ERROR" => new ObjectResult(response) { StatusCode = 500 },
            _ => new BadRequestObjectResult(response)
        };
    }

}
