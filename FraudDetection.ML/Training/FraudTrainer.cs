using Microsoft.ML;
using FraudDetection.ML.Models;

namespace FraudDetection.ML.Training
{
    public class FraudTrainer
    {
        public static void Train()
        {
            var mlContext = new MLContext();

            var data = mlContext.Data.LoadFromTextFile<TransactionData>(
                "Data/fraud_data.csv",
                hasHeader: true,
                separatorChar: ',');

            var pipeline = mlContext.Transforms.Concatenate(
                    "Features",
                    nameof(TransactionData.Amount),
                    nameof(TransactionData.Hour),
                    nameof(TransactionData.Country))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            var model = pipeline.Fit(data);

            var modelDirectory = Path.Combine(AppContext.BaseDirectory, "MLModel");
            Directory.CreateDirectory(modelDirectory);

            var modelPath = Path.Combine(modelDirectory, "fraudModel.zip");

            mlContext.Model.Save(model, data.Schema, modelPath);

            var split = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

            var model = pipeline.Fit(split.TrainSet);

            var predictions = model.Transform(split.TestSet);

            var metrics = mlContext.BinaryClassification.Evaluate(predictions);

            Console.WriteLine($"Accuracy: {metrics.Accuracy}");
            Console.WriteLine($"AUC: {metrics.AreaUnderRocCurve}");
            Console.WriteLine($"F1 Score: {metrics.F1Score}");
        }
    }
}