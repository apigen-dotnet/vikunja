using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for subscriptions operations
/// </summary>
public interface ISubscriptionsClient
{
  /// <summary>
  /// Get all notifications for the current user
  /// Operation: GET /notifications
  /// </summary>
  Task<List<DatabaseNotification>> GetsubscriptionsAsync(GetsubscriptionsRequest? request = null);

  /// <summary>
  /// Mark a notification as (un-)read
  /// Operation: POST /notifications/{id}
  /// </summary>
  Task<DatabaseNotifications> MarkNotificationReadAsync(int id);

  /// <summary>
  /// Subscribes the current user to an entity.
  /// Operation: PUT /subscriptions/{entity}/{entityID}
  /// </summary>
  Task<Subscription> SubscribeAsync(string entity, string entityID);

  /// <summary>
  /// Unsubscribe the current user from an entity.
  /// Operation: DELETE /subscriptions/{entity}/{entityID}
  /// </summary>
  Task<Subscription> DeleteAsync(string entity, string entityID);

}
