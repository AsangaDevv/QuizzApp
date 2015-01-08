using System.Collections.ObjectModel;

using Xamarin.Forms;

using QuizzApp.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


namespace QuizzApp.View
{
	public class LanguageListView : ContentPage
	{
		ListView _languageList;
		ObservableCollection<Language> _languages = new ObservableCollection<Language>();
		ToolbarItem _loginToolbarButton;

		public LanguageListView()
		{
			LoadImagesForDisplay();
			//Title = "Question List";
			//NavigationPage.SetHasNavigationBar (this, false);
			CreateQuestionListView();

			Content = _languageList;
		}


		void LoadImagesForDisplay()
		{

			if (_languages.Count == 0)
			{
				_languages = App.Languages;
			}

		}

		void CreateQuestionListView()
		{
			_languageList = new ListView
			{
				RowHeight = 120,
				HorizontalOptions =  LayoutOptions.Center,
				ItemTemplate = new DataTemplate(typeof(LanguageCell1))
			};
			_languageList.ItemSelected  += LangaugeListOnItemSelected;
		}

		/// <summary>
		///   This method is invoked when the user selects an employee. Will open up the EmployeeDetailsPage for that employee.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArg">Event argument.</param>
		async void LangaugeListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView listView = (ListView)sender;
			if (listView.SelectedItem == null)
			{
				return;
			}

			var langItem = (Language)listView.SelectedItem;
			App._selectedLangauge = langItem.LanguageName;

			await Navigation.PushAsync(new LocationListView1());
			listView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			// This method is invoked by Xamarin.Forms at some point when the 
			// page is being displayed.
			base.OnAppearing();
			LoadImagesForDisplay();
			_languageList.ItemsSource = _languages;

			//			if (App.IsLoggedIn)
			//			{
			//				// Don't have to do anything. 
			//			}
			//			else
			//			{
			//				ToolbarItems.Add(_loginToolbarButton);
			//			}
		}
	}
}

