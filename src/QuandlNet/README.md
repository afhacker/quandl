# QuandlNet
A .Net library for interacting with Quandl API

## Introduction
It's a simple lightweight library for getting data from Quandl API, the library supports both time series and tables APIs of Quandl.

The library uses JSON return type but you can set the return type to XML and then deserialize the response by your self.

All methods have both Async and non Async versions.

## Quick Start
First create a client class instance:

```csharp

using QuandlNet;
using QuandlNet.Enums;
using QuandlNet.Models;

BaseUrls baseUrls = new BaseUrls
{
	TimeSeriesUrl = "https://www.quandl.com/api/v3/datasets/",
	TablesUrl = "https://www.quandl.com/api/v3/datatables/"
};

Client client = new Client(baseUrls, your_api_key);

```

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

Then pass this object to Request, DownloadSeries, or GetDataSet methods of client:

```csharp

// The request method returns the raw response of API call without deserializing it to any object
// You can use this method in case you want to use the XML return type and derserialize it on your own classes
string result = await client.RequestAsync(parameters);

// This method downloads the time series data and returns the data in byte array, you can save the result on a file
byte[] data = await client.DownloadSeriesAsync(parameters, DownloadType.Full)

// This method derserialze the returned data into a DataSet object, the series data is stored on Data property of Dataset class
DataSet dataset = await client.GetDataSetAsync(parameters);

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

string result = await client.RequestAsync(parameters);

// The tables data is derserialized on a DataTable class object
DataTable dataset = await client.GetDataTableAsync(parameters);

```

For more information please check the tester project.