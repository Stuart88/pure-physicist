using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PurePhysicist.Models;
using PurePhysicist.Views.Topics.TopicPageTemplates;
using Xamarin.Forms;

namespace PurePhysicist.Helpers
{
    public static class CoolStuffContents
    {
        private static readonly List<CoolStuffView.CoolStuffListItem> Items = new List<CoolStuffView.CoolStuffListItem>
        {
            new CoolStuffView.CoolStuffListItem(MenuItemType.Astrophysics, "Orbit Sim", new Lazy<ContentPage>(() => new Views.Topics.Astrophysics.CoolStuffItems.OrbitSim())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.ClassicalMechanics, "Simple Pendulum", new Lazy<ContentPage>(() => new Views.Topics.ClassicalMechanics.CoolStuffItems.SimplePendulum())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.ClassicalMechanics, "Centre of Mass",new Lazy<ContentPage>(() => new Views.Topics.ClassicalMechanics.CoolStuffItems.CentreOfGravity())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.ClassicalMechanics, "Acceleration and Velocity",new Lazy<ContentPage>(() => new Views.Topics.ClassicalMechanics.CoolStuffItems.AccelerationAndVelocity())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.ClassicalMechanics, "Spinning Wheel", new Lazy<ContentPage>(() => new Views.Topics.ClassicalMechanics.CoolStuffItems.SpinningWheel())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.Electromagnetism, "Velocity Selector", new Lazy<ContentPage>(() => new Views.Topics.Electromagnetism.CoolStuffItems.MassSpectrometer())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.FluidDynamics, "Flow Sim", new Lazy<ContentPage>(() => new Views.Topics.FluidDynamics.CoolStuffItems.FlowSim())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.Mathematics, "Fourier Waves", new Lazy<ContentPage>(() => new Views.Topics.Mathematics.CoolStuffItems.FourierWaveGenerator())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.QuantumPhysics, "Quantum Tunnelling", new Lazy<ContentPage>(() => new Views.Topics.QuantumPhysics.CoolStuffItems.QuantumTunnel())),
            new CoolStuffView.CoolStuffListItem(MenuItemType.ModernPhysics, "Compton Scattering", new Lazy<ContentPage>(() => new Views.Topics.ModernPhysics.CoolStuffItems.ComptonScattering())),
        };

        public static List<CoolStuffView.CoolStuffListItem> GetItems(MenuItemType topic)
        {
            return Items.Where(i => i.Topic == topic || topic == MenuItemType.CoolStuff).ToList();
        }
    }
}
