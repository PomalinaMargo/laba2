using XML_Manager;
using System.Diagnostics;

namespace GUI;

public partial class MainPage : ContentPage
{
	private Filters CollectFilters()
	{
		var filters = new Filters();
		if (NameCheckbox.IsChecked)
		{
			filters.Name = NameEntry.Text ?? "";
		}

		if (FacultyCheckbox.IsChecked)
		{
			filters.Faculty = FacultyEntry.Text ?? "";
		}

		if (ChairCheckbox.IsChecked)
		{
			filters.Chair = ChairEntry.Text ?? "";
		}

		if (RoleCheckbox.IsChecked)
		{
			filters.Role = RoleEntry.Text ?? "";
		}

		if (SalaryCheckbox.IsChecked)
		{
			filters.Salary = SalaryEntry.Text ?? "";
		}

		if (TimeTenureCheckbox.IsChecked)
		{
			filters.TimeTenure = TimeTenureEntry.Text ?? "";
		}

		return filters;
	}

	private void ClearFilters()
	{
		NameEntry.Text = "";
		NameCheckbox.IsChecked = false;
		ChairEntry.Text = "";
		ChairCheckbox.IsChecked = false;
		FacultyEntry.Text = "";
		FacultyCheckbox.IsChecked = false;
		RoleEntry.Text = "";
		RoleCheckbox.IsChecked = false;
		SalaryEntry.Text = "";
		SalaryCheckbox.IsChecked = false;
		TimeTenureEntry.Text = "";
		TimeTenureCheckbox.IsChecked = false;
	}

	private async Task ValidateFile()
	{
		if (parser == null || ChosenFile == null)
		{
			return;
		}
		if (parser.Load(await ChosenFile.OpenReadAsync(), validationSettings))
		{
			return;
		}

		StatusLabel.Text = "File is not chosen";
		StatusLabel.TextColor = Color.FromRgb(180, 30, 30);
		ChosenFile = null;
		await DisplayAlert("Invalid file", "The file does not satisfy XSD Schema", "Ok");
	}
	private async Task CopyFileToAppDataDirectory(string filename)
	{
		using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);

		string targetFile = Path.Combine(AppDataDirectory, filename);

		using FileStream outputStream = File.Create(targetFile);
		await inputStream.CopyToAsync(outputStream);
	}

	private void InitAppData()
	{
		AppDataDirectory = Path.Combine(FileSystem.AppDataDirectory);
		if (!Path.Exists(AppDataDirectory))
		{
			while (!Path.Exists(AppDataDirectory))
			{
				AppDataDirectory = Directory.GetParent(AppDataDirectory).FullName;
			}
			AppDataDirectory = Path.Combine(AppDataDirectory, "ChangeThisDirName");
			if (!Path.Exists(AppDataDirectory))
			{
				Directory.CreateDirectory(AppDataDirectory);
			}
		}
	}
}
