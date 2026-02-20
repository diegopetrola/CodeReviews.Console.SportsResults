using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsResults.DiegoPetrola.Models;
using SportsResults.DiegoPetrola.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.Configure<MailOptions>(builder.Configuration.GetSection(nameof(MailOptions)));
builder.Services.AddTransient<WebScraperService>();
builder.Services.AddTransient<MailService>();
builder.Services.AddHostedService<DailyService>();

IHost host = builder.Build();

host.Run();
