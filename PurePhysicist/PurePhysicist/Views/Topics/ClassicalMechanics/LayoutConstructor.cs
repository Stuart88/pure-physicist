using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PurePhysicist.Extensions;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        public LayoutConstructor(Color themeColour) :base(themeColour)
        {
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase("Classical Mechanics", themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView();
        }

    }
}
