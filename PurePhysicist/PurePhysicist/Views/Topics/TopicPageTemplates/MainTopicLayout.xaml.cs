﻿using PurePhysicist.Models;
using System;
using PurePhysicist.Views.CustomViews;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTopicLayout : ContentPage
    {
        #region Public Properties

        public Color ThemeColour { get; set; }
        public ContentView ViewContent { get; set; }

        #endregion Public Properties

        #region Private Properties

        private LayoutConstructorBase ConstructorBase { get; set; }

        #endregion Private Properties

        #region Public Constructors

        public MainTopicLayout(LayoutConstructorBase constructor)
        {
            this.ThemeColour = constructor.ButtonsColour;

            this.BindingContext = this;

            InitializeComponent();

            SetupFromBase(constructor);

            SetButtonSizes();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Button1_Pressed(object sender, EventArgs e)
        {
            ((MasterDetailPage)Application.Current.MainPage).IsPresented = true;
        }

        public void Button2_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.ContentsPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button2);
            StartPhysicistsImagesCycle();
        }

        public void Button3_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.EquationsPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button3);
            StopPhysicistsImageCycle();
        }

        public void Button4_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.CoolStuffPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button4);
            StopPhysicistsImageCycle();
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopPhysicistsImageCycle();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartPhysicistsImagesCycle();
        }

        public void StartPhysicistsImagesCycle()
        {
            if (this.ContentArea.Content is IPhysicistFetcher physicistFetcher && !physicistFetcher.IsShowing)
            {
                Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                {
                    Device.BeginInvokeOnMainThread(() => { physicistFetcher.SetPhysicistView(); });
                    return physicistFetcher.IsShowing;
                });

                physicistFetcher.IsShowing = true;
            }
        }

        public void StopPhysicistsImageCycle()
        {
            if (this.ContentArea.Content is IPhysicistFetcher physicistFetcher)
            {
                physicistFetcher.SetIsShowing(false);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void SetButtonColours(Frame selectedButton)
        {
            this.Button1.BackgroundColor = this.Button1 == selectedButton
                ? Color.LightGray
                : Color.White;

            this.Button2.BackgroundColor = this.Button2 == selectedButton
                ? Color.LightGray
                : Color.White;

            this.Button3.BackgroundColor = this.Button3 == selectedButton
                ? Color.LightGray
                : Color.White;

            this.Button4.BackgroundColor = this.Button4 == selectedButton
                ? Color.LightGray
                : Color.White;
        }

        /// <summary>
        /// Ensures square aligned footer buttons
        /// </summary>
        private void SetButtonSizes()
        {
            double size = (DeviceDisplay.MainDisplayInfo.Width / 4d) / DeviceDisplay.MainDisplayInfo.Density;

            this.Button1.WidthRequest = size;
            this.Button2.WidthRequest = size;
            this.Button3.WidthRequest = size;
            this.Button4.WidthRequest = size;

            this.Button1.HeightRequest = size * 0.8;
            this.Button2.HeightRequest = size * 0.8;
            this.Button3.HeightRequest = size * 0.8;
            this.Button4.HeightRequest = size * 0.8;

            this.ButtonImage1.HeightRequest = size * 0.5;
            this.ButtonImage2.HeightRequest = size * 0.5;
            this.ButtonImage3.HeightRequest = size * 0.5;
            this.ButtonImage4.HeightRequest = size * 0.5;

            this.ButtonImage1.WidthRequest = size * 0.5;
            this.ButtonImage2.WidthRequest = size * 0.5;
            this.ButtonImage3.WidthRequest = size * 0.5;
            this.ButtonImage4.WidthRequest = size * 0.5;
        }

        private void SetupFromBase(LayoutConstructorBase constructor)
        {
            ConstructorBase = constructor;

            ConstructorBase.SetupButtonImageSources();

            this.ConstructorBase.Button1Tap.Tapped += Button1_Pressed;
            this.ConstructorBase.Button2Tap.Tapped += Button2_Pressed;
            this.ConstructorBase.Button3Tap.Tapped += Button3_Pressed;
            this.ConstructorBase.Button4Tap.Tapped += Button4_Pressed;

            this.Button1.GestureRecognizers.Add(ConstructorBase.Button1Tap);
            this.Button2.GestureRecognizers.Add(ConstructorBase.Button2Tap);
            this.Button3.GestureRecognizers.Add(ConstructorBase.Button3Tap);
            this.Button4.GestureRecognizers.Add(ConstructorBase.Button4Tap);

            this.ViewContent = ConstructorBase.ContentsPage;

            OnPropertyChanged(nameof(this.ViewContent));

            SetButtonColours(this.Button2); // Button2 is Contents View
        }

        #endregion Private Methods
    }
}