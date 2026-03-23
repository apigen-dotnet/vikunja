using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RelationKind
{
    [JsonStringEnumMemberName("unknown")]
    Unknown,
    [JsonStringEnumMemberName("subtask")]
    Subtask,
    [JsonStringEnumMemberName("parenttask")]
    Parenttask,
    [JsonStringEnumMemberName("related")]
    Related,
    [JsonStringEnumMemberName("duplicateof")]
    Duplicateof,
    [JsonStringEnumMemberName("duplicates")]
    Duplicates,
    [JsonStringEnumMemberName("blocking")]
    Blocking,
    [JsonStringEnumMemberName("blocked")]
    Blocked,
    [JsonStringEnumMemberName("precedes")]
    Precedes,
    [JsonStringEnumMemberName("follows")]
    Follows,
    [JsonStringEnumMemberName("copiedfrom")]
    Copiedfrom,
    [JsonStringEnumMemberName("copiedto")]
    Copiedto,
}
