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
        public class FluidSimParticle
        {
            public int Id { get; set; }
            public CCDrawNode Node { get; set; }
            public Particle Particle { get; set; }
            public double LifeTime { get; set; }
        }
        #region Private Fields

        private readonly CCDrawNode _centreWheelNode = new CCDrawNode() { Color = CCColor3B.Blue, Visible = false };
        private readonly List<FluidSimParticle> _particles = new List<FluidSimParticle>();
        private readonly int _particlesAmount = 650;
        private readonly int _maxLifeTime = 10;
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

            CommonVelocityFields.FlowStrength = 15;
            CommonVelocityFields.CentralObjectRadius = 30;
            CommonVelocityFields.CentralObjectRotation = 5000;
            CommonVelocityFields.FieldDimensions = new Vector(_viewResolution.Width, _viewResolution.Height);

            FlowStrengthSlider.Value = CommonVelocityFields.FlowStrength;
            RadiusSlider.Value = CommonVelocityFields.CentralObjectRadius;
            RotationSlider.Value = CommonVelocityFields.CentralObjectRotation;

            FlowPicker.ItemsSource = this.VelocityFields;

            SetupParticles();

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RedrawCentreCircle();
        }

        private void RedrawCentreCircle()
        {
            _centreWheelNode.Clear();
            _centreWheelNode.DrawSolidCircle(new CCPoint(0, 0), (float) RadiusSlider.Value, CCColor4B.Blue);
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
                _particles.Add(new FluidSimParticle{
                    Id = i,
                    Node = new CCDrawNode() {Position = new CCPoint((float)pos.X, (float)pos.Y) },
                    Particle = point,
                    LifeTime =  rand.Next(0, _maxLifeTime)});
                _layer.AddChild(_particles[i].Node);
                _particles[i].Node.DrawSolidCircle(new CCPoint(0, 0), 0.3f, CCColor4B.White);
            }

            _centreWheelNode.Position = new CCPoint(_viewResolution.Width / 2, _viewResolution.Height / 2);
            _layer.AddChild(_centreWheelNode);
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
                        RedrawCentreCircle();
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

            RedrawCentreCircle();

            _layer.Schedule(Update);
        }

        private void Update(float timeInSeconds)
        {
            Random rand = new Random();
            double[] sides = { 1, _viewResolution.Width - 1};
            double[] topBottom = { 1, _viewResolution.Height - 1};
            foreach(var p in _particles)
            {
                p.Particle.Move(timeInSeconds);
                p.LifeTime += timeInSeconds;

                if (p.Particle.Position.X < 0 || p.Particle.Position.X > _viewResolution.Width || p.Particle.Position.Y < 0 || p.Particle.Position.Y > _viewResolution.Height
                    || p.Particle.Position.X == double.NaN || p.Particle.Position.Y == double.NaN || p.LifeTime > _maxLifeTime)
                {
                    p.LifeTime = rand.Next(0, _maxLifeTime);

                    if (this.SelectedVelocityField == CommonVelocityFields.UniformStream || this.SelectedVelocityField == CommonVelocityFields.ShearFlow
                            || this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.FlowPast_Sphere)
                    {
                        // Rightward motion only so reset points on left
                        p.Particle.Position = new Vector(0, rand.Next(0, _viewResolution.Height));
                    }
                    else
                    {
                        //Field requires particles to appear from all sides

                        if (rand.Next(0, 2) == 1)
                        {
                            // Place on top or bottom
                            double topBottomPos = topBottom[rand.Next(0, 2)]; // random of 0 or _viewRes.H

                            p.Particle.Position = new Vector(rand.Next(1, _viewResolution.Width - 1), topBottomPos);
                        }
                        else
                        {
                            // Place on left or right
                            double sidePos = sides[rand.Next(0, 2)]; // random of 0 or _viewRes.W

                            p.Particle.Position = new Vector(sidePos, rand.Next(1, _viewResolution.Height - 1));
                        }
                    }
                    
                }

                p.Node.Position = new CCPoint((float)p.Particle.Position.X, (float)p.Particle.Position.Y);
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                FlowStrengthLabel.Text = $"Flow Strength: {FlowStrengthSlider.Value.DecimalPoints(0)}";
                RadiusLabel.Text = $"Central Radius: {RadiusSlider.Value.DecimalPoints(0)}";
                RotationLabel.Text = $"Rotation: {RotationSlider.Value.DecimalPoints(0)}";
            });
        }

        void FlowPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var field = (picker.ItemsSource[selectedIndex] as VelocityFieldListItem)?.Field;

                foreach(var p in _particles)
                {
                    p.Particle.ApplyVelocityField(field);
                }

                this.SelectedVelocityField = field;
                this.SetUserControls();
            }
        }

        /// <summary>
        /// Sets min anx max values such that there will be no chance of crashing when assigning new min/max values
        /// </summary>
        /// <param name="s"></param>
        private void ResetSlider(Slider s)
        {
            s.Minimum = int.MinValue;
            s.Maximum = int.MaxValue;
        }

        private void SetUserControls()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                bool showRadius = this.SelectedVelocityField == CommonVelocityFields.FlowPast_Sphere || this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.RankineVortex;
                bool showRotation = this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.RankineVortex ;
                
                RadiusLabel.IsVisible =  showRadius;
                RadiusSlider.IsVisible = showRadius;
                RotationLabel.IsVisible = showRotation;
                RotationSlider.IsVisible = showRotation;

                _centreWheelNode.Visible = showRadius;

                if (this.SelectedVelocityField == CommonVelocityFields.StagnationPoint)
                {
                    ResetSlider(FlowStrengthSlider);
                    FlowStrengthSlider.Minimum = 1;
                    FlowStrengthSlider.Maximum = 5;
                    FlowStrengthSlider.Value = 2;
                }
                else if (this.SelectedVelocityField == CommonVelocityFields.ShearFlow)
                {
                    ResetSlider(FlowStrengthSlider);
                    FlowStrengthSlider.Minimum = 1;
                    FlowStrengthSlider.Maximum = 10;
                    FlowStrengthSlider.Value = 3;
                }
                else if(this.SelectedVelocityField == CommonVelocityFields.UniformStream)
                {
                    ResetSlider(FlowStrengthSlider);
                    FlowStrengthSlider.Minimum = 15;
                    FlowStrengthSlider.Maximum = 30;
                    FlowStrengthSlider.Value = 15;
                }
                else
                {
                    ResetSlider(FlowStrengthSlider);
                    FlowStrengthSlider.Maximum = 30;
                    FlowStrengthSlider.Minimum = 10;
                    FlowStrengthSlider.Value = 20;
                }

                if (this.SelectedVelocityField == CommonVelocityFields.RankineVortex)
                {
                    _centreWheelNode.Visible = false;

                    FlowStrengthSlider.Value = 15;

                    ResetSlider(RotationSlider);
                    RotationSlider.Minimum = -50;
                    RotationSlider.Maximum = 50;
                    RotationSlider.Value = -30;

                    ResetSlider(RadiusSlider);
                    RadiusSlider.Minimum = 0;
                    RadiusSlider.Maximum = 15;
                    RadiusSlider.Value = 10;
                }

                if (this.SelectedVelocityField == CommonVelocityFields.FlowPast_Sphere)
                {
                    ResetSlider(RadiusSlider);
                    RadiusSlider.Minimum = 0;
                    RadiusSlider.Maximum = 40;
                    RadiusSlider.Value = 25;
                }

                if (this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder)
                {
                    ResetSlider(RadiusSlider);
                    RadiusSlider.Minimum = 0;
                    RadiusSlider.Maximum = 40;
                    RadiusSlider.Value = 10;

                    ResetSlider(RotationSlider);
                    RotationSlider.Minimum = -10000;
                    RotationSlider.Maximum = 10000;
                    RotationSlider.Value = 5000;
                }
            });
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