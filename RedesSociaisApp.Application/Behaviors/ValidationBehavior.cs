using System.Reflection;
using FluentValidation;
using MediatR;
using OperationResult;
using RedesSociaisApp.Application.Exceptions;
using RedesSociaisApp.Application.Validators;

namespace RedesSociaisApp.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(next);

        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

            var failures = validationResults
                .Where(r => r.Errors.Count > 0)
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Count > 0)
                throw new FluentValidation.ValidationException(failures);
        }
        return await next().ConfigureAwait(false);
    }
}

// public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : IValidatable, IRequest<TResponse>
// {
//     private readonly AbstractValidator<TRequest> _validator;
//     private readonly MethodInfo? _resultError;
//     private readonly Type _type = typeof(TResponse);

//     public ValidationPipelineBehavior(AbstractValidator<TRequest> validator)
//     {
//         _validator = validator;
//         _resultError = ResultUtils.GetGenericError(_type);
//     }

//     public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//     {
//         FluentValidation.Results.ValidationResult validationResult;

//         validationResult = _validator.Validate(request);
//         if (validationResult.IsValid)
//             return next.Invoke();
        
//         var validationError = new ModeloInvalidoException(validationResult.Errors.GroupBy(v => v.PropertyName, v => v.ErrorMessage).ToDictionary(v => v.Key, v => v.Select(y => y)));

//         return _type == ResultUtils.TypeResult || _resultError is null
//             ? Task.FromResult((TResponse)Convert.ChangeType(Result.Error(validationError), _type))
//             : Task.FromResult((TResponse)Convert.ChangeType(_resultError.Invoke(null, new object[] { validationError }), _type)!);
//     }
// }