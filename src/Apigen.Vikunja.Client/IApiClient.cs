using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for api operations
/// </summary>
public interface IApiClient
{
  /// <summary>
  /// Get a list of all token api routes
  /// Operation: GET /routes
  /// </summary>
  Task<List<ApiTokenRoute>> GetAsync();

  /// <summary>
  /// Get all api tokens of the current user
  /// Operation: GET /tokens
  /// </summary>
  Task<List<ApiToken>> GetAsync(GetapiRequest? request = null);

  /// <summary>
  /// Create a new api token
  /// Operation: PUT /tokens
  /// </summary>
  Task<ApiToken> CreateApiTokenAsync(Apigen.Vikunja.Models.ApiToken apiToken);

  /// <summary>
  /// Deletes an existing api token
  /// Operation: DELETE /tokens/{tokenID}
  /// </summary>
  Task<Message> DeleteAsync(int tokenId);

}
