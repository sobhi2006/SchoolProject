using FluentValidation;
using MediatR;

namespace SchoolProject.Core.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
                                 where TRequest : IRequest<TResponse> 
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var ValidationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = ValidationResults.SelectMany(er => er.Errors).Where(er => er is not null).ToList();

            if(failures.Any())
            {
                var message = failures.Select(v => v.PropertyName + ": " + v.ErrorMessage).FirstOrDefault();
                throw new ValidationException(message);
            }
        }
        return await next(cancellationToken);
    }
}