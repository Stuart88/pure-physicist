using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home", IsDropdown = true },
                new HomeMenuItem {Id = MenuItemType.Topics, Title="Topics", IsDropdown = true }, 
                new HomeMenuItem {Id = MenuItemType.Astrophysics, Title="Astrophysics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.ClassicalMechanics, Title="Classical Mechanics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Electromagnetism, Title="Electromagnetism", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.FluidDynamics, Title="Fluid Dynamics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Mathematics, Title="Mathematics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.QuantumPhysics, Title="Quantum Physics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.Thermodynamics, Title="Thermodynamics", IsDropdown = false, ParentId = MenuItemType.Topics },
                new HomeMenuItem {Id = MenuItemType.About, Title="About", IsDropdown = false }
            };

            SetupMenuItems();

            selectedItem = menuItems[0];
            
        }

        private void SetupMenuItems()
        {
            foreach (HomeMenuItem item in menuItems.Where(item => item.ParentId == null))
            {
                if (item.IsDropdown)
                {
                    MenuStack.Children.Add(CreateMenuDropdown(item));
                }
                else
                {
                    MenuStack.Children.Add(CreateMenuItem(item));
                }
                
            }
        }

        private Expander CreateMenuDropdown(HomeMenuItem item)
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

        private Frame CreateMenuItem(HomeMenuItem item)
        {
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();

            tapGesture.Tapped += async (e, s) =>
            {
                await RootPage.NavigateFromMenu(item.Id);
            };

            Frame itemFrame = new Frame
            {
                Content = new Label {Text = item.Title}
            };

            itemFrame.GestureRecognizers.Add(tapGesture);

            return itemFrame;
        }
    }
}