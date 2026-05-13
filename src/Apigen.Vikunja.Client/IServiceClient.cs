using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for service operations
/// </summary>
public partial interface IServiceClient
{
  /// <summary>
  /// Info
  /// Operation: GET /info
  /// </summary>
  Task<VikunjaInfos> GetAsync(CancellationToken cancellationToken = default);

}
