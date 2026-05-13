using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for api operations
/// </summary>
public partial interface IApiClient
{
  /// <summary>
  /// Get a list of all token api routes
  /// Operation: GET /routes
  /// </summary>
  Task<List<ApiTokenRoute>> GetAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all api tokens of the current user
  /// Operation: GET /tokens
  /// </summary>
  Task<List<ApiToken>> GetAsync(GetapiRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new api token
  /// Operation: PUT /tokens
  /// </summary>
  Task<ApiToken> CreateApiTokenAsync(Apigen.Vikunja.Models.ApiToken apiToken, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes an existing api token
  /// Operation: DELETE /tokens/{tokenID}
  /// </summary>
  Task<Message> DeleteAsync(int tokenId, CancellationToken cancellationToken = default);

}
