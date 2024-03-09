using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = "Data Source=.\\..\\..\\RoomData.db";
builder.Services.AddDbContext<RoomCt>(options => options.UseSqlite(connectionString));

//TODO: Services im DI-Container resgistrieren

var app = builder.Build();



// ====================================================================
// Create DB Code First ===============================================
DbContextOptions options = new DbContextOptionsBuilder()
.UseSqlite(connectionString)
.Options;
RoomCt db = new RoomCt(options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();
// Create DB Code First ===============================================
// ====================================================================



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program { }