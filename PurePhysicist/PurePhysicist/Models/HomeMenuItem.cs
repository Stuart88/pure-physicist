using PurePhysicist.Helpers;
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
        CoolStuff,
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
        public HomeMenuItem(MenuItemType id)
        {
            this.Id = id;

            this.TopicColour = Functions.GetThemeColour(this.Id);

            this.Icon = Functions.CreateMenuIcon(this.Id, this.TopicColour);
        }

        #endregion Public Constructors

    }
}