using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                new HomeMenuItem {Id = MenuItemType.Astrophysics, Title="Astrophysics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.ClassicalMechanics, Title="Classical Mechanics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Electromagnetism, Title="Electromagnetism", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.FluidDynamics, Title="Fluid Dynamics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Mathematics, Title="Mathematics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.QuantumPhysics, Title="Quantum Physics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Thermodynamics, Title="Thermodynamics", ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
            };

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
                    item.frame.BorderColor = Color.CornflowerBlue;
                }
                else if (item.itemRef.IsTopLevel && selectedItem.ParentId == item.itemRef.Id) // is parent of selected item
                {
                    item.frame.BorderColor = Color.Black;
                }
                else
                {
                    item.frame.BorderColor = Color.LightGray;
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
        /// A reference of all menu items in UI. For performing style updates on interaction
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
                    await RootPage.NavigateFromMenu(item.Id);
                }
            };

            Frame itemFrame = new Frame
            {
                Content = new Label
                {
                    Text = item.Title,
                    Style = item.IsTopLevel
                        ? (Style)Application.Current.Resources["MenuItemLabel"]
                        : (Style)Application.Current.Resources["MenuDropdownItemLabel"]
                },
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