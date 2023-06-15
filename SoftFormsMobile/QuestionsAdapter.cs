using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using SoftFormsMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftFormsMobile
{
    public class QuestionsAdapter : BaseAdapter<Question>
    {
        private readonly Activity context;
        List<Question> _questions;
        RadioGroup radioGroup;

        public QuestionsAdapter( List<Question> questions, Activity context)
        {
            _questions = questions;
            this.context = context;
        }

        public override Question this[int position]
        {
            get
            {
                return _questions[position];
            }
        }

        public override int Count
        {
            get
            {
                return _questions.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.question_empty, parent, false);
            }

            View view;

            switch (_questions[position].QuestionType)
            {
                case QuestionType.Text:                  
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_text, parent, false) ;
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;                                  
                    return view;

                case QuestionType.Radio:
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_radio, parent, false);
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;
                    radioGroup = view.FindViewById<RadioGroup>(Resource.Id.radioQuestion);
                    foreach (var option in _questions[position].Options)
                    {
                        RadioButton radioButton = new RadioButton(context);
                        radioButton.Text = option.Value;
                        radioGroup.AddView(radioButton);
                    }
                    return view;
                    
                case QuestionType.Textarea:
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_textarea, parent, false);
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;
                    return view;

                case QuestionType.Number:
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_number, parent, false);
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;
                    return view;
               

                case QuestionType.Date:
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_data, parent, false);
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;
                    return view;

                case QuestionType.Time:
                    view = context.LayoutInflater.Inflate(Resource.Layout.question_time, parent, false);
                    view.FindViewById<TextView>(Resource.Id.textQuestionInput).Text = _questions[position].Title;
                    return view;

            }
            return convertView;          
        }

        public void InputValueChanged(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                Toast.MakeText(context, ((EditText)sender).Id ,ToastLength.Short).Show();
                e.Handled = true;
            }
        }
    }
}