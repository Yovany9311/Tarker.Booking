﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.DataBase.Bokings.Commands.CreateBooking
{
    public class CreateBookingComman: ICreateBookingComman
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public CreateBookingComman(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        { 
            var entity = _mapper.Map<BookingEntity>(model);
            await _databaseService.Booking.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
