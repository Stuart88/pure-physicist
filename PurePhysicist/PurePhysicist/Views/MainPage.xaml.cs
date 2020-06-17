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
using PurePhysicist.Views.Topics.TopicPageTemplates;

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

            this.Detail = new NavigationPage(new ContentPage(){Content = new UnderConstruction()});

            MenuPages.Add(MenuItemType.Topics, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id, Color themeColour)
        {
            if (!MenuPages.ContainsKey(id))
            {
                MenuPages.Add(id, new NavigationPage(GetPageFromId(id, themeColour)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
            }

            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);
            
            IsPresented = false;

        }

        private Page GetPageFromId(MenuItemType id, Color themeColour)
        {
            return id switch
            {
                MenuItemType.Home => throw new NotImplementedException(),
                MenuItemType.Topics => throw new NotImplementedException(),
                MenuItemType.Astrophysics => new MainTopicLayout(new Topics.Astrophysics.LayoutConstructor(themeColour)),
                MenuItemType.ClassicalMechanics => new MainTopicLayout(new Topics.ClassicalMechanics.LayoutConstructor(themeColour)),
                MenuItemType.Electromagnetism => new MainTopicLayout(new Topics.Electromagnetism.LayoutConstructor(themeColour)),
                MenuItemType.FluidDynamics => new MainTopicLayout(new Topics.FluidDynamics.LayoutConstructor(themeColour)),
                MenuItemType.Mathematics => new MainTopicLayout(new Topics.Mathematics.LayoutConstructor(themeColour)),
                MenuItemType.QuantumPhysics => new MainTopicLayout(new Topics.QuantumPhysics.LayoutConstructor(themeColour)),
                MenuItemType.Thermodynamics => new MainTopicLayout(new Topics.Thermodynamics.LayoutConstructor(themeColour)),
                MenuItemType.About => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }
        
    }
}