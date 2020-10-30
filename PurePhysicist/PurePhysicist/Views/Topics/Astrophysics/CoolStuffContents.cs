using System;
using PurePhysicist.Views.Topics.Astrophysics.CoolStuffItems;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Orbit Sim", new Lazy<ContentPage>(() => new CoolStuffItems.OrbitSim())),
        };

        #endregion Public Fields
    }
}