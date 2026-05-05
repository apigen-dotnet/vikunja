using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Search for a background from unsplash
/// Operation: GET /backgrounds/unsplash/search
/// </summary>
public partial class SearchUnsplashBackgroundsRequest : BaseRequest
{
  /// <summary>
  /// Search backgrounds from unsplash with this search term.
  /// </summary>
  [JsonPropertyName("s")]
  public string? S { get; set; }

  /// <summary>
  /// The page number. Used for pagination. If not provided, the first page of results is returned.
  /// </summary>
  [JsonPropertyName("p")]
  public int? P { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (S != null)
      queryParams["s"] = S;
    if (P != null)
      queryParams["p"] = P;

    return queryParams.ToQueryString();
  }
}
