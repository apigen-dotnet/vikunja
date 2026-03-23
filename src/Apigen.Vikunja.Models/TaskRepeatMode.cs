using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskRepeatMode
{
    TaskRepeatModeDefault = 0,
    TaskRepeatModeMonth = 1,
    TaskRepeatModeFromCurrentDate = 2,
}
