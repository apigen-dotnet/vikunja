using System.Text.Json;
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
  Task<List<Team>> GetAsync(GetteamRequest? request = null);

  /// <summary>
  /// Creates a new team
  /// Operation: PUT /teams
  /// </summary>
  Task<Team> CreateTeamAsync(Apigen.Vikunja.Models.Team team);

  /// <summary>
  /// Gets one team
  /// Operation: GET /teams/{id}
  /// </summary>
  Task<Team> GetAsync(int id);

  /// <summary>
  /// Updates a team
  /// Operation: POST /teams/{id}
  /// </summary>
  Task<Team> UpdateTeamAsync(int id, Apigen.Vikunja.Models.Team team);

  /// <summary>
  /// Deletes a team
  /// Operation: DELETE /teams/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id);

  /// <summary>
  /// Add a user to a team
  /// Operation: PUT /teams/{id}/members
  /// </summary>
  Task<TeamMember> AddTeamMemberAsync(int id, Apigen.Vikunja.Models.TeamMember teamMember);

  /// <summary>
  /// Toggle a team member&apos;s admin status
  /// Operation: POST /teams/{id}/members/{userID}/admin
  /// </summary>
  Task<Message> ToggleTeamMemberAdminAsync(int id, int userId);

  /// <summary>
  /// Remove a user from a team
  /// Operation: DELETE /teams/{id}/members/{username}
  /// </summary>
  Task<Message> DeleteAsync(int id, int username);

}
