using MicroCoffees.Api.Application.Mapping;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Endpoints;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("Default")
	?? throw new ArgumentException("Could not configure database connection.");

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddAutoMapper(typeof(CoffeeProfile).Assembly)
	.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());

builder.Services
	.AddScoped<IUnitOfWork, CoffeeContext>()
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
   .MediatePost<AddRequest>()
   .MediateGet<GetAllRequest>("page/{page:int?}/count/{count:int?}")
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
