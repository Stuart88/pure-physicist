using System;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.FluidDynamics
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Flow Sim", new Lazy<ContentPage>(() => new CoolStuffItems.FlowSim())),
        };

        #endregion Public Fields
    }
}