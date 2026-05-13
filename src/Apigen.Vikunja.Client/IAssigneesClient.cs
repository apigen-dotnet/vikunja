using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for assignees operations
/// </summary>
public partial interface IAssigneesClient
{
  /// <summary>
  /// Get all assignees for a task
  /// Operation: GET /tasks/{taskID}/assignees
  /// </summary>
  Task<List<User>> ListAsync(int taskId, GetassigneesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a new assignee to a task
  /// Operation: PUT /tasks/{taskID}/assignees
  /// </summary>
  Task<TaskAssignee> AddAssigneeAsync(int taskId, Apigen.Vikunja.Models.TaskAssignee taskAssignee, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add multiple new assignees to a task
  /// Operation: POST /tasks/{taskID}/assignees/bulk
  /// </summary>
  Task<TaskAssignee> AddMultipleAssigneesAsync(int taskId, Apigen.Vikunja.Models.BulkAssignees bulkAssignees, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete an assignee
  /// Operation: DELETE /tasks/{taskID}/assignees/{userID}
  /// </summary>
  Task<Message> DeleteAsync(int taskId, int userId, CancellationToken cancellationToken = default);

}
