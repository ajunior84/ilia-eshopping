using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Service.Validators
{
    public class OrderStatusValidator : AbstractValidator<Domain.Entities.OrderStatus>
    {
        #region "  Constructors  "

        public OrderStatusValidator()
        {

        }

        #endregion
    }
}
