using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Handlers;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Infra.Repositories;
using ToDo.Domain.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Entity Framework Data Contexts
builder.Services.AddDbContext<ToDoDataContext>(options => options.UseInMemoryDatabase("ToDo"));
// builder.Services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("toDoConnectionString")));

// Inject Handlers
builder.Services.AddTransient<ToDoItemHandler>();

// Inject Repositories
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin()
										  .AllowAnyMethod()
										  .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();