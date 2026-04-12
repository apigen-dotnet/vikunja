using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CsvTaskAttribute
{
    [JsonStringEnumMemberName("title")]
    Title,
    [JsonStringEnumMemberName("description")]
    Description,
    [JsonStringEnumMemberName("due_date")]
    DueDate,
    [JsonStringEnumMemberName("start_date")]
    StartDate,
    [JsonStringEnumMemberName("end_date")]
    EndDate,
    [JsonStringEnumMemberName("done")]
    Done,
    [JsonStringEnumMemberName("priority")]
    Priority,
    [JsonStringEnumMemberName("labels")]
    Labels,
    [JsonStringEnumMemberName("project")]
    Project,
    [JsonStringEnumMemberName("reminder")]
    Reminder,
    [JsonStringEnumMemberName("ignore")]
    Ignore,
}
