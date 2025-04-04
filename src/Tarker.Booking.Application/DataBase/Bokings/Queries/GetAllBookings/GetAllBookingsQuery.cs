using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tarker.Booking.Application.Database;

namespace Tarker.Booking.Application.DataBase.Bokings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery: IGetAllBookingsQuery
    {   //INVOCAR  AL SERVICIO DE BASE DE DATOS 
        private readonly IDataBaseService _databaseService;
        //CREAR CONSTRUCTOR Y PASAR SERVICIO DE BASE DE DATOS 
        public GetAllBookingsQuery(IDataBaseService databaseService)
        {
            //INYECCION DE DEPENDENCIA 
            _databaseService = databaseService;
        }
        //CREAR METODO 
        //Método asíncrono que obtiene todas las reservas con la información del cliente.
        // Usa LINQ para hacer una consulta con JOIN entre Booking y Customer.
        // Devuelve una lista de GetAllBookingsModel, conteniendo datos de la reserva y del cliente asociado.
        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from booking in _databaseService.Booking
                                join customer in _databaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingsModel
                                {
                                    BookingId = booking.BookingId,
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
