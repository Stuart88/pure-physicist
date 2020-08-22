using CSharpMath.Forms;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.ClassicalMechanics;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.TopicPageTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DerivationViewer : ContentPage
    {
        #region Public Constructors

        public DerivationViewer(EquationItem equationItem, string backToName = "List")
        {
            InitializeComponent();

            this.ViewerTitle.Text = equationItem.LabelText;
            this.BackButton.Text = $"Back to {backToName}";

            MathView view = new MathView() { FontSize = equationItem.FontSize, HeightRequest = equationItem.HeightRequest };
            view.LaTeX = $@"{equationItem.EquationLatex}";
            this.ViewArea.Children.Add(view);

            BoxView boxView = new BoxView
            {
                HeightRequest = 1,
                BackgroundColor = Color.FromHex("#999"),
                Margin = new Thickness(0, 20, 0, 20)
            };
            this.ViewArea.Children.Add(boxView);

            foreach (var s in equationItem.DerivationStepsLatex)
            {
                if (s.IsButton)
                {
                    StackLayout infoArea = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };
                    Label forTheAbove = new Label
                    {
                        Text = $"For the above: ",
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    Label infoLabel = new Label
                    {
                        Text = $"See \"{s.ButtonNavigation}\"",
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    };
                    Button infoButton = new Button
                    {
                        Text = "PEEK",
                        Style = (Style)Application.Current.Resources["BlueButton"],
                        VerticalOptions = LayoutOptions.Center,
                        FontSize = 14,
                    };
                    infoButton.Clicked += async (sender, args) =>
                    {
                        var equationToShow = Equations.EquationsList.FirstOrDefault(x => x.LabelText == s.ButtonNavigation);
                        if (equationToShow != null)
                        {
                            await this.Navigation.PushModalAsync(new DerivationViewer(equationToShow, equationItem.LabelText));
                        }
                    };
                    infoArea.Children.Add(forTheAbove);
                    infoArea.Children.Add(infoLabel);
                    infoArea.Children.Add(infoButton);
                    this.ViewArea.Children.Add(infoArea);
                }
                else
                {
                    MathView newview = new MathView { FontSize = s.FontSize, HeightRequest = s.HeightRequest };
                    newview.LaTeX = $@"{s.Latex}";
                    this.ViewArea.Children.Add(newview);
                }
            }
        }

        #endregion Public Constructors

        #region Private Methods

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            if (Navigation.ModalStack.Count > 0)
                await Navigation.PopModalAsync(true);

            ((Button)sender).IsEnabled = true;
        }

        #endregion Private Methods
    }
}