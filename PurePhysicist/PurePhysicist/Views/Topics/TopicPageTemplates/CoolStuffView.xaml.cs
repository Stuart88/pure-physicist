using PurePhysicist.Helpers;
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
        public Color ThemeColour { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public CoolStuffView(string topicTitle, Color themeColour, List<CoolStuffListItem> items)
        {
            PageTitle = topicTitle;
            ThemeColour = themeColour;
            ListItems = new ObservableCollection<CoolStuffListItem>(items);

            BindingContext = this;
            InitializeComponent();

            if (this.PageTitle == Constants.TopicTitles.Thermodynamics)
                this.ContentsTitle.TextColor = Color.White;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void CoolStuffList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(((CoolStuffListItem)e.Item).ModalItem);
        }

        #endregion Private Methods

        #region Public Classes

        public class CoolStuffListItem
        {
            #region Public Properties

            public string Label { get; set; }

            public ContentPage ModalItem { get; set; }

            #endregion Public Properties

            #region Public Constructors

            public CoolStuffListItem(string label, ContentPage modalItem)
            {
                Label = label;
                ModalItem = modalItem;
            }

            #endregion Public Constructors
        }

        #endregion Public Classes
    }
}