using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Request parameters for Get one attachment.
/// Operation: GET /tasks/{id}/attachments/{attachmentID}
/// </summary>
public partial class GetTaskAttachmentRequest : BaseRequest
{
  /// <summary>
  /// The size of the preview image. Can be sm = 100px, md = 200px, lg = 400px or xl = 800px. If provided, a preview image will be returned if the attachment is an image.
  /// </summary>
  [JsonPropertyName("preview_size")]
  public string? PreviewSize { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (PreviewSize != null)
      queryParams["preview_size"] = PreviewSize;

    return queryParams.ToQueryString();
  }
}
