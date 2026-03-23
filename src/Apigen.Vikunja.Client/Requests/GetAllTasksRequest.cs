using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get tasks
/// Operation: GET /tasks/all
/// </summary>
public class GetAllTasksRequest : BaseRequest
{
  /// <summary>
  /// The page number. Used for pagination. If not provided, the first page of results is returned.
  /// </summary>
  [JsonPropertyName("page")]
  public int? Page { get; set; }

  /// <summary>
  /// The maximum number of items per page. Note this parameter is limited by the configured maximum of items per page.
  /// </summary>
  [JsonPropertyName("per_page")]
  public int? PerPage { get; set; }

  /// <summary>
  /// Search tasks by task text.
  /// </summary>
  [JsonPropertyName("s")]
  public string? S { get; set; }

  /// <summary>
  /// The sorting parameter. You can pass this multiple times to get the tasks ordered by multiple different parametes, along with `order_by`. Possible values to sort by are `id`, `title`, `description`, `done`, `done_at`, `due_date`, `created_by_id`, `project_id`, `repeat_after`, `priority`, `start_date`, `end_date`, `hex_color`, `percent_done`, `uid`, `created`, `updated`. Default is `id`.
  /// </summary>
  [JsonPropertyName("sort_by")]
  public string? SortBy { get; set; }

  /// <summary>
  /// The ordering parameter. Possible values to order by are `asc` or `desc`. Default is `asc`.
  /// </summary>
  [JsonPropertyName("order_by")]
  public string? OrderBy { get; set; }

  /// <summary>
  /// The filter query to match tasks by. Check out https://vikunja.io/docs/filters for a full explanation of the feature.
  /// </summary>
  [JsonPropertyName("filter")]
  public string? Filter { get; set; }

  /// <summary>
  /// The time zone which should be used for date match (statements like 
  /// </summary>
  [JsonPropertyName("filter_timezone")]
  public string? FilterTimezone { get; set; }

  /// <summary>
  /// If set to true the result will include filtered fields whose value is set to `null`. Available values are `true` or `false`. Defaults to `false`.
  /// </summary>
  [JsonPropertyName("filter_include_nulls")]
  public string? FilterIncludeNulls { get; set; }

  /// <summary>
  /// If set to `subtasks`, Vikunja will fetch only tasks which do not have subtasks and then in a second step, will fetch all of these subtasks. This may result in more tasks than the pagination limit being returned, but all subtasks will be present in the response. If set to `buckets`, the buckets of each task will be present in the response. If set to `reactions`, the reactions of each task will be present in the response. If set to `comments`, the first 50 comments of each task will be present in the response. You can set this multiple times with different values.
  /// </summary>
  [JsonPropertyName("expand")]
  public string[]? Expand { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (S != null)
      queryParams["s"] = S;
    if (SortBy != null)
      queryParams["sort_by"] = SortBy;
    if (OrderBy != null)
      queryParams["order_by"] = OrderBy;
    if (Filter != null)
      queryParams["filter"] = Filter;
    if (FilterTimezone != null)
      queryParams["filter_timezone"] = FilterTimezone;
    if (FilterIncludeNulls != null)
      queryParams["filter_include_nulls"] = FilterIncludeNulls;
    if (Expand != null)
      queryParams["expand"] = Expand;

    return queryParams.ToQueryString();
  }
}
