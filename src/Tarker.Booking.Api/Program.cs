using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;
using Tarker.Booking.Persistence.DataBase;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// variable para la conexion de base de datos 
//var connetionString = builder.Configuration.GetConnectionString("Connection");
//registrar servicio para la conexion 
//builder.Services.AddDbContext<DataBaseService>(options => options.UseSqlServer(connetionString));

//builder.Services.AddScoped<IDataBaseService, DataBaseService>();
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapPost("/testService", async (IGetCustomerByDocumentNumberQuery service) =>
{
  
    return await service.Execute("9696666");
});

app.Run();

                                                                                                     