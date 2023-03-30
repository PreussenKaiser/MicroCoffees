using MicroCoffees.Api.Application.Mapping;
using MicroCoffees.Api.Endpoints;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Api.Infrastructure.Repositories;
using MicroCoffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("Default")
	?? throw new ArgumentException("Could not configure database connection.");

builder.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen();

builder.Services
	.AddAutoMapper(typeof(CoffeeProfile).Assembly)
	.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());

builder.Services
	.AddScoped<IUnitOfWork, CoffeeContext>()
	.AddScoped<ICoffeeRepository, CoffeeRepository>()
	.AddDbContext<CoffeeContext>(
		options => options.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<CoffeeContext>();

	if (context.Database.GetPendingMigrations().Any())
	{
		context.Database.Migrate();
	}
}

app.MapGroup("/api/coffees/")
   .MapCoffees();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger()
	   .UseSwaggerUI();
}

app.Run();
