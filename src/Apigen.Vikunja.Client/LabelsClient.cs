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
/// Client for labels operations
/// </summary>
public partial class LabelsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal LabelsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all labels a user has access to
  /// Operation: GET /labels
  /// </summary>
  public async Task<List<Label>> ListAsync(GetlabelsRequest? request = null)
  {
    string url = "labels".BuildUrl(request: request);

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
    List<Label>? result = JsonSerializer.Deserialize<List<Label>>(responseContent, JsonConfig.Default);
    return result ?? new List<Label>();
  }


  /// <summary>
  /// Create a label
  /// Operation: PUT /labels
  /// </summary>
  public async Task<Label> CreateLabelAsync(Apigen.Vikunja.Models.Label label)
  {
    string url = "labels";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(label, JsonConfig.Default);
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
    Label? result = JsonSerializer.Deserialize<Label>(responseContent, JsonConfig.Default);
    return result ?? new Label();
  }


  /// <summary>
  /// Gets one label
  /// Operation: GET /labels/{id}
  /// </summary>
  public async Task<Label> GetAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "labels/{id}".BuildUrl(pathParams);

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
    Label? result = JsonSerializer.Deserialize<Label>(responseContent, JsonConfig.Default);
    return result ?? new Label();
  }


  /// <summary>
  /// Update a label
  /// Operation: PUT /labels/{id}
  /// </summary>
  public async Task<Label> UpdateLabelAsync(int id, Apigen.Vikunja.Models.Label label)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "labels/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(label, JsonConfig.Default);
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
    Label? result = JsonSerializer.Deserialize<Label>(responseContent, JsonConfig.Default);
    return result ?? new Label();
  }


  /// <summary>
  /// Delete a label
  /// Operation: DELETE /labels/{id}
  /// </summary>
  public async Task<Label> DeleteAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "labels/{id}".BuildUrl(pathParams);

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
    Label? result = JsonSerializer.Deserialize<Label>(responseContent, JsonConfig.Default);
    return result ?? new Label();
  }


  /// <summary>
  /// Update all labels on a task.
  /// Operation: POST /tasks/{taskID}/labels/bulk
  /// </summary>
  public async Task<LabelTaskBulk> BulkAsync(int taskId, Apigen.Vikunja.Models.LabelTaskBulk labelTaskBulk)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/labels/bulk".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(labelTaskBulk, JsonConfig.Default);
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
    LabelTaskBulk? result = JsonSerializer.Deserialize<LabelTaskBulk>(responseContent, JsonConfig.Default);
    return result ?? new LabelTaskBulk();
  }


  /// <summary>
  /// Get all labels on a task
  /// Operation: GET /tasks/{task}/labels
  /// </summary>
  public async Task<List<Label>> ListAsync(int task, GetlabelsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["task"] = task
    };
    string url = "tasks/{task}/labels".BuildUrl(pathParams, request);

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
    List<Label>? result = JsonSerializer.Deserialize<List<Label>>(responseContent, JsonConfig.Default);
    return result ?? new List<Label>();
  }


  /// <summary>
  /// Add a label to a task
  /// Operation: PUT /tasks/{task}/labels
  /// </summary>
  public async Task<LabelTask> AddLabelToTaskAsync(int task, Apigen.Vikunja.Models.LabelTask labelTask)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["task"] = task
    };
    string url = "tasks/{task}/labels".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(labelTask, JsonConfig.Default);
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
    LabelTask? result = JsonSerializer.Deserialize<LabelTask>(responseContent, JsonConfig.Default);
    return result ?? new LabelTask();
  }


  /// <summary>
  /// Remove a label from a task
  /// Operation: DELETE /tasks/{task}/labels/{label}
  /// </summary>
  public async Task<Message> DeleteAsync(int task, int label)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["task"] = task,
      ["label"] = label
    };
    string url = "tasks/{task}/labels/{label}".BuildUrl(pathParams);

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
