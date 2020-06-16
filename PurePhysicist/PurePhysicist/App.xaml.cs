﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PurePhysicist.Views;

namespace PurePhysicist
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public static double DeviceHeight;
        public static double DeviceWidth;

        public App()
        {
            Device.SetFlags(new[] {
                //"RadioButton_Experimental",
                //"AppTheme_Experimental",
                //"Markup_Experimental",
                "Expander_Experimental"
            });

            MainThread.BeginInvokeOnMainThread(() =>    // iOS required this to invoke on main thread. See: https://docs.microsoft.com/en-us/xamarin/essentials/device-display?tabs=ios#platform-differences 
            {   
                DeviceHeight = DeviceDisplay.MainDisplayInfo.Height;
                DeviceWidth = DeviceDisplay.MainDisplayInfo.Width;
            });

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
