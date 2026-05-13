using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for sharing operations
/// </summary>
public partial interface ISharingClient
{
  /// <summary>
  /// Mark all notifications of a user as read
  /// Operation: POST /notifications
  /// </summary>
  Task<Message> PostAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get teams on a project
  /// Operation: GET /projects/{id}/teams
  /// </summary>
  Task<List<TeamWithPermission>> GetAsync(int id, GetsharingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a team to a project
  /// Operation: PUT /projects/{id}/teams
  /// </summary>
  Task<TeamProject> AddTeamToProjectAsync(int id, Apigen.Vikunja.Models.TeamProject teamProject, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get users on a project
  /// Operation: GET /projects/{id}/users
  /// </summary>
  Task<List<UserWithPermission>> GetProjectsUsersAsync(int id, GetsharingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a user to a project
  /// Operation: PUT /projects/{id}/users
  /// </summary>
  Task<ProjectUser> AddUserToProjectAsync(int id, Apigen.Vikunja.Models.ProjectUser projectUser, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a team &lt;-&gt; project relation
  /// Operation: POST /projects/{projectID}/teams/{teamID}
  /// </summary>
  Task<TeamProject> UpdateProjectTeamAsync(int projectId, int teamId, Apigen.Vikunja.Models.TeamProject teamProject, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a team from a project
  /// Operation: DELETE /projects/{projectID}/teams/{teamID}
  /// </summary>
  Task<Message> DeleteAsync(int projectId, int teamId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a user &lt;-&gt; project relation
  /// Operation: POST /projects/{projectID}/users/{userID}
  /// </summary>
  Task<ProjectUser> UpdateProjectUserAsync(int projectId, int userId, Apigen.Vikunja.Models.ProjectUser projectUser, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a user from a project
  /// Operation: DELETE /projects/{projectID}/users/{userID}
  /// </summary>
  Task<Message> DeleteProjectsUsersAsync(int projectId, int userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all link shares for a project
  /// Operation: GET /projects/{project}/shares
  /// </summary>
  Task<List<LinkSharing>> GetProjectsSharesAsync(int project, GetsharingRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Share a project via link
  /// Operation: PUT /projects/{project}/shares
  /// </summary>
  Task<LinkSharing> CreateProjectShareAsync(int project, Apigen.Vikunja.Models.LinkSharing linkSharing, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get one link shares for a project
  /// Operation: GET /projects/{project}/shares/{share}
  /// </summary>
  Task<LinkSharing> GetAsync(int project, int share, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a link share
  /// Operation: DELETE /projects/{project}/shares/{share}
  /// </summary>
  Task<Message> DeleteProjectsSharesAsync(int project, int share, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an auth token for a share
  /// Operation: POST /shares/{share}/auth
  /// </summary>
  Task<AuthToken> AuthenticateShareAsync(string share, Apigen.Vikunja.Models.LinkShareAuth linkShareAuth, CancellationToken cancellationToken = default);

}
