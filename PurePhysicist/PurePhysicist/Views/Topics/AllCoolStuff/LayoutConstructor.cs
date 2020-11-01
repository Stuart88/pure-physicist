using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Views.Topics.AllCoolStuff
{
    public class LayoutConstructor : LayoutConstructorBase
    {
        #region Public Constructors

        public LayoutConstructor(Color themeColour) : base(themeColour)
        {
            this.Icon = Functions.CreateMenuIcon(MenuItemType.CoolStuff, themeColour);
            this.ContentsPage = null;
            this.EquationsPage = null;
            this.CoolStuffPage = new CoolStuffView(Constants.TopicTitles.CoolStuff, themeColour, CoolStuffContents.GetItems(MenuItemType.CoolStuff));
            this.IsCoolStuffPage = true;
        }

        #endregion Public Constructors
    }
}