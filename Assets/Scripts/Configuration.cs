using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public static class Configuration
{
    public static bool Loaded = false;

    public static readonly string FilePath = Application.persistentDataPath + "/config.cfg";

    public static readonly Dictionary<string, string> Settings = new Dictionary<string, string>();
    public static readonly string TEAMCITY_URL_FIELD = "Teamcity.URL";
    public static readonly string USERNAME_FIELD = "Username";
    public static readonly string PASSWORD_FIELD = "Password";

    public static void Initialize()
    {
        Debug.Log(FilePath);
        if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
        }
        if (!File.Exists(FilePath))
        {
            var writer = new StreamWriter(FilePath);
            writer.WriteLine(TEAMCITY_URL_FIELD + "=" + "https://teamcity.iqmetrix.com/httpAuth/app/rest/");
            writer.WriteLine(USERNAME_FIELD + "=");
            writer.WriteLine(PASSWORD_FIELD + "=");
            writer.Flush();
            writer.Close();
        }
        var configFile = new StreamReader(FilePath);
        string line;
        while ((line = configFile.ReadLine()) != null)
        {
            string[] tokens = line.Split('=');
            Debug.Log(tokens[0] + " " + tokens[1]);
            if (tokens.Length == 2)
            {
                Settings [tokens [0]] = tokens [1];
            }
        }
        Loaded = true;
    }
}
