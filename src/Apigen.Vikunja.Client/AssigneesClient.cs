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
  public async Task<List<User>> ListAsync(int taskID, GetassigneesRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskID
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    List<User>? result = JsonSerializer.Deserialize<List<User>>(responseContent, JsonConfig.Default);
    return result ?? new List<User>();
  }


  /// <summary>
  /// Add a new assignee to a task
  /// Operation: PUT /tasks/{taskID}/assignees
  /// </summary>
  public async Task<TaskAssginee> AddAssigneeAsync(int taskID, Apigen.Vikunja.Models.TaskAssginee taskAssginee)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskID
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(taskAssginee, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "PUT", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    TaskAssginee? result = JsonSerializer.Deserialize<TaskAssginee>(responseContent, JsonConfig.Default);
    return result ?? new TaskAssginee();
  }


  /// <summary>
  /// Add multiple new assignees to a task
  /// Operation: POST /tasks/{taskID}/assignees/bulk
  /// </summary>
  public async Task<TaskAssginee> AddMultipleAssigneesAsync(int taskID, Apigen.Vikunja.Models.BulkAssignees bulkAssignees)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskID
    };
    string url = "tasks/{taskID}/assignees/bulk".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(bulkAssignees, JsonConfig.Default);
    HttpClientLog.RequestBody(_logger, "POST", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    TaskAssginee? result = JsonSerializer.Deserialize<TaskAssginee>(responseContent, JsonConfig.Default);
    return result ?? new TaskAssginee();
  }


  /// <summary>
  /// Delete an assignee
  /// Operation: DELETE /tasks/{taskID}/assignees/{userID}
  /// </summary>
  public async Task<Message> DeleteAsync(int taskID, int userID)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskID,
      ["userID"] = userID
    };
    string url = "tasks/{taskID}/assignees/{userID}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.RequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.RequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.RequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }

    HttpClientLog.ResponseBody(_logger, url, responseContent);
    Message? result = JsonSerializer.Deserialize<Message>(responseContent, JsonConfig.Default);
    return result ?? new Message();
  }


}
