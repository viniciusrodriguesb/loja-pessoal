using Infrastructure.CrossCutting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddHttpContextAccessor();

//Add Cache
builder.Services.AddMemoryCache();

//Add Services
builder.Services.AddServices(builder.Configuration);

//Add controladores
builder.Services.AddControllers();

//Add Autentica��o
builder.Services.AddServiceAuthentication(builder.Configuration);

//Add Swagger
builder.Services.AddSwaggerConfiguration();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger Documenta��o Web API",
        Description = "Documenta��o referente a aplica��o de Gerenciamento de Empresas e Servi�os.",
        Contact = new OpenApiContact() { Name = "Vinicius Bastos", Email = "viniciusrbastos@hotmail.com" }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();