using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.Icon = Functions.CreateMenuIcon(MenuItemType.ClassicalMechanics, themeColour);
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(Constants.TopicTitles.ClassicalMechanics, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(Constants.TopicTitles.ClassicalMechanics, themeColour, CoolStuffContents.GetItems(MenuItemType.ClassicalMechanics));
        }

        #endregion Public Constructors
    }
}