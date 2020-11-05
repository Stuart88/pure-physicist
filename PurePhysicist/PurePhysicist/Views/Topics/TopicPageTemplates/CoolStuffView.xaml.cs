using PurePhysicist.Helpers;
using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoolStuffView : ContentView
    {
        #region Public Properties

        public List<CoolStuffListItem> ListItems { get; set; }
        public ObservableCollection<CoolStuffListItem> ItemsFiltered { get; set; }
        public string PageTitle { get; set; }
        public bool TappedItem { get; set; }
        public Color ThemeColour { get; set; }

        #endregion Public Properties

        #region Private Properties

        private bool SingleTopicList { get; set; }

        /// <summary>
        /// Set to true to bypass 'Item clicked' event for on 'coming soon' item in empty list
        /// </summary>
        private bool ListEmpty { get; set; }

        #endregion Private Properties

        #region Public Constructors

        public CoolStuffView(string topicTitle, Color themeColour, List<CoolStuffListItem> items)
        {
            if (items.Count == 0)
            {
                items.Add(new CoolStuffListItem(MenuItemType.CoolStuff, "More Coming Soon!", null));
                ListEmpty = true;
            }


            this.PageTitle = topicTitle;
            this.ThemeColour = themeColour;
            this.ListItems = new List<CoolStuffListItem>(items);
            this.ItemsFiltered = new ObservableCollection<CoolStuffListItem>(items);

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
            if (!this.TappedItem && !this.ListEmpty)
            {
                this.TappedItem = true;
                await this.Navigation.PushModalAsync(((CoolStuffListItem)e.Item).ModalItem.Value);
                this.TappedItem = false;
            }
        }

        private void FilterEquationsList(string query)
        {
            if (this.ListEmpty)
                return;

            query = query.MakeNicerQueryString();
            char[] splitChars = { ' ', '-', '(', ')' };
            var queryWords = query.Split(splitChars).Where(s => !string.IsNullOrEmpty(s));

            var filtered = (from item in this.ListItems
                    let label = item.Label.ToLower().MakeNicerQueryString().Trim()
                    let labelWords = label.Split(splitChars).Where(s => !string.IsNullOrEmpty(s))
                    where string.IsNullOrEmpty(query)
                          || labelWords.Intersect(queryWords).Any()
                          || labelWords.Any(w => queryWords.Any(q => w.StartsWith(q)))
                          || label.StartsWith(query)
                    orderby label.StartsWith(query)
                        //labelWords.Any(w => queryWords.Any(q => w.StartsWith(q)))
                        descending
                    select item)
                .ToList();

            ItemsFiltered = new ObservableCollection<CoolStuffListItem>(filtered);
            OnPropertyChanged(nameof(ItemsFiltered));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = ((SearchBar)sender).Text.ToLower().Trim(); //remove apostrophes for lazy searching

            this.FilterEquationsList(query);
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