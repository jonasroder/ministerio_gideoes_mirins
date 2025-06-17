using Application.SharedKernel.Extensions;
using FiapTechChallenge.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Extensions;
using Infrastructure.SharedKernel.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsParaDesenvolvimento", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services
       .AddInfrastructure(builder.Configuration)
       .AddApplicationServices()
       .AddJwtAuthentication(builder.Configuration)
       .AddSwaggerWithJwt();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("CorsParaDesenvolvimento");
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Serve index.html automaticamente se existir
app.UseDefaultFiles();

// Serve os arquivos estáticos de wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();
