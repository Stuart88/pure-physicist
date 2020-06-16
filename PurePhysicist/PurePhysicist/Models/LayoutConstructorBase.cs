using PurePhysicist.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using PurePhysicist.Views.Topics;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public class LayoutConstructorBase
    {
        public LayoutConstructorBase(Color buttonsColour)
        {
            this.ButtonsColour = buttonsColour;
        }
        public ContentView ContentsPage { get; set; } = new UnderConstruction();
        public ContentView EquationsPage { get; set; } = new UnderConstruction();
        public ContentView CoolStuffPage { get; set; } = new UnderConstruction();

        public TapGestureRecognizer Button1Tap { get; set; } = new TapGestureRecognizer();
        public TapGestureRecognizer Button2Tap { get; set; } = new TapGestureRecognizer();
        public TapGestureRecognizer Button3Tap { get; set; } = new TapGestureRecognizer();
        public TapGestureRecognizer Button4Tap { get; set; } = new TapGestureRecognizer();

        public Color ButtonsColour { get; set; }

        public virtual void SetupButtonImageSources() { }
    }
}
