
using System.Security.Principal;
using System.Text;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//service extend ettik
builder.Services.AddApplicationServivces(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
//authorization mapcontrollden önce corstan sonra gelmelidir. Ve Aauthentication önce olmalıdır
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
