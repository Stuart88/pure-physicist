using System;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Mathematics
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Fourier Waves", new Lazy<ContentPage>(() => new CoolStuffItems.FourierWaveGenerator())),
        };

        #endregion Public Fields
    }
}