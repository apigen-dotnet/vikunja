using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for auth operations
/// </summary>
public partial interface IAuthClient
{
  /// <summary>
  /// Authenticate a user with OpenID Connect
  /// Operation: POST /auth/openid/{provider}/callback
  /// </summary>
  Task<AuthToken> GetTokenOpenIdAsync(int provider, Apigen.Vikunja.Models.Callback callback);

  /// <summary>
  /// Login
  /// Operation: POST /login
  /// </summary>
  Task<AuthToken> LoginAsync(Apigen.Vikunja.Models.Login login);

  /// <summary>
  /// Register
  /// Operation: POST /register
  /// </summary>
  Task<User> RegisterAsync(Apigen.Vikunja.Models.UserRegister userRegister);

  /// <summary>
  /// Logout
  /// Operation: POST /user/logout
  /// </summary>
  Task<Message> LogoutAsync();

  /// <summary>
  /// Renew link share token
  /// Operation: POST /user/token
  /// </summary>
  Task<AuthToken> PostAsync();

  /// <summary>
  /// Refresh user token
  /// Operation: POST /user/token/refresh
  /// </summary>
  Task<AuthToken> RefreshTokenAsync();

}
