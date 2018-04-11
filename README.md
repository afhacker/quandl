# quandl
A .Net library for interacting with Quandl API

## Introduction
It's a simple library just for returning the plain response of Quandl API calls, it doesn't deserialize the responses to any object it just returns the raw response text.
The library supports both time series and tables APIs of Quandl.

## Quick Start
Quandl has two types of API:

### Time-Series
To get a time series dataset from Quandl first create a TimeSeriesParameters:
```csharp
TimeSeriesParameters parameters = new TimeSeriesParameters()
{
    DatabaseCode = "WIKI",
    DatasetCode = "FB",
    ReturnFormat = ReturnFormat.JSON,
    Limit = 50
};
```
Then pass this object to Request class Execute or ExecuteAsync method with your API key:
```csharp
string result = Request.Execute(parameters, your_api_key);
// in case you want to execute the request asynchronously
string result = await Request.ExecuteAsync(parameters, your_api_key);
```
The TimeSeriesParameters class has all the time-series API parameters.

### Tables
Getting tables data is similar to time-series except here you create TablesParameters instead of TimeSeriesParameters:
```csharp
TablesParameters parameters = new TablesParameters()
{
    VendorCode = "ETFG",
    DatatableCode = "FUND",
    ReturnFormat = ReturnFormat.JSON,
};

string result = Request.Execute(parameters, your_api_key);
```

For more information please check the tester project.