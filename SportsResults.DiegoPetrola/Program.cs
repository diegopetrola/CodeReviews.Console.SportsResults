using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsResults.DiegoPetrola.Models;
using SportsResults.DiegoPetrola.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.Configure<MailOptions>(builder.Configuration.GetSection(nameof(MailOptions)));
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddScoped<WebScraperService>();
builder.Services.AddHostedService<DailyService>();

IHost host = builder.Build();

host.Run();
