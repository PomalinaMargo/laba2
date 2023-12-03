using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : Parser
{
    public LINQParser()
    {
        People = new List<Person>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        XDocument document;
        using var reader = XmlReader.Create(inputStream, settings);
        try
        {
            People.Clear();
            document = XDocument.Load(reader);
            if (document == null)
            {
                return true;
            }
            var result = from person in document.Descendants("Person")
                         select
            new Person
            {
                Name = new Person.FullName
                {
                    FirstName = person.Element("Name")?.Element("FirstName")?.Value ?? "",
                    LastName = person.Element("Name")?.Element("LastName")?.Value ?? ""
                },
                Faculty = person.Element("Faculty")?.Value ?? "",
                Chair = person.Element("Chair")?.Value ?? "",
                Role = person.Element("Role")?.Value ?? "",
                Salary = person.Element("Salary")?.Value ?? "",
                TimeTenure = person.Element("TimeTenure")?.Value ?? "",
            };
            foreach (var person in result)
            {
                People.Add(person);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
