using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public static class FileManager
{
    public static bool WriteToFile(string filename, string contents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, filename);

        try
        {
            File.WriteAllText(fullPath, contents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static bool FileExists(string filename)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, filename);

        return File.Exists(fullPath);
    }

    public static bool LoadFromFile(string filename, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, filename);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return false;
        }
    }
}