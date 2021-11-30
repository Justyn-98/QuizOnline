﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizOnlineApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingPage : ContentPage
    {
        public RankingPage()
        {
            InitializeComponent();

            RankingCategoryPicker.Items.Add("PHP");
            RankingCategoryPicker.Items.Add("C#");
            RankingCategoryPicker.Items.Add("Docker");

            RankingDatePicker.Items.Add("Today");
            RankingDatePicker.Items.Add("Weekly");
            RankingDatePicker.Items.Add("Monthly");

            RankingFriendsPicker.Items.Add("Friends");
            RankingFriendsPicker.Items.Add("Global");

            RankingCategoryPicker.SelectedIndex = 0;
            RankingDatePicker.SelectedIndex = 0;
            RankingFriendsPicker.SelectedIndex = 0;
        }
    }
}