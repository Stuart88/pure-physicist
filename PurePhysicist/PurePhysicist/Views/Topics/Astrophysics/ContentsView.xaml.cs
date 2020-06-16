using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurePhysicist.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsView : ContentView, ITopicPage
    {
        public ContentsView()
        {
            InitializeComponent();
        }

        public Color ThemeColour { get; set; }
    }
}