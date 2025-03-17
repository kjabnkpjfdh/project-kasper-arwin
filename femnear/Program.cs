using femnear;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);









builder.Services.AddDbContext<femContext>(options =>

options.UseSqlServer("Server=SLCB22-0014;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false"));

builder.Services.AddControllers();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();


app.UseCors("AllowAllOrigins");




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/", () => "Hello World!");


app.Run();