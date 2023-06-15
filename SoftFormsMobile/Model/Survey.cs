using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftFormsMobile.Model
{
    public class Survey
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public Guid UserId { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "pages")]
        public List<Page> Pages { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; set; }
        [JsonProperty(PropertyName = "updated")]
        public DateTime? Updated { get; set; }
    }
}