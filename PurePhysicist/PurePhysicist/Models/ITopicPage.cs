using PurePhysicist.Helpers;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public interface ITopicPage
    {
        #region Public Properties
        public Color ThemeColour { get; set; }
        public string PageTitle { get; set; }

        #endregion

        
    }
}