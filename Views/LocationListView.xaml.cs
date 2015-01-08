using System.Collections.ObjectModel;

using Xamarin.Forms;

using QuizzApp.Model;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;


namespace QuizzApp.View
{
	public class LocationListView1 : ContentPage
	{
		ListView _locationList;
		ObservableCollection<Location> _locations = new ObservableCollection<Location>();

		public LocationListView1()
		{
			LoadLocationForDisplay ();

			//CreateLoginToolbarButton();
			CreateLocationListView ();
			NavigationPage.SetHasNavigationBar (this, false);
			Content = _locationList;
			BackgroundColor = Color.White;
			Padding = new Thickness (0, 15, 0, 0);
		}
//		void CreateLoginToolbarButton()
//		{
//			if (_loginToolbarButton != null)
//			{
//				return;
//			}
//
//			// There is a bug with Android which prevents the use of null for the iconName.
//			string iconName = Device.OnPlatform(null, "ic_action_content_new.png", null);
////			_loginToolbarButton = new ToolbarItem("Login", iconName, async () => {
////				ToolbarItems.Remove(_loginToolbarButton);
////				await  Navigation.PushAsync(new LoginPage());
////			});
//		}



		void LoadLocationForDisplay()
		{

				if (_locations.Count == 0)
				{
					_locations = App.Locations;
				}

		}

		void CreateLocationListView()
		{
			_locationList = new ListView
			{
				RowHeight = 50,
				ItemTemplate = new DataTemplate(typeof(LocationCell1))
			};

			_locationList.ItemSelected  += LocationListOnItemSelected;
		}


		async void LocationListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView listView = (ListView)sender;
			if (listView.SelectedItem == null)
			{
				return;
			}

			var loc = (Location)listView.SelectedItem;

			App._questionList = QuestionList.CreateQuestionList(string.Format("QuizzApp.Android.{0}", loc.QuestionFileName));

			await Navigation.PushAsync(new QuestionView());
			listView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			// This method is invoked by Xamarin.Forms at some point when the 
			// page is being displayed.
			base.OnAppearing();
			LoadLocationForDisplay();
			_locationList.ItemsSource = _locations;

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

