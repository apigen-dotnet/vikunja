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
/// Client for task operations
/// </summary>
public partial class TaskClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TaskClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Create a task
  /// Operation: PUT /projects/{id}/tasks
  /// </summary>
  public async Task<TaskItem> CreateTaskAsync(int id, Apigen.Vikunja.Models.TaskItem taskItem)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "projects/{id}/tasks".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(taskItem, JsonConfig.Default);
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
    TaskItem? result = JsonSerializer.Deserialize<TaskItem>(responseContent, JsonConfig.Default);
    return result ?? new TaskItem();
  }


  /// <summary>
  /// Get tasks in a project
  /// Operation: GET /projects/{id}/views/{view}/tasks
  /// </summary>
  public async Task<List<TaskItem>> GetTasksAsync(int id, int view, GetTasksRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["view"] = view
    };
    string url = "projects/{id}/views/{view}/tasks".BuildUrl(pathParams, request);

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
    List<TaskItem>? result = JsonSerializer.Deserialize<List<TaskItem>>(responseContent, JsonConfig.Default);
    return result ?? new List<TaskItem>();
  }


  /// <summary>
  /// Get one task by its per-project index
  /// Operation: GET /projects/{project}/tasks/by-index/{index}
  /// </summary>
  public async Task<TaskItem> GetTaskByIndexAsync(int project, int index, GetTaskByIndexRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["project"] = project,
      ["index"] = index
    };
    string url = "projects/{project}/tasks/by-index/{index}".BuildUrl(pathParams, request);

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
    TaskItem? result = JsonSerializer.Deserialize<TaskItem>(responseContent, JsonConfig.Default);
    return result ?? new TaskItem();
  }


  /// <summary>
  /// Update a task bucket
  /// Operation: POST /projects/{project}/views/{view}/buckets/{bucket}/tasks
  /// </summary>
  public async Task<TaskBucket> AddTaskToBucketAsync(int project, int view, int bucket, Apigen.Vikunja.Models.TaskBucket taskBucket)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["project"] = project,
      ["view"] = view,
      ["bucket"] = bucket
    };
    string url = "projects/{project}/views/{view}/buckets/{bucket}/tasks".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(taskBucket, JsonConfig.Default);
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
    TaskBucket? result = JsonSerializer.Deserialize<TaskBucket>(responseContent, JsonConfig.Default);
    return result ?? new TaskBucket();
  }


  /// <summary>
  /// Get tasks
  /// Operation: GET /tasks
  /// </summary>
  public async Task<List<TaskItem>> GetAllTasksAsync(GetAllTasksRequest? request = null)
  {
    string url = "tasks".BuildUrl(request: request);

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
    List<TaskItem>? result = JsonSerializer.Deserialize<List<TaskItem>>(responseContent, JsonConfig.Default);
    return result ?? new List<TaskItem>();
  }


  /// <summary>
  /// Update multiple tasks
  /// Operation: POST /tasks/bulk
  /// </summary>
  public async Task<List<TaskItem>> BulkUpdateTasksAsync(Apigen.Vikunja.Models.BulkTask bulkTask)
  {
    string url = "tasks/bulk";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(bulkTask, JsonConfig.Default);
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
    List<TaskItem>? result = JsonSerializer.Deserialize<List<TaskItem>>(responseContent, JsonConfig.Default);
    return result ?? new List<TaskItem>();
  }


  /// <summary>
  /// Get one task
  /// Operation: GET /tasks/{id}
  /// </summary>
  public async Task<TaskItem> GetTaskAsync(int id, GetTaskRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams, request);

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
    TaskItem? result = JsonSerializer.Deserialize<TaskItem>(responseContent, JsonConfig.Default);
    return result ?? new TaskItem();
  }


  /// <summary>
  /// Update a task
  /// Operation: POST /tasks/{id}
  /// </summary>
  public async Task<TaskItem> UpdateTaskAsync(int id, Apigen.Vikunja.Models.TaskItem taskItem)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(taskItem, JsonConfig.Default);
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
    TaskItem? result = JsonSerializer.Deserialize<TaskItem>(responseContent, JsonConfig.Default);
    return result ?? new TaskItem();
  }


  /// <summary>
  /// Delete a task
  /// Operation: DELETE /tasks/{id}
  /// </summary>
  public async Task<Message> DeleteAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}".BuildUrl(pathParams);

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
  /// Get  all attachments for one task.
  /// Operation: GET /tasks/{id}/attachments
  /// </summary>
  public async Task<List<TaskAttachment>> GetTaskAttachmentsAsync(int id, GetTaskAttachmentsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/attachments".BuildUrl(pathParams, request);

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
    List<TaskAttachment>? result = JsonSerializer.Deserialize<List<TaskAttachment>>(responseContent, JsonConfig.Default);
    return result ?? new List<TaskAttachment>();
  }


  /// <summary>
  /// Upload a task attachment
  /// Operation: PUT /tasks/{id}/attachments
  /// </summary>
  public async Task<Message> UploadTaskAttachmentAsync(int id)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/attachments".BuildUrl(pathParams);

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
    Message? result = JsonSerializer.Deserialize<Message>(responseContent, JsonConfig.Default);
    return result ?? new Message();
  }


  /// <summary>
  /// Get one attachment.
  /// Operation: GET /tasks/{id}/attachments/{attachmentID}
  /// </summary>
  public async Task<Stream> GetTaskAttachmentAsync(int id, int attachmentId, GetTaskAttachmentRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["attachmentID"] = attachmentId
    };
    string url = "tasks/{id}/attachments/{attachmentID}".BuildUrl(pathParams, request);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string errorContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, errorContent, ex);
      throw;
    }
    return await response.Content.ReadAsStreamAsync();
  }


  /// <summary>
  /// Delete an attachment
  /// Operation: DELETE /tasks/{id}/attachments/{attachmentID}
  /// </summary>
  public async Task<Message> DeleteAsync(int id, int attachmentId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["attachmentID"] = attachmentId
    };
    string url = "tasks/{id}/attachments/{attachmentID}".BuildUrl(pathParams);

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
  /// Updates a task position
  /// Operation: POST /tasks/{id}/position
  /// </summary>
  public async Task<TaskPosition> UpdateTaskPositionAsync(int id, Apigen.Vikunja.Models.TaskPosition taskPosition)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id
    };
    string url = "tasks/{id}/position".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(taskPosition, JsonConfig.Default);
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
    TaskPosition? result = JsonSerializer.Deserialize<TaskPosition>(responseContent, JsonConfig.Default);
    return result ?? new TaskPosition();
  }


  /// <summary>
  /// Mark a task as read
  /// Operation: POST /tasks/{projecttask}/read
  /// </summary>
  public async Task<TaskUnreadStatus> MarkTaskAsReadAsync(int projecttask)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["projecttask"] = projecttask
    };
    string url = "tasks/{projecttask}/read".BuildUrl(pathParams);

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
    TaskUnreadStatus? result = JsonSerializer.Deserialize<TaskUnreadStatus>(responseContent, JsonConfig.Default);
    return result ?? new TaskUnreadStatus();
  }


  /// <summary>
  /// Get all task comments
  /// Operation: GET /tasks/{taskID}/comments
  /// </summary>
  public async Task<List<TaskComment>> GetTaskCommentsAsync(int taskId, GetTaskCommentsRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/comments".BuildUrl(pathParams, request);

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
    List<TaskComment>? result = JsonSerializer.Deserialize<List<TaskComment>>(responseContent, JsonConfig.Default);
    return result ?? new List<TaskComment>();
  }


  /// <summary>
  /// Create a new task comment
  /// Operation: PUT /tasks/{taskID}/comments
  /// </summary>
  public async Task<TaskComment> CreateTaskCommentAsync(int taskId, Apigen.Vikunja.Models.TaskComment taskComment)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/comments".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(taskComment, JsonConfig.Default);
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
    TaskComment? result = JsonSerializer.Deserialize<TaskComment>(responseContent, JsonConfig.Default);
    return result ?? new TaskComment();
  }


  /// <summary>
  /// Get a task comment
  /// Operation: GET /tasks/{taskID}/comments/{commentID}
  /// </summary>
  public async Task<TaskComment> GetTaskCommentAsync(int taskId, int commentId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["commentID"] = commentId
    };
    string url = "tasks/{taskID}/comments/{commentID}".BuildUrl(pathParams);

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
    TaskComment? result = JsonSerializer.Deserialize<TaskComment>(responseContent, JsonConfig.Default);
    return result ?? new TaskComment();
  }


  /// <summary>
  /// Update an existing task comment
  /// Operation: POST /tasks/{taskID}/comments/{commentID}
  /// </summary>
  public async Task<TaskComment> UpdateTaskCommentAsync(int taskId, int commentId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["commentID"] = commentId
    };
    string url = "tasks/{taskID}/comments/{commentID}".BuildUrl(pathParams);

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
    TaskComment? result = JsonSerializer.Deserialize<TaskComment>(responseContent, JsonConfig.Default);
    return result ?? new TaskComment();
  }


  /// <summary>
  /// Remove a task comment
  /// Operation: DELETE /tasks/{taskID}/comments/{commentID}
  /// </summary>
  public async Task<Message> DeleteTasksCommentsAsync(int taskId, int commentId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["commentID"] = commentId
    };
    string url = "tasks/{taskID}/comments/{commentID}".BuildUrl(pathParams);

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
  /// Duplicate a task
  /// Operation: PUT /tasks/{taskID}/duplicate
  /// </summary>
  public async Task<TaskDuplicate> DuplicateTaskAsync(int taskId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/duplicate".BuildUrl(pathParams);

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
    TaskDuplicate? result = JsonSerializer.Deserialize<TaskDuplicate>(responseContent, JsonConfig.Default);
    return result ?? new TaskDuplicate();
  }


  /// <summary>
  /// Create a new relation between two tasks
  /// Operation: PUT /tasks/{taskID}/relations
  /// </summary>
  public async Task<TaskRelation> CreateTaskRelationAsync(int taskId, Apigen.Vikunja.Models.TaskRelation taskRelation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId
    };
    string url = "tasks/{taskID}/relations".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(taskRelation, JsonConfig.Default);
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
    TaskRelation? result = JsonSerializer.Deserialize<TaskRelation>(responseContent, JsonConfig.Default);
    return result ?? new TaskRelation();
  }


  /// <summary>
  /// Remove a task relation
  /// Operation: DELETE /tasks/{taskID}/relations/{relationKind}/{otherTaskID}
  /// </summary>
  public async Task<Message> DeleteAsync(int taskId, string relationKind, int otherTaskId, Apigen.Vikunja.Models.TaskRelation taskRelation)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["taskID"] = taskId,
      ["relationKind"] = relationKind,
      ["otherTaskID"] = otherTaskId
    };
    string url = "tasks/{taskID}/relations/{relationKind}/{otherTaskID}".BuildUrl(pathParams);

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
  /// Get all reactions for an entity
  /// Operation: GET /{kind}/{id}/reactions
  /// </summary>
  public async Task<List<ReactionMap>> GetReactionsAsync(int id, int kind)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["kind"] = kind
    };
    string url = "{kind}/{id}/reactions".BuildUrl(pathParams);

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
    List<ReactionMap>? result = JsonSerializer.Deserialize<List<ReactionMap>>(responseContent, JsonConfig.Default);
    return result ?? new List<ReactionMap>();
  }


  /// <summary>
  /// Add a reaction to an entity
  /// Operation: PUT /{kind}/{id}/reactions
  /// </summary>
  public async Task<Reaction> AddReactionAsync(int id, int kind, Apigen.Vikunja.Models.Reaction reaction)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["kind"] = kind
    };
    string url = "{kind}/{id}/reactions".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    string json = JsonSerializer.Serialize(reaction, JsonConfig.Default);
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
    Reaction? result = JsonSerializer.Deserialize<Reaction>(responseContent, JsonConfig.Default);
    return result ?? new Reaction();
  }


  /// <summary>
  /// Removes the user&apos;s reaction
  /// Operation: POST /{kind}/{id}/reactions/delete
  /// </summary>
  public async Task<Message> DeleteReactionAsync(int id, int kind, Apigen.Vikunja.Models.Reaction reaction)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["kind"] = kind
    };
    string url = "{kind}/{id}/reactions/delete".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(reaction, JsonConfig.Default);
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
    Message? result = JsonSerializer.Deserialize<Message>(responseContent, JsonConfig.Default);
    return result ?? new Message();
  }


}
