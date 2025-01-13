using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PoliclinicaHope.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<PoliclinicaHopeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PoliclinicaHopeContext") ?? throw new InvalidOperationException("Connection string 'PoliclinicaHopeContext' not found.")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
