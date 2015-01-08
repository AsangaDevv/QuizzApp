using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;

namespace QuizzApp.Model
{
	public class QuestionList
	{
		public List<QuestionEn> Questions { get; set; }

		public QuestionList ()
		{

		}

		public static List<Question> CreateQuestionList(string fileName)
		{
			List<Question> qList = new List<Question>();

			try
			{

//				Assembly assembly = Assembly.GetExecutingAssembly();
//				string[] resources = assembly.GetManifestResourceNames();

				var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

				using (var reader = new System.IO.StreamReader (stream))
				{
					var jsonData = reader.ReadToEnd();

					switch (App._selectedLangauge)
					{
					case "En":
						var qListEn  =  JsonConvert.DeserializeObject<List<QuestionEn>>(jsonData);
						qList = ConvertEnToGeneric(qListEn);
						 break;
					case "Sv":
						var qListSv  =  JsonConvert.DeserializeObject<List<QuestionSv>>(jsonData);
						qList = ConvertSvToGeneric(qListSv);
						//qList = ConvertToGeneric(qListSv);
						break;
					case "Ty":
						var qListTy  =  JsonConvert.DeserializeObject<List<QuestionTy>>(jsonData);
						qList = ConvertTyToGeneric(qListTy);
						break;
					case "Dk":
						var qListDk  =  JsonConvert.DeserializeObject<List<QuestionDk>>(jsonData);
						qList = ConvertDkToGeneric(qListDk);
						break;

					}


				}
			}
			catch (Exception ex)
			{
				var d = ex.Message;
			}

			return qList;
		}


		private static List<Question> ConvertEnToGeneric(List<QuestionEn> list)
		{
			List<Question> qList = new List<Question>();

			foreach (var li in list) 
			{
				if (li.QuestionText != null) {
					var q = new Question {
						QuestionText = li.QuestionText,
						CorrectAnswer = li.CorrectAnswer,
						HeadLine = li.HeadLine,
						QuestionImage = li.QuestionImage,
						AnswerImage = li.AnswerImage
					};

					q.Answers = new List<Answer> ();
					var count = 1;

					foreach (var ans in li.Answers) {
						q.Answers.Add (new Answer{ Id = count, AnswerText = ans });
						count++;
					}

					qList.Add (q);
				}
			}

			return qList;
		}

		private static List<Question> ConvertSvToGeneric(List<QuestionSv> list)
		{
			List<Question> qList = new List<Question>();

			foreach (var li in list) 
			{
				if (li.QuestionText != null) {
					var q = new Question {
						QuestionText = li.QuestionText,
						CorrectAnswer = li.CorrectAnswer,
						HeadLine = li.HeadLine,
						QuestionImage = li.QuestionImage,
						AnswerImage = li.AnswerImage
					};

					q.Answers = new List<Answer> ();
					var count = 1;

					foreach (var ans in li.Answers) {
						q.Answers.Add (new Answer{ Id = count, AnswerText = ans });
						count++;
					}

					qList.Add (q);
				}
			}

			return qList;
		}

		private static List<Question> ConvertDkToGeneric(List<QuestionDk> list)
		{
			List<Question> qList = new List<Question>();

			foreach (var li in list) 
			{
				if (li.QuestionText != null) {
					var q = new Question {
						QuestionText = li.QuestionText,
						CorrectAnswer = li.CorrectAnswer,
						HeadLine = li.HeadLine,
						QuestionImage = li.QuestionImage,
						AnswerImage = li.AnswerImage

					};

					q.Answers = new List<Answer> ();
					var count = 1;

					foreach (var ans in li.Answers) {
						q.Answers.Add (new Answer{ Id = count, AnswerText = ans });
						count++;
					}

					qList.Add (q);
				}
			}

			return qList;
		}

		private static List<Question> ConvertTyToGeneric(List<QuestionTy> list)
		{
			List<Question> qList = new List<Question>();

			foreach (var li in list) 
			{
				if (li.QuestionText != null) {
					var q = new Question {
						QuestionText = li.QuestionText,
						CorrectAnswer = li.CorrectAnswer,
						HeadLine = li.HeadLine,
						QuestionImage = li.QuestionImage,
						AnswerImage = li.AnswerImage

					};

					q.Answers = new List<Answer> ();
					var count = 1;

					foreach (var ans in li.Answers) {
						q.Answers.Add (new Answer{ Id = count, AnswerText = ans });
						count++;
					}

					qList.Add (q);
				}
			}

			return qList;
		}
	}
}

