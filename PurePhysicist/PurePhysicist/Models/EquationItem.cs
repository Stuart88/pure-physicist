using CSharpMath.Atom;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public class EquationItem
    {
        /// <summary>
        /// Automatically assigned when sent into view as part of a list.
        /// </summary>
        public string Id { get; set; }

        public string EquationLatex { get; set; }
        public double HeightRequest { get; set; }

        public string LabelText{ get; set; }
        public List<DerivationStep> DerivationStepsLatex { get; set; }
        public EquationItem(string label, double heightRequest = 60)
        {
            this.LabelText = label;
            this.HeightRequest = heightRequest;
        }

        public bool ShowDetailsButton => DerivationStepsLatex?.Count > 0;
    }

    public class DerivationStep
    {
        public DerivationStep(string latex, double heightRequest = 60)
        {
            this.Latex = latex;
            this.HeightRequest = heightRequest;
        }
        public string Latex{ get; set; }
        public double HeightRequest{ get; set; }

        public static implicit operator string(DerivationStep d) => d.Latex;
        public static explicit operator DerivationStep(string s) => new DerivationStep(s);
    }
}
