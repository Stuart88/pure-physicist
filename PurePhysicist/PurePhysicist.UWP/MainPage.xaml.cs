namespace PurePhysicist.UWP
{
    public sealed partial class MainPage
    {
        #region Public Constructors

        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new PurePhysicist.App());
        }

        #endregion Public Constructors
    }
}