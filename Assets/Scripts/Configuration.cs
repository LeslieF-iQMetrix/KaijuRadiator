using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public static class Configuration
{

    private static readonly string filePath = Application.persistentDataPath + "/config.cfg";
    public static readonly Dictionary<string, string> Settings = new Dictionary<string, string>();
    public static readonly string TeamcityUrl = "https://teamcity.iqmetrix.com/httpAuth/app/rest/";

    public static readonly string TEAMCITY_URL_FIELD = "Teamcity.URL";
    public static readonly string USERNAME_FIELD = "Username";
    public static readonly string PASSWORD_FIELD = "Password";

    public static void Initialize()
    {
        Debug.Log(filePath);
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
        if (!File.Exists(filePath))
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine(TEAMCITY_URL_FIELD + "=");
            writer.WriteLine(USERNAME_FIELD + "=");
            writer.WriteLine(PASSWORD_FIELD + "=");
            writer.Flush();
            writer.Close();
        }
        var configFile = new StreamReader(filePath);
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
    }

    public static IEnumerator Login ()
    {
        var login = String.Format ("{0}:{1}", Settings[USERNAME_FIELD], Settings[PASSWORD_FIELD]);
        var headers = new Dictionary<string, string> ();
        headers ["Authorization"] = "Basic " + System.Convert.ToBase64String (System.Text.Encoding.ASCII.GetBytes (login)); 
        var www = new WWW (Configuration.Settings[Configuration.TEAMCITY_URL_FIELD], null, headers);
        yield return www;
        if (www.error != null) {
            Debug.Log (www.error);
            yield break;
        }
        
        Debug.Log(string.Format ("Successful login by user {0}", Settings[USERNAME_FIELD]));
        GameObject.Find ("LoginGUI").AddComponent ("LoginMessage");
    }
}
