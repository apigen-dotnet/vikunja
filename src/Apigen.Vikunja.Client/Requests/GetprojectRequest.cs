using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get all projects a user has access to
/// Operation: GET /projects
/// </summary>
public class GetprojectRequest : BaseRequest
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
  /// Search projects by title.
  /// </summary>
  [JsonPropertyName("s")]
  public string? S { get; set; }

  /// <summary>
  /// If true, also returns all archived projects.
  /// </summary>
  [JsonPropertyName("is_archived")]
  public bool? IsArchived { get; set; }

  /// <summary>
  /// If set to `permissions`, Vikunja will return the max permission the current user has on this project. You can currently only set this to `permissions`.
  /// </summary>
  [JsonPropertyName("expand")]
  public string? Expand { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;
    if (S != null)
      queryParams["s"] = S;
    if (IsArchived != null)
      queryParams["is_archived"] = IsArchived;
    if (Expand != null)
      queryParams["expand"] = Expand;

    return queryParams.ToQueryString();
  }
}
