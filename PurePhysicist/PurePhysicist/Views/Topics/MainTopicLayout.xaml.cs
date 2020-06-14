using PurePhysicist.Extensions;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTopicLayout : ContentPage
    {
        public ContentView ViewContent { get; set; }
        LayoutConstructorBase ConstructorBase { get; set; }
        public MainTopicLayout(LayoutConstructorBase constructor)
        {
            InitializeComponent();

            SetupFromBase(constructor);

            this.BindingContext = this;

            SetButtonSizes();
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

            this.Button1.HeightRequest = size;
            this.Button2.HeightRequest = size;
            this.Button3.HeightRequest = size;
            this.Button4.HeightRequest = size;

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

            this.ButtonImage1.BackgroundColor = ConstructorBase.ButtonsColour;
            this.ButtonImage2.BackgroundColor = ConstructorBase.ButtonsColour;
            this.ButtonImage3.BackgroundColor = ConstructorBase.ButtonsColour;
            this.ButtonImage4.BackgroundColor = ConstructorBase.ButtonsColour;
            
            this.ViewContent = ConstructorBase.ContentsPage;

            OnPropertyChanged(nameof(this.ViewContent));

            SetButtonColours(this.Button2); // Button2 is Contents View
        }


        public void Button1_Pressed(object sender, EventArgs e)
        {
            ((MasterDetailPage)Application.Current.MainPage).IsPresented = true;
        }

        public void Button2_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.ContentsPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button2);
        }

        public void Button3_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.EquationsPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button3);
        }

        public void Button4_Pressed(object sender, EventArgs e)
        {
            this.ViewContent = this.ConstructorBase.CoolStuffPage;
            OnPropertyChanged(nameof(this.ViewContent));
            SetButtonColours(this.Button4);
        }

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
    }
}