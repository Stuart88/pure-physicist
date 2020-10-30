using System;
using PurePhysicist.Views.Topics.Electromagnetism.CoolStuffItems;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Electromagnetism
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Velocity Selector", new Lazy<ContentPage>(() => new CoolStuffItems.MassSpectrometer())),
        };

        #endregion Public Fields
    }
}