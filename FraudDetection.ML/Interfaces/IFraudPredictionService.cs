using FraudDetection.ML.Models;

namespace FraudDetection.ML.Interfaces
{
    public interface IFraudPredictionService
    {
        FraudPrediction Predict(TransactionData transaction);
    }
}