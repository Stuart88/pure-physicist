using PurePhysicist.Models;
using PurePhysicist.Views.Topics;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurePhysicist.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        #region Private Fields

        private Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();

        #endregion Private Fields

        #region Public Constructors

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            NavigationPage.SetHasNavigationBar(this, false);

            this.Detail = new NavigationPage(new HomePage());

            MenuPages.Add(MenuItemType.Topics, (NavigationPage)Detail);
        }

        #endregion Public Constructors

        #region Public Methods

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

        #endregion Public Methods

        #region Private Methods

        private Page GetPageFromId(MenuItemType id, Color themeColour)
        {
            return id switch
            {
                MenuItemType.Home => new HomePage(),
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

        #endregion Private Methods
    }
}