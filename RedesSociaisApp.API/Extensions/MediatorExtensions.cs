using MediatR;
using OperationResult;

namespace RedesSociaisApp.API.Extensions;
public static class MediatorExtensions
{
	public static async Task<IResult> SendCommand<TResponse>(this IMediator mediator, IRequest<Result<TResponse>> request)
	{
		var result = await mediator.Send(request);

		if (!result.IsSuccess)
		{
			throw result.Exception;
		}

		return Results.Ok(result.Value);
	}
}
