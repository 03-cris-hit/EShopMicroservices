using Ordering.API;
using Ordering.Application;
using Ordering.Infranstructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationService()
    .AddInfrastructureService(builder.Configuration)
    .AddApiService();

var app = builder.Build();



app.Run();
