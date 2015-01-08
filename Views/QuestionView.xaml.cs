using System;
using System.Collections.Generic;
using Xamarin.Forms;
using QuizzApp.Model;
using System.Windows.Input;

namespace QuizzApp.View
{
	public partial class QuestionView : ContentPage
	{
		readonly ICommand _nextCommand;
		readonly ICommand _preCommand;
		ListView _answerList;
		Question _question;
		bool _answerd = false;

		public QuestionView ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
			_answerd = false;
			try
			{


			#region Initialize the command that will be execute when the user clicks on the delete button.
			_nextCommand = new Command (() => 
			{
						if(_answerd)
						{
							if (App._currentQuestion + 1 < App._questionList.Count) 
							{
								App._currentQuestion++;
								_answerd = false;
								SetView();
								//
							}
							else
							{
								Navigation.PushModalAsync (new ResultView ());
							}
						}
			});

			_preCommand = new Command (() => {

				if (App._currentQuestion > 0) {
					App._currentQuestion--;
				SetView();
				}
			});

			#endregion

				SetView();
			
		}
			catch(Exception ex)
			{
				var tt = ex.Message;
			}
		}


		private void SetView()
		{
			_question = App._questionList [App._currentQuestion];
			Padding = new Thickness (20);
			BindingContext = _question;

			Image map = new Image
			{
				Source = ImageSource.FromFile("mapIntro.png")
			};

			Image correct = new Image
			{
				Source = ImageSource.FromFile("mynt.png"),
			};

			Image incorrect = new Image
			{
				Source = ImageSource.FromFile("doskalle.png"),
			};

			Image questionImage = new Image();
			var tapGesture1 = new TapGestureRecognizer {

				TappedCallback = (v, o) => Navigation.PushAsync(new ImageView(_question.QuestionImage, _question.AnswerImage)),
				//TappedCallback = (v, o) => questionImage.WidthRequest = 600,
				NumberOfTapsRequired = 1,
				
			};

			if (_question.QuestionImage != null) 
			{
				questionImage = new Image
				{
					Source = ImageSource.FromFile(_question.QuestionImage),
					WidthRequest = HeightRequest = 100,
				};

				questionImage.GestureRecognizers.Add (tapGesture1);
			}

			Label header = new Label {
				LineBreakMode = LineBreakMode.WordWrap,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Font = Fonts.SmallTitle
			};

			header.SetBinding (Label.TextProperty, "QuestionText");


			Grid buttonsLayout = new Grid {
				ColumnDefinitions = {
//					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (2, GridUnitType.Star) },
				},
				Children = {
//					{ CreatePreviousButton (), 0, 0 },
					{ CreateNextButton (), 0, 0 }
				}
			};

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

			_answerList = new ListView 
			{
				ItemsSource = _question.Answers,
				RowHeight = 50,

				ItemTemplate = new DataTemplate (() => 
				{
					// Create views with bindings for displaying each property.
					Label nameLabel = new Label ();
					nameLabel.SetBinding (Label.TextProperty, "AnswerText");
					nameLabel.Font = Fonts.Twitter;

					// Return an assembled ViewCell.
					return new ViewCell {
						View = new StackLayout {
							Padding = new Thickness (0, 5),
							Orientation = StackOrientation.Horizontal,
							Children = {
								new StackLayout {
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,

									Children = {
										nameLabel
									}
								}
							}
						}
					};
				})

			};

			var absLayout = new AbsoluteLayout();

			absLayout.Children.Add(map, new Point(0,0));
			var x = 10;
			var y = 10;

			foreach(var answer in App._answers)
			{
				if (answer.Value == true) {
					absLayout.Children.Add (new Image
						{
							Source = ImageSource.FromFile("mynt.png"),
						}, new Point (x, y));
				} else {
					absLayout.Children.Add (new Image
						{
							Source = ImageSource.FromFile("doskalle.png"),
						}, new Point (x, y));
				}

				x = x + 30;
			}

			var q = new StackLayout{ 
				Children = {
					header,
					_answerList
				}
			};

			var scrollView = new ScrollView {
				Content = q
			};

			_answerList.ItemSelected  += AnswerListOnItemSelected;
			// Add the controls to a StackLayout 
			Content = new StackLayout {

				Children = {
					absLayout,
					questionImage,
					scrollView,
					buttonsLayout,
					menuLayout
				},
			};
		}


		public ICommand NextCommand { get { return _nextCommand; } }
		public ICommand PreviousCommand { get { return _preCommand; } }


		private Xamarin.Forms.View CreateNextButton()
		{
			Button nextButton = new Button
			{
				Text = ">>",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Color.Gray
			};

			//nextButton.Clicked += async (sender, e) =>  Navigation.PopAsync();
			nextButton.SetBinding(Button.CommandProperty, "NextCommand");
			nextButton.BindingContext = this;
			return nextButton;
		}

		private Xamarin.Forms.View  CreatePreviousButton()
		{
			// First create the button.
			Button preButton = new Button
			{
				Text = "<<",
				BorderRadius = 5,
				TextColor = Color.White,
				BackgroundColor = Color.Gray
			};

			// Setup data binding.
			preButton.SetBinding(Button.CommandProperty, "PreviousCommand");
			preButton.BindingContext = this;
			return preButton;
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

			listButton.Clicked += async (sender, e) => await  Navigation.PopAsync();
			return listButton;
		}

		async void AnswerListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			ListView listView = (ListView)sender;
			if (listView.SelectedItem == null)
			{
				return;
			}

			var ans = (Answer)listView.SelectedItem;
			_answerd = true;
			try
			{
				if (ans.Id == _question.CorrectAnswer) 
				{
					App._answers.Add (_question.HeadLine, true);
					//Add win image


				} 
				else 
				{
					App._answers.Add (_question.HeadLine, false);
					//Add faile image
				}
			}
			catch(Exception ex) 
			{
				var xx = ex.Message;
			}
			//var tt = TapGestureRecognizer
			//App._questionList = QuestionList.CreateQuestionList(string.Format("QuizzApp.Android.{0}", loc.QuestionFileName));

			//await Navigation.PushAsync(new QuestionView());
			//listView.SelectedItem = null;
		}
	}
}

