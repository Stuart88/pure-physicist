using PurePhysicist.Models;
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

        public static List<HomeMenuItem> GetMenuItems()
        {
            return new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title = "Home"},
                new HomeMenuItem {Id = MenuItemType.Topics, Title = "Topics", IsPageReference = false},
                new HomeMenuItem(MenuItemType.Astrophysics, "astro.png") {Title = "Astro", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.ClassicalMechanics, "classical.png") {Title = "Classical Mechanics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Electromagnetism, "electromag.png") {Title = "Electromag", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.FluidDynamics, "fluid.png") {Title = "Fluid Dynamics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Mathematics, "maths.png") {Title = "Maths", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.QuantumPhysics, "quantum.png") {Title = "Quantum Physics", ParentId = MenuItemType.Topics},
                new HomeMenuItem(MenuItemType.Thermodynamics, "thermo.png") {Title = "Thermo", ParentId = MenuItemType.Topics},
                new HomeMenuItem {Id = MenuItemType.About, Title = "About"}
            };
        }

        #endregion Public Methods
    }
}