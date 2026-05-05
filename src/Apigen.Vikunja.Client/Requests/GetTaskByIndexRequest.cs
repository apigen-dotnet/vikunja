using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get one task by its per-project index
/// Operation: GET /projects/{project}/tasks/by-index/{index}
/// </summary>
public partial class GetTaskByIndexRequest : BaseRequest
{
  /// <summary>
  /// If set to `subtasks`, Vikunja will fetch only tasks which do not have subtasks and then in a second step, will fetch all of these subtasks. This may result in more tasks than the pagination limit being returned, but all subtasks will be present in the response. You can only set this to `subtasks`.
  /// </summary>
  [JsonPropertyName("expand")]
  public string? Expand { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Expand != null)
      queryParams["expand"] = Expand;

    return queryParams.ToQueryString();
  }
}
