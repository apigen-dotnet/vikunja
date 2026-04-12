using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.Vikunja.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public class VikunjaApiClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for auth operations
  /// </summary>
  public AuthClient Auth { get; }

  /// <summary>
  /// Client for project operations
  /// </summary>
  public ProjectClient Project { get; }

  /// <summary>
  /// Client for filter operations
  /// </summary>
  public FilterClient Filter { get; }

  /// <summary>
  /// Client for service operations
  /// </summary>
  public ServiceClient Service { get; }

  /// <summary>
  /// Client for labels operations
  /// </summary>
  public LabelsClient Labels { get; }

  /// <summary>
  /// Client for migration operations
  /// </summary>
  public MigrationClient Migration { get; }

  /// <summary>
  /// Client for subscriptions operations
  /// </summary>
  public SubscriptionsClient Subscriptions { get; }

  /// <summary>
  /// Client for sharing operations
  /// </summary>
  public SharingClient Sharing { get; }

  /// <summary>
  /// Client for task operations
  /// </summary>
  public TaskClient Task { get; }

  /// <summary>
  /// Client for webhooks operations
  /// </summary>
  public WebhooksClient Webhooks { get; }

  /// <summary>
  /// Client for api operations
  /// </summary>
  public ApiClient Api { get; }

  /// <summary>
  /// Client for assignees operations
  /// </summary>
  public AssigneesClient Assignees { get; }

  /// <summary>
  /// Client for team operations
  /// </summary>
  public TeamClient Team { get; }

  /// <summary>
  /// Client for testing operations
  /// </summary>
  public TestingClient Testing { get; }

  /// <summary>
  /// Client for user operations
  /// </summary>
  public UserClient User { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public VikunjaApiClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    Auth = new AuthClient(_httpClient, _logger);
    Project = new ProjectClient(_httpClient, _logger);
    Filter = new FilterClient(_httpClient, _logger);
    Service = new ServiceClient(_httpClient, _logger);
    Labels = new LabelsClient(_httpClient, _logger);
    Migration = new MigrationClient(_httpClient, _logger);
    Subscriptions = new SubscriptionsClient(_httpClient, _logger);
    Sharing = new SharingClient(_httpClient, _logger);
    Task = new TaskClient(_httpClient, _logger);
    Webhooks = new WebhooksClient(_httpClient, _logger);
    Api = new ApiClient(_httpClient, _logger);
    Assignees = new AssigneesClient(_httpClient, _logger);
    Team = new TeamClient(_httpClient, _logger);
    Testing = new TestingClient(_httpClient, _logger);
    User = new UserClient(_httpClient, _logger);
  }

  private VikunjaApiClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    Auth = new AuthClient(_httpClient, _logger);
    Project = new ProjectClient(_httpClient, _logger);
    Filter = new FilterClient(_httpClient, _logger);
    Service = new ServiceClient(_httpClient, _logger);
    Labels = new LabelsClient(_httpClient, _logger);
    Migration = new MigrationClient(_httpClient, _logger);
    Subscriptions = new SubscriptionsClient(_httpClient, _logger);
    Sharing = new SharingClient(_httpClient, _logger);
    Task = new TaskClient(_httpClient, _logger);
    Webhooks = new WebhooksClient(_httpClient, _logger);
    Api = new ApiClient(_httpClient, _logger);
    Assignees = new AssigneesClient(_httpClient, _logger);
    Team = new TeamClient(_httpClient, _logger);
    Testing = new TestingClient(_httpClient, _logger);
    User = new UserClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with Basic Authentication
  /// </summary>
  public static VikunjaApiClient WithBasicAuth(string username, string password, string baseUrl = "/api/v1", ILogger? logger = null)
  {
    HttpClient httpClient = CreateBasicAuthHttpClient(username, password, baseUrl);
    return new VikunjaApiClient(httpClient, true, logger);
  }

  /// <summary>
  /// Create client with API key authentication
  /// </summary>
  public static VikunjaApiClient WithApiKey(string apiKey, string baseUrl = "/api/v1", ILogger? logger = null)
  {
    HttpClient httpClient = CreateTokenAuthHttpClient(apiKey, baseUrl, "Authorization", false);
    return new VikunjaApiClient(httpClient, true, logger);
  }

  private static HttpClient CreateTokenAuthHttpClient(string apiToken, string baseUrl, string headerName, bool useBearer)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    if (useBearer)
    {
      client.DefaultRequestHeaders.Add(headerName, $"Bearer {apiToken}");
    }
    else
    {
      client.DefaultRequestHeaders.Add(headerName, apiToken);
    }

    return client;
  }

  private static HttpClient CreateBasicAuthHttpClient(string username, string password, string baseUrl)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

    return client;
  }

  private static HttpClient CreateCookieAuthHttpClient(string token, string cookieName, string baseUrl)
  {
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    System.Net.CookieContainer cookies = new();
    cookies.Add(new Uri(normalizedBaseUrl), new System.Net.Cookie(cookieName, token));
    HttpClientHandler handler = new() { CookieContainer = cookies };
    HttpClient client = new(handler) { BaseAddress = new Uri(normalizedBaseUrl) };

    return client;
  }

  /// <summary>
  /// Dispose resources
  /// </summary>
  public void Dispose()
  {
    if (_disposeHttpClient)
    {
      _httpClient?.Dispose();
    }
  }
}
