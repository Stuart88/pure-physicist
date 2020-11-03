using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.ModernPhysics
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.Icon = Functions.CreateMenuIcon(MenuItemType.QuantumPhysics, themeColour);
            this.ContentsPage = new ContentsView(themeColour);
            this.EquationsPage = new EquationsViewBase(Constants.TopicTitles.ModernPhysics, themeColour, Equations.EquationsList);
            this.CoolStuffPage = new CoolStuffView(Constants.TopicTitles.ModernPhysics, themeColour, CoolStuffContents.GetItems(MenuItemType.ModernPhysics));
        }

        #endregion Public Constructors
    }
}