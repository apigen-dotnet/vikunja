using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get users
/// Operation: GET /users
/// </summary>
public partial class GetuserRequest : BaseRequest
{
  /// <summary>
  /// The search criteria.
  /// </summary>
  [JsonPropertyName("s")]
  public string? S { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (S != null)
      queryParams["s"] = S;

    return queryParams.ToQueryString();
  }
}
