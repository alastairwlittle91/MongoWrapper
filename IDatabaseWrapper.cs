using MongoDB.Driver;

namespace MongoWrapper;
  public interface IDatabaseWrapper 
  {
      ///<summary>
      /// This method retrieves the client used to initialise the DB connection.
      ///<summary>
      IMongoClient RetrieveClient();
      ///<summary>
      /// This method initialises a collection of given entity type T
      /// <param name="collectionName">The name of the collection of entity type T</param>
      ///<summary>
      IMongoCollection<T> InitialiseCollection<T>(string collectionName);
  }