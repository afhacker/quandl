# EasyQuandl
This library uses the Quandl library and it makes the usage of Quandl API very easy by deserializing the responses to DataSet and DataTable classes.

## Introduction
All API calls return type is JSON and it then deserializes the returned data to either DataSet or DataTable classes. 

## Quick Start
First of all, add this two namespaces:

```csharp
using Quandl;
using EasyQuandl;
```

Getting a dataset:

```csharp
TimeSeriesParameters parameters = new TimeSeriesParameters()
{
    DatabaseCode = "WIKI",
    DatasetCode = "FB",
    Limit = 50
};

DataSet dataSet = await Client.GetDataSetAsync(parameters, your_api_key);
```

You don't have to set the return type parameter.

Getting a data table:

```csharp
TablesParameters parameters = new TablesParameters()
{
    VendorCode = "ETFG",
    DatatableCode = "FUND",
    PerPage = 10
};

DataTable dataTable = await Client.GetDataTableAsync(parameters, your_api_key);
```

Then use the DataSet and DataTable "Data" property to access the data.

To get metadata use the client class "Get*MetaData" methods.