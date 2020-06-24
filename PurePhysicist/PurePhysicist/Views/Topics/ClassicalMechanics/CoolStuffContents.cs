using System;
using System.Collections.Generic;
using System.Text;
using PurePhysicist.Views.Topics.ClassicalMechanics.CoolStuffItems;
using PurePhysicist.Views.Topics.TopicPageTemplates;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class CoolStuffContents
    {
        public static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem("Simple Pendulum", new SimplePendulum()),
            new CoolStuffView.CoolStuffListItem("Centre of Mass", new CentreOfGravity()),
            new CoolStuffView.CoolStuffListItem("Acceleration and Velocity", new AccelerationAndVelocity()),
            new CoolStuffView.CoolStuffListItem("Spinning Wheel", new SpinningWheel())
        };
    }
}
