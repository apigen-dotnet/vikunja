using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for labels operations
/// </summary>
public partial interface ILabelsClient
{
  /// <summary>
  /// Get all labels a user has access to
  /// Operation: GET /labels
  /// </summary>
  Task<List<Label>> ListAsync(GetlabelsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a label
  /// Operation: PUT /labels
  /// </summary>
  Task<Label> CreateLabelAsync(Apigen.Vikunja.Models.Label label, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets one label
  /// Operation: GET /labels/{id}
  /// </summary>
  Task<Label> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a label
  /// Operation: PUT /labels/{id}
  /// </summary>
  Task<Label> UpdateLabelAsync(int id, Apigen.Vikunja.Models.Label label, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a label
  /// Operation: DELETE /labels/{id}
  /// </summary>
  Task<Label> DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update all labels on a task.
  /// Operation: POST /tasks/{taskID}/labels/bulk
  /// </summary>
  Task<LabelTaskBulk> BulkAsync(int taskId, Apigen.Vikunja.Models.LabelTaskBulk labelTaskBulk, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all labels on a task
  /// Operation: GET /tasks/{task}/labels
  /// </summary>
  Task<List<Label>> ListAsync(int task, GetlabelsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a label to a task
  /// Operation: PUT /tasks/{task}/labels
  /// </summary>
  Task<LabelTask> AddLabelToTaskAsync(int task, Apigen.Vikunja.Models.LabelTask labelTask, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a label from a task
  /// Operation: DELETE /tasks/{task}/labels/{label}
  /// </summary>
  Task<Message> DeleteAsync(int task, int label, CancellationToken cancellationToken = default);

}
