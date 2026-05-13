using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for user operations
/// </summary>
public partial interface IUserClient
{
  /// <summary>
  /// Get user information
  /// Operation: GET /user
  /// </summary>
  Task<UserWithSettings> ListAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Confirm the email of a new user
  /// Operation: POST /user/confirm
  /// </summary>
  Task<Message> ConfirmEmailAsync(Apigen.Vikunja.Models.EmailConfirm emailConfirm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Abort a user deletion request
  /// Operation: POST /user/deletion/cancel
  /// </summary>
  Task<Message> CancelAccountDeletionAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Confirm a user deletion request
  /// Operation: POST /user/deletion/confirm
  /// </summary>
  Task<Message> ConfirmAccountDeletionAsync(Apigen.Vikunja.Models.UserDeletionRequestConfirm userDeletionRequestConfirm, CancellationToken cancellationToken = default);

  /// <summary>
  /// Request the deletion of the user
  /// Operation: POST /user/deletion/request
  /// </summary>
  Task<Message> RequestAccountDeletionAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get current user data export
  /// Operation: GET /user/export
  /// </summary>
  Task<UserExportStatus> GetAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Download a user data export.
  /// Operation: POST /user/export/download
  /// </summary>
  Task<Message> DownloadDataExportAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Request a user data export.
  /// Operation: POST /user/export/request
  /// </summary>
  Task<Message> RequestDataExportAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change password
  /// Operation: POST /user/password
  /// </summary>
  Task<Message> ChangePasswordAsync(Apigen.Vikunja.Models.UserPassword userPassword, CancellationToken cancellationToken = default);

  /// <summary>
  /// Resets a password
  /// Operation: POST /user/password/reset
  /// </summary>
  Task<Message> ResetPasswordAsync(Apigen.Vikunja.Models.PasswordReset passwordReset, CancellationToken cancellationToken = default);

  /// <summary>
  /// Request password reset token
  /// Operation: POST /user/password/token
  /// </summary>
  Task<Message> RequestPasswordResetTokenAsync(Apigen.Vikunja.Models.PasswordTokenRequest passwordTokenRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Return user avatar setting
  /// Operation: GET /user/settings/avatar
  /// </summary>
  Task<UserAvatarProvider> GetUserSettingsAvatarAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Set the user&apos;s avatar
  /// Operation: POST /user/settings/avatar
  /// </summary>
  Task<Message> SetAvatarProviderAsync(Apigen.Vikunja.Models.UserAvatarProvider userAvatarProvider, CancellationToken cancellationToken = default);

  /// <summary>
  /// Upload a user avatar
  /// Operation: PUT /user/settings/avatar/upload
  /// </summary>
  Task<Message> UploadAvatarAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Update email address
  /// Operation: POST /user/settings/email
  /// </summary>
  Task<Message> UpdateEmailAsync(Apigen.Vikunja.Models.EmailUpdate emailUpdate, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change general user settings of the current user.
  /// Operation: POST /user/settings/general
  /// </summary>
  Task<Message> UpdateUserSettingsAsync(Apigen.Vikunja.Models.UserSettings userSettings, CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns the caldav tokens for the current user
  /// Operation: GET /user/settings/token/caldav
  /// </summary>
  Task<List<UserToken>> GetUserSettingsTokenCaldavAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Generate a caldav token
  /// Operation: PUT /user/settings/token/caldav
  /// </summary>
  Task<UserToken> GenerateCaldavTokenAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a caldav token by id
  /// Operation: DELETE /user/settings/token/caldav/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Totp setting for the current user
  /// Operation: GET /user/settings/totp
  /// </summary>
  Task<Totp> GetUserSettingsTotpAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Disable totp settings
  /// Operation: POST /user/settings/totp/disable
  /// </summary>
  Task<Message> DisableTotpAsync(Apigen.Vikunja.Models.Login login, CancellationToken cancellationToken = default);

  /// <summary>
  /// Enable a previously enrolled totp setting.
  /// Operation: POST /user/settings/totp/enable
  /// </summary>
  Task<Message> EnableTotpAsync(Apigen.Vikunja.Models.TotpPasscode totpPasscode, CancellationToken cancellationToken = default);

  /// <summary>
  /// Enroll a user into totp
  /// Operation: POST /user/settings/totp/enroll
  /// </summary>
  Task<Totp> EnrollTotpAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Totp QR Code
  /// Operation: GET /user/settings/totp/qrcode
  /// </summary>
  Task<JsonElement> GetUserSettingsTotpQrcodeAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all available time zones on this vikunja instance
  /// Operation: GET /user/timezones
  /// </summary>
  Task<JsonElement> GetUserTimezonesAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get users
  /// Operation: GET /users
  /// </summary>
  Task<List<User>> GetAsync(GetuserRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// User Avatar
  /// Operation: GET /{username}/avatar
  /// </summary>
  Task<Stream> GetAsync(string username, GetuserRequest? request = null, CancellationToken cancellationToken = default);

}
