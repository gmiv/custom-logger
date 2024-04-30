using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json; // For JSON serialization, Newtonsoft.Json is a commonly used library

public static class CustomLogger
{
    private static string logFilePath = "logs.txt"; // Replace with an appropriate file path
    private static HttpClient httpClient = new HttpClient();

    public enum LogType { Log, Warning, Error }

    public static void Log(string message)
    {
        var logData = CreateLogData(message, LogType.Log);
        ProcessLog(logData);
    }

    public static void Warn(string message)
    {
        var logData = CreateLogData(message, LogType.Warning);
        ProcessLog(logData);
    }

    public static void Error(string message)
    {
        var logData = CreateLogData(message, LogType.Error);
        ProcessLog(logData);
    }

    private static Dictionary<string, object> CreateLogData(string message, LogType logType)
    {
        return new Dictionary<string, object>
        {
            {"Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
            {"LogType", logType.ToString()},
            {"Message", message},
            // Add more contextual data here as needed
        };
    }

    private static void ProcessLog(Dictionary<string, object> logData)
    {
        string jsonLog = JsonConvert.SerializeObject(logData);

        Console.WriteLine(jsonLog); // Standard console logging

        WriteToFile(jsonLog);
        SendToServer(jsonLog);
    }

    private static void WriteToFile(string message)
    {
        File.AppendAllText(logFilePath, message + Environment.NewLine);
    }

    private static async void SendToServer(string message)
    {
        // Implement server logging logic here
    }
}
