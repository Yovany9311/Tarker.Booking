﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bokings.Commands.CreateBooking
{
    public interface ICreateBookingComman
    {
        Task<CreateBookingModel> Execute(CreateBookingModel model);
    }
}
