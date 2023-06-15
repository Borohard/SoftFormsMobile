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
    public enum QuestionType
    {
        SingleLineText,
        MultiLineText,
        Radio,
        Checkboxes,
        Dropdown,
        Text,
        Textarea,
        Number,
        Date,
        Time
    }
}