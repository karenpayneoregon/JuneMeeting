namespace VisualStudioExternalToolsApp.Classes;

/// <summary>
/// Provides a singleton implementation for managing environment settings related to Visual Studio external tools.
/// </summary>
/// <remarks>
/// This class encapsulates properties and logic for handling the file path, directory existence, 
/// and file name of the settings file used by Visual Studio external tools. 
/// It ensures that only one instance of the settings is created and shared across the application.
/// </remarks>
public sealed class EnvironmentSettings
{
    private static readonly Lazy<EnvironmentSettings> Lazy = new(() => new EnvironmentSettings());
    public static EnvironmentSettings Instance => Lazy.Value;

    public string FilePath { get; set; }
    public bool DirectoryExists { get; set; }
    public string FileName { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnvironmentSettings"/> class.
    /// This constructor is private to enforce the singleton pattern.
    /// It sets the default file path, checks if the directory exists, 
    /// and constructs the full file name for the settings file.
    /// </summary>
    private EnvironmentSettings()
    {
        var userName = Environment.UserName;
        FilePath = $"C:\\Users\\{userName}\\AppData\\Local\\Microsoft\\VisualStudio\\17.0_f56beab6\\Settings";
        DirectoryExists = Directory.Exists(FilePath);
        FileName = Path.Combine(FilePath, "CurrentSettings.vssettings");
    }
}