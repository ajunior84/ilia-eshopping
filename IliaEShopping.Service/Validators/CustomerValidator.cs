using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Service.Validators
{
    /// <summary>
    /// Customer entity validator
    /// </summary>
    public class CustomerValidator : AbstractValidator<Domain.Entities.Customer>
    {
        #region "  Constructors  "

        public CustomerValidator()
        {
            // Name validation
            RuleFor(p => p.Name)
                .MaximumLength(100)
                .NotEmpty()
                    .WithMessage(MessagesResource.CUSTOMER_NAME_REQUIRED)
                .NotNull()
                    .WithMessage(MessagesResource.CUSTOMER_NAME_REQUIRED);

            // E-mail validation
            RuleFor(p => p.Email)
                .MaximumLength(50)
                .NotEmpty()
                    .WithMessage(MessagesResource.CUSTOMER_EMAIL_REQUIRED)
                .NotNull()
                    .WithMessage(MessagesResource.CUSTOMER_EMAIL_REQUIRED)
                .EmailAddress()
                    .WithMessage(MessagesResource.CUSTOMER_EMAIL_INVALID);
        }

        #endregion
    }
}
