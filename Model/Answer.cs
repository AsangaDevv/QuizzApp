using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizzApp.Model
{	
	public class Answer : INotifyPropertyChanged
	{	
		public int Id{ get; set;}
		public string AnswerText{ get; set; }

		public Answer ()
		{

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

