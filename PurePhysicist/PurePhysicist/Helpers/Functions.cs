using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace PurePhysicist.Helpers
{
    public static class Functions
    {
        #region Public Methods

        public static void AssignIds(this List<EquationItem> items)
        {
            int id = 0;
            foreach (EquationItem i in items)
            {
                i.Id = (id++).ToString();
            }
        }

        public static ImageSource CreateImageSource(string filename)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            return ImageSource.FromResource($"PurePhysicist.Images.{filename}", currentAssembly);
        }

        public static Frame CreateMenuIcon(MenuItemType id, Color topicColour)
        {
            string filename = id switch
            {
                MenuItemType.Astrophysics => "astro.png",
                MenuItemType.ClassicalMechanics => "classical.png",
                MenuItemType.Electromagnetism => "electromag.png",
                MenuItemType.FluidDynamics => "fluid.png",
                MenuItemType.Mathematics => "maths.png",
                MenuItemType.ModernPhysics => "circles.png",
                MenuItemType.Thermodynamics => "thermo.png",
                MenuItemType.QuantumPhysics => "quantum.png",
                MenuItemType.CoolStuff => "cool.png",
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
            };
            Frame imageFrame = new Frame()
            {
                Content = new Image
                {
                    Source = CreateImageSource($"Icons.{filename}"),
                    Style = (Style)Application.Current.Resources["MenuIcon"],
                    BackgroundColor = topicColour
                },
                BackgroundColor = Color.White,
                BorderColor = Color.Transparent,
                Padding = 2,
            };
            return imageFrame;
        }

        public static List<HomeMenuItem> GetMenuItems()
        {
            return new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title = "Home"},
                new HomeMenuItem {Id = MenuItemType.Topics, Title = "Topics", IsPageReference = false},
                new HomeMenuItem(MenuItemType.Astrophysics) {Title = "Astro", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.ClassicalMechanics) {Title = "Classical Mechanics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Electromagnetism) {Title = "Electromag", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.FluidDynamics) {Title = "Fluid Dynamics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Mathematics) {Title = "Maths", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.QuantumPhysics) {Title = "Quantum Physics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.ModernPhysics) {Title = "Modern Physics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Thermodynamics) {Title = "Thermo", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.CoolStuff) {Title = "Cool Stuff", ParentId = MenuItemType.Topics},
                new HomeMenuItem {Id = MenuItemType.About, Title = "About"}
            };
        }

        public static Color GetThemeColour(MenuItemType id)
        {
            return id switch
            {
                MenuItemType.Home => throw new NotImplementedException(),
                MenuItemType.Topics => throw new NotImplementedException(),
                MenuItemType.Astrophysics => Color.Red,
                MenuItemType.ClassicalMechanics => Color.Orange,
                MenuItemType.Electromagnetism => Color.Yellow,
                MenuItemType.FluidDynamics => Color.LightGreen,
                MenuItemType.Mathematics => Color.CornflowerBlue,
                MenuItemType.ModernPhysics => Color.LightPink,
                MenuItemType.Thermodynamics => Color.MediumPurple,
                MenuItemType.QuantumPhysics => Color.Violet,
                MenuItemType.CoolStuff => Color.White,
                MenuItemType.About => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }

        #endregion Public Methods
    }
}