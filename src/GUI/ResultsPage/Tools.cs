using XML_Manager;

namespace GUI;

public partial class ResultsPage
{
    public void Display()
    {
        for (int i = 0; i < People.Count; i++)
        {
            DisplayResult(People[i], i);
        }
    }

    private void CreateLabel(int row, int column, string text)
    {
        var label = new Label
        {
            Text = text,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        grid.SetRow(label, row);
        grid.SetColumn(label, column);
        grid.Children.Add(label);
    }

    private void DisplayResult(Person person, int row)
    {
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        CreateLabel(row, 0, person.Name.FirstName + " " + person.Name.LastName);
        CreateLabel(row, 1, person.Faculty);
        CreateLabel(row, 2, person.Chair);
        CreateLabel(row, 3, person.Role);
        CreateLabel(row, 4, person.Salary);
        CreateLabel(row, 5, person.TimeTenure);
    }
}