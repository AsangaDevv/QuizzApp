using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QuizzApp.View
{
	public class LocationCell1 : ViewCell
	{
		public LocationCell1()
		{
			StackLayout locationLayout = CreateLocationTextLayout();
			Image image = CreateLocationImageLayout;

			StackLayout viewLayout = new StackLayout
			{
				Padding = new Thickness(20,0,0,0),
				Orientation = StackOrientation.Horizontal,
				Children = { image, locationLayout },
				BackgroundColor = Color.White
			};

			View = viewLayout;
		}

		/// <summary>
		///   Create a Xamarin.Forms image and bind it to the ImageUri property.
		/// </summary>
		/// <value>The create employee image layout.</value>
		static Image CreateLocationImageLayout
		{
			get
			{
				Image image = new Image
				{
					HorizontalOptions = LayoutOptions.Start
				};
				image.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
				image.WidthRequest = image.HeightRequest = 40;
				return image;
			}
		}

		static StackLayout CreateLocationTextLayout()
		{
			#region Create a Label for location text
			Label locationLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				TextColor = Color.Black
			};
			locationLabel.SetBinding(Label.TextProperty, "LocationText");
			#endregion

			StackLayout nameLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { locationLabel }
			};
			return nameLayout;
		}
	}
}

