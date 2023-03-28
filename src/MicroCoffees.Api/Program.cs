using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Endpoints;
using MicroCoffees.Api.Infrastructure.Persistence;
using MicroCoffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new ArgumentException("Could not configure database connection.");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>())
	.AddScoped<IUnitOfWork, CoffeeContext>()
	.AddDbContext<CoffeeContext>(
		options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGroup("/api/bikes/")
   .MediatePost<AddRequest>()
   .MediateGet<GetAllRequest>("page={page:int?}?count={count:int?}")
   .MediateGet<GetCoffeeRequest>("{id:guid}")
   .MediatePut<ServeRequest>("{id:guid}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
