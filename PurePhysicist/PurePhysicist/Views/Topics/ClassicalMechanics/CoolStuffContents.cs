using System;
using PurePhysicist.Views.Topics.ClassicalMechanics.CoolStuffItems;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class CoolStuffContents
    {
        #region Public Fields

        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Simple Pendulum", new Lazy<ContentPage>(() => new CoolStuffItems.SimplePendulum())),
            new CoolStuffView.CoolStuffListItem("Centre of Mass",new Lazy<ContentPage>(() => new CoolStuffItems.CentreOfGravity())),
            new CoolStuffView.CoolStuffListItem("Acceleration and Velocity",new Lazy<ContentPage>(() => new CoolStuffItems.AccelerationAndVelocity())),
            new CoolStuffView.CoolStuffListItem("Spinning Wheel", new Lazy<ContentPage>(() => new CoolStuffItems.SpinningWheel()))
        };

        #endregion Public Fields
    }
}