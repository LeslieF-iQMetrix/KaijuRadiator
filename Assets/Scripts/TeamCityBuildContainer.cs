using System.Collections.Generic;
using System.Xml.Serialization;

[XmlTypeAttribute(AnonymousType = true)]
[XmlRootAttribute("builds")]
public class TeamCityBuildContainer
{
    [XmlElementAttribute("build")]
    public List<TeamCityBuild> builds = new List<TeamCityBuild>();
}