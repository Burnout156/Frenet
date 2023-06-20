using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FrenetCalculate.Controllers;
using FrenetCalculate.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the IHttpClientFactory service.
builder.Services.AddHttpClient();

// Configure the DbContext with the appropriate connection string.
builder.Services.AddDbContext<FreightQuoteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FreightQuoteDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Frenet}/{action=Index}/{id?}");

app.Run();
