using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;

namespace QuizzApp.View
{	
	public class ImageView : ContentPage
	{	
		readonly ICommand _nextCommand;
		string _imageSource = string.Empty;

		public ImageView (string imageUrlQ, string imageUrlA)
		{
			try
			{
//			_nextCommand = new Command (() => {
//				if (_imageSource == imageUrlQ) 
//				{
//					_imageSource = imageUrlA;
//					SetView();
//				}
//				else
//				{
//					Navigation.PopAsync();
//				}
//			});

			_imageSource = imageUrlQ;

			SetView ();
			}
			catch(Exception ex) {
				var xx = ex.Message;
			}
		}

		private void SetView()
		{
			try
			{
				Image image = new Image
				{
					Source = ImageSource.FromFile(_imageSource)

				};

//				Grid buttonsLayout = new Grid {
//					ColumnDefinitions = {
//						//					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
//						new ColumnDefinition { Width = new GridLength (2, GridUnitType.Star) },
//					},
//					Children = {
//						//					{ CreatePreviousButton (), 0, 0 },
//						{ CreateNextButton (), 0, 0 }
//					}
//				};

				Content = new StackLayout {
					Children = {
						image,
						//buttonsLayout
					}
				};
			}
			catch(Exception ex) {
				var xx = ex.Message;
			}
		}

//		public ICommand NextCommand { get { return _nextCommand; } }
//
//		private Xamarin.Forms.View CreateNextButton()
//		{
//			Button nextButton = new Button
//			{
//				Text = ">>",
//				BorderRadius = 5,
//				TextColor = Color.White,
//				BackgroundColor = Color.Gray
//			};
//
//			//nextButton.Clicked += async (sender, e) =>  Navigation.PopAsync();
//			nextButton.SetBinding(Button.CommandProperty, "NextCommand");
//			nextButton.BindingContext = this;
//			return nextButton;
//		}
	}
}

