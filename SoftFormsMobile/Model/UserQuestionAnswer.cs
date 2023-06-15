using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftFormsMobile.Model
{
    public class UserQuestionAnswer
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SurveyId { get; set; }
        public Guid QuestionId { get; set; }
        public List<string> AnswerValues { get; set; }
        public DateTime? Created { get; set; }
    }
}