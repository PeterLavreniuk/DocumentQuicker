using DocumentQuicker.Api.Models.Dto;
using FluentValidation;

namespace DocumentQuicker.Api.Validator
{
    public class ShortBankDtoValidator : AbstractValidator<ShortBankDto>
    {
        public ShortBankDtoValidator()
        {
            RuleFor(x => x.Bic)
                .Length(5, 100)
                .WithMessage("Bic length must be at least 5 and no more than 100 characters! ");
            RuleFor(x => x.Description)
                .Length(10, 200)
                .WithMessage("Description length must be at least 10 and no more than 100 characters! ");;
            RuleFor(x => x.CorrAccount)
                .Length(10, 200)
                .WithMessage("CorrAccount length must be at least 10 and no more than 100 characters! ");;
        }
    }
}