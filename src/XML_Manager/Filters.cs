namespace XML_Manager;

public struct Filters
{
    public string Name { get; set; }

    public string Faculty { get; set; }

    public string Chair { get; set; }

    public string Salary { get; set; }

    public string TimeTenure { get; set; }

    public string Role { get; set; }

    public Filters()
    {
        Name = "";
        Faculty = "";
        Chair = "";
        Salary = "";
        TimeTenure = "";
        Role = "";
    }

    public readonly bool ValidatePerson(Person person)
    {
        var name = $"{person.Name.FirstName.ToLower()} {person.Name.LastName}".Contains(Name.ToLower());
        var role = person.Role.ToLower().Contains(Role.ToLower());
        var faculty = person.Faculty.ToLower().Contains(Faculty.ToLower());
        var chair = person.Chair.ToLower().Contains(Chair.ToLower());
        var salary = person.Salary.ToLower().Contains(Salary.ToLower());
        var timeTenure = person.TimeTenure.ToLower().Contains(TimeTenure.ToLower());

        return name && role && faculty && chair && salary && timeTenure;
    }
}
