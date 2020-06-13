using System;
using System.Collections.Generic;
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
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public bool IsDropdown { get; set; }
        /// <summary>
        /// For dropdown menu items
        /// </summary>
        public MenuItemType? ParentId { get; set; }

    }
}
