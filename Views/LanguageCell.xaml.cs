using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QuizzApp
{
	public class LanguageCell1 : ViewCell
	{
		public LanguageCell1 ()
		{
			Image image = CreateImageLayout;

			StackLayout viewLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				//Padding(50,0,0,0),
				Children = { image }
			};

			View = viewLayout;
		}

		static Image CreateImageLayout
		{
			get
			{
				Image image = new Image
				{
					HorizontalOptions = LayoutOptions.Center
				};

				image.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
				image.WidthRequest = image.HeightRequest = 110;
				return image;
			}
		}
	}
}

