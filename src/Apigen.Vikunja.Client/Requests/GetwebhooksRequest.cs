using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get all api webhook targets for the specified project
/// Operation: GET /projects/{id}/webhooks
/// </summary>
public class GetwebhooksRequest : BaseRequest
{
  /// <summary>
  /// The page number. Used for pagination. If not provided, the first page of results is returned.
  /// </summary>
  [JsonPropertyName("page")]
  public int? Page { get; set; }

  /// <summary>
  /// The maximum number of items per bucket per page. This parameter is limited by the configured maximum of items per page.
  /// </summary>
  [JsonPropertyName("per_page")]
  public int? PerPage { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;

    return queryParams.ToQueryString();
  }
}
