using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DocumentQuicker.Api.Interfaces;
using DocumentQuicker.Api.Models;
using FluentValidation.Results;

namespace DocumentQuicker.Api.Services
{
    public class ValidationDecorator : IValidationDecorator
    {
        private readonly ValidationDecoratorConfig _config;

        public ValidationDecorator(ValidationDecoratorConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
        }

        public async Task<ValidationResult> ValidateAsync<T>(T obj, CancellationToken cancellationToken = default(CancellationToken)) 
            where T : class
        {
            var validator = _config.FindValidator(obj);

            return await validator.ValidateAsync(obj, cancellationToken);
        }

        public async Task<(bool Result, IList<ValidationDetails> Errors)> ValidateAsyncEx<T>(T obj, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            var validator = _config.FindValidator(obj);
            
            var validationResult = await validator.ValidateAsync(obj, cancellationToken);
            if (validationResult.IsValid)
            {
                return (Result: true, Errors: new List<ValidationDetails>());
            }

            var validationErrors = validationResult.Errors.Select(x => new ValidationDetails()
            {
                AttemptedValue = x.AttemptedValue == null ? "null" : x.AttemptedValue.ToString(),
                ErrorMessage = x.ErrorMessage,
                PropertyName = x.PropertyName
            }).ToList();

            // ReSharper disable once RedundantExplicitTupleComponentName
            return (Result: true, Errors: validationErrors);
        }
    }
}