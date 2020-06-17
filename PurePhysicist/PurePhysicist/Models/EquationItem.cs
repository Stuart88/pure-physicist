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
        public DerivationStep(string latex, double heightRequest = 60, float fontSize = 40)
        {
            this.Latex = latex;
            this.HeightRequest = heightRequest;
            this.FontSize = fontSize;
        }
        public string Latex{ get; set; }
        public double HeightRequest{ get; set; }
        public float FontSize { get; set; }
    }
}
