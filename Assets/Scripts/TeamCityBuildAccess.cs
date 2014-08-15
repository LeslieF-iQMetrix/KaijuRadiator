using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class TeamCityBuildAccess : MonoBehaviour {

    private string BuildInfoUrl = "builds";
    private TeamCityAccess instance;

    private TeamCityBuildContainer _buildContainer;

	// Use this for initialization
	void Start () {
        instance = ((TeamCityAccess) GetComponent("TeamCityAccess"));
        StartCoroutine(GetBuildInfoXml());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GetBuildInfoXml()
    {
        while (Configuration.Loaded == false)
            yield return new WaitForSeconds(0.1f);
        instance.StartCoroutine(instance.Access(BuildInfoUrl));
        while (TeamCityAccess.isLoadingPage)
            yield return new WaitForSeconds(0.1f);
        var buildInfoXml = instance.response;

        var serializer = new XmlSerializer(typeof(TeamCityBuildContainer));
        var reader = new StringReader(buildInfoXml);
        _buildContainer = serializer.Deserialize(reader) as TeamCityBuildContainer;
    }
}
