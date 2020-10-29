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
        private readonly List<(int id, CCDrawNode node, Particle particle)> _particles = new List<(int id, CCDrawNode node, Particle charge)>();
        private readonly int _particlesAmount = 500;
        private bool _sceneLoaded;
        private readonly CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2)};
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Private Properties

        private VelocityField SelectedVelocityField { get; set; } = CommonVelocityFields.UniformStream;
        public List<VelocityFieldListItem> VelocityFields { get; set; } = new List<VelocityFieldListItem>()
        {
            new VelocityFieldListItem("Uniform Flow", CommonVelocityFields.UniformStream),
            new VelocityFieldListItem("Shear Flow", CommonVelocityFields.ShearFlow),
            new VelocityFieldListItem("Stagnation Point Flow", CommonVelocityFields.StagnationPoint),
            new VelocityFieldListItem("Vortex",CommonVelocityFields.Vortex),
            new VelocityFieldListItem("Rankine Vortex",CommonVelocityFields.RankineVortex),
            new VelocityFieldListItem("Flow Past a Sphere",CommonVelocityFields.FlowPast_Sphere),
            new VelocityFieldListItem("Rotating Cylinder",CommonVelocityFields.RotatingCylinder)
        };

        #endregion Private Properties

        #region Public Constructors

        public FlowSim()
        {
            InitializeComponent();

            CommonVelocityFields.FlowStrength = 1;
            CommonVelocityFields.CentralObjectRadius = 30;
            CommonVelocityFields.CentralObjectRotation = 5000;
            CommonVelocityFields.FieldDimensions = new Vector(_viewResolution.Width, _viewResolution.Height);

            FlowStrengthSlider.Value = CommonVelocityFields.FlowStrength;
            RadiusSlider.Value = CommonVelocityFields.CentralObjectRadius;
            RotationSlider.Value = CommonVelocityFields.CentralObjectRotation;

            FlowPicker.ItemsSource = this.VelocityFields;
            FlowPicker.SelectedItem = this.VelocityFields.FirstOrDefault(f => f.Field == CommonVelocityFields.UniformStream);

            SetupParticles();

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

        private void SetupParticles()
        {
            Random rand = new Random();

            for (int i = 0; i < _particlesAmount; i++)
            {
                Vector pos = new Vector(rand.Next(0, _viewResolution.Width), rand.Next(0, _viewResolution.Height));
                var point = new Particle(1, pos);
                point.ApplyVelocityField(SelectedVelocityField);
                _particles.Add((i, new CCDrawNode() {Position = new CCPoint((float)pos.X, (float)pos.Y) }, point));
                _layer.AddChild(_particles[i].node);
                _particles[i].node.DrawSolidCircle(new CCPoint(0, 0), 0.4f, CCColor4B.White);
            }
        }

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

                    case "Radius":
                        CommonVelocityFields.CentralObjectRadius = e.NewValue;
                        break;

                    case "Rotation":
                        CommonVelocityFields.CentralObjectRotation = e.NewValue;
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
            Random rand = new Random();
            double[] sides = { 1, _viewResolution.Width - 1};
            double[] topBottom = { 1, _viewResolution.Height - 1};
            foreach (var p in _particles)
            {
                p.particle.Move(timeInSeconds);

                if (p.particle.Position.X < 0 || p.particle.Position.X > _viewResolution.Width || p.particle.Position.Y < 0 || p.particle.Position.Y > _viewResolution.Height
                    || p.particle.Position.X == double.NaN || p.particle.Position.Y == double.NaN)
                {

                    if(rand.Next(0,2) == 1)
                    {
                        // Place on top or bottom
                        double topBottomPos = topBottom[rand.Next(0, 2)]; // random of 0 or _viewRes.H

                        p.particle.Position = new Vector(rand.Next(1, _viewResolution.Width - 1), topBottomPos);
                    }
                    else
                    {
                        // Place on left or right
                        double sidePos = sides[rand.Next(0, 2)]; // random of 0 or _viewRes.W

                        p.particle.Position = new Vector(sidePos, rand.Next(1, _viewResolution.Height - 1));
                    }

                }

                p.node.Position = new CCPoint((float)p.particle.Position.X, (float)p.particle.Position.Y);
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                FlowStrengthLabel.Text = $"Flow Strength: {FlowStrengthSlider.Value.DecimalPoints(2)}";
            });
        }

        void FlowPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var field = (picker.ItemsSource[selectedIndex] as VelocityFieldListItem).Field;

                foreach(var p in _particles)
                {
                    p.particle.ApplyVelocityField(field);
                }
            }
        }

        #endregion Private Methods

        public class VelocityFieldListItem
        {
            public VelocityFieldListItem(string name, VelocityField v)
            {
                this.Name = name;
                this.Field = v;
            }
            public string Name { get; set; }
            public VelocityField Field { get; set; }
        }
    }
}