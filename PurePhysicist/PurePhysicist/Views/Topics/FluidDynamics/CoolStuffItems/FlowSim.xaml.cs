using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.FluidDynamics;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.FluidDynamics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowSim : ContentPage
    {
        #region Private Fields

        private readonly CCDrawNode _centreWheelNode = new CCDrawNode { Color = CCColor3B.Blue, Visible = false };

        private readonly CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };

        private readonly int _maxLifeTime = 15;

        private readonly List<FluidSimParticle> _particles = new List<FluidSimParticle>();

        private readonly int _particlesAmount = 650;

        /// <summary>
        /// Small visible nodule added to spinning wheel to give spinning effect.
        /// </summary>
        private readonly CCDrawNode _spinningWheelNode = new CCDrawNode { Color = CCColor3B.White, Visible = false };

        /// <summary>
        ///     These will appear when user touches screen
        /// </summary>
        private readonly List<FluidSimParticle> _touchParticles = new List<FluidSimParticle>();

        private readonly int _touchParticlesAmount = 200;

        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Public Properties

        public List<VelocityFieldListItem> VelocityFields { get; set; } = new List<VelocityFieldListItem>
        {
            new VelocityFieldListItem("Uniform Flow", CommonVelocityFields.UniformStream),
            new VelocityFieldListItem("Shear Flow", CommonVelocityFields.ShearFlow),
            new VelocityFieldListItem("Stagnation Point Flow", CommonVelocityFields.StagnationPoint),
            new VelocityFieldListItem("Vortex", CommonVelocityFields.Vortex),
            new VelocityFieldListItem("Rankine Vortex", CommonVelocityFields.RankineVortex),
            new VelocityFieldListItem("Flow Past a Sphere", CommonVelocityFields.FlowPast_Sphere),
            new VelocityFieldListItem("Rotating Cylinder", CommonVelocityFields.RotatingCylinder)
        };

        #endregion Public Properties

        #region Private Properties

        private double ElapsedTime { get; set; }

        private bool IsTouchingScreen { get; set; }

        /// <summary>
        ///     The Elapsed time after which another touchParticle can be released
        /// </summary>
        private double NextParticleRelease { get; set; }

        private Random Rand { get; } = new Random();

        private VelocityField SelectedVelocityField { get; set; } = CommonVelocityFields.UniformStream;

        private CCPoint TouchLocation { get; set; }

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

        #endregion Protected Methods

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await this.Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        /// <summary>
        ///     Checks to see if another particle can be released at touch point.
        ///     If particle an be released, method returns true then sets the next available release time to ElapsedTime + 0.05;
        ///     In other words, particles can only be released every 0.05 seconds (20 particles per second)
        /// </summary>
        /// <returns></returns>
        private bool CanReleaseParticle()
        {
            if (this.ElapsedTime > this.NextParticleRelease)
            {
                this.NextParticleRelease = this.ElapsedTime + 0.05;
                return true;
            }

            return false;
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

        private void FlowPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                VelocityField field = (picker.ItemsSource[selectedIndex] as VelocityFieldListItem)?.Field;

                foreach (FluidSimParticle p in _particles)
                {
                    p.Particle.ApplyVelocityField(field);
                }

                foreach (FluidSimParticle p in _touchParticles)
                {
                    p.Particle.ApplyVelocityField(field);
                }

                this.SelectedVelocityField = field;
                SetUserControls();
            }
        }

        private double GetNewLifeTime()
        {
            return this.Rand.NextDouble() * _maxLifeTime;
        }

        private void HandleViewCreated(object sender, EventArgs e)
        {
            if (!(sender is CCGameView gameView))
            {
                return;
            }

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
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Common Flows");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent arg)
        {
            this.TouchLocation = touch.Location;
            this.IsTouchingScreen = true;
            return true;
        }

        private void OnTouchEnded(CCTouch arg1, CCEvent arg2)
        {
            this.IsTouchingScreen = false;
        }

        private void OnTouchMoved(CCTouch touch, CCEvent arg2)
        {
            this.TouchLocation = touch.Location;
        }

        private void RedrawCentreCircle()
        {
            _centreWheelNode.Clear();
            _spinningWheelNode.Clear();

            _centreWheelNode.DrawSolidCircle(new CCPoint(0, 0), (float)RadiusSlider.Value, CCColor4B.Blue);
            _spinningWheelNode.DrawSolidCircle(new CCPoint(0, 0), (float)RadiusSlider.Value / 10, CCColor4B.Black);
        }

        /// <summary>
        ///     Sets min anx max values such that there will be no chance of crashing when assigning new min/max values
        /// </summary>
        /// <param name="s"></param>
        private void ResetSlider(Slider s)
        {
            s.Minimum = int.MinValue;
            s.Maximum = int.MaxValue;
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            RedrawCentreCircle();

            _layer.Schedule(Update);
        }

        private void SetupParticles()
        {
            for (int i = 0; i < _particlesAmount; i++)
            {
                Vector pos = new Vector(this.Rand.Next(0, _viewResolution.Width), this.Rand.Next(0, _viewResolution.Height));
                Particle point = new Particle(1, pos);
                point.ApplyVelocityField(this.SelectedVelocityField);

                _particles.Add(new FluidSimParticle
                {
                    Id = i,
                    Node = new CCDrawNode { Position = new CCPoint((float)pos.X, (float)pos.Y) },
                    Particle = point,
                    LifeTime = GetNewLifeTime()
                });

                _layer.AddChild(_particles[i].Node);
                _particles[i].Node.DrawSolidCircle(new CCPoint(0, 0), 0.3f, CCColor4B.White);
            }

            for (int i = 0; i < _touchParticlesAmount; i++)
            {
                Particle point = new Particle(1, new Vector());
                point.ApplyVelocityField(this.SelectedVelocityField);
                _touchParticles.Add(new FluidSimParticle
                {
                    Id = i,
                    Node = new CCDrawNode { Position = new CCPoint(0, 0), Visible = false },
                    Particle = point,
                    LifeTime = 0
                });
                _layer.AddChild(_touchParticles[i].Node);
                _touchParticles[i].Node.DrawSolidCircle(new CCPoint(0, 0), 0.8f, CCColor4B.Yellow);
            }

            _centreWheelNode.Position = new CCPoint(_viewResolution.Width / 2, _viewResolution.Height / 2);
            _spinningWheelNode.Position = new CCPoint(_centreWheelNode.Position.X, _centreWheelNode.Position.Y + (float)RadiusSlider.Value);
            _layer.AddChild(_centreWheelNode);
            _layer.AddChild(_spinningWheelNode);
        }

        private void SetUserControls()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                bool showRadius = this.SelectedVelocityField == CommonVelocityFields.FlowPast_Sphere || this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.RankineVortex;
                bool showRotation = this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.RankineVortex;

                RadiusLabel.IsVisible = showRadius;
                RadiusSlider.IsVisible = showRadius;
                RotationLabel.IsVisible = showRotation;
                RotationSlider.IsVisible = showRotation;

                _centreWheelNode.Visible = showRadius;
                _spinningWheelNode.Visible = false;

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
                else if (this.SelectedVelocityField == CommonVelocityFields.UniformStream)
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
                    _spinningWheelNode.Visible = true;

                    ResetSlider(RadiusSlider);
                    RadiusSlider.Minimum = 5;
                    RadiusSlider.Maximum = 40;
                    RadiusSlider.Value = 10;

                    ResetSlider(RotationSlider);
                    RotationSlider.Minimum = -10000;
                    RotationSlider.Maximum = 10000;
                    RotationSlider.Value = 2800;
                }
            });
        }

        private bool ShouldResetParticle(FluidSimParticle p)
        {
            return p.Particle.Position.X < 0 || p.Particle.Position.X > _viewResolution.Width || p.Particle.Position.Y < 0 || p.Particle.Position.Y > _viewResolution.Height
                   || p.Particle.Position.X == double.NaN || p.Particle.Position.Y == double.NaN || p.LifeTime > _maxLifeTime;
        }

        private void Update(float timeInSeconds)
        {
            this.ElapsedTime += timeInSeconds;

            double[] sides = { 1, _viewResolution.Width - 1 };
            double[] topBottom = { 1, _viewResolution.Height - 1 };
            foreach (FluidSimParticle p in _particles)
            {
                p.Particle.Move(timeInSeconds);
                p.LifeTime += timeInSeconds;

                if (ShouldResetParticle(p))
                {
                    p.LifeTime = GetNewLifeTime();

                    if (this.SelectedVelocityField == CommonVelocityFields.UniformStream || this.SelectedVelocityField == CommonVelocityFields.ShearFlow
                                                                                         || this.SelectedVelocityField == CommonVelocityFields.RotatingCylinder || this.SelectedVelocityField == CommonVelocityFields.FlowPast_Sphere)
                    {
                        // Rightward motion only so reset points on left
                        p.Particle.Position = new Vector(0, this.Rand.Next(0, _viewResolution.Height));
                    }
                    //else if (this.SelectedVelocityField == CommonVelocityFields.Vortex || this.SelectedVelocityField == CommonVelocityFields.RankineVortex)
                    //{
                    //    // Reset particles randomly on screen.
                    //    // Cannot reset to walls because it results in a 'square' coming into the centre as each wave of particles die. Doesn't look right.
                    //    p.Particle.Position = new Vector(this.Rand.Next(0, _viewResolution.Width), this.Rand.Next(0, _viewResolution.Height));
                    //}
                    else
                    {
                        //Field requires particles to appear from all sides

                        if (this.Rand.Next(0, 2) == 1)
                        {
                            // Place on top or bottom
                            double topBottomPos = topBottom[this.Rand.Next(0, 2)]; // random of 0 or _viewRes.H

                            p.Particle.Position = new Vector(this.Rand.Next(1, _viewResolution.Width - 1), topBottomPos);
                        }
                        else
                        {
                            // Place on left or right
                            double sidePos = sides[this.Rand.Next(0, 2)]; // random of 0 or _viewRes.W

                            p.Particle.Position = new Vector(sidePos, this.Rand.Next(1, _viewResolution.Height - 1));
                        }
                    }
                }

                p.Node.Position = new CCPoint((float)p.Particle.Position.X, (float)p.Particle.Position.Y);
            }

            foreach (FluidSimParticle p in _touchParticles.Where(x => x.Node.Visible))
            {
                p.Particle.Move(timeInSeconds);
                p.LifeTime += timeInSeconds;

                if (ShouldResetParticle(p))
                {
                    // Hide!
                    p.Node.Visible = false;
                    p.LifeTime = 0;
                }
                else
                {
                    //Update node position
                    p.Node.Position = new CCPoint((float)p.Particle.Position.X, (float)p.Particle.Position.Y);
                }
            }

            if (this.IsTouchingScreen && CanReleaseParticle())
            {
                // Get next available touch particle
                // The next available is any particle that is currentlty not visible, OR if all particles are already visible, it instead uses the oldest one

                FluidSimParticle p = _touchParticles
                    .OrderBy(x => x.Node.Visible)
                    .ThenByDescending(x => x.LifeTime)
                    .First();

                p.LifeTime = 0;
                p.Particle.Position = new Vector(this.TouchLocation.X, this.TouchLocation.Y);
                p.Node.Position = this.TouchLocation;
                p.Node.Visible = true;
            }

            if (_spinningWheelNode.Visible)
            {
                float x = (float)(_centreWheelNode.Position.X + (RadiusSlider.Value * 0.9) * Math.Cos(this.ElapsedTime * RotationSlider.Value / 250));
                float y = (float)(_centreWheelNode.Position.Y + (RadiusSlider.Value * 0.9) * Math.Sin(this.ElapsedTime * RotationSlider.Value / 250));
                _spinningWheelNode.Position = new CCPoint(x, y);
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                FlowStrengthLabel.Text = $"Flow: {FlowStrengthSlider.Value.DecimalPoints(0)}m/s";
                RadiusLabel.Text = $"Centre Radius: {RadiusSlider.Value.DecimalPoints(0)}m";
                RotationLabel.Text = $"Spin: {RotationSlider.Value.DecimalPoints(0)}rad/s";
            });
        }

        #endregion Private Methods

        #region Public Classes

        public class FluidSimParticle
        {
            #region Public Properties

            public int Id { get; set; }
            public double LifeTime { get; set; }
            public CCDrawNode Node { get; set; }
            public Particle Particle { get; set; }

            #endregion Public Properties
        }

        public class VelocityFieldListItem
        {
            #region Public Properties

            public VelocityField Field { get; set; }

            public string Name { get; set; }

            #endregion Public Properties

            #region Public Constructors

            public VelocityFieldListItem(string name, VelocityField v)
            {
                this.Name = name;
                this.Field = v;
            }

            #endregion Public Constructors
        }

        #endregion Public Classes
    }
}