using PurePhysicist.Models;
using System;
using System.Reflection;
using Xamarin.Forms;

namespace PurePhysicist.Helpers
{
    public static class ImageSourceHelpers
    {
        #region Public Methods

        public static ImageSource CreateImageSource(string source, Assembly assembly)
        {
            return ImageSource.FromResource($"PurePhysicist.Images.{source}", assembly);
        }

        public static ImageSource CreateRandomPhysicistImageSource(Assembly assembly)
        {
            int randomIndex = new Random().Next(0, PhyscistsCollection.Physicists.Count);

            return ImageSource.FromResource($"PurePhysicist.Images.Physicists.{PhyscistsCollection.Physicists[randomIndex].ImageFileName}", assembly);
        }

        #endregion Public Methods
    }
}