
using AutoMapper;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery: IGetAllCustomersQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public GetAllCustomersQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<List<GetAllCustomersModel>> Execute()
        {
            var listEntity =  await _databaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomersModel>>(listEntity);
            
        }
    }
}
