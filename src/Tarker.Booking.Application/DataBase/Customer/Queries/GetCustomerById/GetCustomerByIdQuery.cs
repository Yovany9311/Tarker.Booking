using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{

    public class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public GetCustomerByIdQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {
            var entity = await _databaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return _mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
