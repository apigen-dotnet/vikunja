using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for testing operations
/// </summary>
public partial interface ITestingClient
{
  /// <summary>
  /// Truncate all tables
  /// Operation: DELETE /test/all
  /// </summary>
  Task<JsonElement> TruncateAllTablesAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Reset the db to a defined state
  /// Operation: PATCH /test/{table}
  /// </summary>
  Task<List<User>> PatchAsync(string table, CancellationToken cancellationToken = default);

}
