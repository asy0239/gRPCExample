using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using WorkerService;
using WorkerService.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddGrpc();
builder.Services.AddMediatR();
builder.Services.AddMapper();
builder.Services.AddRepositories();
builder.Services.AddQueue();
builder.Services.AddHostedService<Worker>();
builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddControllers();
app.UseAuthentication();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();


//var host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((hostContext, services) =>
//    {
//        services.AddGrpc();
//        services.AddMediatR();
//        services.AddMapper();
//        services.AddHostedService<Worker>();
//        services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();
//    }).Build();

//host.Run();

public partial class Program { }
