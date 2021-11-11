using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Service.Validators
{
    public class OrderValidator : AbstractValidator<Domain.Entities.Order>
    {
        #region "  Constructor  "

        public OrderValidator()
        {
            // Price validation
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0.01)
                .NotEmpty()
                .NotNull();

            // CustomerId validation
            RuleFor(p => p.CustomerId)
                .GreaterThanOrEqualTo(1)
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
