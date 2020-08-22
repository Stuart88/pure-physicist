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


        #endregion Public Methods
    }
}