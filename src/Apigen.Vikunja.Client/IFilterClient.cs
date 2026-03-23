using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for filter operations
/// </summary>
public interface IFilterClient
{
  /// <summary>
  /// Creates a new saved filter
  /// Operation: PUT /filters
  /// </summary>
  Task<SavedFilter> CreateFilterAsync();

  /// <summary>
  /// Gets one saved filter
  /// Operation: GET /filters/{id}
  /// </summary>
  Task<SavedFilter> GetAsync(int id);

  /// <summary>
  /// Updates a saved filter
  /// Operation: POST /filters/{id}
  /// </summary>
  Task<SavedFilter> UpdateFilterAsync(int id);

  /// <summary>
  /// Removes a saved filter
  /// Operation: DELETE /filters/{id}
  /// </summary>
  Task<SavedFilter> DeleteAsync(int id);

}
