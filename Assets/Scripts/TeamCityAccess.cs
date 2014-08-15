using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamCityAccess : MonoBehaviour {

    public string response = "";
    public static bool isLoadingPage { get; private set; }

	// Use this for initialization
	void Start () {
        isLoadingPage = false;
        Configuration.Initialize();
        StartCoroutine(Login());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Login()
    {
        StartCoroutine(Access());
        while (isLoadingPage)
            yield return new WaitForSeconds(0.1f);

        if (response == null)
        {
            Debug.LogError("Team City login failed. Please edit " + Configuration.FilePath + " to include valid credentials");
            Application.Quit();
        }
        Debug.Log(string.Format ("Successful login by user {0}", Configuration.Settings[Configuration.USERNAME_FIELD]));
    }

    public IEnumerator Access (string targetInfoUrl = "")
    {
        isLoadingPage = true;
        response = null;
        var login = String.Format ("{0}:{1}", Configuration.Settings[Configuration.USERNAME_FIELD], Configuration.Settings[Configuration.PASSWORD_FIELD]);
        var headers = new Dictionary<string, string> ();
        headers ["Authorization"] = "Basic " + System.Convert.ToBase64String (System.Text.Encoding.ASCII.GetBytes (login)); 
        var www = new WWW (Configuration.Settings[Configuration.TEAMCITY_URL_FIELD] + targetInfoUrl, null, headers);
        yield return www;
        if (www.error != null) {
            Debug.Log (www.error);
            yield break;
        }
        response = www.text;
        isLoadingPage = false;
    }
}
