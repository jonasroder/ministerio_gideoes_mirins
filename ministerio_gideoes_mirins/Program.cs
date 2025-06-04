using Application.SharedKernel.Extensions;
using FiapTechChallenge.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
       .AddInfrastructure(builder.Configuration)
       .AddApplicationServices()
       .AddJwtAuthentication(builder.Configuration)
       .AddSwaggerWithJwt();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
