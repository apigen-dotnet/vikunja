using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for user operations
/// </summary>
public interface IUserClient
{
  /// <summary>
  /// Get user information
  /// Operation: GET /user
  /// </summary>
  Task<UserWithSettings> ListAsync();

  /// <summary>
  /// Confirm the email of a new user
  /// Operation: POST /user/confirm
  /// </summary>
  Task<Message> ConfirmEmailAsync(Apigen.Vikunja.Models.EmailConfirm emailConfirm);

  /// <summary>
  /// Abort a user deletion request
  /// Operation: POST /user/deletion/cancel
  /// </summary>
  Task<Message> CancelAccountDeletionAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation);

  /// <summary>
  /// Confirm a user deletion request
  /// Operation: POST /user/deletion/confirm
  /// </summary>
  Task<Message> ConfirmAccountDeletionAsync(Apigen.Vikunja.Models.UserDeletionRequestConfirm userDeletionRequestConfirm);

  /// <summary>
  /// Request the deletion of the user
  /// Operation: POST /user/deletion/request
  /// </summary>
  Task<Message> RequestAccountDeletionAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation);

  /// <summary>
  /// Get current user data export
  /// Operation: GET /user/export
  /// </summary>
  Task<UserExportStatus> GetAsync();

  /// <summary>
  /// Download a user data export.
  /// Operation: POST /user/export/download
  /// </summary>
  Task<Message> DownloadDataExportAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation);

  /// <summary>
  /// Request a user data export.
  /// Operation: POST /user/export/request
  /// </summary>
  Task<Message> RequestDataExportAsync(Apigen.Vikunja.Models.UserPasswordConfirmation userPasswordConfirmation);

  /// <summary>
  /// Change password
  /// Operation: POST /user/password
  /// </summary>
  Task<Message> ChangePasswordAsync(Apigen.Vikunja.Models.UserPassword userPassword);

  /// <summary>
  /// Resets a password
  /// Operation: POST /user/password/reset
  /// </summary>
  Task<Message> ResetPasswordAsync(Apigen.Vikunja.Models.PasswordReset passwordReset);

  /// <summary>
  /// Request password reset token
  /// Operation: POST /user/password/token
  /// </summary>
  Task<Message> RequestPasswordResetTokenAsync(Apigen.Vikunja.Models.PasswordTokenRequest passwordTokenRequest);

  /// <summary>
  /// Return user avatar setting
  /// Operation: GET /user/settings/avatar
  /// </summary>
  Task<UserAvatarProvider> GetUserSettingsAvatarAsync();

  /// <summary>
  /// Set the user&apos;s avatar
  /// Operation: POST /user/settings/avatar
  /// </summary>
  Task<Message> SetAvatarProviderAsync(Apigen.Vikunja.Models.UserAvatarProvider userAvatarProvider);

  /// <summary>
  /// Upload a user avatar
  /// Operation: PUT /user/settings/avatar/upload
  /// </summary>
  Task<Message> UploadAvatarAsync();

  /// <summary>
  /// Update email address
  /// Operation: POST /user/settings/email
  /// </summary>
  Task<Message> UpdateEmailAsync(Apigen.Vikunja.Models.EmailUpdate emailUpdate);

  /// <summary>
  /// Change general user settings of the current user.
  /// Operation: POST /user/settings/general
  /// </summary>
  Task<Message> UpdateUserSettingsAsync(Apigen.Vikunja.Models.UserSettings userSettings);

  /// <summary>
  /// Returns the caldav tokens for the current user
  /// Operation: GET /user/settings/token/caldav
  /// </summary>
  Task<List<UserToken>> GetUserSettingsTokenCaldavAsync();

  /// <summary>
  /// Generate a caldav token
  /// Operation: PUT /user/settings/token/caldav
  /// </summary>
  Task<UserToken> GenerateCaldavTokenAsync();

  /// <summary>
  /// Delete a caldav token by id
  /// Operation: DELETE /user/settings/token/caldav/{id}
  /// </summary>
  Task<Message> DeleteAsync(int id);

  /// <summary>
  /// Totp setting for the current user
  /// Operation: GET /user/settings/totp
  /// </summary>
  Task<Totp> GetUserSettingsTotpAsync();

  /// <summary>
  /// Disable totp settings
  /// Operation: POST /user/settings/totp/disable
  /// </summary>
  Task<Message> DisableTotpAsync(Apigen.Vikunja.Models.Login login);

  /// <summary>
  /// Enable a previously enrolled totp setting.
  /// Operation: POST /user/settings/totp/enable
  /// </summary>
  Task<Message> EnableTotpAsync(Apigen.Vikunja.Models.TotpPasscode totpPasscode);

  /// <summary>
  /// Enroll a user into totp
  /// Operation: POST /user/settings/totp/enroll
  /// </summary>
  Task<Totp> EnrollTotpAsync();

  /// <summary>
  /// Totp QR Code
  /// Operation: GET /user/settings/totp/qrcode
  /// </summary>
  Task<JsonElement> GetUserSettingsTotpQrcodeAsync();

  /// <summary>
  /// Get all available time zones on this vikunja instance
  /// Operation: GET /user/timezones
  /// </summary>
  Task<JsonElement> GetUserTimezonesAsync();

  /// <summary>
  /// Get users
  /// Operation: GET /users
  /// </summary>
  Task<List<User>> GetAsync(GetuserRequest? request = null);

  /// <summary>
  /// User Avatar
  /// Operation: GET /{username}/avatar
  /// </summary>
  Task<Stream> GetAsync(string username, GetuserRequest? request = null);

}
