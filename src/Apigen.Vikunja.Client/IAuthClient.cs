using System.Text.Json;
using System.Threading;
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
  Task<AuthToken> GetTokenOpenIdAsync(int provider, Apigen.Vikunja.Models.Callback callback, CancellationToken cancellationToken = default);

  /// <summary>
  /// Login
  /// Operation: POST /login
  /// </summary>
  Task<AuthToken> LoginAsync(Apigen.Vikunja.Models.Login login, CancellationToken cancellationToken = default);

  /// <summary>
  /// Register
  /// Operation: POST /register
  /// </summary>
  Task<User> RegisterAsync(Apigen.Vikunja.Models.UserRegister userRegister, CancellationToken cancellationToken = default);

  /// <summary>
  /// Logout
  /// Operation: POST /user/logout
  /// </summary>
  Task<Message> LogoutAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Renew link share token
  /// Operation: POST /user/token
  /// </summary>
  Task<AuthToken> PostAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Refresh user token
  /// Operation: POST /user/token/refresh
  /// </summary>
  Task<AuthToken> RefreshTokenAsync(CancellationToken cancellationToken = default);

}
