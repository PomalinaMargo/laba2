using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace XML_Manager;

public class SAXParser : Parser
{
    public SAXParser()
    {
        People = new List<Person>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        People.Clear();
        try
        {
            var reader = XmlReader.Create(inputStream, settings);
            while (reader.Read())
            {
                if (!(reader.NodeType == XmlNodeType.Element && reader.Name == "Person"))
                {
                    continue;
                }

                var person = new Person();
                SkipToText(reader);
                person.Name.FirstName = reader.Value;
                SkipToText(reader);
                person.Name.LastName = reader.Value;
                SkipToText(reader);
                person.Faculty = reader.Value;
                SkipToText(reader);
                person.Chair = reader.Value;
                SkipToText(reader);
                person.Role = reader.Value;
                SkipToText(reader);
                person.Salary = reader.Value;
                SkipToText(reader);
                person.TimeTenure = reader.Value;

                People.Add(person);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void SkipToText(XmlReader reader)
    {
        do
        {
            if (!reader.Read())
            {
                throw new Exception();
            }
        } while (reader.NodeType != XmlNodeType.Text);
    }
}
