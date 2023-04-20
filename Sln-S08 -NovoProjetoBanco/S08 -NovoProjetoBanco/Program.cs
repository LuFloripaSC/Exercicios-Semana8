using S08__NovoProjetoBanco.Interfaces;
using S08__NovoProjetoBanco.Services;


var builder = WebApplication.CreateBuilder();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteServices, ClientesServices>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();