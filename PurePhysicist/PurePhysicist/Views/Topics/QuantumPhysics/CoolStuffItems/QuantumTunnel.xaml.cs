using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityPhysics.Enums;
using UniversityPhysics.Maths;
using UniversityPhysics.UnitsAndConstants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.QuantumPhysics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuantumTunnel : ContentPage
    {
        #region Private Fields

        private readonly CCDrawNode _barrierNode = new CCDrawNode();
        private readonly List<CCDrawNode> _connectingLines = new List<CCDrawNode>();
        private readonly CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };
        private readonly List<SimParticle> _particles = new List<SimParticle>();
        private readonly int _particlesAmount = 100;
        private readonly List<GraphPoint> _points = new List<GraphPoint>();

        private readonly int _pointsAmount = 1000;
        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Public Properties

        private float BarrierWidth => (float)(this.Tunnel.BarrierWidth * 10E9);

        #endregion Public Properties

        #region Private Properties

        private CCColor4B ParticleLineColour { get; set; } = CCColor4B.White;
        private Random Rand { get; set; } = new Random();
        private double ScaleAfterTunnelling => this.Tunnel.BarrierEnergy.ElectronVolts + this.BarrierWidth;
        private int StandardMoveRate { get; } = 50;
        private UniversityPhysics.QuantumMechanics.QuantumTunnel Tunnel { get; set; }

        //new CCColor4B(255, 255, 255, 1);

        /// <summary>
        ///     Adjustment for setting y position to centre of screen, rather than bottom
        /// </summary>
        private float YPosAdjustment => _viewResolution.Height / 4;

        #endregion Private Properties

        #region Public Constructors

        public QuantumTunnel()
        {
            InitializeComponent();

            Tunnel = new UniversityPhysics.QuantumMechanics.QuantumTunnel(new Energy(5, EnergyMeasure.eV), new Energy(2, EnergyMeasure.eV), 0.4E-9, UniversityPhysics.UnitsAndConstants.Constants.Common.M_e);

            BarrierVoltageSlider.Value = this.Tunnel.BarrierEnergy.ElectronVolts;
            BarrierWidthSlider.Value = this.Tunnel.BarrierWidth * 10E9;
            ElectronEnergySlider.Value = this.Tunnel.ParticleEnergy.ElectronVolts;

            SetupDrawNodes();

            UpdateLabels();

            DrawParticleLine();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                int nextId = _particles.Count();

                _particles.Add(new SimParticle { Id = nextId, Node = new CCDrawNode { Position = new CCPoint(0, Rand.Next(_viewResolution.Height / 2, _viewResolution.Height)) } });

                _layer.AddChild(_particles[nextId].Node);
                _particles[nextId].Node.DrawSolidCircle(new CCPoint(0, 0), 0.2f, CCColor4B.White);

                return _particles.Count < _particlesAmount; // True = Repeat again
            });
        }

        #endregion Protected Methods

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await this.Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void DrawParticleLine()
        {
            foreach (GraphPoint p in _points)
            {
                p.Node.Position = new CCPoint(p.XPos, GetYPos(p.XPos));
            }

            ReDrawConnectingLines();
        }

        private float GetYPos(float xPos)
        {
            double l = this.BarrierWidth;
            xPos = xPos - (float)_viewResolution.Width / 2;
            double h = 10 * this.Tunnel.ParticleEnergy.ElectronVolts;
            double hAfter = h / ScaleAfterTunnelling; // Not real physics. Just for visualising how hAfter varies with barrier voltage and width
            double k = -Math.Log(hAfter / h) / l;

            float yAdjust = (float)h + 2; // for shifting line up a bit from base

            if (xPos <= -l / 2)
            {
                return yAdjust + (float)(h * Math.Cos(xPos + l / 2));
            }
            else if (xPos > -l / 2 && xPos < l / 2)
            {
                return yAdjust + (float)(h * Math.Exp(-k * (xPos + l / 2)));
            }
            else if (xPos >= l / 2)
            {
                return yAdjust + (float)(hAfter * Math.Cos(xPos - l / 2));
            }

            return YPosAdjustment;
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

            // Starts CocosSharp:
            gameView.RunWithScene(gameScene);
        }

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            InfoButton.IsEnabled = false;
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Fourier Wave Equation");
            await this.Navigation.PushModalAsync(new DerivationViewer(equation, "demo"));
            InfoButton.IsEnabled = true;
        }

        private bool ParticleHitBarrier(SimParticle p)
        {
            double xShift = (double)_viewResolution.Width / 2;
            return p.Node.Position.X >= xShift - this.BarrierWidth / 2 && p.Node.Position.X < xShift + this.BarrierWidth / 2;
        }

        private void ReDrawBarrier()
        {
            _barrierNode.Clear();

            // barrier colour varies from solid blue (high voltage) to dark/grey-blue (low voltage)
            byte rgb = (byte)(255 * this.BarrierVoltageSlider.Value / this.BarrierVoltageSlider.Maximum);

            _barrierNode.DrawLine(new CCPoint(0, 0), new CCPoint(0, _viewResolution.Height), BarrierWidth / 2, new CCColor4B(0, 0, rgb));
        }

        private void ReDrawConnectingLines()
        {
            for (int i = 0; i < _points.Count - 1; i++)
            {
                _connectingLines[i].Clear();
                _connectingLines[i].Position = _points[i].Node.Position;

                CCPoint lineEnd = _points[i].Node.Position - _points[i + 1].Node.Position; // difference between point n and point n+1

                _connectingLines[i].DrawLine(new CCPoint(0, 0), lineEnd, 0.1f, this.ParticleLineColour, CCLineCap.Square);
            }
        }

        private void SetupConnectingLines()
        {
            for (int i = 0; i < _pointsAmount - 1; i++)
            {
                _connectingLines.Add(new CCDrawNode());
                _layer.AddChild(_connectingLines[i]);
            }
        }

        private void SetupDrawNodes()
        {
            _layer.AddChild(_barrierNode);
            _barrierNode.Position = new CCPoint(_viewResolution.Width / 2, 0);
            ReDrawBarrier();

            // add graph line points
            for (int i = 0; i < _pointsAmount; i++)
            {
                _points.Add(new GraphPoint
                {
                    XPos = (float)i * 100 / _pointsAmount,
                    Node = new CCDrawNode { Position = new CCPoint(0, 0) }
                });

                _layer.AddChild(_points[i].Node);
                _points[i].Node.DrawSolidCircle(new CCPoint(0, 0), 0.1f, this.ParticleLineColour);
            }

            SetupConnectingLines();
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);
            _layer.Schedule(Update);
        }

        private bool ShouldResetParticle(SimParticle p)
        {
            return p.Node.Position.X < 0 || p.Node.Position.X > _viewResolution.Width;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender is Slider s)
            {
                switch (s.AutomationId)
                {
                    case "Voltage":
                        this.Tunnel.BarrierEnergy = new Energy(e.NewValue, EnergyMeasure.eV);
                        break;

                    case "Width":
                        this.Tunnel.BarrierWidth = e.NewValue * 10E-10;
                        break;

                    case "Energy":
                        this.Tunnel.ParticleEnergy = new Energy(e.NewValue, EnergyMeasure.eV);
                        break;
                }

                ReDrawBarrier();
                DrawParticleLine();
                UpdateLabels();
            }
        }

        private void Update(float timeInSeconds)
        {
            foreach (SimParticle p in _particles)
            {
                p.Node.Position = new CCPoint((float)(p.Node.Position.X + timeInSeconds * p.MoveRate * StandardMoveRate * this.Tunnel.ParticleEnergy.ElectronVolts * p.MoveDirection), p.Node.Position.Y);

                if (ShouldResetParticle(p))
                {
                    p.MoveDirection = 1;
                    p.MoveRate = 1;
                    p.Node.Position = new CCPoint(0, Rand.Next(_viewResolution.Height / 2, _viewResolution.Height));
                }

                if (ParticleHitBarrier(p))
                {
                    // Decide if particle should reflect back, or pass through, based on tunnel probability

                    // For very low probability, the probaility range will be large
                    int probabilityRange = Convert.ToInt32(1d / this.Tunnel.TunnelProbability);

                    //For large probaility range, there is less chance of rand giving 1, i.e. less chance of tunneling.
                    bool shouldTunnel = Rand.Next(1, probabilityRange + 1) == 1;

                    if (shouldTunnel)
                    {
                        //jump to other side and reduce speed
                        p.Node.Color = CCColor3B.Green;
                        p.Node.Position = new CCPoint((float)_viewResolution.Width / 2 + this.BarrierWidth / 2, p.Node.Position.Y);
                        p.MoveRate = 1 / ScaleAfterTunnelling;
                    }
                    else
                    {
                        // Reverse direction, and place just to left of barrier to ensure it doesn't collide again
                        p.Node.Position = new CCPoint((float)_viewResolution.Width / 2 - this.BarrierWidth / 2 - 2, p.Node.Position.Y);
                        p.MoveDirection = -1;
                    }
                }
            }
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BarrierVoltageLabel.Text = $"{this.Tunnel.BarrierEnergy.ElectronVolts.DecimalPoints(1)}eV";
                BarrierWidthLabel.Text = $"{this.BarrierWidthSlider.Value.DecimalPoints(1)}nm";
                ElectronEnergyLabel.Text = $"{this.Tunnel.ParticleEnergy.ElectronVolts.DecimalPoints(1)}eV";
                ProbabilityLabel.Text = $"Tunnel Probability: {this.Tunnel.TunnelProbability:G3}";
            });
        }

        #endregion Private Methods

        #region Public Classes

        public class GraphPoint
        {
            #region Public Properties

            public CCDrawNode Node { get; set; }
            public float XPos { get; set; }

            #endregion Public Properties
        }

        public class SimParticle
        {
            #region Public Properties

            public int Id { get; set; }

            /// <summary>
            /// Set to +/- 1 to combine with move direction
            /// </summary>
            public int MoveDirection { get; set; } = 1;

            public double MoveRate { get; set; } = 1;
            public CCDrawNode Node { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}