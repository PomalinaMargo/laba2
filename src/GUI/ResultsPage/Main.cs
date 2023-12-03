using XML_Manager;

namespace GUI;

public partial class ResultsPage : ContentPage
{
    private IList<Person> People { get; set; }
    public ResultsPage(IList<Person> people)
    {
        InitializeComponent();
        People = people;
        Display();
    }
}
