using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpMath.Forms;
using PurePhysicist.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DerivationViewer : ContentPage
    {

        public DerivationViewer(EquationItem equationItem)
        {
            InitializeComponent();

            this.ViewerTitle.Text = equationItem.LabelText;

            MathView view = new MathView(){FontSize = 40, HeightRequest = equationItem.HeightRequest};
            view.LaTeX = $@"{equationItem.EquationLatex}";
            this.ViewArea.Children.Add(view);

            BoxView boxView = new BoxView
            {
                HeightRequest = 1, BackgroundColor = Color.FromHex("#999"), 
                Margin = new Thickness(0,20,0,20)
            };
            this.ViewArea.Children.Add(boxView);


            foreach (var s in equationItem.DerivationStepsLatex)
            {
                MathView newview = new MathView { FontSize = 40, HeightRequest = s.HeightRequest };
                newview.LaTeX = $@"{s.Latex}";
                this.ViewArea.Children.Add(newview);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            if (Navigation.ModalStack.Count > 0)
                await Navigation.PopModalAsync(true);

            ((Button)sender).IsEnabled = true;
        }
    }
}