using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DocumentQuicker.Api.Models;
using FluentValidation.Results;

namespace DocumentQuicker.Api.Interfaces
{
    public interface IValidationDecorator
    {
        Task<ValidationResult> ValidateAsync<T>(T obj, CancellationToken cancellationToken = default(CancellationToken))
            where T : class;

        Task<(bool Result, IList<ValidationDetails> Errors)> ValidateAsyncEx<T>(T obj,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : class;
    }
}