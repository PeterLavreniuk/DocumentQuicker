using System;
using System.Collections.Generic;
using System.Linq;
using DocumentQuicker.Api.Models;
using FluentValidation.Results;

namespace DocumentQuicker.Api.Extensions
{
    public static class ValidationResultEx
    {
        public static IList<ValidationDetails> GetValidationDetails(this ValidationResult validationResult)
        {
            if (validationResult == null)
                throw new NullReferenceException(nameof(validationResult));
            
            return validationResult.Errors.Select(x => new ValidationDetails()
            {
                AttemptedValue = x.AttemptedValue == null ? "null" : x.AttemptedValue.ToString(),
                ErrorMessage = x.ErrorMessage,
                PropertyName = x.PropertyName
            }).ToList();
        }
    }
}