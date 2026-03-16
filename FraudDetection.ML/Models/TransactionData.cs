using Microsoft.ML.Data;

namespace FraudDetection.ML.Models
{
    public class TransactionData
    {
        [LoadColumn(0)]
        public float Amount { get; set; }

        [LoadColumn(1)]
        public float Hour { get; set; }

        [LoadColumn(2)]
        public float Country { get; set; }

        [LoadColumn(3)]
        public bool Label { get; set; }
    }
}