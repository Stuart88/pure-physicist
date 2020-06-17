using CSharpMath.Atom;
using CSharpMath.Rendering.BackEnd;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public class EquationItem : DerivationStep
    {
        /// <summary>
        /// Automatically assigned when sent into view as part of a list.
        /// </summary>
        public string Id { get; set; }

        public string EquationLatex { get; set; }
        public string LabelText{ get; set; }
        public List<DerivationStep> DerivationStepsLatex { get; set; }
        public EquationItem(string label, double heightRequest = 60, float fontSize = 40) 
        {
            this.LabelText = label;
            this.HeightRequest = heightRequest;
            this.FontSize = fontSize;
        }

        public bool ShowDetailsButton => DerivationStepsLatex?.Count > 0;
    }

    public class DerivationStep
    {
        public DerivationStep(){}

        /// <param name="latex">Latex code for equation</param>
        /// <param name="isButton">If this will act as a button to navigate to another equation</param>
        /// <param name="buttonNavivation">The label text of the equation to navigate</param>
        public DerivationStep(string latex, double heightRequest = 60, float fontSize = 40, bool isButton = false, string buttonNavivation = "")
        {
            this.Latex = latex;
            this.HeightRequest = heightRequest;
            this.FontSize = fontSize;
            this.IsButton = isButton;
            this.ButtonNavigation = buttonNavivation;
        }
        public string Latex{ get; set; }
        public double HeightRequest{ get; set; }
        public float FontSize { get; set; }
        public bool IsButton { get; set; }
        /// <summary>
        /// Label title of the equation the button should navigate to
        /// </summary>
        public string ButtonNavigation { get; set; }
    }
}
