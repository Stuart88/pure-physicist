using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.ClassicalMechanics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccelerationAndVelocity : ContentPage
    {
        #region Private Fields

        private Particle _car1 = new Particle(1);
        private CCDrawNode _car1DrawNode = new CCDrawNode { Color = CCColor3B.Blue };
        private CCRect _car1Rect;
        private Particle _car2 = new Particle(1);
        private CCDrawNode _car2DrawNode = new CCDrawNode { Color = CCColor3B.Orange };
        private CCRect _car2Rect;
        private float _elapsedTime = 0f;

        private bool _isRunning = false;
        private CCLayer _layer = new CCLayer() { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };
        private CCSizeI _viewResolution = new CCSizeI(100, 110);

        #endregion Private Fields

        #region Public Constructors

        public AccelerationAndVelocity()
        {
            _car1Rect = new CCRect(0, 0, 5, 10) { Origin = new CCPoint(0, 0) };
            _car2Rect = new CCRect(0, 0, 5, 10) { Origin = new CCPoint(0, 0) };

            InitializeComponent();

            StartStopButton.Text = "Start";

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void Car1AccelerationSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _car1.Acceleration = new Vector(0, e.NewValue, 0);
            UpdateLabels();
        }

        private void Car1VelocitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _car1.Velocity = new Vector(0, e.NewValue, 0);
            UpdateLabels();
        }

        private void Car2AccelerationSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _car2.Acceleration = new Vector(0, e.NewValue, 0);
            UpdateLabels();
        }

        private void Car2VelocitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _car2.Velocity = new Vector(0, e.NewValue, 0);
            UpdateLabels();
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

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            InfoButton.IsEnabled = false;
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "The SUVAT Equations");
            await Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private void ReDrawScene()
        {
            _car1DrawNode.Clear();
            _car2DrawNode.Clear();

            _layer.AddChild(_car1DrawNode);
            _layer.AddChild(_car2DrawNode);

            _car1DrawNode.PositionX = (float)_viewResolution.Width / 5;
            _car1DrawNode.PositionY = 0;

            _car2DrawNode.PositionX = 4 * (float)_viewResolution.Width / 5;
            _car2DrawNode.PositionY = 0;

            _car1DrawNode.DrawRect(_car1Rect);
            _car2DrawNode.DrawRect(_car2Rect);

            _car1.Position = new Vector(_car1DrawNode.Position.X, _car1DrawNode.Position.Y);
            _car2.Position = new Vector(_car2DrawNode.Position.X, _car2DrawNode.Position.Y);
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            StartStopRunning(true);

            _elapsedTime = 0;

            _car1.Acceleration = new Vector(0, Car1AccelerationSlider.Value);
            _car2.Acceleration = new Vector(0, Car2AccelerationSlider.Value);
            _car1.Velocity = new Vector(0, Car1VelocitySlider.Value);
            _car2.Velocity = new Vector(0, Car2VelocitySlider.Value);

            ReDrawScene();
            UpdateLabels();
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            ReDrawScene();

            _layer.Schedule(Update);
        }

        private void StartStopButton_Clicked(object sender, EventArgs e)
        {
            StartStopRunning(_isRunning);
        }

        private void StartStopRunning(bool shouldPause)
        {
            if (shouldPause)
            {
                _isRunning = false;
                _layer.Pause();
                Device.BeginInvokeOnMainThread(() => { StartStopButton.Text = "Start"; });
                StartStopButton.BackgroundColor = Color.Green;
            }
            else
            {
                _isRunning = true;
                _layer.Resume();
                Device.BeginInvokeOnMainThread(() => { StartStopButton.Text = "Stop"; });
                StartStopButton.BackgroundColor = Color.Red;
            }
        }

        private void Update(float timeInSeconds)
        {
            if (_isRunning)
            {
                if (_car1.Position.Y >= 100) StartStopRunning(true);

                if (_car2.Position.Y >= 100) StartStopRunning(true);

                _elapsedTime += timeInSeconds;

                _car1.Move(timeInSeconds);
                _car2.Move(timeInSeconds);

                _car1DrawNode.PositionY = (float)_car1.Position.Y;
                _car2DrawNode.PositionY = (float)_car2.Position.Y;

                UpdateLabels();
            }
            else
            {
                StartStopRunning(true);
            }
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Car1Velocity.Text = $"v: {_car1.Velocity.Y.DecimalPoints(2)} m/s";
                Car1Displacement.Text = $"s: {_car1.Position.Y.DecimalPoints(2)} m";
                Car2Velocity.Text = $"v: {_car2.Velocity.Y.DecimalPoints(2)} m/s";
                Car2Displacement.Text = $"s: {_car2.Position.Y.DecimalPoints(2)} m";

                Car1VelocitySliderLabel.Text = $"{Car1VelocitySlider.Value} m/s";
                Car1AccelerationSliderLabel.Text = $"{Car1AccelerationSlider.Value} m/s";
                Car2VelocitySliderLabel.Text = $"{Car2VelocitySlider.Value} m/s";
                Car2AccelerationSliderLabel.Text = $"{Car2AccelerationSlider.Value} m/s";

                TimerLabel.Text = $"{MathsHelpers.DecimalPoints(_elapsedTime, 2):0.00}s";
            });
        }

        #endregion Private Methods
    }
}