using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        public LayoutConstructor(Color buttonsColour) : base(buttonsColour)
        {
            this.ContentsPage = new ContentsView();
        }
    }
}
