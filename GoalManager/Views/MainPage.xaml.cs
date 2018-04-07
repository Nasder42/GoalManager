using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GoalManager.Data;
using GoalManager.Models;
using Xamarin.Forms;

namespace GoalManager.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly GoalsPreviewVM _goalsPreviewList;
        private int periodIndex = 0;
        private List<Goal> _listGoals;

        public MainPage()
        {
            _listGoals = GoalsDB.GetInstance();

            // Start reviewing weekly goal's.
            _goalsPreviewList = new GoalsPreviewVM();
            //DisplayGoals(periodIndex);
            InitializeComponent();

            //goalsListView.ItemSelected += OnSelection;
            //goalsListView.ItemTapped += OnTap;


        }

        // 0 = Weekly, 1 = Quarter, 2 = ...
        void DisplayGoals(int index)
        {
            // Parses index between avalible marginal.
            if (index < 0)
            {
                periodIndex = 3;
            }
            else if (index >= 4)
            {
                periodIndex = 0;
            }

            switch (periodIndex)
            {
                case 0:
                    _goalsPreviewList.Todos = GoalsDB.GetWeekList();
                    _goalsPreviewList.Intro = "Weekly Goals";
                    _goalsPreviewList.Summary = "There is " + _goalsPreviewList.Todos.Count + " Goals this week";
                    break;

                case 1:
                    _goalsPreviewList.Todos = GoalsDB.GetQuarterList();
                    _goalsPreviewList.Intro = "Month Goals";
                    _goalsPreviewList.Summary = "There is " + _goalsPreviewList.Todos.Count + " Goals this month";
                    break;

                case 2:
                    _goalsPreviewList.Todos = GoalsDB.GetQuarterList();
                    _goalsPreviewList.Intro = "Quarter Goals";
                    _goalsPreviewList.Summary = "There is " + _goalsPreviewList.Todos.Count + " Goals this quarter";
                    break;

                case 3:
                    _goalsPreviewList.Todos = GoalsDB.GetYearList();
                    _goalsPreviewList.Intro = "Year Goals";
                    _goalsPreviewList.Summary = "There is " + _goalsPreviewList.Todos.Count + " Goals this year";
                    break;
            }
            goalsListView.ItemsSource = _goalsPreviewList.Todos;
            periodTitle.Text = _goalsPreviewList.Intro;
			BindingContext = _goalsPreviewList;
        }

        protected override void OnAppearing()
        {
            DisplayGoals(periodIndex);
        }

        void NextPeriodGoals(object sender, EventArgs e)
        {
            periodIndex++;
            DisplayGoals(periodIndex);

        }

        void BackPeriodGoals(object sender, EventArgs e)
        {
            periodIndex--;
            DisplayGoals(periodIndex);
        }

        async void AddNewTodo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTodoPage());
        }

        async void ShowCompletedTodo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArchivedTodoPage());
        }

        async void ShowFutureTodo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FutureTodoPage());
        }

        async void ShowWeather(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage());
        }

        public void OnCompleted(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            GoalsDB.CompletedGoal(mi.CommandParameter.ToString());
            DisplayGoals(periodIndex);
        }

        public void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Not yet", mi.CommandParameter + "Editing its yet not implemented.", "OK");
        }

        public void OnRemove(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            GoalsDB.RemoveGoal(mi.CommandParameter.ToString());
            //BindingContext = _goalsPreviewList;
            DisplayGoals(periodIndex);

        }



        //void OnSelection(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //    {
        //        return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
        //    }
        //    DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        //    //comment out if you want to keep selections
        //    ListView lst = (ListView)sender;
        //    lst.SelectedItem = null;
        //}
    }
}
