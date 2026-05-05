using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get all task comments
/// Operation: GET /tasks/{taskID}/comments
/// </summary>
public partial class GetTaskCommentsRequest : BaseRequest
{
  /// <summary>
  /// Sort order. Can be &apos;asc&apos; for ascending or &apos;desc&apos; for descending. Defaults to &apos;asc&apos;.
  /// </summary>
  [JsonPropertyName("order_by")]
  public string? OrderBy { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (OrderBy != null)
      queryParams["order_by"] = OrderBy;

    return queryParams.ToQueryString();
  }
}
