using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Extensions
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        #region Public Properties

        public string Source { get; set; }

        #endregion Public Properties

        #region Public Methods

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            return ImageSource.FromResource($"PurePhysicist.Images.{Source}", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        }

        #endregion Public Methods
    }
}