using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controller
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]

    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
      public async Task<IActionResult>Create(
        [FromBody] CreateCustomerModel model,
        [FromServices] ICreateCustomerCommand createCustomerCommand)
        {
            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(
        [FromBody] UpdateCustomerModel model,
        [FromServices] IUpdateCustomerCommand updateCustomerCommand)
        {
            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
       [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            if(customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            var data = await deleteCustomerCommand.Execute(customerId);
            if (!data)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
       [FromServices] IGetAllCustomersQuery getAllCustomersQuery)
        {
            var data = await getAllCustomersQuery.Execute();
            if (data.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
