using CocosSharp;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PurePhysicist.Views.Topics.Mathematics.CoolStuffItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourierWaveGenerator : ContentPage
    {
        #region Private Fields

        private readonly List<CCDrawNode> _connectingLines = new List<CCDrawNode>();

        private readonly CCLayer _layer = new CCLayer { ContentSize = new CCSize((float)App.DeviceWidth, (float)App.DeviceHeight / 2) };

        private readonly List<GraphPoint> _points = new List<GraphPoint>();

        private readonly int _pointsAmount = 2000;

        private CCSizeI _viewResolution = new CCSizeI(100, 100);

        #endregion Private Fields

        #region Public Properties

        public List<WaveTypeOption> WaveTypeOptions { get; set; } = new List<WaveTypeOption>
        {
            new WaveTypeOption("Square Wave", WaveType.Square),
            new WaveTypeOption("Saw Wave", WaveType.Saw),
            new WaveTypeOption("Triangle Wave", WaveType.Triangle)
        };

        #endregion Public Properties

        #region Private Properties

        private float Height { get; set; } = 30f;

        private bool IsTouchingScreen { get; set; }

        private int NValue { get; set; } = 3;

        private float Period { get; set; } = 50f;

        private WaveType SelectedWaveType { get; set; }

        private CCPoint TouchLocation { get; set; }

        /// <summary>
        ///     Adjustment for setting y position to centre of screen, rather than bottom
        /// </summary>
        private float YPosAdjustment => _viewResolution.Height / 2;

        #endregion Private Properties

        #region Public Enums

        public enum WaveType
        {
            Square,
            Saw,
            Triangle
        }

        #endregion Public Enums

        #region Public Constructors

        public FourierWaveGenerator()
        {
            InitializeComponent();

            nSlider.Value = this.NValue;
            HeightSlider.Value = this.Height;
            PeriodSlider.Value = this.Period;

            WaveTypePicker.ItemsSource = this.WaveTypeOptions;
            WaveTypePicker.SelectedItem = WaveTypeOptions.First(); // Square wave

            SetupPoints();

            UpdateLabels();

            DrawFourierLine();

            GameView.ViewCreated += HandleViewCreated;
        }

        #endregion Public Constructors

        #region Private Methods

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            BackButton.IsEnabled = false;
            await this.Navigation.PopModalAsync();
            BackButton.IsEnabled = true;
        }

        private void DrawFourierLine()
        {
            foreach (GraphPoint p in _points)
            {
                p.Node.Position = new CCPoint(p.XPos, GetYPos(p.XPos));
            }

            ReDrawConnectingLines();
        }

        private float GetYPos(float xPos)
        {
            return this.SelectedWaveType switch
            {
                WaveType.Square => SquareWaveYPos(xPos),
                WaveType.Saw => SawWaveYPos(xPos),
                WaveType.Triangle => TriangleWaveYPos(xPos),
                _ => throw new ArgumentOutOfRangeException()
            };
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
            EquationItem equation = Equations.EquationsList.FirstOrDefault(x => x.LabelText == "Fourier Wave Equation");
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

        private void ReDrawConnectingLines()
        {
            for (int i = 0; i < _points.Count - 1; i++)
            {
                _connectingLines[i].Clear();
                _connectingLines[i].Position = _points[i].Node.Position;

                CCPoint lineEnd = _points[i].Node.Position - _points[i + 1].Node.Position; // difference between point n and point n+1

                _connectingLines[i].DrawLine(new CCPoint(0, 0), lineEnd, 0.1f, CCColor4B.White, CCLineCap.Square);
            }
        }

        private float SawWaveYPos(double x)
        {
            float sum = 0;

            for (int n = 1; n <= this.NValue; n++)
            {
                sum += (float)(1f / n * Math.Sin(2 * n * Math.PI * (x - _viewResolution.Width / 2) / this.Period));
            }

            return this.YPosAdjustment - (float)(this.Height / Math.PI) * sum;
        }

        private void SetupConnectingLines()
        {
            for (int i = 0; i < _pointsAmount - 1; i++)
            {
                _connectingLines.Add(new CCDrawNode());
                _layer.AddChild(_connectingLines[i]);
            }
        }

        private void SetupGameScene(CCScene gameScene)
        {
            gameScene.AddLayer(_layer);
        }

        private void SetupPoints()
        {
            for (int i = 0; i < _pointsAmount; i++)
            {
                _points.Add(new GraphPoint
                {
                    XPos = (float)i * 100 / _pointsAmount,
                    Node = new CCDrawNode { Position = new CCPoint(0, 0) }
                });

                _layer.AddChild(_points[i].Node);
                _points[i].Node.DrawSolidCircle(new CCPoint(0, 0), 0.1f, CCColor4B.White);
            }

            SetupConnectingLines();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender is Slider s)
            {
                switch (s.AutomationId)
                {
                    case "NValue":

                        this.NValue = (int)Math.Round(e.NewValue);

                        if (this.SelectedWaveType == WaveType.Triangle || this.SelectedWaveType == WaveType.Square && this.NValue % 2 == 0)
                        {
                            // Triangle wave and square wave only give value for n = 1, 3, 5, 7, etc.
                            // This if block catches the case where NValue is even number. So... just increment it by 1.
                            this.NValue += 1;
                        }

                        break;

                    case "Height":
                        this.Height = (float)e.NewValue;
                        break;

                    case "Period":
                        this.Period = (float)e.NewValue;
                        break;
                }

                DrawFourierLine();
                UpdateLabels();
            }
        }

        private float SquareWaveYPos(double x)
        {
            float sum = 0;

            for (int n = 1; n <= this.NValue; n++)
            {
                sum += (float)(2 * this.Height / (n * Math.PI) * Math.Sin(n * Math.PI / 2) * Math.Cos(2 * Math.PI * n * (x - _viewResolution.Width / 2) / this.Period));
            }

            return this.YPosAdjustment + sum;
        }

        private float TriangleWaveYPos(double x)
        {
            float sum = 0;

            for (int n = 1; n <= this.NValue; n++)
            {
                if (this.SelectedWaveType == WaveType.Triangle && n % 2 == 0) // Triangle waves only valid for n = 1, 3, 5, 7...
                {
                    continue;
                }

                sum += (float)(Math.Pow(-1, ((double)n - 1) / 2) / (n * n) * Math.Sin(n * Math.PI * (x - _viewResolution.Width / 2) / this.Period));
            }

            return this.YPosAdjustment + (float)(8 * this.Height / Math.Pow(Math.PI, 2)) * sum;
        }

        private void UpdateLabels()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                nLabel.Text = $"n: {this.NValue}";
                HeightLabel.Text = $"Height: {Math.Round(this.Height, 0)}";
                PeriodLabel.Text = $"Length: {Math.Round(this.Period, 0)}";
            });
        }

        private void WaveTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                this.SelectedWaveType = ((WaveTypeOption)picker.ItemsSource[selectedIndex]).WaveType;

                DrawFourierLine();
                UpdateLabels();
            }
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

        public class WaveTypeOption
        {
            #region Public Properties

            public string Name { get; set; }

            public WaveType WaveType { get; set; }

            #endregion Public Properties

            #region Public Constructors

            public WaveTypeOption(string name, WaveType type)
            {
                this.Name = name;
                this.WaveType = type;
            }

            #endregion Public Constructors
        }

        #endregion Public Classes
    }
}