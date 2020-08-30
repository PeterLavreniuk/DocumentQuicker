using System;
using System.Threading;
using System.Threading.Tasks;
using DocumentQuicker.BusinessLayer.Interfaces;
using FluentValidation.Results;

namespace DocumentQuicker.BusinessLayer.Services
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
    }
}