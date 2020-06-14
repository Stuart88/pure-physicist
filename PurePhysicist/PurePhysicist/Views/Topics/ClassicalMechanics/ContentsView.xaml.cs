using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsView : ContentView, ITopicPage
    {
        public Color ThemeColour { get; set; }
        public ContentsView(Color themeColour)
        {
            this.ThemeColour = themeColour;
            
            this.BindingContext = this;
            
            InitializeComponent();
            
        }
    }
}