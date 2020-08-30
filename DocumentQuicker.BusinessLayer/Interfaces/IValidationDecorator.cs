using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace DocumentQuicker.BusinessLayer.Interfaces
{
    public interface IValidationDecorator
    {
        Task<ValidationResult> ValidateAsync<T>(T obj, CancellationToken cancellationToken = default(CancellationToken))
            where T : class;
    }
}