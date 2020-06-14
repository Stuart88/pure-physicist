using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        HomeMenuItem selectedItem;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home"},
                new HomeMenuItem {Id = MenuItemType.Topics, Title="Topics", IsPageReference = false},
                new HomeMenuItem(MenuItemType.Astrophysics, "astro.png") { Title="Astrophysics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.ClassicalMechanics, "classical.png") {Title="Classical Mechanics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Electromagnetism,"electromag.png") { Title="Electromagnetism", ParentId = MenuItemType.Topics },
                new HomeMenuItem(MenuItemType.FluidDynamics, "fluid.png") { Title="Fluid Dynamics", ParentId = MenuItemType.Topics },
                new HomeMenuItem(MenuItemType.Mathematics, "maths.png") {Title="Mathematics", ParentId = MenuItemType.Topics },
                new HomeMenuItem(MenuItemType.QuantumPhysics, "quantum.png") {Title="Quantum Physics", ParentId = MenuItemType.Topics },
                new HomeMenuItem(MenuItemType.Thermodynamics,"thermo.png") { Title="Thermodynamics", ParentId = MenuItemType.Topics},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
            };

            this.BackgroundColor = Color.FromRgba(255d, 255d, 255d, 0.5);

            SetupMenuItems();
            selectedItem = menuItems[0];
            ApplySelectedItemStyling();
        }

       

        private void ApplySelectedItemStyling()
        {
            foreach (var item in this.MenuUiItems)
            {
                if (item.itemRef == selectedItem)
                {
                    item.frame.BorderColor = Color.White;
                }
                else if (item.itemRef.IsTopLevel && selectedItem.ParentId == item.itemRef.Id) // is parent of selected item
                {
                    item.frame.BorderColor = Color.Black;
                }
                else
                {
                    item.frame.BorderColor = Color.Transparent;
                }
            }
        }

        private void SetupMenuItems()
        {
            foreach (HomeMenuItem item in menuItems.Where(item => item.ParentId == null))
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


        private Expander CreateExpander(HomeMenuItem item)
        {
            return new Expander
            {
                Header = CreateMenuItem(item),
                Content = CreateDropdownItems(menuItems.Where(i => i.ParentId == item.Id))
            };
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

        /// <summary>
        /// A reference of all menu items in UI. For performing style updates on user interaction
        /// </summary>
        private List<(HomeMenuItem itemRef, Frame frame)> MenuUiItems { get; set; } = new List<(HomeMenuItem itemRef, Frame frame)>();

        private Frame CreateMenuItem(HomeMenuItem item)
        {
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();

            tapGesture.Tapped += async (e, s) =>
            {
                if (item.IsPageReference)
                {
                    selectedItem = item;
                    ApplySelectedItemStyling();
                    await RootPage.NavigateFromMenu(item.Id, item.TopicColour);
                }
            };

            Grid itemGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            itemGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            itemGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});

            Label itemLabel = new Label
            {
                Text = item.Title,
                Style = item.IsTopLevel
                    ? (Style) Application.Current.Resources["MenuItemLabel"]
                    : (Style) Application.Current.Resources["MenuDropdownItemLabel"]
            };

            itemGrid.Children.Add(itemLabel);
            Grid.SetRow(itemLabel, 0);
            Grid.SetColumn(itemLabel, 0);

            if (item.Icon != null)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
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
    }
}