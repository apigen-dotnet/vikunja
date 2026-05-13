using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for team operations
/// </summary>
public partial interface ITeamClient
{
  /// <summary>
  /// Get teams
  /// Operation: GET /teams
  /// </summary>
  Task<List<Team>> GetAsync(GetteamRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Creates a new team
  /// Operation: PUT /teams
  /// </summary>
  Task<Team> CreateTeamAsync(Apigen.Vikunja.Models.Team team, CancellationToken cancellationToken = default);

  /// <summary>
  /// Gets one team
  /// Operation: GET /teams/{id}
  /// </summary>
  Task<Team> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a team
  /// Operation: POST /teams/{id}
  /// </summary>
  Task<Team> UpdateTeamAsync(int id, Apigen.Vikunja.Models.Team team, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a team
  /// Operation: DELETE /teams/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a user to a team
  /// Operation: PUT /teams/{id}/members
  /// </summary>
  Task<TeamMember> AddTeamMemberAsync(int id, Apigen.Vikunja.Models.TeamMember teamMember, CancellationToken cancellationToken = default);

  /// <summary>
  /// Toggle a team member&apos;s admin status
  /// Operation: POST /teams/{id}/members/{userID}/admin
  /// </summary>
  Task<Message> ToggleTeamMemberAdminAsync(int id, int userId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a user from a team
  /// Operation: DELETE /teams/{id}/members/{username}
  /// </summary>
  Task<Message> DeleteAsync(int id, int username, CancellationToken cancellationToken = default);

}
