using MongoDB.Driver;

namespace MongoWrapper;
public interface IDatabaseService
{
  ///<summary>
  /// This method creates a given entity of type T in the target collection.
  /// <param name="entity">The entity which is going to be created</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task CreateEntity<T>(T entity, string collectionName);
  ///<summary>
  /// This method creates a given list of entity of type T in the target collection.
  /// <param name="entities">The list of entities which are going to be created</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task CreateEntities<T>(List<T> entities, string collectionName);
  ///<summary>
  /// This method updates a single entity matching the given filter with the target update definition.
  /// <param name="filter">The filter that determines the entities that should be updated</param>
  /// <param name="update">The updated that determines how the entities should be updated</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task UpdateEntity<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, string collectionName);
  ///<summary>
  /// This method updates entities matching the given filter with the target update definition.
  /// <param name="filter">The filter that determines the entities that should be updated</param>
  /// <param name="update">The updated that determines how the entities should be updated</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task UpdateEntities<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, string collectionName);
  ///<summary>
  /// This method reads a single entity matching the given filter.
  /// <param name="filter">The filter that determines the entities that should be read</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task<T> ReadEntity<T>(FilterDefinition<T> filter, string collectionName);
  ///<summary>
  /// This method reads multiple entities in the collection type T.
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task<List<T>> ReadEntities<T>(string collectionName);
  ///<summary>
  /// This method reads multiple entities in the collection type T matching the given filter.
  /// <param name="filter">The filter that determines the entities that should be read</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task<List<T>> ReadEntities<T>(Func<T, bool> filter, string collectionName);
  ///<summary>
  /// This method deletes a single entity matching the given filter.
  /// <param name="filter">The filter that determines the entity that should be deleted</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task DeleteEntity<T>(FilterDefinition<T> filter, string collectionName);
  ///<summary>
  /// This method deletes multiple entities matching the given filter.
  /// <param name="filter">The filter that determines the entities that should be deleted</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task DeleteEntities<T>(FilterDefinition<T> filter, string collectionName);
  ///<summary>
  /// This method reads multiple entities in the collection type T matching the given filter.
  /// <param name="filter">The filter that determines the entities that should be read</param>
  /// <param name="collectionName">The name of the collection of entity type T</param>
  ///<summary>
  Task<List<T>> ReadEntities<T>(FilterDefinition<T> filter, string collectionName);
}