using FraudDetection.ML.Service;
using FraudDetection.ML.Interfaces;
using Microsoft.AspNetCore.Builder;
using FraudDetection.ML.Training;

FraudTrainer.Train();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFraudPredictionService, FraudPredictionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();