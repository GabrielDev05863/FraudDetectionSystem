using Microsoft.AspNetCore.Mvc;
using FraudDetection.ML.Models;
using FraudDetection.ML.Interfaces;
using FraudDetection.ML.Training;

namespace FraudDetection.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudPredictionService _service;

        public FraudController(IFraudPredictionService service)
        {
            _service = service;
        }

        [HttpPost("predict")]
        public IActionResult Predict([FromBody] TransactionData transaction)
        {
            var result = _service.Predict(transaction);

            return Ok(result);
        }

        [HttpPost("retrain")]
        public IActionResult Retrain()
        {
            FraudTrainer.Train();
            return Ok("Model retrained successfully.");
        }

   
}