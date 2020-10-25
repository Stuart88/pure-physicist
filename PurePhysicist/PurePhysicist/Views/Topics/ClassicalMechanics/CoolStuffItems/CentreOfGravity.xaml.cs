using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Maths;
using UniversityPhysics.Mechanics;
using UniversityPhysics.PhysicsObjects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.ClassicalMechanics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CentreOfGravity : ContentPage
    {
        #region Private Fields

        private ParticleItem _centreOfGrav;

        private CCLayer _layer = new CCLayer() { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };

        private List<ParticleItem> _particles = new List<ParticleItem>();

        private Random _rand = new Random();

        /// <summary>
        /// The particle being moved during a touch event
        /// </summary>
        private ParticleItem _selectedParticle;

        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Public Constructors

        public CentreOfGravity()
        {
            // Add initial particles

            for (int i = 0; i < 3; i++) AddParticle();
            _selectedParticle = _particles[0];

            // Add centre of grav point

            Vector centre = _particles.Select(p => p.Particle).ToList().CentreOfMass();

            _centreOfGrav = new ParticleItem
            {
                Particle = new Particle(1, centre),
                GraphicalPoint = new CCPoint((float)centre.X, (float)centre.Y),
                DrawNode = new CCDrawNode()
            };

            InitializeComponent();

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RedrawParticles();
        }

        #endregion Protected Methods

        #region Private Methods

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            if (_particles.Count < 10)
            {
                AddParticle();
                _selectedParticle = _particles.Last();
                RedrawParticles();
            }
        }

        private void AddParticle()
        {
            //Start with mass = 4kg, otherwise replicate selected ball.
            double mass = _selectedParticle == null ? 4 : _selectedParticle.Particle.Mass;

            double randX = _rand.NextDouble() * _viewResolution.Width;
            double randY = _rand.NextDouble() * _viewResolution.Height;
            _particles.Add(new ParticleItem
            {
                Particle = new Particle(mass, new Vector(randX, randY)),
                GraphicalPoint = new CCPoint((float)randX, (float)randY),
                DrawNode = new CCDrawNode()
            });
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

            // Register for touch events
            var touchListener = new CCEventListenerTouchOneByOne();
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
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Centre of Mass");
            await Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private void MassSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_selectedParticle != null)
            {
                _selectedParticle.Particle.Mass = e.NewValue;
                RedrawParticles();
            }
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent arg)
        {
            //Get nearest particle
            _selectedParticle = _particles.OrderBy(p => p.Particle.Position.DistanceTo(new Vector(touch.Location.X, touch.Location.Y))).First();

            if (_selectedParticle != null)
            {
                MassSlider.Value = _selectedParticle.Particle.Mass.Kilograms;
            }

            UpdateLabels();

            return true;
        }

        private void OnTouchEnded(CCTouch arg1, CCEvent arg2)
        {
            //_selectedParticle = null;
        }

        private void OnTouchMoved(CCTouch touch, CCEvent arg2)
        {
            if (_selectedParticle != null && WithinGameArea(touch.Location))
            {
                _selectedParticle.Particle.Position = new Vector(touch.Location.X, touch.Location.Y);
                _selectedParticle.GraphicalPoint = touch.Location;
                RedrawParticles();
            }
        }

        /// <summary>
        /// Places centre of gravity at correct location based on particles list
        /// </summary>
        private void PositionCentreOfGravity()
        {
            Vector centre = _particles.Select(p => p.Particle).ToList().CentreOfMass();

            _centreOfGrav.Particle.Position = centre;
            _centreOfGrav.DrawNode.PositionX = (float)centre.X;
            _centreOfGrav.DrawNode.PositionY = (float)centre.Y;
        }

        private void RedrawParticles()
        {
            _layer.Children?.Clear();

            foreach (ParticleItem p in _particles)
            {
                p.DrawNode.Clear();

                _layer.AddChild(p.DrawNode);
                p.DrawNode.PositionX = p.GraphicalPoint.X;
                p.DrawNode.PositionY = p.GraphicalPoint.Y;
                CCColor4B circleColour = p == _selectedParticle ? CCColor4B.Green : CCColor4B.White;
                double mass = p == _selectedParticle ? _selectedParticle.Particle.Mass : p.Particle.Mass;
                p.DrawNode.DrawSolidCircle(new CCPoint(0, 0), (float)mass, circleColour);
            }

            _centreOfGrav.DrawNode.Clear();
            _layer.AddChild(_centreOfGrav.DrawNode);
            _centreOfGrav.DrawNode.DrawLine(new CCPoint(-2, -2), new CCPoint(2, 2), lineWidth: 0.5f, CCColor4B.Red);
            _centreOfGrav.DrawNode.DrawLine(new CCPoint(2, -2), new CCPoint(-2, 2), lineWidth: 0.5f, CCColor4B.Red);
            PositionCentreOfGravity();
            UpdateLabels();
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            if (_particles.Count > 1)
            {
                ParticleItem toRemove = _particles[_particles.Count - 1];

                _particles.Remove(_selectedParticle);

                _selectedParticle = _particles[0];

                RedrawParticles();
            }
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            RedrawParticles();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Vector centre = _centreOfGrav.Particle.Position;
                CentreOfMassLabel.Text = $"Centre of Mass: ({centre.X.DecimalPoints(2)}, {centre.Y.DecimalPoints(2)})";
                MassLabel.Text = $"{_selectedParticle?.Particle.Mass.Kilograms.DecimalPoints(2)} kg";
            });
        }

        private bool WithinGameArea(CCPoint p)
        {
            return p.X > 0 &&
                   p.Y > 0 &&
                   p.X < _viewResolution.Width &&
                   p.Y < _viewResolution.Height;
        }

        #endregion Private Methods

        #region Public Classes

        public class ParticleItem
        {
            #region Public Properties

            public CCDrawNode DrawNode { get; set; }

            public CCPoint GraphicalPoint { get; set; }

            public Particle Particle { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}