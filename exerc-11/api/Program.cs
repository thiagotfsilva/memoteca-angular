using System.Data;
using Api.Infra.Interfaces;
using Api.Infra.Repositories;
using Api.Service;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

#region  Dapper
builder.Services.AddScoped<IDbConnection>(provider => 
{
    SqlConnection connection = new(connectionString);
    connection.Open();
    return connection;
});
#endregion


builder.Services.AddScoped<IQuoteRepository, QuoteRepositoy>();
builder.Services.AddScoped<IQuoteServices, QuoteService>();

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
