using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

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

app.Run();

