﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator: AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        { //reglas 
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
        }
    }
}
