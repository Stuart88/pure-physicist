using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Electromagnetism;
using UniversityPhysics.Maths;
using UniversityPhysics.PhysicsObjects;
using UniversityPhysics.UnitsAndConstants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.Electromagnetism.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MassSpectrometer : ContentPage
    {
        #region Private Fields

        private readonly CCDrawNode _bFieldPoints = new CCDrawNode();
        private readonly CCDrawNode _bottomBarNode = new CCDrawNode() { Color = CCColor3B.Blue };
        private readonly List<(int id, CCDrawNode node, PointCharge charge)> _chargeNodes = new List<(int id, CCDrawNode node, PointCharge charge)>();
        private readonly int _chargesAmount = 10;
        private bool _sceneLoaded;
        private readonly CCLayer _staticLayer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2)};
        private readonly CCLayer _particlesLayer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2), Color = CCColor3B.White };
        private readonly CCDrawNode _topBarNode = new CCDrawNode() { Color = CCColor3B.Blue };
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Private Properties

        private double BaseBFieldVal { get; set; } = 0.83;
        private double BaseEFieldVal { get; set; } = 6E6;
        private Vector BField { get; set; }
        private Vector EField { get; set; }
        private Vector ElectronVelocity { get; set; }
        private List<int> _chargesIdToShow = new List<int>{0};

        #endregion Private Properties

        #region Public Constructors

        public MassSpectrometer()
        {
            InitializeComponent();

            this.EFieldSlider.Value = 1.245;
            this.BFieldSlider.Value = 1.0;
            this.MassSlider.Value = 5;
            this.VelocitySlider.Value = 0.03;

            this.EField = new Vector(0, BaseEFieldVal * this.EFieldSlider.Value, 0);
            this.BField = new Vector(0, 0, BaseBFieldVal * this.BFieldSlider.Value);

            for (int i = 0; i < this._chargesAmount; i++)
            {
                PointCharge charge = new PointCharge(10, new Vector(0, _viewResolution.Height / 2.0))
                {
                    Mass = Constants.Common.M_e * Math.Pow(10, this.MassSlider.Value),
                    Charge = Constants.Common.e
                };

                this.ApplyFieldsToCharge(charge);
                _chargeNodes.Add((i, new CCDrawNode(), charge));
            }

            UpdateLabels();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_sceneLoaded)
            {
                _staticLayer.AddChild(_topBarNode);
                _staticLayer.AddChild(_bottomBarNode);
                foreach (var c in _chargeNodes)
                {
                    _particlesLayer.AddChild(c.node);
                }
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                int nextId = _chargesIdToShow.Max() + 1;

                if (_chargeNodes.All(x => x.id != nextId)) //none left
                {
                    return false; // stop repeat timer
                }
                else
                {
                    _chargesIdToShow.Add(nextId); //now this charge will have a velocity assigned on the next update
                    RedrawGameScene();
                }

                return true; // True = Repeat again
            });

            this._sceneLoaded = true;

            RedrawGameScene();
        }

        #endregion Protected Methods

        #region Private Methods

        private void ApplyFieldsToCharge(PointCharge charge)
        {
            charge.ApplyElectricField(new ElectricField(p => charge.Charge * EField));
            charge.ApplyMagneticField(new MagneticField(p => charge.Charge * this.ElectronVelocity.Cross(BField)));
        }

        private void AssignVelocityToCharge(PointCharge charge)
        {
            double velx = this.VelocitySlider.Value * 3E8;

            int[] randSigns = { -1, 1 };
            Random rando = new Random();

            double vely = velx * 0.1 * randSigns[rando.Next(0, 2)] * rando.NextDouble(); // add some random scatter to particle direction

            charge.Velocity = new Vector(velx, vely, 0);
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
                    case "EField":
                        this.EField = new Vector(0, this.BaseEFieldVal * e.NewValue, 0);
                        foreach (var c in _chargeNodes)
                            this.ApplyFieldsToCharge(c.charge);
                        RedrawGameScene();
                        break;

                    case "BField":
                        this.BField = new Vector(0, 0, this.BaseBFieldVal * e.NewValue);
                        foreach (var c in _chargeNodes)
                            this.ApplyFieldsToCharge(c.charge);
                        RedrawGameScene();
                        break;

                    case "EMF":
                        this.ElectronVelocity = new Vector(e.NewValue * 3E8, 0, 0);
                        break;

                    case "Mass":
                        foreach (var c in _chargeNodes)
                            c.charge.Mass = Constants.Common.M_e * Math.Pow(10, e.NewValue);
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
            InfoButton.IsEnabled = false;
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Mass Spectrometer");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private void RedrawBFieldPoints()
        {
            _bFieldPoints.Clear();
            _staticLayer.AddChild(_bFieldPoints);

            int screenDivisionW = _viewResolution.Width / 10;
            int screenDivisionH = _viewResolution.Height / 10;

            int[] currentPos = { 0, _viewResolution.Height - 10 };

            _bFieldPoints.Position = new CCPoint(0, 0);

            float radius = (float)(4.5 * BFieldSlider.Value -3.95);

            for (int i = 0; i < 9; i++) // stops at 9 because last row overlaps the bottom E-field bar
            {
                for (int j = 0; j < 10; j++)
                {
                    _bFieldPoints.DrawSolidCircle(new CCPoint(currentPos[0], currentPos[1]), radius, CCColor4B.Yellow);
                    currentPos[0] += screenDivisionW;
                }

                currentPos[0] = 0;
                currentPos[1] -= screenDivisionH;
            }
        }
        private void DrawCharges()
        {
            foreach (var c in _chargeNodes)
            {

                c.node.Clear();

                if (!_sceneLoaded)
                {
                    c.charge.Position = new Vector(0, _viewResolution.Height / 2f);
                }

                if (_chargesIdToShow.Contains(c.id))
                {
                    AssignVelocityToCharge(c.charge);
                }

                c.node.Position = new CCPoint((float)c.charge.Position.X, (float)c.charge.Position.Y);
                c.node.DrawSolidCircle(new CCPoint(0, 0), 1, CCColor4B.White);

            }
        }

        private void RedrawGameScene()
        {
            RedrawBFieldPoints();
            RedrawTopBottomBars();
            DrawCharges();
        }

        private void RedrawTopBottomBars()
        {
            _bottomBarNode.Clear();
            _topBarNode.Clear();
            

            float lineWidth = (float)((5f / 7f) * EFieldSlider.Value + (6f / 7f)) * 1.3f;

            _bottomBarNode.Position = new CCPoint(0, _viewResolution.Height);
            _bottomBarNode.DrawLine(new CCPoint(0, 0), new CCPoint(_viewResolution.Width, 0), lineWidth, CCColor4B.Aquamarine);

            _topBarNode.Position = new CCPoint(0, 0);
            _topBarNode.DrawLine(new CCPoint(0, 0), new CCPoint(_viewResolution.Width, 0), lineWidth, CCColor4B.Aquamarine);
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_staticLayer);
            gameScene.AddLayer(_particlesLayer);

            RedrawGameScene();

            _staticLayer.Schedule(Update);
            _particlesLayer.Schedule(Update);
        }

        private void Update(float timeInSeconds)
        {
            foreach (var c in _chargeNodes)
            {
                c.charge.Move((timeInSeconds / 150000));
                c.node.Position = new CCPoint((float)c.charge.Position.X, (float)c.charge.Position.Y);

                if (c.node.Position.X < 0 || c.node.Position.X > _viewResolution.Width || c.node.Position.Y < 0 || c.node.Position.Y > _viewResolution.Height || float.IsNaN(c.node.Position.X) || float.IsNaN(c.node.Position.Y))
                {
                    c.charge.Position = new Vector(0, _viewResolution.Height / 2f);
                    AssignVelocityToCharge(c.charge);
                    c.node.Position = new CCPoint(0, _viewResolution.Height / 2f);
                }
            }

            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                EFieldSliderLabel.Text = $"E: {Math.Round(this.EField.Y / 1E6, 2)}E6 N/C";
                BFieldSliderLabel.Text = $"B: {this.BField.Z.DecimalPoints(2)}T";
                MassSliderLabel.Text = $"Particle m: {this.MassSlider.Value.DecimalPoints(0)}e";
                VelocitySliderLabel.Text = $"Particle v: {(this.ElectronVelocity.X / 3E8).DecimalPoints(2)}c";
            });
        }

        #endregion Private Methods
    }
}