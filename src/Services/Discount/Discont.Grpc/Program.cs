
using Discont.Grpc.Data;
using Discont.Grpc.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// gRPC + Reflection
builder.Services.AddGrpc();

builder.Services.AddDbContext<DiscountContext>(opts => {
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));
});

var app = builder.Build();
app.UseMigration();
app.MapGrpcService<DiscountService>();



app.MapGet("/", () => "gRPC up");
app.Run();
