using PurePhysicist.Views.Topics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PurePhysicist.Models;
using Xamarin.Forms;

namespace PurePhysicist.Helpers
{
    public static class Functions
    {
        public static ImageSource CreateImageSource(string filename)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            return ImageSource.FromResource($"PurePhysicist.Images.{filename}", currentAssembly);
        }

        public static void AssignIds(this List<EquationItem> items)
        {
            int id = 0;
            foreach (EquationItem i in items)
            {
                i.Id = (id++).ToString();
            }
        }
    }
}
