// FileHandler.cs
using System;
using System.IO;
using System.Text.Json;

public class FileHandler
{
    public static void SaveData<T>(T data, string fileName)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Failed to save data: {e.Message}");
        }
    }

    public static T LoadData<T>(string fileName)
    {
        try
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Failed to load data: {e.Message}");
            return default(T);
        }
        catch (JsonException e)
        {
            Console.WriteLine($"Failed to deserialize data: {e.Message}");
            return default(T);
        }
    }
}
