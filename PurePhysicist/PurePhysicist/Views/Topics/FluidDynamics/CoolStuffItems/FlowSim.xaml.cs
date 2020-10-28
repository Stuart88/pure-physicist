using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Electromagnetism;
using UniversityPhysics.FluidDynamics;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.FluidDynamics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowSim : ContentPage
    {
        #region Private Fields

        private readonly CCDrawNode _centreWheelNode = new CCDrawNode() { Color = CCColor3B.Blue };
        private readonly List<(int id, CCDrawNode node, PointMass charge)> _particles = new List<(int id, CCDrawNode node, PointMass charge)>();
        private readonly int _particlesAmount = 500;
        private bool _sceneLoaded;
        private readonly CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2)};
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Private Properties

        private VelocityField SelectedVelocityField { get; set; } = CommonVelocityFields.UniformStream;

        private double FlowStrength { get; set; } = 1d;

        #endregion Private Properties

        #region Public Constructors

        public FlowSim()
        {
            InitializeComponent();

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this._sceneLoaded = true;

            RedrawGameScene();
        }

        private void RedrawGameScene()
        {
            
        }

        #endregion Protected Methods

        #region Private Methods


        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await this.Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void FieldSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender is Slider s)
            {
                switch (s.AutomationId)
                {
                    case "FlowRate":
                        CommonVelocityFields.FlowStrength = e.NewValue;
                        break;

                }
            }
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
            //InfoButton.IsEnabled = false;
            //EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Velocity Selector");
            //await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            //InfoButton.IsEnabled = true;
        }

       
        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            RedrawGameScene();

            _layer.Schedule(Update);
        }

        private void Update(float timeInSeconds)
        {
            

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //VelocitySliderLabel.Text = $"Particle v: {(this.ElectronVelocity.X / 3E8).DecimalPoints(2)}c";
            });
        }

        #endregion Private Methods
    }
}