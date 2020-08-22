using PurePhysicist.Helpers;
using PurePhysicist.Models;
using PurePhysicist.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.Thermodynamics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentsView : ContentView, ITopicPage, IPhysicistFetcher
    {
        #region Public Properties

        public bool IsShowing { get; set; }
        public string PageTitle { get; set; }
        public RandomPhysicistFetcher PhysicistFetcher { get; }
        public Color ThemeColour { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public ContentsView(Color themeColour)
        {
            this.ThemeColour = themeColour;

            this.PageTitle = Constants.TopicTitles.Thermodynamics;

            this.BindingContext = this;

            this.PhysicistFetcher = new RandomPhysicistFetcher(TopicsEnum.Thermodynamics);

            InitializeComponent();

            SetPhysicistView();
        }

        #endregion Public Constructors

        #region Public Methods

        public void SetIsShowing(bool isShowing)
        {
            this.IsShowing = isShowing;
        }

        public void SetPhysicistView()
        {
            this.PhysicistView.Content = new PhysicistCard(this.PhysicistFetcher.GetNextPhysicist());
        }

        #endregion Public Methods
    }
}