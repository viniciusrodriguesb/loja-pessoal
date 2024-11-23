using Infrastructure.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Configuração do logging
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

//Add Autenticação
builder.Services.AddServiceAuthentication(builder.Configuration);

//Add Swagger
builder.Services.AddSwaggerConfiguration();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
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