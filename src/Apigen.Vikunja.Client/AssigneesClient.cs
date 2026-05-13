using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Client for assignees operations
/// </summary>
public partial class AssigneesClient
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
  public async Task<List<User>> ListAsync(int taskId, GetassigneesRequest? request = null, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams, request);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
      HttpResponseMessage response = await _httpClient.GetAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorBody, null);
        throw new ApiException(response.StatusCode, "GET", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      List<User>? result = JsonSerializer.Deserialize<List<User>>(responseContent, JsonConfig.Default);
      return result ?? new List<User>();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "GET", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "GET", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "GET", url, ex);
      throw;
    }
  }


  /// <summary>
  /// Add a new assignee to a task
  /// Operation: PUT /tasks/{taskID}/assignees
  /// </summary>
  public async Task<TaskAssignee> AddAssigneeAsync(int taskId, Apigen.Vikunja.Models.TaskAssignee taskAssignee, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
      string json = JsonSerializer.Serialize(taskAssignee, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PutAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, errorBody, null);
        throw new ApiException(response.StatusCode, "PUT", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      TaskAssignee? result = JsonSerializer.Deserialize<TaskAssignee>(responseContent, JsonConfig.Default);
      return result ?? new TaskAssignee();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "PUT", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "PUT", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "PUT", url, ex);
      throw;
    }
  }


  /// <summary>
  /// Add multiple new assignees to a task
  /// Operation: POST /tasks/{taskID}/assignees/bulk
  /// </summary>
  public async Task<TaskAssignee> AddMultipleAssigneesAsync(int taskId, Apigen.Vikunja.Models.BulkAssignees bulkAssignees, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/assignees/bulk".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(bulkAssignees, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorBody, null);
        throw new ApiException(response.StatusCode, "POST", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      TaskAssignee? result = JsonSerializer.Deserialize<TaskAssignee>(responseContent, JsonConfig.Default);
      return result ?? new TaskAssignee();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "POST", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "POST", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "POST", url, ex);
      throw;
    }
  }


  /// <summary>
  /// Delete an assignee
  /// Operation: DELETE /tasks/{taskID}/assignees/{userID}
  /// </summary>
  public async Task<Message> DeleteAsync(int taskId, int userId, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["userID"] = userId
    };
    string url = "tasks/{taskID}/assignees/{userID}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
      HttpResponseMessage response = await _httpClient.DeleteAsync(url, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, errorBody, null);
        throw new ApiException(response.StatusCode, "DELETE", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      Message? result = JsonSerializer.Deserialize<Message>(responseContent, JsonConfig.Default);
      return result ?? new Message();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "DELETE", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "DELETE", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "DELETE", url, ex);
      throw;
    }
  }


}
