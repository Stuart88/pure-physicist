using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PurePhysicist.Models;
using PurePhysicist.Views.Topics.ClassicalMechanics;
using PurePhysicist.Views.Topics.Astrophysics;
using PurePhysicist.Views.Topics.Electromagnetism;
using PurePhysicist.Views.Topics.FluidDynamics;
using PurePhysicist.Views.Topics.Mathematics;
using PurePhysicist.Views.Topics.Thermodynamics;
using PurePhysicist.Views.Topics.QuantumPhysics;

namespace PurePhysicist.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(MenuItemType.Topics, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                MenuPages.Add(id, new NavigationPage(GetPageFromId(id)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        private Page GetPageFromId(MenuItemType id)
        {
            return id switch
            {
                MenuItemType.Home => throw new NotImplementedException(),
                MenuItemType.Topics => throw new NotImplementedException(),
                MenuItemType.Astrophysics => new MainAstrophysics(),
                MenuItemType.ClassicalMechanics => new MainClassicalMechanics(),
                MenuItemType.Electromagnetism => new MainElectromagnetism(),
                MenuItemType.FluidDynamics => new MainFluidDynamics(),
                MenuItemType.Mathematics => new MainMathematics(),
                MenuItemType.Thermodynamics => new MainThermodynamics(),
                MenuItemType.QuantumPhysics => new MainQuantumPhysics(),
                MenuItemType.About => new AboutPage(),
                _ => throw new NotImplementedException()
            };
        }
        
    }
}