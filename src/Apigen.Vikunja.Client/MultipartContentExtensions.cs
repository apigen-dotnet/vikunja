using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Client;

internal static class MultipartContentExtensions
{
  /// <summary>
  /// Converts a DTO object to MultipartFormDataContent for file upload endpoints.
  /// Properties of type byte[] are added as file content, all others as string fields.
  /// Uses JsonPropertyName attribute for field names.
  /// </summary>
  public static MultipartFormDataContent ToMultipartContent(this object dto)
  {
    MultipartFormDataContent content = new();

    foreach (PropertyInfo prop in dto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
      object? value = prop.GetValue(dto);
      if (value == null) continue;

      // Use JsonPropertyName attribute for the field name, fall back to property name
      string fieldName = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

      if (value is byte[] bytes)
      {
        ByteArrayContent fileContent = new(bytes);
        content.Add(fileContent, fieldName, fieldName);
      }
      else if (value is Stream stream)
      {
        StreamContent streamContent = new(stream);
        content.Add(streamContent, fieldName, fieldName);
      }
      else if (value is bool boolValue)
      {
        content.Add(new StringContent(boolValue.ToString().ToLowerInvariant()), fieldName);
      }
      else if (value is DateTime dateTime)
      {
        content.Add(new StringContent(dateTime.ToString("O")), fieldName);
      }
      else if (value is DateTimeOffset dateTimeOffset)
      {
        content.Add(new StringContent(dateTimeOffset.ToString("O")), fieldName);
      }
      else
      {
        content.Add(new StringContent(value.ToString() ?? ""), fieldName);
      }
    }

    return content;
  }
}
