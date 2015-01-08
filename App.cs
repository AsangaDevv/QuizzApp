using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

using QuizzApp.Model;
using QuizzApp.View;

namespace QuizzApp
{
	public class App
	{

		static ObservableCollection<Location> _locations;
		static ObservableCollection<Language> _languages;
		public static string _selectedLangauge = "En";
		public static List<Question> _questionList;
		public static int _currentQuestion = 0;
		public static Dictionary <string, bool> _answers = new Dictionary<string, bool>();

		public static ObservableCollection<Location> Locations
		{
			get
			{
				if (_locations != null)
				{
					return _locations;
				}
				List<Location> list = Location.GetLocationList ("QuizzApp.Android.LocationData.json");

				int counter = 1;

				_locations = new ObservableCollection<Location>(list);
				return _locations;
			}
		}

		public static ObservableCollection<Language> Languages
		{
			get
			{
				if (_languages != null)
				{
					return _languages;
				}
				List<Language> list = new List<Language>
				{
					new Language { LanguageName = "Sv", ImageUri = "SwedenFlag" },
					new Language { LanguageName = "En", ImageUri = "UnitedKFlag" },
					new Language { LanguageName = "Ty", ImageUri = "GermanyFlag" },
					new Language { LanguageName = "Dk", ImageUri = "DenmarkFlag" },


				};

				int counter = 1;

				_languages = new ObservableCollection<Language>(list);
				return _languages;
			}
		}

		public static Page GetMainPage ()
		{	
//			
			NavigationPage mainNav = new NavigationPage(new LanguageListView());
			return mainNav;


		}
	}
}

