﻿using ENEI.SessionsApp.Model;
using ENEI.SessionsApp.ViewModels;
using Xamarin.Forms;

namespace ENEI.SessionsApp.Views
{
    public partial class SessionsView : ContentPage
    {
        public SessionsView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Session>(this, "SeeSessionDetails", session =>
            {
                Navigation.PushAsync(new SessionDetailsView(session), true);
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = BindingContext as SessionViewModel;
            if (viewmodel != null)
            {
                await viewmodel.LoadDataAsync();
            }
        }

        private void SessionsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //workarround to clean the select item
            if (SessionsList.SelectedItem == null)
            {
                return;
            }

            SessionsList.SelectedItem = null;
        }
    }
}
