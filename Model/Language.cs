using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace QuizzApp.Model
{
	public class Language: INotifyPropertyChanged
	{
		string _language;
		string _imageUri;

		public Language()
		{
			ImageUri = "VC";
		}

		public string LanguageName { get { return _language;} 
		
			set
			{
				_language = value;
				OnPropertyChanged();
				OnPropertyChanged("LanguageName");
			}
		}


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
		public event PropertyChangedEventHandler PropertyChanged; // Required by INotifyPropertyChanged

		/// <summary>
		///   This is a helper method that will raise the PropertyChanged event when a property is changed.
		/// </summary>
		/// <param name="propertyName">Property name. If null, then this property will hold the name of the member that invoked it.</param>
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

