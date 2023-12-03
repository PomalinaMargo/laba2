using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace XML_Manager;

public interface IParser
{
    public bool Load(Stream inputStream, XmlReaderSettings settings);
    public IList<Person> Find(Filters filters);
}
