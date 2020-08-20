using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using PurePhysicist.Models;

namespace PurePhysicist.Views.Topics.Astrophysics
{
    public class Equations
    {
        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Newton's Law of Gravitation", 80) {EquationLatex = @"F = \frac{G m_1 m_2}{r^2}"},
            new EquationItem("Gravitational Potential", 80)
            {
                EquationLatex = @"U = - \frac{G m_E m}{r}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Derivation}}", 50),
                    new DerivationStep(@"\text{Work done by gravity:}", 30, 30),
                    new DerivationStep(@"W = \int_{r_1}^{r_2} F_r \ dr", 80),
                    new DerivationStep(@"W = - \int_{r_1}^{r_2} \frac{G m_E m}{r^2} \ dr", 80),
                    new DerivationStep(@"\text{(negative as gravity acts toward earth)}", 50, 30),
                    new DerivationStep(@"W = -\frac{G m_E m}{r_1} + \frac{G m_E m}{r_2}", 80),
                    new DerivationStep(@"\text{Potential energy U is defined by W = U_1 - U_2}",50, 30),
                    new DerivationStep(@"\text{Thus, } U = - \frac{G m_E m}{r}", 80),
                }
            },
            new EquationItem("Escape Velocity", 80)
            {
                EquationLatex = @"v_{escape} = \sqrt{\frac{2GM}{R}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Derivation}}", 50),
                    new DerivationStep(@"\text{Kinetic energy must equal work done to}", 30, 30),
                    new DerivationStep(@"\text{escape to infinite distance}", 30, 30),
                    new DerivationStep(@"\frac{1}{2}mv^2 = -(-\frac{G M m}{r_1} + \frac{G M m}{r_2})", 80),
                    new DerivationStep("", 0, 0, true, "Gravitational Potential"),
                    new DerivationStep(@"\frac{1}{2}mv^2 = -(-\frac{G M m}{R} + \frac{G M m}{\infty})", 80),
                    new DerivationStep(@"\frac{1}{2}mv^2 = \frac{G M m}{R}", 80),
                    new DerivationStep(@"v_{escape} = \sqrt{\frac{2GM}{R}}", 80),
                    new DerivationStep(@"\text{For any body mass M, at radius R}", 30, 30),

                }
            },
            new EquationItem("Kepler's 1st Law", 60, 30) {EquationLatex = @"\text{All planets move in an elliptical orbit \\ with one focus about a star}"},
            new EquationItem("Kepler's 2nd Law", 80)
            {
                EquationLatex = @"\frac{dA}{dt} = \frac{1}{2} \ r^2 \ \frac{d \theta}{dt}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{A line connecting a planet to its central star}", 30, 30),
                    new DerivationStep(@"\text{sweeps an equal area for all changes in time.}", 30, 30),
                    new DerivationStep(@"\text{(Conservation of angular momentum)}", 30, 30),
                }
            },
            new EquationItem("Kepler's 3rd Law", 80) {EquationLatex = @"T = \frac{2 \pi a^{\frac{3}{2}}}{\sqrt{G M_s}}"},
            new EquationItem("Schwarzchild Radius", 80) {EquationLatex = @"R_S = \frac{2GM}{c^2}"},
        };


    }
}
