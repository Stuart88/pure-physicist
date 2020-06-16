using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using PurePhysicist.Models;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class Equations
    {
        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Net Force on a Body")
            {
                EquationLatex = @"\vec{F}_{total}= \sum \ \vec{F}_n",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{F}_1 + \vec{F}_2 + \vec{F}_3 + ... + \vec{F}_i= \sum_{n=1}^{i} \ \vec{F}_n")
                }
            },
            new EquationItem("Newton's 1st Law") {EquationLatex = @"\sum \ \vec{F}_n = 0"},
            new EquationItem("Newton's 2nd Law") {EquationLatex = @"\sum \ \vec{F}_n = m\vec{a}"},
            new EquationItem("Newton's 3rd Law") {EquationLatex = @"\vec{F}_{AB} = - \vec{F}_{BA}"},
            new EquationItem("Uniform Circular Motion", 75) {EquationLatex = @"a_{radial} = \frac{v^2}{R} = \frac{4 \pi^2R}{T^2}"},
            new EquationItem("Work Done by a Force")
            {
                EquationLatex = @"W = \vec{F}\cdot\vec{s}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W = Fs \ cos\theta"),
                    new DerivationStep(@"\theta = \text{angle between } \vec{F} \text{ and } \vec{s}")
                }
            },
            new EquationItem("Work Done on a Curved Path", 125)
            {
                EquationLatex = @"W = \int_{P_{start}}^{P_{end}} \vec{F}\cdot d\vec{l} \\ \\ \\ \text{for any smooth path } P",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} F \ cos\theta \ dl",80),
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} F _{\parallel} \ l ", 80),
                    new DerivationStep(@"\text{(amount of force parallel to l).}", 50),
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} \vec{F}\cdot d\vec{l}", 80)
                }
            },
            new EquationItem("Kinetic Energy") {EquationLatex = @"K = \frac{1}{2}mv^2"},
            new EquationItem("Power", 70)
            {
                EquationLatex = @"P_{average} = \frac{\Delta W}{\Delta t}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"P = \frac{dW}{dt}",80),
                    new DerivationStep(@"P = \vec{F} \cdot \vec{v}",60),
                }
            },
            new EquationItem("Conservation of Energy") {EquationLatex = @"K_1 + U_1 = K_2 + U_2"},
            new EquationItem("Work done by Potential Energy")
            {
                EquationLatex = @"W = U_1 - U_2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W_g = mgh_1 - mgh_2",60),
                    new DerivationStep(@"\text{gravitational potential}",40),
                    new DerivationStep(@"W_{el} = \frac{1}{2}kx_1^2 - \frac{1}{2}kx_2^2",70),
                    new DerivationStep(@"\text{elastic potential potential}",40),
                }
            },
            new EquationItem("Momentum on a point")
            {
                EquationLatex = @"\vec{p} = m \vec{v}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Net force equals rate \\ of change of momentum}", 100),
                    new DerivationStep(@"\sum \vec{F} = \frac{d \vec{p}}{dt} \ \  \left( = m\frac{d\vec{v}}{dt} \right)", 80),
                }
            },
            new EquationItem("Conservation of Momentum")
            {
                EquationLatex = @"m_1 u_1 + m_2 u_2 = m_1v_1 + m_2v_2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"u = \text{velocity before}", 50),
                    new DerivationStep(@"u = \text{velocity after}", 50),
                }
            },
            new EquationItem("Elastic Collisions")
            {
                EquationLatex = @"\frac{1}{2}m_1 u_1^2 + \frac{1}{2} m_2 u_2^2 = \frac{1}{2} m_1v_1^2 + \frac{1}{2}m_2v_2^2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{One Dimensional Elastic Collision}}", 60),
                    new DerivationStep(@"\text{Combine with momentum conservation:}", 50),
                    new DerivationStep(@"m_1 u_1 + m_2 u_2 = m_1v_1 + m_2v_2", 60),
                    new DerivationStep(@"\text{Then solve to find}", 50),
                    new DerivationStep(@"v_1 = \frac{m_1-m_2}{m_1+m_2}u_1+\frac{2m_2}{m_1+m_2}u_2", 60),
                    new DerivationStep(@"v_2 = \frac{2m_1}{m_1+m_2}u_1+\frac{m_2-m_1}{m_1+m_2}u_2", 60),
                }
            },

        };


    }
}
