using PurePhysicist.Views.Topics;
using Xamarin.Forms;

namespace PurePhysicist.Models
{
    public class LayoutConstructorBase
    {
        #region Public Properties

        public TapGestureRecognizer Button1Tap { get; set; } = new TapGestureRecognizer();

        public TapGestureRecognizer Button2Tap { get; set; } = new TapGestureRecognizer();

        public TapGestureRecognizer Button3Tap { get; set; } = new TapGestureRecognizer();

        public TapGestureRecognizer Button4Tap { get; set; } = new TapGestureRecognizer();

        public Color ButtonsColour { get; set; }

        public ContentView ContentsPage { get; set; } = new UnderConstruction();

        public ContentView CoolStuffPage { get; set; } = new UnderConstruction();

        public ContentView EquationsPage { get; set; } = new UnderConstruction();

        #endregion Public Properties

        #region Public Constructors

        public LayoutConstructorBase(Color buttonsColour)
        {
            this.ButtonsColour = buttonsColour;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual void SetupButtonImageSources()
        {
        }

        #endregion Public Methods
    }
}