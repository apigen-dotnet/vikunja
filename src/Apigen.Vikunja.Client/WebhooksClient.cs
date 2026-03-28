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
/// Client for webhooks operations
/// </summary>
public class WebhooksClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal WebhooksClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all api webhook targets for the specified project
  /// Operation: GET /projects/{id}/webhooks
  /// </summary>
  public async Task<List<Webhook>> ListAsync(int id, GetwebhooksRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "projects/{id}/webhooks".BuildUrl(pathParams, request);

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
    List<Webhook>? result = JsonSerializer.Deserialize<List<Webhook>>(responseContent, JsonConfig.Default);
    return result ?? new List<Webhook>();
  }


  /// <summary>
  /// Create a webhook target
  /// Operation: PUT /projects/{id}/webhooks
  /// </summary>
  public async Task<Webhook> CreateWebhookAsync(int id, Apigen.Vikunja.Models.Webhook webhook)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "projects/{id}/webhooks".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(webhook, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
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
    Webhook? result = JsonSerializer.Deserialize<Webhook>(responseContent, JsonConfig.Default);
    return result ?? new Webhook();
  }


  /// <summary>
  /// Change a webhook target&apos;s events.
  /// Operation: POST /projects/{id}/webhooks/{webhookID}
  /// </summary>
  public async Task<Webhook> UpdateWebhookAsync(int id, int webhookId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["webhookID"] = webhookId
    };
    string url = "projects/{id}/webhooks/{webhookID}".BuildUrl(pathParams);

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
    Webhook? result = JsonSerializer.Deserialize<Webhook>(responseContent, JsonConfig.Default);
    return result ?? new Webhook();
  }


  /// <summary>
  /// Deletes an existing webhook target
  /// Operation: DELETE /projects/{id}/webhooks/{webhookID}
  /// </summary>
  public async Task<Message> DeleteAsync(int id, int webhookId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["webhookID"] = webhookId
    };
    string url = "projects/{id}/webhooks/{webhookID}".BuildUrl(pathParams);

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
    Message? result = JsonSerializer.Deserialize<Message>(responseContent, JsonConfig.Default);
    return result ?? new Message();
  }


  /// <summary>
  /// Get all possible webhook events
  /// Operation: GET /webhooks/events
  /// </summary>
  public async Task<JsonElement> GetwebhooksAsync()
  {
    string url = "webhooks/events";

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


}
