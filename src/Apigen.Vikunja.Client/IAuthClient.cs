using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for auth operations
/// </summary>
public interface IAuthClient
{
  /// <summary>
  /// Authenticate a user with OpenID Connect
  /// Operation: POST /auth/openid/{provider}/callback
  /// </summary>
  Task<AuthToken> GetTokenOpenidAsync(int provider, Apigen.Vikunja.Models.Callback callback);

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

}
