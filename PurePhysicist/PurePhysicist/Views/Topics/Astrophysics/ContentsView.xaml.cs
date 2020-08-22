using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PurePhysicist.Extensions;
using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsView : ContentView, ITopicPage
    {
        public Color ThemeColour { get; set; }

        private int _num = 0;
        public ContentsView(Color themeColour)
        {
            this.ThemeColour = themeColour;

            this.BindingContext = this;

            InitializeComponent();

            this.PhysicistView.Content = new PhysicistCard(PhyscistsCollection.RandomPhysicist());

            Device.StartTimer(TimeSpan.FromSeconds(3), () => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.PhysicistView.Content = new PhysicistCard(PhyscistsCollection.RandomPhysicist());
                });
                return true;
            });

        }
    }
}