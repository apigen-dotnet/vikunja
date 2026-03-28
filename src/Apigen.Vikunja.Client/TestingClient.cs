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
/// Client for testing operations
/// </summary>
public class TestingClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TestingClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Reset the db to a defined state
  /// Operation: PATCH /test/{table}
  /// </summary>
  public async Task<List<User>> PatchAsync(string table)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["table"] = table
    };
    string url = "test/{table}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PATCH", url);
    HttpResponseMessage response = await _httpClient.PatchAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PATCH", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PATCH", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    List<User>? result = JsonSerializer.Deserialize<List<User>>(responseContent, JsonConfig.Default);
    return result ?? new List<User>();
  }


}
