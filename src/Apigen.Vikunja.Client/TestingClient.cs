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
/// Client for testing operations
/// </summary>
public partial class TestingClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TestingClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Truncate all tables
  /// Operation: DELETE /test/all
  /// </summary>
  public async Task<JsonElement> TruncateAllTablesAsync(CancellationToken cancellationToken = default)
  {
    string url = "test/all";

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
      JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
      return result;
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


  /// <summary>
  /// Reset the db to a defined state
  /// Operation: PATCH /test/{table}
  /// </summary>
  public async Task<List<User>> PatchAsync(string table, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["table"] = table
    };
    string url = "test/{table}".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "PATCH", url);
      HttpResponseMessage response = await _httpClient.PatchAsync(url, null, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PATCH", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PATCH", url, errorBody, null);
        throw new ApiException(response.StatusCode, "PATCH", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      List<User>? result = JsonSerializer.Deserialize<List<User>>(responseContent, JsonConfig.Default);
      return result ?? new List<User>();
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "PATCH", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "PATCH", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "PATCH", url, ex);
      throw;
    }
  }


}
