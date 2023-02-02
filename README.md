# MongoWrapper

Basic MongoDB wrapper to allow a reusable instance of a Mongo DB instance with CRUD control.

## Installation

There are two required settings that must be made available through app settings. Those settings are as follows:

```json

{
  "MongoWrapper": {
    "ConnectionString": "MongoDB Connection String",
    "DatabaseName": "Target Database Name"
  }
}

```

## Usage

To initialise the connection to the datase, the method `AddMongoWrapper` should be called passing in an `IConfiguration` instance that contains the above configuration settings.

I.e. `.AddMongoWrapper(_configuration);`

To then utilise the connection provided, ensure the interface `IDatabaseService` is injected wherever it needs to be utilised. This can then be referenced to complete basic CRUD operations on the database for a given target collection.

I.e. 
```c#
  private readonly IDatabaseService _databaseService;

  public MyRepository (IDatabaseService databaseService) {
    _databaseService = databaseService;
  }

  public Task<List<Entity>> MyMethod =>
    _databaseService.ReadEntities<Entity>("MyCollectionName");
  
```
