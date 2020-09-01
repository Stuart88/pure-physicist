using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Diagnostics;
using System.Linq;
using UniversityPhysics.Astrophysics;
using UniversityPhysics.Maths;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LocalConstants = UniversityPhysics.UnitsAndConstants.Constants;

namespace PurePhysicist.Views.Topics.Astrophysics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrbitSim : ContentPage
    {
        #region Private Fields

        private const double AU = LocalConstants.AstrophysicalConstants.AU;
        private CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };
        private (double min, double max) _massRange = (0.000003003, 5 * 0.000003003);
        private GravitationalBody _planet;
        private CCDrawNode _planetNode = new CCDrawNode { Color = CCColor3B.Green };
        private GravitationalBody _star;
        private CCDrawNode _starNode = new CCDrawNode { Color = CCColor3B.Yellow };
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Private Properties

        private double TimeRate { get; set; }
        private double TotalTimeElapsed { get; set; }

        #endregion Private Properties

        #region Public Constructors

        public OrbitSim()
        {
            _planet = new GravitationalBody(LocalConstants.AstrophysicalConstants.Earth_Radius, LocalConstants.AstrophysicalConstants.Solar_Mass * _massRange.min);
            _star = CommonAstroObjects.Sol;

            InitializeComponent();

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RedrawGameScene();
        }

        #endregion Protected Methods

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await this.Navigation.PopModalAsync();
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

            // Register for touch events
            CCEventListenerTouchOneByOne touchListener = new CCEventListenerTouchOneByOne();
            touchListener.OnTouchBegan += OnTouchBegan;
            touchListener.OnTouchMoved += OnTouchMoved;
            touchListener.OnTouchEnded += OnTouchEnded;

            _layer.AddEventListener(touchListener, _layer);

            // Starts CocosSharp:
            gameView.RunWithScene(gameScene);
        }

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            InfoButton.IsEnabled = false;
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Kepler's 2nd Law");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent arg)
        {
            return true;
        }

        private void OnTouchEnded(CCTouch touch, CCEvent arg)
        {
            this.TotalTimeElapsed = 0;

            _planet.Position.X = ((2d * touch.Location.X / _viewResolution.Width - 1) * 3 * AU);
            _planet.Position.Y = ((2d * touch.Location.Y / _viewResolution.Height - 1) * 3 * AU);

            CCPoint d = touch.Delta;
            _planet.Velocity = new Vector(d.X, d.Y) * 10000;
        }

        private void OnTouchMoved(CCTouch touch, CCEvent arg2)
        {
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            this.TimeRate = ((RadioButton)sender).Text switch
            {
                "Days" => LocalConstants.Time.Day_Seconds,
                "Weeks" => LocalConstants.Time.Week_Seconds,
                "Months" => LocalConstants.Time.Month_Seconds,
                "Years" => LocalConstants.Time.Year_Seconds,
                _ => throw new Exception("No time rate value!")
            };

            UpdateLabels();
        }

        private const float StarRadiusInView = 5;
        private const float PlanetRadiusInView = 2;
        private void RedrawGameScene()
        {
            _star.Position = new Vector(0, 0);
            _planet.Position = new Vector(LocalConstants.AstrophysicalConstants.AU, 0);
            _planet.Velocity = new Vector(0, 29780); //Earth average velocity 29780 m/s

            _planetNode.Clear();
            _layer.Children?.Clear();
            _layer.AddChild(_starNode);
            _layer.AddChild(_planetNode);

            _starNode.PositionX = (float)_viewResolution.Width / 2;
            _starNode.PositionY = (float)_viewResolution.Height / 2;
            _starNode.DrawCircle(new CCPoint(0, 0), StarRadiusInView, CCColor4B.Yellow);

            _planetNode.PositionX = (float)(_planet.Position.X / (3 * AU)) * _viewResolution.Width / 2 + (_viewResolution.Width / 2f);
            _planetNode.PositionY = (float)(_planet.Position.Y / (3 * AU)) * _viewResolution.Height / 2 + (_viewResolution.Height / 2f);
            _planetNode.DrawCircle(new CCPoint(0, 0), PlanetRadiusInView, CCColor4B.Green);
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            RedrawGameScene();

            _layer.Schedule(Update);
        }

        private void Update(float timeInSeconds)
        {
            try
            {
                var planetPosInView = new Vector(_planetNode.Position.X - _viewResolution.Width / 2, _planetNode.Position.Y - _viewResolution.Height / 2);
                if (planetPosInView.Abs() <= StarRadiusInView + PlanetRadiusInView)
                    throw new OverLappingRadiusException();

                Vector forceFelt = _planet.GravitationalForceToward(_star);

                this.TotalTimeElapsed += timeInSeconds * this.TimeRate;

                _planet.AddForce_Translational(forceFelt);
                _planet.Move(timeInSeconds * this.TimeRate);
                _planet.ClearForce_Translational();

                _star.AddForce_Translational(-forceFelt);
                _star.Move(timeInSeconds * this.TimeRate);
                _star.ClearForce_Translational();

                _planetNode.PositionX = _planet.Position.X == 0 ? 0 : (float)(_planet.Position.X / (3f * AU)) * _viewResolution.Width / 2f + (_viewResolution.Width / 2f);
                _planetNode.PositionY = _planet.Position.Y == 0 ? 0 : (float)(_planet.Position.Y / (3f * AU)) * _viewResolution.Height / 2f + (_viewResolution.Height / 2f);

                UpdateLabels();
            }
            catch (OverLappingRadiusException ex)
            {
                RedrawGameScene();
            }

           
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TotalTimeLabel.Text = "Time: " + this.TimeRate switch
                {
                    LocalConstants.Time.Day_Seconds => $"{MathsHelpers.SecondsToTimeMeasure(this.TotalTimeElapsed, UniversityPhysics.Enums.TimeMeasure.Day, 0)} days",
                    LocalConstants.Time.Week_Seconds => $"{MathsHelpers.SecondsToTimeMeasure(this.TotalTimeElapsed, UniversityPhysics.Enums.TimeMeasure.Week, 0)} weeks",
                    LocalConstants.Time.Month_Seconds => $"{MathsHelpers.SecondsToTimeMeasure(this.TotalTimeElapsed, UniversityPhysics.Enums.TimeMeasure.Month, 0)} months",
                    LocalConstants.Time.Year_Seconds => $"{MathsHelpers.SecondsToTimeMeasure(this.TotalTimeElapsed, UniversityPhysics.Enums.TimeMeasure.Year, 0)} years",
                    _ => $"{MathsHelpers.SecondsToTimeMeasure(this.TotalTimeElapsed, UniversityPhysics.Enums.TimeMeasure.Second, 0)} seconds"
                };

                VelocityLabel.Text = $"Velocity: {_planet.Velocity.Abs().DecimalPoints(0)} m/s";
                RadiusLabel.Text = $"Radius: {(_planet.Position.DistanceTo(_star.Position) / AU).DecimalPoints(3)}AU";
                KineticEnergyLabel.Text = $"KE: {(_planet.KineticEnergy_Translational.Abs() / 1E27).DecimalPoints(1)}E27 J";
                PotentialEnergyLabel.Text = $"PE: {(_planet.PotentialEnergyFrom(_star) / 1E27).DecimalPoints(1)} E27 J";
            });
        }

        #endregion Private Methods

    }
}