using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PurePhysicist.Extensions;
using PurePhysicist.Models;
using Xamarin.Forms;

namespace PurePhysicist.Helpers
{
    public static class ImageSourceHelpers
    {
        public static ImageSource CreateImageSource(string source, Assembly assembly)
        {
            return ImageSource.FromResource($"PurePhysicist.Images.{source}", assembly);
        }

        public static ImageSource CreateRandomPhysicistImageSource(Assembly assembly)
        {
            int randomIndex = new Random().Next(0, PhyscistsCollection.Physicists.Count);

            return ImageSource.FromResource($"PurePhysicist.Images.Physicists.{PhyscistsCollection.Physicists[randomIndex].ImageFileName}", assembly);
        }
    }
}
