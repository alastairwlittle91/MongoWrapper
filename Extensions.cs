using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MongoWrapper;

public static class Extensions
{
  public static IServiceCollection AddMongoWrapper(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetSection("MongoWrapper:ConnectionString").Value ?? string.Empty;
    var databaseName = configuration.GetSection("MongoWrapper:DatabaseName").Value ?? string.Empty;

    services.AddTransient<IDatabaseWrapper>(o =>
    {
      return new DatabaseWrapper(connectionString, databaseName);
    });
    services.AddTransient<IDatabaseService, DatabaseService>();

    return services;
  }
}