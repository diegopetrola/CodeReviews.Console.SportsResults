using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

IHost host = builder.Build();

host.Run();
