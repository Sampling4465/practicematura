using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

public partial class Program { }