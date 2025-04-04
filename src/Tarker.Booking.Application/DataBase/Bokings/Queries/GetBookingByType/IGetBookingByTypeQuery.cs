using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bokings.Queries.GetBookingByType
{
    public interface IGetBookingByTypeQuery
    {
        Task<List<GetBookingByTypeModel>> Execute(string type);
    }
}
