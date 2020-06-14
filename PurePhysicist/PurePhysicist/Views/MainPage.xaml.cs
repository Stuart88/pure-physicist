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
using PurePhysicist.Views.Topics;

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

        public async Task NavigateFromMenu(MenuItemType id, Color buttonsColour)
        {
            if (!MenuPages.ContainsKey(id))
            {
                MenuPages.Add(id, new NavigationPage(GetPageFromId(id, buttonsColour)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

            }
                
            IsPresented = false;
        }

        private Page GetPageFromId(MenuItemType id, Color buttonsColour)
        {
            return id switch
            {
                MenuItemType.Home => throw new NotImplementedException(),
                MenuItemType.Topics => throw new NotImplementedException(),
                MenuItemType.Astrophysics => new MainTopicLayout(new Topics.Astrophysics.LayoutConstructor(buttonsColour)),
                MenuItemType.ClassicalMechanics => new MainTopicLayout(new Topics.ClassicalMechanics.LayoutConstructor(buttonsColour)),
                MenuItemType.Electromagnetism => new MainTopicLayout(new Topics.Electromagnetism.LayoutConstructor(buttonsColour)),
                MenuItemType.FluidDynamics => new MainTopicLayout(new Topics.FluidDynamics.LayoutConstructor(buttonsColour)),
                MenuItemType.Mathematics => new MainTopicLayout(new Topics.Mathematics.LayoutConstructor(buttonsColour)),
                MenuItemType.QuantumPhysics => new MainTopicLayout(new Topics.QuantumPhysics.LayoutConstructor(buttonsColour)),
                MenuItemType.Thermodynamics => new MainTopicLayout(new Topics.Thermodynamics.LayoutConstructor(buttonsColour)),
                MenuItemType.About => new AboutPage(),
                _ => throw new NotImplementedException()
            };
        }
        
    }
}