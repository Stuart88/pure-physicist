using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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
    }
}
