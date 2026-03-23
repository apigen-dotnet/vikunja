using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReminderRelation
{
    [JsonStringEnumMemberName("due_date")]
    DueDate,
    [JsonStringEnumMemberName("start_date")]
    StartDate,
    [JsonStringEnumMemberName("end_date")]
    EndDate,
}
