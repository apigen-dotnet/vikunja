# Apigen.Vikunja

Generated C# client for the [Vikunja](https://vikunja.io/) task management API.

## Installation

```bash
dotnet add package Apigen.Vikunja.Client
```

## Usage

```csharp
using Apigen.Vikunja.Client;
using Apigen.Vikunja.Models;

// Create client with API key
var client = VikunjaApiClient.WithApiKey(
    "your-api-key",
    "https://your-vikunja-instance/api/v1");

// Or with basic authentication
var client = VikunjaApiClient.WithBasicAuth(
    "username", "password",
    "https://your-vikunja-instance/api/v1");

// Or use a pre-configured HttpClient
var client = new VikunjaApiClient(httpClient);
```

## License

MIT
