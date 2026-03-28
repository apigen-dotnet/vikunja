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
/// Client for service operations
/// </summary>
public class ServiceClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ServiceClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Info
  /// Operation: GET /info
  /// </summary>
  public async Task<VikunjaInfos> GetAsync()
  {
    string url = "info";

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
    VikunjaInfos? result = JsonSerializer.Deserialize<VikunjaInfos>(responseContent, JsonConfig.Default);
    return result ?? new VikunjaInfos();
  }


}
