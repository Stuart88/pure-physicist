using PurePhysicist.Helpers;
using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoolStuffView : ContentView
    {
        #region Public Properties

        public ObservableCollection<CoolStuffListItem> ListItems { get; set; }
        public string PageTitle { get; set; }
        public bool TappedItem { get; set; }
        public Color ThemeColour { get; set; }

        #endregion Public Properties

        #region Private Properties

        private bool SingleTopicList { get; set; }

        #endregion Private Properties

        #region Public Constructors

        public CoolStuffView(string topicTitle, Color themeColour, List<CoolStuffListItem> items)
        {
            this.PageTitle = topicTitle;
            this.ThemeColour = themeColour;
            this.ListItems = new ObservableCollection<CoolStuffListItem>(items);
            this.SingleTopicList = topicTitle != Constants.TopicTitles.CoolStuff;

            foreach (var item in this.ListItems)
            {
                item.IconVisible = !this.SingleTopicList;
            }

            this.BindingContext = this;
            InitializeComponent();
            OnPropertyChanged(nameof(this.ListItems));

            if (this.PageTitle == Constants.TopicTitles.Thermodynamics)
                ContentsTitle.TextColor = Color.White;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void CoolStuffList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!this.TappedItem)
            {
                this.TappedItem = true;
                await this.Navigation.PushModalAsync(((CoolStuffListItem)e.Item).ModalItem.Value);
                this.TappedItem = false;
            }
        }

        #endregion Private Methods

        #region Public Classes

        public class CoolStuffListItem
        {
            #region Public Properties

            public Frame Icon { get; set; } = new Frame();
            public bool IconVisible { get; set; }
            public string Label { get; set; }
            public Lazy<ContentPage> ModalItem { get; set; }
            public MenuItemType Topic { get; set; }

            #endregion Public Properties

            #region Public Constructors

            public CoolStuffListItem(MenuItemType topic, string label, Lazy<ContentPage> modalItem)
            {
                this.Icon = Functions.CreateMenuIcon(topic, Functions.GetThemeColour(topic));
                this.Topic = topic;
                this.Label = label;
                this.ModalItem = modalItem;
            }

            #endregion Public Constructors
        }

        #endregion Public Classes
    }
}