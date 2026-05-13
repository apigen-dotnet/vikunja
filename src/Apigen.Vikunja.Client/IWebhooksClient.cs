using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for webhooks operations
/// </summary>
public partial interface IWebhooksClient
{
  /// <summary>
  /// Get all api webhook targets for the specified project
  /// Operation: GET /projects/{id}/webhooks
  /// </summary>
  Task<List<Webhook>> ListAsync(int id, GetwebhooksRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a webhook target
  /// Operation: PUT /projects/{id}/webhooks
  /// </summary>
  Task<Webhook> CreateProjectWebhookAsync(int id, Apigen.Vikunja.Models.Webhook webhook, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change a webhook target&apos;s events.
  /// Operation: POST /projects/{id}/webhooks/{webhookID}
  /// </summary>
  Task<Webhook> UpdateProjectWebhookAsync(int id, int webhookId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes an existing webhook target
  /// Operation: DELETE /projects/{id}/webhooks/{webhookID}
  /// </summary>
  Task<Message> DeleteAsync(int id, int webhookId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all user-level webhook targets
  /// Operation: GET /user/settings/webhooks
  /// </summary>
  Task<List<Webhook>> GetUserWebhooksAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a user-level webhook target
  /// Operation: PUT /user/settings/webhooks
  /// </summary>
  Task<Webhook> CreateUserWebhookAsync(Apigen.Vikunja.Models.Webhook webhook, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get available user-directed webhook events
  /// Operation: GET /user/settings/webhooks/events
  /// </summary>
  Task<JsonElement> GetUserWebhookEventsAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a user-level webhook target
  /// Operation: POST /user/settings/webhooks/{id}
  /// </summary>
  Task<Webhook> UpdateUserWebhookAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a user-level webhook target
  /// Operation: DELETE /user/settings/webhooks/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all possible webhook events
  /// Operation: GET /webhooks/events
  /// </summary>
  Task<JsonElement> GetWebhookEventsAsync(CancellationToken cancellationToken = default);

}
