using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace XML_Manager;

public abstract class Parser : IParser
{
    protected IList<Person> People;
    public IList<Person> Find(Filters filters)
    {
        return People.Where(filters.ValidatePerson).ToList();

    }

    public abstract bool Load(Stream inputstream, XmlReaderSettings settings);
}