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
/// Client for assignees operations
/// </summary>
public class AssigneesClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal AssigneesClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all assignees for a task
  /// Operation: GET /tasks/{taskID}/assignees
  /// </summary>
  public async Task<List<User>> ListAsync(int taskId, GetassigneesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams, request);

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
    List<User>? result = JsonSerializer.Deserialize<List<User>>(responseContent, JsonConfig.Default);
    return result ?? new List<User>();
  }


  /// <summary>
  /// Add a new assignee to a task
  /// Operation: PUT /tasks/{taskID}/assignees
  /// </summary>
  public async Task<TaskAssignee> AddAssigneeAsync(int taskId, Apigen.Vikunja.Models.TaskAssignee taskAssignee)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(taskAssignee, JsonConfig.Default);
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
    TaskAssignee? result = JsonSerializer.Deserialize<TaskAssignee>(responseContent, JsonConfig.Default);
    return result ?? new TaskAssignee();
  }


  /// <summary>
  /// Add multiple new assignees to a task
  /// Operation: POST /tasks/{taskID}/assignees/bulk
  /// </summary>
  public async Task<TaskAssignee> AddMultipleAssigneesAsync(int taskId, Apigen.Vikunja.Models.BulkAssignees bulkAssignees)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees/bulk".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(bulkAssignees, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
    TaskAssignee? result = JsonSerializer.Deserialize<TaskAssignee>(responseContent, JsonConfig.Default);
    return result ?? new TaskAssignee();
  }


  /// <summary>
  /// Delete an assignee
  /// Operation: DELETE /tasks/{taskID}/assignees/{userID}
  /// </summary>
  public async Task<Message> DeleteAsync(int taskId, int userId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["userID"] = userId
    };
    string url = "tasks/{taskID}/assignees/{userID}".BuildUrl(pathParams);

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


}
