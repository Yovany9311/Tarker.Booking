using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bokings.Queries.GetBookingByType
{
    public class GetBookingByTypeQuery: IGetBookingByTypeQuery
    {
        //INVOCAR  AL SERVICIO DE BASE DE DATOS 
        private readonly IDataBaseService _dataBaseService;
        //CREAR CONSTRUCTOR Y PASAR SERVICIO DE BASE DE DATOS 
        public GetBookingByTypeQuery(IDataBaseService dataBaseService)
        {
            //INYECCION DE DEPENDENCIA 
            _dataBaseService = dataBaseService;
        }
        //CREAR METODO 
        //Método asíncrono que obtiene todas las reservas con la información del cliente.
        // Usa LINQ para hacer una consulta con JOIN entre Booking y Customer.
        // Devuelve una lista de GetBookingByDocumentNumberModel.
        public async Task<List<GetBookingByTypeModel>> Execute(string type)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where booking.Type == type
                                select new GetBookingByTypeModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber
                                }).ToListAsync();
            return result;
        }
    }
}