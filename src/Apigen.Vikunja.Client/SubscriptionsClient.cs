using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Client for subscriptions operations
/// </summary>
public partial class SubscriptionsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal SubscriptionsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all notifications for the current user
  /// Operation: GET /notifications
  /// </summary>
  public async Task<List<DatabaseNotification>> GetsubscriptionsAsync(GetsubscriptionsRequest? request = null)
  {
    string url = "notifications".BuildUrl(request: request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<DatabaseNotification>? result = JsonSerializer.Deserialize<List<DatabaseNotification>>(responseContent, JsonConfig.Default);
    return result ?? new List<DatabaseNotification>();
  }


  /// <summary>
  /// Mark a notification as (un-)read
  /// Operation: POST /notifications/{id}
  /// </summary>
  public async Task<DatabaseNotifications> MarkNotificationReadAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "notifications/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    DatabaseNotifications? result = JsonSerializer.Deserialize<DatabaseNotifications>(responseContent, JsonConfig.Default);
    return result ?? new DatabaseNotifications();
  }


  /// <summary>
  /// Subscribes the current user to an entity.
  /// Operation: PUT /subscriptions/{entity}/{entityID}
  /// </summary>
  public async Task<Subscription> SubscribeAsync(string entity, string entityId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["entity"] = entity,
      ["entityID"] = entityId
    };
    string url = "subscriptions/{entity}/{entityID}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    Subscription? result = JsonSerializer.Deserialize<Subscription>(responseContent, JsonConfig.Default);
    return result ?? new Subscription();
  }


  /// <summary>
  /// Unsubscribe the current user from an entity.
  /// Operation: DELETE /subscriptions/{entity}/{entityID}
  /// </summary>
  public async Task<Subscription> DeleteAsync(string entity, string entityId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["entity"] = entity,
      ["entityID"] = entityId
    };
    string url = "subscriptions/{entity}/{entityID}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    Subscription? result = JsonSerializer.Deserialize<Subscription>(responseContent, JsonConfig.Default);
    return result ?? new Subscription();
  }


}
