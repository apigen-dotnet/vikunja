using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for webhooks operations
/// </summary>
public interface IWebhooksClient
{
  /// <summary>
  /// Get all api webhook targets for the specified project
  /// Operation: GET /projects/{id}/webhooks
  /// </summary>
  Task<List<Webhook>> ListAsync(int id, GetwebhooksRequest? request = null);

  /// <summary>
  /// Create a webhook target
  /// Operation: PUT /projects/{id}/webhooks
  /// </summary>
  Task<Webhook> CreateWebhookAsync(int id, Apigen.Vikunja.Models.Webhook webhook);

  /// <summary>
  /// Change a webhook target&apos;s events.
  /// Operation: POST /projects/{id}/webhooks/{webhookID}
  /// </summary>
  Task<Webhook> UpdateWebhookAsync(int id, int webhookId);

  /// <summary>
  /// Deletes an existing webhook target
  /// Operation: DELETE /projects/{id}/webhooks/{webhookID}
  /// </summary>
  Task<Message> DeleteAsync(int id, int webhookId);

  /// <summary>
  /// Get all possible webhook events
  /// Operation: GET /webhooks/events
  /// </summary>
  Task<JsonElement> GetwebhooksAsync();

}
