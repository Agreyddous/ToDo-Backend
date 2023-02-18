using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using ToDo.Domain.Handlers;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Infra.Repositories;
using ToDo.Domain.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.Authority = $"https://securetoken.google.com/{builder.Configuration["Firebase:Project"]}";
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = $"https://securetoken.google.com/{builder.Configuration["Firebase:Project"]}",
						ValidateAudience = true,
						ValidAudience = $"{builder.Configuration["Firebase:Project"]}",
						ValidateLifetime = true
					};
				});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Google", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.OAuth2,
		Flows = new OpenApiOAuthFlows()
		{
			Implicit = new OpenApiOAuthFlow()
			{
				AuthorizationUrl = new Uri(builder.Configuration["Firebase:AuthorizationUrl"]!),
				TokenUrl = new Uri(builder.Configuration["Firebase:TokenUrl"]!),
				Scopes = new Dictionary<string, string> { { "openid", "User Profile" } }
			}
		},
		Extensions = new Dictionary<string, IOpenApiExtension>
		{
			{"x-tokenName", new OpenApiString("id_token")}
		}

	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Google"
				},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string> {"email", "profile"}
		}
	});
});

// Inject Entity Framework Data Contexts
// builder.Services.AddDbContext<ToDoDataContext>(options => options.UseInMemoryDatabase("ToDo"));
builder.Services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionString")));

// Inject Handlers
builder.Services.AddTransient<ToDoItemHandler>();

// Inject Repositories
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
	app.UseSwagger().UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("swagger/v1/swagger.json", "To-Do Backend");
		options.RoutePrefix = string.Empty;

		options.OAuthClientId(builder.Configuration["Firebase:OAuthClientId"]);
	});

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin()
										  .AllowAnyMethod()
										  .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();