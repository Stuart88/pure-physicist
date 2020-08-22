using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public interface ITopicPage
    {
        #region Public Properties

        public string PageTitle { get; set; }
        public Color ThemeColour { get; set; }

        #endregion Public Properties
    }
}