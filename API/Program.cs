
using Business.Abstract;
using Business.Concrete;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<AstralContext>();
builder.Services.AddTransient<IUserInterface,UserManager>();

builder.Services.AddCors();
var app = builder.Build();



// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.MapControllers();

app.Run();
