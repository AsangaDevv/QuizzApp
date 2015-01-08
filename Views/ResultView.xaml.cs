using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace QuizzApp.View
{
	public class ResultView : ContentPage
	{
		public ResultView ()
		{

			Image map = new Image
			{
				Source = ImageSource.FromFile("mapIntro.png")

			};

			Image image = new Image
			{
				Source = ImageSource.FromFile("skattkista.png")

			};

			Label header = new Label {
				LineBreakMode = LineBreakMode.WordWrap,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Font = Fonts.LargeTitle,
				Text = "Gratulerar!"
			};

			Label resultText = new Label {
				LineBreakMode = LineBreakMode.WordWrap,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Font = Fonts.SmallTitle
			};

			int correctAnswers = App._answers.Where (a => a.Value == true).Count();

			resultText.Text = string.Format ("Du klarde {0} av {1}", correctAnswers, App._answers.Count);

			Grid menuLayout = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
				},
				Children = {
					{ CreateMapButton (), 0, 0 },
					{ CreateListButton (), 1, 0 }
				}
			};

			Content = new StackLayout {
				Children = {
					map,
					header,
					image,
					resultText,
					menuLayout
				}
			};
		}

		private Xamarin.Forms.View CreateMapButton()
		{
			Button mapButton = new Button
			{
				Text = "Map",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Color.Gray
			};

			//nextButton.Clicked += async (sender, e) =>  Navigation.PopAsync();
			mapButton.SetBinding(Button.CommandProperty, "NextCommand");
			mapButton.BindingContext = this;
			return mapButton;
		}

		private Xamarin.Forms.View CreateListButton()
		{
			Button listButton = new Button
			{
				Text = "List",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Color.Gray,
			};

			listButton.Clicked += async (sender, e) => await  Navigation.PushAsync(new LocationListView1());
			return listButton;
		}
	}
}

