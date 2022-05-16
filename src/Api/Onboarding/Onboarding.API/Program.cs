using Onboarding.API.Middlewares;
using Onboarding.Application.Bootstrap;
using Onboarding.Persistence.Bootstrap;
using Onboarding.Persistence.TestData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOnboardingApplication();
builder.Services.AddOnboardingPersistance();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.SeedTestData();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<DomainExceptionErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
