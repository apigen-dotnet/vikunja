using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Vikunja.Models;

#nullable enable

namespace Apigen.Vikunja.Client;

/// <summary>
/// Interface for migration operations
/// </summary>
public interface IMigrationClient
{
  /// <summary>
  /// Detect CSV structure
  /// Operation: PUT /migration/csv/detect
  /// </summary>
  Task<CsvDetectionResult> DetectCsvStructureAsync();

  /// <summary>
  /// Import CSV file
  /// Operation: PUT /migration/csv/migrate
  /// </summary>
  Task<Message> MigrateFromCsvAsync();

  /// <summary>
  /// Preview CSV import
  /// Operation: PUT /migration/csv/preview
  /// </summary>
  Task<CsvPreviewResult> PreviewCsvImportAsync();

  /// <summary>
  /// Get CSV migration status
  /// Operation: GET /migration/csv/status
  /// </summary>
  Task<Status> GetCsvMigrationStatusAsync();

  /// <summary>
  /// Get the auth url from Microsoft Todo
  /// Operation: GET /migration/microsoft-todo/auth
  /// </summary>
  Task<AuthUrl> GetAsync();

  /// <summary>
  /// Migrate all projects, tasks etc. from Microsoft Todo
  /// Operation: POST /migration/microsoft-todo/migrate
  /// </summary>
  Task<Message> MigrateFromMicrosoftTodoAsync(Apigen.Vikunja.Models.MicrosoftTodoMigration microsoftTodoMigration);

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/microsoft-todo/status
  /// </summary>
  Task<Status> GetMigrationMicrosoftTodoStatusAsync();

  /// <summary>
  /// Import all projects, tasks etc. from a TickTick backup export
  /// Operation: PUT /migration/ticktick/migrate
  /// </summary>
  Task<Message> PutAsync();

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/ticktick/status
  /// </summary>
  Task<Status> GetMigrationTicktickStatusAsync();

  /// <summary>
  /// Get the auth url from todoist
  /// Operation: GET /migration/todoist/auth
  /// </summary>
  Task<AuthUrl> GetMigrationTodoistAuthAsync();

  /// <summary>
  /// Migrate all lists, tasks etc. from todoist
  /// Operation: POST /migration/todoist/migrate
  /// </summary>
  Task<Message> MigrateFromTodoistAsync(Apigen.Vikunja.Models.TodoistMigration todoistMigration);

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/todoist/status
  /// </summary>
  Task<Status> GetMigrationTodoistStatusAsync();

  /// <summary>
  /// Get the auth url from trello
  /// Operation: GET /migration/trello/auth
  /// </summary>
  Task<AuthUrl> GetMigrationTrelloAuthAsync();

  /// <summary>
  /// Migrate all projects, tasks etc. from trello
  /// Operation: POST /migration/trello/migrate
  /// </summary>
  Task<Message> MigrateFromTrelloAsync(Apigen.Vikunja.Models.TrelloMigration trelloMigration);

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/trello/status
  /// </summary>
  Task<Status> GetMigrationTrelloStatusAsync();

  /// <summary>
  /// Import all projects, tasks etc. from a Vikunja data export
  /// Operation: POST /migration/vikunja-file/migrate
  /// </summary>
  Task<Message> PostAsync();

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/vikunja-file/status
  /// </summary>
  Task<Status> GetMigrationVikunjaFileStatusAsync();

  /// <summary>
  /// Import all projects, tasks etc. from a WeKan board export
  /// Operation: PUT /migration/wekan/migrate
  /// </summary>
  Task<Message> MigrateFromWekanAsync();

  /// <summary>
  /// Get migration status
  /// Operation: GET /migration/wekan/status
  /// </summary>
  Task<Status> GetWekanMigrationStatusAsync();

}
