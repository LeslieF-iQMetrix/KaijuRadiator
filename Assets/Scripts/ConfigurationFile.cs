using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public static class ConfigurationFile {

	private static string filePath = "/sdcard/KaijuRadiator/config.cfg";

	public static Dictionary<string, string> Options = new Dictionary<string, string>();
	public static readonly string TeamcityUrl = "https://teamcity.iqmetrix.com/httpAuth/app/rest/";
	public static string username = "Username";
	public static string password = "Password";

	public static void Initialize()
	{
		TextReader configFile;
		if (!File.Exists (filePath)) {
			File.Create(filePath);
		}

		configFile = new StreamReader(filePath);
		string line;
		while ((line = configFile.ReadLine()) != null) 
		{
			string[] tokens = line.Split('=');
			if (tokens.Length == 2)
			{
				Options[tokens[0]] = tokens[1];
			}
		}
	}
}
