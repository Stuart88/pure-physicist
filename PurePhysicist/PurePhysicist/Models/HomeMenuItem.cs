using System;
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
        #region Public Properties

        public Frame Icon { get; set; }

        public MenuItemType Id { get; set; }

        public bool IsPageReference { get; set; } = true;

        public bool IsTopLevel => ParentId == null;

        /// <summary>
        /// For dropdown menu items
        /// </summary>
        public MenuItemType? ParentId { get; set; }

        public string Title { get; set; }

        public Color TopicColour { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public HomeMenuItem()
        {
        }

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

            Icon = Helpers.Functions.CreateMenuIcon(this.Id, this.TopicColour);
        }

        #endregion Public Constructors

    }
}