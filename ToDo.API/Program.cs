using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
// builder.Services.AddDbContext<ToDoDataContext>(options => options.UseInMemoryDatabase("ToDo"));
builder.Services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionString")));

// Inject Handlers
builder.Services.AddTransient<ToDoItemHandler>();

// Inject Repositories
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.Authority = "https://securetoken.google.com/todo-90757";
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = "https://securetoken.google.com/todo-90757",
						ValidateAudience = true,
						ValidAudience = "todo-90757",
						ValidateLifetime = true
					};
				});

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