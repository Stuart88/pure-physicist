using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Thermodynamics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Private Fields

        private const string TopicTitle = "Thermodynamics";

        #endregion Private Fields

        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(TopicTitle, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(TopicTitle, themeColour, CoolStuffContents.Items);
        }

        #endregion Public Constructors
    }
}