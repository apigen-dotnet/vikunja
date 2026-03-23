using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SharingType
{
    SharingTypeUnknown = 0,
    SharingTypeWithoutPassword = 1,
    SharingTypeWithPassword = 2,
}
