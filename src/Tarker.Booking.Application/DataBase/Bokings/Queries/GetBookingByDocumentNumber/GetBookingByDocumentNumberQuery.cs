using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Bokings.Queries.GetAllBookings;
using Tarker.Booking.Application.Database;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Bokings.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberQuery: IGetBookingByDocumentNumberQuery
    {
        //INVOCAR  AL SERVICIO DE BASE DE DATOS 
        private readonly IDataBaseService _databaseService;
        //CREAR CONSTRUCTOR Y PASAR SERVICIO DE BASE DE DATOS 
        public GetBookingByDocumentNumberQuery(IDataBaseService databaseService)
        {
            //INYECCION DE DEPENDENCIA 
            _databaseService = databaseService;
        }
        //CREAR METODO 
        //Método asíncrono que obtiene todas las reservas con la información del cliente.
        // Usa LINQ para hacer una consulta con JOIN entre Booking y Customer.
        // Devuelve una lista de GetBookingByDocumentNumberModel.
        public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _databaseService.Booking
                                join customer in _databaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == documentNumber
                                select new GetBookingByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type
                                }).ToListAsync();
            return result;
        }
    }
}
