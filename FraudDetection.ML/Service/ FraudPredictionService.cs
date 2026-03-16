using Microsoft.ML;
using FraudDetection.ML.Models;
using FraudDetection.ML.Interfaces;

namespace FraudDetection.ML.Service
{
    public class FraudPredictionService : IFraudPredictionService
    {
        private readonly PredictionEngine<TransactionData, FraudPrediction> _engine;

        public FraudPredictionService()
        {
            var mlContext = new MLContext();

            var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModel", "fraudModel.zip");

            var model = mlContext.Model.Load(modelPath, out var schema);

            _engine = mlContext.Model.CreatePredictionEngine<TransactionData, FraudPrediction>(model);
        }

        public FraudPrediction Predict(TransactionData data)
        {
            return _engine.Predict(data);
        }
    }
}