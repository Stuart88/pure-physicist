using PurePhysicist.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace PurePhysicist.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        #region Private Fields

        private readonly List<HomeMenuItem> _menuItems = Helpers.Functions.GetMenuItems();
        public static HomeMenuItem SelectedItem;

        #endregion Private Fields

        #region Private Properties

        /// <summary>
        /// A reference of all menu items in UI. For performing style updates on user interaction
        /// </summary>
        private List<(HomeMenuItem itemRef, Frame frame)> MenuUiItems { get; set; } = new List<(HomeMenuItem itemRef, Frame frame)>();

        private MainPage RootPage => Application.Current.MainPage as MainPage;

        #endregion Private Properties

        #region Public Constructors

        public MenuPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.FromRgba(255d, 255d, 255d, 0.5);

            SetupMenuItems();
            SelectedItem = _menuItems[0];
            ApplySelectedItemStyling();
        }

        protected override void OnAppearing()
        {
            ApplySelectedItemStyling();
            base.OnAppearing();
        }

        #endregion Public Constructors

        #region Private Methods

        private void ApplySelectedItemStyling()
        {
            foreach (var item in this.MenuUiItems)
            {
                if (item.itemRef == SelectedItem)
                {
                    item.frame.BorderColor = Color.White;
                }
                else if (item.itemRef.IsTopLevel && SelectedItem.ParentId == item.itemRef.Id) // is parent of selected item
                {
                    item.frame.BorderColor = Color.Black;
                }
                else
                {
                    item.frame.BorderColor = Color.Transparent;
                }
            }
        }

        private StackLayout CreateDropdownItems(IEnumerable<HomeMenuItem> items)
        {
            StackLayout dropdownStack = new StackLayout();

            foreach (var item in items)
            {
                dropdownStack.Children.Add(CreateMenuItem(item));
            }

            return dropdownStack;
        }

        private Expander CreateExpander(HomeMenuItem item)
        {
            return new Expander
            {
                Header = CreateMenuItem(item),
                Content = CreateDropdownItems(_menuItems.Where(i => i.ParentId == item.Id))
            };
        }

        private Frame CreateMenuItem(HomeMenuItem item)
        {
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();

            tapGesture.Tapped += async (e, s) =>
            {
                if (item.IsPageReference)
                {
                    SelectedItem = item;
                    ApplySelectedItemStyling();
                    await RootPage.NavigateFromMenu(item.Id, item.TopicColour);
                }
            };

            Grid itemGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            itemGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            Label itemLabel = new Label
            {
                Text = item.Title,
                Style = item.IsTopLevel
                    ? (Style)Application.Current.Resources["MenuItemLabel"]
                    : (Style)Application.Current.Resources["MenuDropdownItemLabel"]
            };

            itemGrid.Children.Add(itemLabel);
            Grid.SetRow(itemLabel, 0);
            Grid.SetColumn(itemLabel, 0);

            if (item.Icon != null)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                itemGrid.Children.Add(item.Icon);
                Grid.SetRow(item.Icon, 0);
                Grid.SetColumn(item.Icon, 1);
            }

            Frame itemFrame = new Frame
            {
                Content = itemGrid,
                Style = item.IsTopLevel
                    ? (Style)Application.Current.Resources["MenuItemFrame"]
                    : (Style)Application.Current.Resources["MenuDropdownItemFrame"]
            };

            itemFrame.GestureRecognizers.Add(tapGesture);

            MenuUiItems.Add((item, itemFrame));

            return itemFrame;
        }

        private void SetupMenuItems()
        {
            foreach (HomeMenuItem item in _menuItems.Where(item => item.ParentId == null))
            {
                if (item.IsTopLevel)
                {
                    MenuStack.Children.Add(CreateExpander(item));
                }
                else
                {
                    MenuStack.Children.Add(CreateMenuItem(item));
                }
            }
        }

        #endregion Private Methods
    }
}