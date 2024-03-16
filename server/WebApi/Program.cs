using WebApi;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Create Logger from settings from appsettings.json
//var logger = new LoggerConfiguration()
//.ReadFrom.Configuration(builder.Configuration)
//.CreateLogger();

////Add Logger
//Log.Logger = logger;
//builder.Host.UseSerilog ( logger );

builder.Services.AddControllers ();

builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen ();

builder.Services.AddInfrastructure ( builder.Configuration );
var app = builder.Build();

if ( app.Environment.IsDevelopment () ) {
    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseHttpsRedirection ();

//Use Logger after any custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

//Use Serilog
// app.UseSerilogRequestLogging ();

app.UseAuthorization ();

app.MapControllers ();

app.Run ();
