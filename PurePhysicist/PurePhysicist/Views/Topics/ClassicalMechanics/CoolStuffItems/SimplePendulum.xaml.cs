using CocosSharp;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Linq;
using UniversityPhysics.Maths;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.ClassicalMechanics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplePendulum : ContentPage
    {
        #region Public Fields

        public UniversityPhysics.Mechanics.SimplePendulum Pendulum = new UniversityPhysics.Mechanics.SimplePendulum(10, 1, Math.PI / 6);

        #endregion Public Fields

        #region Private Fields

        private float _elapsedTime = 0f;

        private CCLayer _layer = new CCLayer() {ContentSize = new CCSize((float) App.DeviceWidth, (float) App.DeviceHeight / 2)};

        private CCRect _pendulumRect;
        private CCDrawNode _pendulumString = new CCDrawNode {Color = CCColor3B.White};

        /// <summary>
        /// Amount to scale pendulum on screen
        /// </summary>
        private float _scaleFactor = 5;

        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Public Constructors

        public SimplePendulum()
        {
            //_scaleFactor = (float)(_viewResolution.Height / Pendulum.StringLength);

            _pendulumRect = new CCRect(0, 0, 1, -(float) Pendulum.StringLength * _scaleFactor) {Origin = new CCPoint(0, 0)};

            InitializeComponent();

            LengthSlider.Value = Pendulum.StringLength;
            AngleSlider.Value = Pendulum.StartAngle;
            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Private Methods

        private void AngleSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //this.StartStopAnimation(shouldStop: true);

            Pendulum.StartAngle = e.NewValue;

            _pendulumString.Rotation = (float) MathsHelpers.ToDegrees(e.NewValue);

            UpdateLabels();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void HandleViewCreated(object sender, EventArgs e)
        {
            if (!(sender is CCGameView gameView)) return;

            // This sets the game "world" resolution to 100x100:
            gameView.DesignResolution = _viewResolution;

            // GameScene is the root of the CocosSharp rendering hierarchy:
            CCScene gameScene = new CCScene(gameView);

            SetupGameScene(gameScene);

            // Starts CocosSharp:
            gameView.RunWithScene(gameScene);
        }

        private void LengthSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Pendulum.StringLength = e.NewValue;

            _pendulumRect.Size.Height = -(float) e.NewValue * _scaleFactor;
            _pendulumString.Clear();
            _pendulumString.DrawRect(_pendulumRect);

            UpdateLabels();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Pendulum.LocalGravity = ((RadioButton) sender).Text switch
            {
                "0g" => 0,
                "g" => UniversityPhysics.UnitsAndConstants.Constants.Common.StandardGravity,
                "5g" => 5 * UniversityPhysics.UnitsAndConstants.Constants.Common.StandardGravity,
                "10g" => 10 * UniversityPhysics.UnitsAndConstants.Constants.Common.StandardGravity,
                _ => throw new Exception("No gravity value!")
            };

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            bool justShowZero = Pendulum.StartAngle == 0 || Pendulum.StringLength == 0;

            Device.BeginInvokeOnMainThread(() =>
            {
                AngleLabel.Text = $"{(justShowZero ? 0 : MathsHelpers.ToDegrees(Pendulum.StartAngle).DecimalPoints(2))}°";
                StringLengthLabel.Text = $"{Pendulum.StringLength.DecimalPoints(2)} m";
                PeriodLabel.Text = $"T = {(justShowZero ? 0 : Pendulum.Period.DecimalPoints(2))} s";
                FrequencyLabel.Text = $"f = {Pendulum.Frequency.DecimalPoints(2)} Hz";
                AngularFrequencyLabel.Text = $"ω = {Pendulum.Frequency.DecimalPoints(2)} rad/s";
            });
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            _layer.AddChild(_pendulumString);

            _pendulumString.PositionX = (float) _viewResolution.Width / 2;
            _pendulumString.PositionY = _viewResolution.Height;

            _pendulumString.DrawRect(_pendulumRect);

            _layer.Schedule(Update);
        }


        private void Update(float timeInSeconds)
        {
            _elapsedTime += timeInSeconds;

            _pendulumString.Rotation = (float) Pendulum.AngleAfterTime((double) _elapsedTime);
        }

        #endregion Private Methods

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            InfoButton.IsEnabled = false;
            var equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "The Simple Pendulum");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "Cool Stuff"));
            InfoButton.IsEnabled = true;
        }

        private void LengthSlider_DragStarted(object sender, EventArgs e)
        {
            _layer.Pause();
        }

        private void LengthSlider_DragCompleted(object sender, EventArgs e)
        {
            _layer.Resume();
        }
    }
}