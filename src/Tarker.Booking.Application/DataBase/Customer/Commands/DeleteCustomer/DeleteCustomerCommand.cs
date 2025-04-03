using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {

        private readonly IDataBaseService _databaseService;
    
        public DeleteCustomerCommand(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public async Task<bool> Execute(int customerId)
        {
            var entity = await _databaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (entity == null)
                return false;
            _databaseService.Customer.Remove(entity);
            return await _databaseService.SaveAsync();
        }            
    }
}
