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
            new EquationItem("Centre of Mass", 80)
            {
                EquationLatex = @"\vec{r}_{cm} = \frac{\sum m_i \vec{r}_{i}}{\sum m_i}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{r}_{cm} = \frac{m_1 \vec{r}_{1} + m_2 \vec{r}_{2} + m_3 \vec{r}_{3} + ...}{m_1 + m_2 + m_3 + ...}", 80),
                }
            },
            new EquationItem("Rotational Motion", 80)
            {
                EquationLatex = @"\omega_z = \frac{d \theta}{dt}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Analogy with Linear Motion}}", 60),
                    new DerivationStep(@"v = \frac{d s}{d t}", 60),
                    new DerivationStep(@"\omega_z = \frac{d \theta}{dt}",60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"s = s_0 + ut + \frac{1}{2}a t ^2", 60),
                    new DerivationStep(@"\theta = \theta_0 + \omega_{0_z} t + \frac{1}{2}\alpha_z t ^2", 60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"v = u +at", 60),
                    new DerivationStep(@"\omega_z = \omega_{0_z} + \alpha_z t", 60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"v^2 = u^2 +2a(s - s_0)", 60),
                    new DerivationStep(@"\omega_z^2 = \omega_{0_z}^2 +2\alpha_z(\theta - \theta_0)", 60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{(all for constant \alpha_z only)}", 60),
                }
            },
            new EquationItem("Relating Angular and Linear Motion", 60)
            {
                EquationLatex = @"v = r \omega",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"a_{tangential} = \frac{dv}{dt} = r \frac{d \omega}{dt} = r \alpha", 80),
                    new DerivationStep(@"a_{radial} = \frac{v^2}{r} = \omega^2 r", 80),
                }
            },
            new EquationItem("Moment of Inertia")
            {
                EquationLatex = @"I = \sum_i m_i {r_i}^2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Two point masses separated by distance x}", 40, 30),
                    new DerivationStep(@"I = \frac{m_1 m_2}{m_1 + m_2} x^2 = \mu x^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Thin cylindrical shell with open ends,\\ radius r and mass m}", 40, 30),
                    new DerivationStep(@"I \approx m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Solid cylinder, radius r,\\ height h, mass m}", 40, 30),
                    new DerivationStep(@"I_z = \frac{1}{2}mr^2"),
                    new DerivationStep(@"I_x = I_y = \frac{1}{12}m(3r^2 + h^2)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Hollow sphere,\\ radius r and mass m}", 40, 30),
                    new DerivationStep(@"I = \frac{2}{3} m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Solid sphere,\\ radius r and mass m}", 40, 30),
                    new DerivationStep(@"I = \frac{2}{5} m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                }
            },
            new EquationItem("Rotational Kinetic Energy", 80) {EquationLatex = @"K = \frac{1}{2}I \omega^2"},
            new EquationItem("Torque", 60) {EquationLatex = @"\vec{\tau} = \vec{r} \times \vec{F}"},
            new EquationItem("Newton's 2nd Law (rotational)", 60) {EquationLatex = @"\sum \tau_z = I \alpha_z"},
            new EquationItem("Kinetic Energy of Rotational and Linear Motion", 80) {EquationLatex = @"K = \frac{1}{2}Mv^2 + \frac{1}{2}I \omega^2"},
            new EquationItem("Work Done by a Torque", 80)
            {
                EquationLatex = @"W = \int_{\theta_1}^{\theta_2} \tau_z \ d \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W_{total} = \frac{1}{2} I {\omega_{2}}^2 - \frac{1}{2} I {\omega_{1}}^2", 60),
                }
            },
            new EquationItem("Angular Momentum", 80)
            {
                EquationLatex = @"\vec{L} = I \vec{\omega}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Relation to torque}", 40),
                    new DerivationStep(@"\sum \vec{\tau} = \frac{d \vec{L}}{dt}", 80),
                }
            },
            new EquationItem("Gyroscopic Precession Angular Speed", 80)
            {
                EquationLatex = @"\Omega = \frac{wr}{I\omega}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\Omega = \frac{d \phi}{dt} = \frac{|d \vec{L}|/|\vec{L}|}{dt} = \frac{\tau_z}{L_z} = \frac{wr}{I\omega}", 80),
                }
            },
            new EquationItem("Equilibrium", 60) {EquationLatex = @"\sum \vec{F} = \sum \vec{\tau} = 0"},
            new EquationItem("Hooke's Law", 80) {EquationLatex = @"\frac{\text{stress}}{\text{strain}} = \text{elastic modulus}"},
            new EquationItem("Young's Modulus", 80)
            {
                EquationLatex = @"Y = \frac{\text{tensile stress}}{\text{tensile strain}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"Y = \frac{F_{\perp} / A}{\Delta l / l_0} = \frac{F_{\perp} \ l_0}{A \ \Delta l}", 80)
                }
            },
            new EquationItem("Shear Modulus", 80)
            {
                EquationLatex = @"Y = \frac{\text{shear stress}}{\text{shear strain}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"Y = \frac{F_{\parallel} / A}{x / h} = \frac{F_{\parallel} \ h}{A \ x}", 80)
                }
            },
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
            new EquationItem("Periodic Motion", 80)
            {
                EquationLatex = @"f = \frac{1}{T} \ \ \ \ \ \ T = \frac{1}{f}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = 2 \pi f = \frac{2 \pi}{T}", 80)
                }
            },
            new EquationItem("Simple Harmonic Motion", 80)
            {
                EquationLatex = @"\ddot{x} = - \omega^2 x",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"x = A e^{i \omega t}"),
                    new DerivationStep(@"\text{\underline{\ \ \ \ \ \ \ \ \ \ \ \ }}"),
                    new DerivationStep(@"\omega = \sqrt{\frac{k}{m}}", 80),
                    new DerivationStep(@"f = \frac{\omega}{2 \pi} = \frac{1}{2 \pi}\sqrt{\frac{k}{m}}", 80),
                    new DerivationStep(@"T = \frac{2 \pi}{\omega} = 2 \pi \sqrt{\frac{m}{k}}", 80),
                    new DerivationStep("",60,40,true, "Periodic Motion"),
                }
            },
            new EquationItem("Energy in Simple Harmonic Motion", 80, 35) {EquationLatex = @"E = \frac{1}{2}mv_x^2 + \frac{1}{2}k x^2 = \frac{1}{2}k A^2 = constant"},
            new EquationItem("The Simple Pendulum", 80)
            {
                EquationLatex = @"\ddot{\theta} = - \omega^2 \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = \sqrt{\frac{k}{m}} = \sqrt{\frac{g}{L}}", 80),
                    new DerivationStep(@"f = \frac{\omega}{2 \pi} = \frac{1}{2 \pi}\sqrt{\frac{g}{L}}", 80),
                    new DerivationStep(@"T = \frac{2 \pi}{\omega} = 2 \pi \sqrt{\frac{L}{g}}", 80),
                    new DerivationStep("",60,40,true, "Periodic Motion"),
                }
            },
            new EquationItem("The Physical Pendulum", 80)
            {
                EquationLatex = @"\ddot{\theta} = - \frac{mgd}{I} \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = \sqrt{\frac{mgd}{I}}", 80),
                    new DerivationStep(@"T = 2 \pi \sqrt{\frac{I}{mgd}}", 80),
                    new DerivationStep(@"\text{Where } I \text{ is the moment of inertia}", 30, 35),
                    new DerivationStep("",60,40,true, "Moment of Inertia"),
                }
            },
            new EquationItem("Damped Oscillation", 80)
            {
                EquationLatex = @"x = Ae^{-(\frac{b}{2m} + i \omega')t}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega' = \sqrt{\frac{k}{m} - \frac{b^2}{4m^2}}", 80),
                    new DerivationStep(@"b = \text{damping factor}", 50),
                    new DerivationStep(@"b < 2\sqrt{km} \ \ \text{underdamping}"),
                    new DerivationStep(@"b = 2\sqrt{km} \ \ \text{critical damping}"),
                    new DerivationStep(@"b > 2\sqrt{km} \ \ \text{overdamping}"),
                }
            },
            new EquationItem("Driven (Forced) oscillation", 80)
            {
                EquationLatex = @"A = \frac{F_{max}}{\sqrt{(k - m \omega_d^2)^2 + b^2 \omega_d^2}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega_d = \text{driving frequency}"),
                    new DerivationStep(@"b= \text{damping factor}"),
                    new DerivationStep("", 60,40,true, "Damped Oscillation"),
                }
            },
        };


    }
}
