using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CrossCuttingConcerns.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            var failures = validators.Run(context).ToList();

            //TODO Probably a better way to set this up, should homogenize all exception messaging response formats
            var message = string.Join(",", failures.Select(o => o.ErrorMessage));

            if (failures.Count != 0)
            {
                throw new BadRequestException(message);
            }

            return next();
        }
    }

    public static class ValidatorExtensions
    {
        public static IEnumerable<ValidationFailure> Run<TRequest>(this IEnumerable<IValidator<TRequest>> validators,
            ValidationContext context)
        {
            return validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null);
        }
    }
}
