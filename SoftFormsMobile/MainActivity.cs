using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using SoftFormsMobile.API;
using SoftFormsMobile.Model;
using System.Collections.Generic;
using Android.Widget;
using Refit;
using Android.Util;
using System.Text;
using System.IO;
using Android.Views;

namespace SoftFormsMobile
{
    [Activity(Label = "ConnectingToApiExample", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ISoftFormsAPI softFormsApi;

        List<Question> questions = new List<Question>();
        List<Page> pages = new List<Page>();

        Button fetchQuestions_btn;  
        ListView questionsListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                SetContentView(Resource.Layout.activity_main);

                fetchQuestions_btn = FindViewById<Button>(Resource.Id.btn_list_surveys);
                questionsListView = FindViewById<ListView>(Resource.Id.containerLayout_questions);
                fetchQuestions_btn.Click += FetchQuestions_btn_Click;

                JsonConvert.DefaultSettings =()=> new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        Converters = { new StringEnumConverter() }
                };

                softFormsApi = RestService.For<ISoftFormsAPI>("http://10.0.2.2:5267/");               
            }
            catch (Exception ex)
            {
                Log.Error("myApp", ex.Message);
            }           
        }

        private void FetchQuestions_btn_Click(object sender, EventArgs e)
        {
            GetSurveys();
        }

        private async void GetSurveys()
        {     
            try
            {
                Survey response = await softFormsApi.GetSurvey();
                pages = response.Pages;

                foreach (var page in pages)
                {
                    var pageQuestions = page.Questions;
                    foreach ( var question in pageQuestions)
                    {
                        questions.Add(question);
                    }
                }
              
                var adapter = new QuestionsAdapter(questions, this);
                questionsListView.Adapter = adapter;                    
            }
            catch(Exception ex) 
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                Console.WriteLine(ex.Message);
                Log.Error("softFormsApp", ex.Message);                
            }
        }
    }
}