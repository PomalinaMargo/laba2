namespace XML_Manager;

public class Person
{
    public class FullName
    {
        public FullName()
        {
            FirstName = "";
            LastName = "";
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
    public Person()
    {
        Name = new();
        Faculty = "";
        Chair = "";
        Salary = "";
        TimeTenure = "";
        Role = "";
    }
    public FullName Name { get; set; }

    public string Faculty { get; set; }

    public string Chair { get; set; }

    public string Salary { get; set; }

    public string TimeTenure { get; set; }

    public string Role { get; set; }
}
