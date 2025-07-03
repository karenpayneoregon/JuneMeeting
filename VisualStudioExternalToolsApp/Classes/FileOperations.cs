using System.Diagnostics;

namespace VisualStudioExternalToolsApp.Classes;
public class FileOperations
{
    /// <summary>
    /// Opens the specified settings file in Visual Studio Code.
    /// </summary>
    /// <param name="filePath">
    /// The full path to the settings file to be opened. If the file does not exist, 
    /// a message will be displayed indicating that the file was not found.
    /// </param>
    /// <remarks>
    /// This method attempts to launch Visual Studio Code with the specified file. 
    /// If an error occurs during the process, an error message will be displayed in the console.
    /// </remarks>

    public void OpenSettingsFile(string filePath)
    {

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Settings file not found.");
            return;
        }

        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
                Arguments = $"\"{filePath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                CreateNoWindow = true
            };

            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to open settings file in VS Code. Error: {ex.Message}");
        }
    }
}

