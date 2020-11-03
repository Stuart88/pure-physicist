using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.ModernPhysics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.ModernPhysics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComptonScattering : ContentPage
    {
        #region Private Fields

        private bool _isRunning = false;
        private CCLayer _layer = new CCLayer() { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Private Properties

        private CCDrawNode ElectronNode { get; set; } = new CCDrawNode();
        private CCPoint ElectronStartPos { get; set; } = new CCPoint(0, 0);

        /// <summary>
        /// In nanometres
        /// </summary>
        private double InitialWavelength { get; set; } = 0.24;

        private CCDrawNode PhotonNode { get; set; } = new CCDrawNode();
        private float PhotonSpeed { get; set; } = 1;

        private Random Rand { get; set; } = new Random();

        //nm

        private ComptonScatter Scatter { get; set; }

        private bool Scattered { get; set; } = false;

        private ComptonScatter.ComptonScatterResult ScatterResult { get; set; }

        private float SpeedScale { get; set; } = 500;

        #endregion Private Properties

        #region Public Constructors

        public ComptonScattering()
        {
            InitializeComponent();
            Scatter = new ComptonScatter(InitialWavelength * 1E-9);
            WavelengthSlider.Value = InitialWavelength;

            ElectronStartPos = new CCPoint(_viewResolution.Width / 2, _viewResolution.Height / 2);

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DrawNodes();
        }

        #endregion Protected Methods

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void DrawNodes()
        {
            _layer.Children?.Clear();

            ElectronNode.Clear();
            ElectronNode.DrawSolidCircle(new CCPoint(0, 0), 5, CCColor4B.Blue);

            PhotonNode.Clear();
            PhotonNode.DrawSolidCircle(new CCPoint(0, 0), 2, CCColor4B.White);

            _layer.AddChild(ElectronNode);
            _layer.AddChild(PhotonNode);

            ResetPositions();
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
            var touchListener = new CCEventListenerTouchOneByOne();
            touchListener.OnTouchBegan += OnTouchBegan;
            touchListener.OnTouchMoved += OnTouchMoved;

            _layer.AddEventListener(touchListener, _layer);

            // Starts CocosSharp:
            gameView.RunWithScene(gameScene);
        }

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            InfoButton.IsEnabled = false;
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Compton Scattering");
            await Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent arg)
        {
            Scattered = false;
            _isRunning = false;
            SetNodePositions(touch);
            return true;
        }

        private void OnTouchMoved(CCTouch touch, CCEvent arg2)
        {
            SetNodePositions(touch);
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            StopAndReset();
        }

        private void ResetPositions()
        {
            Scattered = false;
            ElectronNode.Position = ElectronStartPos;
            PhotonNode.Position = new CCPoint(-20, ElectronNode.Position.Y);
        }

        private void SetNodePositions(CCTouch t)
        {
            ElectronNode.Position = t.Location;
            ElectronStartPos = ElectronNode.Position;
            PhotonNode.Position = new CCPoint(-20, ElectronNode.Position.Y);
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            _layer.Schedule(Update);
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
                ResetPositions();

            ScatterResult = Scatter.PerformScatter(MathsHelpers.ToRadians(Rand.Next(-180, 181)));

            UpdateLabels();

            this.ElectronStartPos = ElectronNode.Position;

            _isRunning = true;
        }

        private void StopAndReset()
        {
            _isRunning = false;
            Scattered = false;
            ResetPositions();
        }

        private void Update(float timeInSeconds)
        {
            if (_isRunning)
            {
                if (!WithinGameArea(ElectronNode.Position))
                {
                    StopAndReset();
                }

                if (PhotonNode.Position.X < this.ElectronStartPos.X && !Scattered)
                {
                    PhotonNode.Position = new CCPoint(PhotonNode.Position.X + timeInSeconds * PhotonSpeed * SpeedScale, PhotonNode.Position.Y);
                }
                else
                {
                    Scattered = true;
                    double photonX = PhotonSpeed * SpeedScale * Math.Cos(ScatterResult.ResultantPhotonAngle);
                    double photonY = PhotonSpeed * SpeedScale * Math.Sin(ScatterResult.ResultantPhotonAngle);
                    PhotonNode.Position = new CCPoint(PhotonNode.Position.X + timeInSeconds * (float)photonX, PhotonNode.Position.Y + timeInSeconds * (float)photonY);

                    ElectronNode.Position = new CCPoint(ElectronNode.Position.X + (float)ScatterResult.ElectronVelocity.X / 3E7f, ElectronNode.Position.Y + (float)ScatterResult.ElectronVelocity.Y / 3E7f);
                }
            }
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LambdaBeforeLabel.Text = $"{Scatter.IncidentPhotonWavelength * 1E9:G3}nm";
                LambdaAfterLabel.Text = $"{ScatterResult.ResultantPhotonWavelength * 1E9:G3}nm";
                PhotonAngleLabel.Text = $"{MathsHelpers.ToDegrees(ScatterResult.ResultantPhotonAngle).DecimalPoints(0)}°";
                ElectronAngleLabel.Text = $"{-MathsHelpers.ToDegrees(ScatterResult.ElectronAngle).DecimalPoints(0)}°";
                ElectronVLabel.Text = $"{(ScatterResult.ElectronVelocity.Abs() / 3E8):G3}c";
            });
        }

        private void WavelengthSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            StopAndReset();
            Scatter.IncidentPhotonWavelength = e.NewValue * 1E-9;
            Device.BeginInvokeOnMainThread(() =>
            {
                LambdaBeforeLabel.Text = $"{Scatter.IncidentPhotonWavelength * 1E9:G3}nm";
                LambdaAfterLabel.Text = "";
                PhotonAngleLabel.Text = "";
                ElectronAngleLabel.Text = "";
                ElectronVLabel.Text = "";
            });
        }

        private bool WithinGameArea(CCPoint p)
        {
            return p.Y >= 0 &&
                   p.X <= _viewResolution.Width &&
                   p.Y <= _viewResolution.Height;
        }

        #endregion Private Methods
    }
}