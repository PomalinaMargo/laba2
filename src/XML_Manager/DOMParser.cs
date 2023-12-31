using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace XML_Manager;

public class DOMParser : Parser
{
    public DOMParser()
    {
        People = new List<Person>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        People.Clear();
        var document = new XmlDocument();
        using var reader = XmlReader.Create(inputStream, settings);
        try
        {
            document.Load(reader);
            if (document == null || document.DocumentElement == null)
            {
                return true;
            }
            var serializer = new XmlSerializer(typeof(Person));
            foreach (XmlNode child in document.DocumentElement.ChildNodes)
            {
                if (serializer.Deserialize(new StringReader(child.OuterXml)) is Person person)
                {
                    People.Add(person);
                }
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}
