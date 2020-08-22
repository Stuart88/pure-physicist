using PurePhysicist.Helpers;
using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PurePhysicist.Views.CustomViews
{
    public class PhysicistCard: Grid
    {
        public Image Image { get; }
        private Label NameText { get; }
        private Label FamousForText { get; }

        public PhysicistCard(Physicist physicist)
        {
            this.Image = new Image
            {
                Source = ImageSourceHelpers.CreateImageSource($"Physicists.{physicist.ImageFileName}", this.GetType().Assembly),
                Style = Application.Current.Resources["PhysicistImage"] as Style,
            };

            this.NameText = new Label
            {
                Text = physicist.Name,
                Style = Application.Current.Resources["NameText"] as Style
            };
            this.FamousForText = new Label()
            {
                Text = physicist.FamousFor,
                Style = Application.Current.Resources["FamousForText"] as Style
            };

            CreateView();
        }

        private void CreateView()
        {
            this.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            this.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            this.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});

            this.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});

            this.Children.Add(this.NameText);
            this.Children.Add(this.Image);
            this.Children.Add(this.FamousForText);

            Grid.SetRow(this.Image, 0);
            Grid.SetRow(this.NameText, 1);
            Grid.SetRow(this.FamousForText, 2);

        }
    }
}
