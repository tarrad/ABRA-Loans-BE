using ABRA_Loans.Engines;
using ABRA_Loans.Handlers;
using ABRA_Loans.Repositories;
using ABRA_Loans.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<LoanUnder20Engine>();
builder.Services.AddSingleton<LoanBetween20And35Engine>();
builder.Services.AddSingleton<LoanAbove35Engine>();
builder.Services.AddSingleton<IClientRepository, ClientRepositoryMock>();
builder.Services.AddSingleton<LoanHandler>();
builder.Services.AddSingleton<LoanCalculationService>();

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  
              .AllowAnyHeader()                    
              .AllowAnyMethod()                    
              .AllowCredentials();                 
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("AllowLocalhost");
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
