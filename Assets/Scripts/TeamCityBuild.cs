using System.Xml;
using System.Xml.Serialization;
using System;

[XmlTypeAttribute(AnonymousType = true)]
public class TeamCityBuild
{
    public enum Status
    {
        [XmlEnumAttribute("SUCCESS")]
        SUCCESS,
        [XmlEnumAttribute("FAILURE")]
        FAILURE,
        [XmlEnumAttribute("ERROR")]
        ERROR
    }

    [XmlAttribute("id")]
    public string id;
    [XmlAttribute("buildTypeId")]
    public string buildTypeId;
    [XmlAttribute("number")]
    public string number;
    [XmlAttribute("status")]
    public Status status;
    [XmlAttribute("state")]
    public string state;
    [XmlAttribute("branchName")]
    public string branchName;
    [XmlAttribute("defaultBranch")]
    public bool defaultBranch;
    [XmlAttribute("href")]
    public string href;
    [XmlAttribute("webUrl")]
    public string webUrl;
}