using System;
using System.Collections.Generic;
using System.Text;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        private const string TopicTitle = "Astrophysics";
        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(TopicTitle, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(TopicTitle, themeColour, CoolStuffContents.Items);
        }
    }
}
