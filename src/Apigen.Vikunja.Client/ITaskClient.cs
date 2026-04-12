using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for task operations
/// </summary>
public interface ITaskClient
{
  /// <summary>
  /// Create a task
  /// Operation: PUT /projects/{id}/tasks
  /// </summary>
  Task<TaskItem> CreateTaskAsync(int id, Apigen.Vikunja.Models.TaskItem taskItem);

  /// <summary>
  /// Get tasks in a project
  /// Operation: GET /projects/{id}/views/{view}/tasks
  /// </summary>
  Task<List<TaskItem>> GetTasksAsync(int id, int view, GetTasksRequest? request = null);

  /// <summary>
  /// Get one task by its per-project index
  /// Operation: GET /projects/{project}/tasks/by-index/{index}
  /// </summary>
  Task<TaskItem> GetTaskByIndexAsync(int project, int index, GetTaskByIndexRequest? request = null);

  /// <summary>
  /// Update a task bucket
  /// Operation: POST /projects/{project}/views/{view}/buckets/{bucket}/tasks
  /// </summary>
  Task<TaskBucket> AddTaskToBucketAsync(int project, int view, int bucket, Apigen.Vikunja.Models.TaskBucket taskBucket);

  /// <summary>
  /// Get tasks
  /// Operation: GET /tasks
  /// </summary>
  Task<List<TaskItem>> GetAllTasksAsync(GetAllTasksRequest? request = null);

  /// <summary>
  /// Update multiple tasks
  /// Operation: POST /tasks/bulk
  /// </summary>
  Task<List<TaskItem>> BulkUpdateTasksAsync(Apigen.Vikunja.Models.BulkTask bulkTask);

  /// <summary>
  /// Get one task
  /// Operation: GET /tasks/{id}
  /// </summary>
  Task<TaskItem> GetTaskAsync(int id, GetTaskRequest? request = null);

  /// <summary>
  /// Update a task
  /// Operation: POST /tasks/{id}
  /// </summary>
  Task<TaskItem> UpdateTaskAsync(int id, Apigen.Vikunja.Models.TaskItem taskItem);

  /// <summary>
  /// Delete a task
  /// Operation: DELETE /tasks/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id);

  /// <summary>
  /// Get  all attachments for one task.
  /// Operation: GET /tasks/{id}/attachments
  /// </summary>
  Task<List<TaskAttachment>> GetTaskAttachmentsAsync(int id, GetTaskAttachmentsRequest? request = null);

  /// <summary>
  /// Upload a task attachment
  /// Operation: PUT /tasks/{id}/attachments
  /// </summary>
  Task<Message> UploadTaskAttachmentAsync(int id);

  /// <summary>
  /// Get one attachment.
  /// Operation: GET /tasks/{id}/attachments/{attachmentID}
  /// </summary>
  Task<Stream> GetTaskAttachmentAsync(int id, int attachmentId, GetTaskAttachmentRequest? request = null);

  /// <summary>
  /// Delete an attachment
  /// Operation: DELETE /tasks/{id}/attachments/{attachmentID}
  /// </summary>
  Task<Message> DeleteAsync(int id, int attachmentId);

  /// <summary>
  /// Updates a task position
  /// Operation: POST /tasks/{id}/position
  /// </summary>
  Task<TaskPosition> UpdateTaskPositionAsync(int id, Apigen.Vikunja.Models.TaskPosition taskPosition);

  /// <summary>
  /// Mark a task as read
  /// Operation: POST /tasks/{projecttask}/read
  /// </summary>
  Task<TaskUnreadStatus> MarkTaskAsReadAsync(int projecttask);

  /// <summary>
  /// Get all task comments
  /// Operation: GET /tasks/{taskID}/comments
  /// </summary>
  Task<List<TaskComment>> GetTaskCommentsAsync(int taskId, GetTaskCommentsRequest? request = null);

  /// <summary>
  /// Create a new task comment
  /// Operation: PUT /tasks/{taskID}/comments
  /// </summary>
  Task<TaskComment> CreateTaskCommentAsync(int taskId, Apigen.Vikunja.Models.TaskComment taskComment);

  /// <summary>
  /// Get a task comment
  /// Operation: GET /tasks/{taskID}/comments/{commentID}
  /// </summary>
  Task<TaskComment> GetTaskCommentAsync(int taskId, int commentId);

  /// <summary>
  /// Update an existing task comment
  /// Operation: POST /tasks/{taskID}/comments/{commentID}
  /// </summary>
  Task<TaskComment> UpdateTaskCommentAsync(int taskId, int commentId);

  /// <summary>
  /// Remove a task comment
  /// Operation: DELETE /tasks/{taskID}/comments/{commentID}
  /// </summary>
  Task<Message> DeleteTasksCommentsAsync(int taskId, int commentId);

  /// <summary>
  /// Duplicate a task
  /// Operation: PUT /tasks/{taskID}/duplicate
  /// </summary>
  Task<TaskDuplicate> DuplicateTaskAsync(int taskId);

  /// <summary>
  /// Create a new relation between two tasks
  /// Operation: PUT /tasks/{taskID}/relations
  /// </summary>
  Task<TaskRelation> CreateTaskRelationAsync(int taskId, Apigen.Vikunja.Models.TaskRelation taskRelation);

  /// <summary>
  /// Remove a task relation
  /// Operation: DELETE /tasks/{taskID}/relations/{relationKind}/{otherTaskID}
  /// </summary>
  Task<Message> DeleteAsync(int taskId, string relationKind, int otherTaskId, Apigen.Vikunja.Models.TaskRelation taskRelation);

  /// <summary>
  /// Get all reactions for an entity
  /// Operation: GET /{kind}/{id}/reactions
  /// </summary>
  Task<List<ReactionMap>> GetReactionsAsync(int id, int kind);

  /// <summary>
  /// Add a reaction to an entity
  /// Operation: PUT /{kind}/{id}/reactions
  /// </summary>
  Task<Reaction> AddReactionAsync(int id, int kind, Apigen.Vikunja.Models.Reaction reaction);

  /// <summary>
  /// Removes the user&apos;s reaction
  /// Operation: POST /{kind}/{id}/reactions/delete
  /// </summary>
  Task<Message> DeleteReactionAsync(int id, int kind, Apigen.Vikunja.Models.Reaction reaction);

}
