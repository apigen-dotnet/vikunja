using System;
using System.Text.Json.Serialization;

namespace Apigen.Vikunja.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Permission
{
    PermissionRead = 0,
    PermissionWrite = 1,
    PermissionAdmin = 2,
}
