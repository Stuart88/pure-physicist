using CocosSharp;
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
    public partial class SpinningWheel : ContentPage
    {
        #region Private Fields

        private Object3D _centre = new Object3D(
            new System.Collections.Generic.List<PointMass>
            {
                new PointMass(new Vector(-10, 0), 1),
                new PointMass(new Vector(0, 10), 1),
                new PointMass(new Vector(10, 0), 1),
                new PointMass(new Vector(0, -10), 1),
            }, new Vector(0, 0));

        private double _frictionFromSlider = 0d;
        private CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };
        private CCSizeI _viewResolution = new CCSizeI(100, 100);
        private CCDrawNode _wheel = new CCDrawNode { Color = CCColor3B.White };

        #endregion Private Fields

        #region Public Constructors

        public SpinningWheel()
        {
            InitializeComponent();

            UpdateLabels();

            MassSlider.Value = _centre.Mass;
            FrictionSlider.Value = 0d;

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
            await Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void FrictionSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _frictionFromSlider = e.NewValue;
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
            var equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Rotational Motion");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private void MassSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newMass = e.NewValue / _centre.MassPoints.Count; //if user picks 4kg, it should give 1kg to each point (if there are 4 points)

            foreach (var p in _centre.MassPoints)
            {
                p.Mass = newMass;
            }

            _centre.UpdateMomentOfInertia();

            RedrawGameScene();
        }

        private bool OnTouchBegan(CCTouch touch, CCEvent arg)
        {
            return true;
        }

        private void OnTouchEnded(CCTouch touch, CCEvent arg)
        {
            _centre.ExternalTorque = new Vector();
        }

        private void OnTouchMoved(CCTouch touch, CCEvent arg2)
        {
            //gameView centre
            var d = touch.Delta;
            var l = touch.Location;
            var w = _wheel.Position;
            var dForce = new Vector(d.X, d.Y);

            _centre.AddForce_OffCentre(dForce, new Vector(l.X - w.X, l.Y - w.Y));
        }

        private void RedrawGameScene()
        {
            _wheel.Clear();
            _layer.Children?.Clear();
            _layer.AddChild(_wheel);

            float lineWidth = (float)_centre.Mass / 10;

            if (lineWidth < 1f)
                lineWidth = 1f;

            _wheel.DrawLine(new CCPoint(-20, -20), new CCPoint(20, 20), lineWidth: lineWidth, CCColor4B.White);
            _wheel.DrawLine(new CCPoint(-20, 20), new CCPoint(20, -20), lineWidth: lineWidth, CCColor4B.White);

            _wheel.PositionX = (float)_viewResolution.Width / 2;
            _wheel.PositionY = (float)_viewResolution.Height / 2;
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);

            RedrawGameScene();

            _layer.Schedule(Update);
        }

        private void Update(float timeInSeconds)
        {
            //Friction generates heat, so heavier and faster means more heat..
            double friction = _centre.AngularVelocity.Z * _centre.Mass * _frictionFromSlider;

            double energyToRemove = friction * 0.1;//random scaling number... friction is just a coefficient anyway so this can be whatever suits...

            //now remove that heat energy from the sytem
            _centre.AddRotationalKineticEnergy(new Vector(0, 0, -energyToRemove));

            _centre.Move(timeInSeconds);

            if (_centre.AngularVelocity.Z > 10)
            {
                _centre.AngularVelocity.Z = 10; // rotational speed limits!
            }

            if (_centre.AngularVelocity.Z < -10)
            {
                _centre.AngularVelocity.Z = -10;
            }

            _wheel.Rotation = (float)_centre.RotationAsDegreesPerSecond().Z;

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            string frictionText = _frictionFromSlider switch
            {
                var x when x == 0 => "None",
                var x when x < 0.33 => "Low",
                var x when x >= 0.33 && x < 0.66 => "Medium",
                var x when x >= 0.66 && x < 0.99 => "High",
                var x when x >= 0.99 => "Max",
                _ => "How has this happened."
            };
            Device.BeginInvokeOnMainThread(() =>
            {
                RotationLabel.Text = $"Angular Velocity: {_centre.AngularVelocity.Z.DecimalPoints(2)} /s";
                PeriodLabel.Text = $"Period: {_centre.RotationPeriod(UniversityPhysics.Enums.Axis_Cartesian.Z).DecimalPoints(2)} s";
                MassLabel.Text = $"{_centre.Mass.Kilograms.DecimalPoints(0)} kg";
                RotationalKineticEnergyLabel.Text = $"Rotational Energy: {_centre.KineticEnergy_Rotational.Z.DecimalPoints(0)} J";
                FrictionLabel.Text = frictionText;
            });
        }

        #endregion Private Methods
    }
}