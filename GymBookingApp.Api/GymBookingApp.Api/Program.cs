using GymBookingApp.Api.Repositories;
using GymBookingApp.Api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPricingService, PricingService>();

builder.Services.AddSingleton<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }


