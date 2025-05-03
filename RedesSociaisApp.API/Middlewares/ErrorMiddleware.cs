using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RedesSociaisApp.Application.Exceptions;

namespace RedesSociaisApp.API.Middlewares;
public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (ValidationException ex)
		{
			var errors = ex.Errors
				.GroupBy(e => e.PropertyName)
				.ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

			await WriteProblemDetails(context, StatusCodes.Status400BadRequest, "Erro de validação", errors);
		}
		
		catch (Exception ex)
		{
            _logger.LogError(ex, "Ocorreu um erro inesperado: {Message}", ex.Message);
			await WriteProblemDetails(context, StatusCodes.Status500InternalServerError, "Erro interno do servidor", "Ocorreu um erro inesperado. Tente novamente mais tarde!");
		}
	}

	private static async Task WriteProblemDetails(HttpContext context, int statusCode, string title, object details)
	{
		context.Response.StatusCode = statusCode;

		var problem = new ProblemDetails
		{
			Title = title,
			Status = statusCode,
			Detail = details is string str ? str : null,
			Extensions = { ["errors"] = details is string ? null : details }
		};

		await context.Response.WriteAsJsonAsync(problem);
	}
}
