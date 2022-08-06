using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SettingsDemo.Data;
using SettingsDemo.Options;

var builder = WebApplication.CreateBuilder(args);

// builder.Host.ConfigureAppConfiguration((context, config) =>
// {
//     config.AddJsonFile("custom.json", optional: true, reloadOnChange: true);
//     config.AddXmlFile("custom.xml", optional: true, reloadOnChange: true);
//     config.AddIniFile("custom.ini", optional: true, reloadOnChange: true);
// });

//builder.Services.Configure<EmailSettingsOptions>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddOptions<EmailSettingsOptions>().BindConfiguration("EmailSettings");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();