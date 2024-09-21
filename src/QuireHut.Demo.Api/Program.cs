using QuireHut.Demo.Api;
using QuireHut.Demo.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwaggerDocs();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
