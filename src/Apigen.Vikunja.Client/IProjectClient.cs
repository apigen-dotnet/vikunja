using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for project operations
/// </summary>
public partial interface IProjectClient
{
  /// <summary>
  /// Get an unsplash image
  /// Operation: GET /backgrounds/unsplash/image/{image}
  /// </summary>
  Task<Stream> GetUnsplashImageAsync(int image, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an unsplash thumbnail image
  /// Operation: GET /backgrounds/unsplash/image/{image}/thumb
  /// </summary>
  Task<Stream> GetUnsplashThumbnailAsync(int image, CancellationToken cancellationToken = default);

  /// <summary>
  /// Search for a background from unsplash
  /// Operation: GET /backgrounds/unsplash/search
  /// </summary>
  Task<List<Image>> SearchUnsplashBackgroundsAsync(SearchUnsplashBackgroundsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all projects a user has access to
  /// Operation: GET /projects
  /// </summary>
  Task<List<Project>> GetAsync(GetprojectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Creates a new project
  /// Operation: PUT /projects
  /// </summary>
  Task<Project> CreateProjectAsync(Apigen.Vikunja.Models.Project project, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets one project
  /// Operation: GET /projects/{id}
  /// </summary>
  Task<Project> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a project
  /// Operation: POST /projects/{id}
  /// </summary>
  Task<Project> UpdateProjectAsync(int id, Apigen.Vikunja.Models.Project project, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a project
  /// Operation: DELETE /projects/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get the project background
  /// Operation: GET /projects/{id}/background
  /// </summary>
  Task<Stream> GetProjectBackgroundAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a project background
  /// Operation: DELETE /projects/{id}/background
  /// </summary>
  Task<Project> RemoveProjectBackgroundAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Set an unsplash photo as project background
  /// Operation: POST /projects/{id}/backgrounds/unsplash
  /// </summary>
  Task<Project> SetUnsplashBackgroundAsync(int id, Apigen.Vikunja.Models.Image image, CancellationToken cancellationToken = default);

  /// <summary>
  /// Upload a project background
  /// Operation: PUT /projects/{id}/backgrounds/upload
  /// </summary>
  Task<Message> UploadProjectBackgroundAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get users
  /// Operation: GET /projects/{id}/projectusers
  /// </summary>
  Task<List<User>> GetAsync(int id, GetprojectRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all kanban buckets of a project
  /// Operation: GET /projects/{id}/views/{view}/buckets
  /// </summary>
  Task<List<Bucket>> GetAsync(int id, int view, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a new bucket
  /// Operation: PUT /projects/{id}/views/{view}/buckets
  /// </summary>
  Task<Bucket> CreateBucketAsync(int id, int view, Apigen.Vikunja.Models.Bucket bucket, CancellationToken cancellationToken = default);

  /// <summary>
  /// Duplicate an existing project
  /// Operation: PUT /projects/{projectID}/duplicate
  /// </summary>
  Task<ProjectDuplicate> DuplicateProjectAsync(int projectId, Apigen.Vikunja.Models.ProjectDuplicate projectDuplicate, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update an existing bucket
  /// Operation: POST /projects/{projectID}/views/{view}/buckets/{bucketID}
  /// </summary>
  Task<Bucket> UpdateBucketAsync(int projectId, int bucketId, int view, Apigen.Vikunja.Models.Bucket bucket, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes an existing bucket
  /// Operation: DELETE /projects/{projectID}/views/{view}/buckets/{bucketID}
  /// </summary>
  Task<Message> DeleteAsync(int projectId, int bucketId, int view, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all project views for a project
  /// Operation: GET /projects/{project}/views
  /// </summary>
  Task<List<ProjectView>> GetProjectsViewsAsync(int project, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a project view
  /// Operation: PUT /projects/{project}/views
  /// </summary>
  Task<ProjectView> CreateProjectViewAsync(int project, Apigen.Vikunja.Models.ProjectView projectView, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get one project view
  /// Operation: GET /projects/{project}/views/{id}
  /// </summary>
  Task<ProjectView> GetProjectsViewsAsync(int project, int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a project view
  /// Operation: POST /projects/{project}/views/{id}
  /// </summary>
  Task<ProjectView> UpdateProjectViewAsync(int project, int id, Apigen.Vikunja.Models.ProjectView projectView, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a project view
  /// Operation: DELETE /projects/{project}/views/{id}
  /// </summary>
  Task<Message> DeleteAsync(int project, int id, CancellationToken cancellationToken = default);

}
