using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QuizzApp.Model
{
	public class Question: INotifyPropertyChanged
	{
		string _headLine;
		string _questionText;
		string _imageUriQ;
		string _imageUriA;
		List<Answer> _answers;
		int _correctAnswer;

		public Question()
		{
			//ImageUri = "VC";
		}

		public string QuestionText { get { return _questionText;} 
			set
			{
				_questionText = value;
				OnPropertyChanged();
				OnPropertyChanged("QuestionText");
			}
		}

		public string HeadLine { get { return _headLine;} 
			set
			{
				_headLine = value;
				OnPropertyChanged();
				OnPropertyChanged("HeadLine");
			}
		}


		public int CorrectAnswer { get { return _correctAnswer;} 
			set
			{
				_correctAnswer = value;
				OnPropertyChanged();
				OnPropertyChanged("CorrectAnswer");
			}
		}

		public string QuestionImage { get { return _imageUriQ;} 
			set
			{
				_imageUriQ = value;
				OnPropertyChanged();
				OnPropertyChanged("QuestionImage");
			}
		}

		public string AnswerImage { get { return _imageUriA;} 
			set
			{
				_imageUriA = value;
				OnPropertyChanged();
				OnPropertyChanged("AnswerImage");
			}
		}

		public List<Answer> Answers { get { return _answers;} 
			set
			{
				_answers = value;
				OnPropertyChanged();
				OnPropertyChanged("Answers");
			}
		}


//		public string ImageUri
//		{
//			get { return _imageUri; }
//			set
//			{
//				if (value.Equals(_imageUri, StringComparison.Ordinal))
//				{
//					return;
//				}
//				_imageUri = value;
//				OnPropertyChanged();
//			}
//		}
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

