using DocumentQuicker.Api.Models;
using FluentValidation;

namespace DocumentQuicker.Api.Validators
{
    public sealed class ShortBankInfoDtoValidator : AbstractValidator<ShortBankInfoDto>
    {
        public ShortBankInfoDtoValidator()
        {
            RuleFor(x => x.Description).Length(6, 200);
            RuleFor(x => x.CorrAccount).Length(6, 200);
            RuleFor(x => x.Bic).Length(6, 200);
        }
    }
}