using PurePhysicist.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics
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
