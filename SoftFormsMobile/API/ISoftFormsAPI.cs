using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using SoftFormsMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftFormsMobile.API
{
    [Headers("User-Agent: :request")]
    public interface ISoftFormsAPI
    {
        [Get("/Survey/2f5972f7-6e91-4ed4-9f84-98351d7b9ca1")]
        Task<Survey> GetSurvey();
    }
}