using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.Database;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery: IGetCustomerByDocumentNumberQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;
        public GetCustomerByDocumentNumberQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<GetAllCustomersModel> Execute(string documentNumber)
        {
            var entity = await _databaseService.Customer.FirstOrDefaultAsync(x=> x.DocumentNumber == documentNumber);
            return _mapper.Map<GetAllCustomersModel>(entity);

        }
    } 
}
