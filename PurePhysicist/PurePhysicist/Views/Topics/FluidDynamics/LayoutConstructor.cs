using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.FluidDynamics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.Icon = Functions.CreateMenuIcon(MenuItemType.FluidDynamics, themeColour);
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(Constants.TopicTitles.FluidDynamics, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(Constants.TopicTitles.FluidDynamics, themeColour, CoolStuffContents.GetItems(MenuItemType.FluidDynamics));
        }

        #endregion Public Constructors
    }
}