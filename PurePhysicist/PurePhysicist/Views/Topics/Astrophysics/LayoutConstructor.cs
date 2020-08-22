using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(Constants.TopicTitles.Astrophysics, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(Constants.TopicTitles.Astrophysics, themeColour, CoolStuffContents.Items);
        }

        #endregion Public Constructors
    }
}