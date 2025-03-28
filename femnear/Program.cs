using femnear;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<femContext>(options =>
    options.UseSqlServer("Data Source=SLCB22-0014;Initial Catalog=SchoolDB;Integrated Security=True;Encrypt=False"));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});



var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();



app.UseCors("AllowAllOrigins");

app.MapGet("/", () => "Hello World!");
app.Run(); 