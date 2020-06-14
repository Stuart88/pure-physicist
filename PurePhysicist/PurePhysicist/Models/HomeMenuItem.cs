using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public enum MenuItemType
    {
        Home,
        /***/
        Topics,
        Astrophysics,
        ClassicalMechanics,
        Electromagnetism,
        FluidDynamics,
        Mathematics,
        Thermodynamics,
        QuantumPhysics,
        /***/
        About
    }
    public class HomeMenuItem
    {
        public HomeMenuItem(){}

        /// <summary>
        /// Only use this constructor for making menu items with an icon (i.e. submenus)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iconFile"></param>
        public HomeMenuItem(MenuItemType id, string iconFile)
        {
            this.Id = id;
            
            this.TopicColour = Id switch
            {
                MenuItemType.Home => throw new NotImplementedException(),
                MenuItemType.Topics => throw new NotImplementedException(),
                MenuItemType.Astrophysics => Color.Red,
                MenuItemType.ClassicalMechanics => Color.Orange,
                MenuItemType.Electromagnetism => Color.Yellow,
                MenuItemType.FluidDynamics => Color.LightGreen,
                MenuItemType.Mathematics => Color.CornflowerBlue,
                MenuItemType.Thermodynamics => Color.Indigo,
                MenuItemType.QuantumPhysics => Color.Violet,
                MenuItemType.About => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };

            Icon = CreateMenuIcon(iconFile);
        }
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// For dropdown menu items
        /// </summary>
        public MenuItemType? ParentId { get; set; }

        public bool IsTopLevel => ParentId == null;

        public bool IsPageReference { get; set; } = true;

        public Frame Icon { get; set; }

        public Color TopicColour { get; set; }

        private Frame CreateMenuIcon(string filename)
        {
            Frame imageFrame = new Frame()
            {
                Content = new Image
                {
                    Source = Helpers.Functions.CreateImageSource($"Icons.{filename}"),
                    Style = (Style)Application.Current.Resources["MenuIcon"],
                    BackgroundColor = this.TopicColour
                },
                BackgroundColor = Color.White,
                BorderColor = Color.Transparent,
                Padding = 2,
            };
            return imageFrame;
        }
    }
}
