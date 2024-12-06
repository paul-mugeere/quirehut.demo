using System.Text.Json;
using System.Text.Json.Serialization;
using QuireHut.Demo.Api;
using QuireHut.Demo.Api.Configurations;
using QuireHut.Demo.Api.Extensions.IServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

var authOptions = builder.Configuration.GetSection(AuthenticationOptions.SectionName).Get<AuthenticationOptions>()?? 
    throw new InvalidOperationException("Authentication options not found in configs.");
builder.Services.AddJwtAuthentication(authOptions);
builder.Services.AddSwaggerDocs(authOptions);
builder.Services.AddAuthorizationServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddMediatR();
builder.Services.AddAutoMapperProfiles();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwaggerDocs();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
