using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

namespace QuizzApp.Model
{
	public class Location: INotifyPropertyChanged
	{
		string _locationText;
		string _imageUri;
		string _questionFile;

		public Location()
		{
			ImageUri = "VC";
		}

		public string LocationText { get { return _locationText;} 
		
			set
			{
				_locationText = value;
				OnPropertyChanged();
				OnPropertyChanged("LocationText");
			}
		}

		public string QuestionFileName{ get; set; }

		public string ImageUri
		{
			get { return _imageUri; }
			set
			{
				if (value.Equals(_imageUri, StringComparison.Ordinal))
				{
					return;
				}
				_imageUri = value;
				OnPropertyChanged();
			}
		}

		public static List<Location> GetLocationList(string fileName)
		{
			var lList = new List<Location> ();
			var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

			using (var reader = new System.IO.StreamReader (stream)) 
			{
				var jsonData = reader.ReadToEnd ();

				lList  =  JsonConvert.DeserializeObject<List<Location>>(jsonData);
			}

			return lList;
		}

		public event PropertyChangedEventHandler PropertyChanged; // Required by INotifyPropertyChanged


		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

