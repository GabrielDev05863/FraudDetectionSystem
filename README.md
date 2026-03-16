\# Fraud Detection System



A fraud detection API for financial transactions built with Machine Learning.



This project was developed using \*\*C#\*\*, \*\*ASP.NET Core\*\*, and \*\*ML.NET\*\* to demonstrate how a machine learning model can be integrated into a REST API to detect potentially fraudulent transactions.



\## Technologies



\* C#

\* .NET 9

\* ASP.NET Core Web API

\* ML.NET

\* Swagger / OpenAPI



\## Project Architecture



The system is divided into two main projects:



\*\*FraudDetection.API\*\*



Responsible for exposing the REST API that receives transaction data and returns fraud predictions.



\*\*FraudDetection.ML\*\*



Responsible for training the machine learning model and performing predictions.



\## Project Structure



FraudDetectionSystem

│

├── FraudDetection.API

│   ├── Controllers

│   │   └── FraudController.cs

│   ├── Program.cs

│   └── MLModel

│       └── fraudModel.zip

│

└── FraudDetection.ML

├── Models

│   ├── TransactionData.cs

│   └── FraudPrediction.cs

├── Interfaces

│   └── IFraudPredictionService.cs

├── Services

│   └── FraudPredictionService.cs

├── Training

│   └── FraudTrainer.cs

└── Data

└── fraud\_data.csv



\## How to Run the Project



1\. Clone the repository



git clone https://github.com/GabrielDev05863/fraud-detection-system.git



2\. Navigate to the project folder



cd FraudDetectionSystem



3\. Restore dependencies



dotnet restore



4\. Run the API



dotnet run --project FraudDetection.API



\## Testing the API



After running the project, Swagger will be available at:



\[https://localhost:xxxx/swagger](https://localhost:xxxx/swagger)



Main endpoint:



POST /api/fraud/predict



Example request:



{

"amount": 3500,

"hour": 2,

"country": 3

}



Example response:



{

"isFraud": true,

"probability": 0.82,

"score": 1.54

}



\## Features



\* Machine learning model training

\* Fraud prediction for transactions

\* REST API for external integrations

\* Automatic API documentation with Swagger



\## Future Improvements



\* Integration with real-world fraud datasets

\* Fraud monitoring dashboard

\* Cloud deployment (Azure or AWS)

\* Docker containerization



\## Author



Gabriel Alves



