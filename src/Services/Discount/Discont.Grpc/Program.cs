
using Discont.Grpc.Data;
using Discont.Grpc.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// gRPC + Reflection
builder.Services.AddGrpc();

builder.Services.AddGrpcReflection();
builder.Services.AddDbContext<DiscountContext>(opts => {
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database"));
});


builder.WebHost.ConfigureKestrel(o =>
{
    o.ListenAnyIP(5052, lo => { lo.UseHttps(); lo.Protocols = HttpProtocols.Http2; });
    // opcional, gRPC sin TLS (h2c)
    // o.ListenAnyIP(5002, lo => { lo.Protocols = HttpProtocols.Http2; });
});

var app = builder.Build();
app.UseMigration();
app.MapGrpcService<DiscountService>();

app.MapGrpcReflectionService();


app.MapGet("/", () => "gRPC up");
app.Run();
