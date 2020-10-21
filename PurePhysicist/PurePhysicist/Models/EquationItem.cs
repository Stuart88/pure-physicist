using System.Collections.Generic;

namespace PurePhysicist.Models
{
    public class DerivationStep
    {
        #region Public Properties

        /// <summary>
        /// Label title of the equation the button should navigate to
        /// </summary>
        public string ButtonNavigation { get; set; }

        public float FontSize { get; set; }

        public double HeightRequest { get; set; }

        public bool IsButton { get; set; }

        public string Latex { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public DerivationStep()
        {
        }

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

        #endregion Public Constructors
    }

    public class EquationItem : DerivationStep
    {
        #region Public Properties

        public List<DerivationStep> DerivationStepsLatex { get; set; }

        public string EquationLatex { get; set; }

        /// <summary>
        /// Automatically assigned when sent into view as part of a list.
        /// </summary>
        public string Id { get; set; }

        public string LabelText { get; set; }
        public bool ShowDetailsButton => DerivationStepsLatex?.Count > 0;

        #endregion Public Properties

        #region Public Constructors

        public EquationItem(string label, double heightRequest = 80, float fontSize = 40)
        {
            this.LabelText = label;
            this.HeightRequest = heightRequest;
            this.FontSize = fontSize;
        }

        #endregion Public Constructors
    }
}