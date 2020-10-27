using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("The SUVAT Equations")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"v = u +at"),
                    new DerivationStep(@"s = ut + \frac{1}{2}a t ^2"),
                    new DerivationStep(@"s = \frac{1}{2} (u + v) t"),
                    new DerivationStep(@"v^2 = u^2 +2as"),
                    new DerivationStep(@"s = vt - \frac{1}{2}a t ^2"),
                }
            },
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
            new EquationItem("Uniform Circular Motion") {EquationLatex = @"a_{radial} = \frac{v^2}{R} = \frac{4 \pi^2R}{T^2}"},
            new EquationItem("Work Done by a Force")
            {
                EquationLatex = @"W = \vec{F}\cdot\vec{s}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W = Fs \ cos\theta"),
                    new DerivationStep(@"\theta = \text{angle between } \vec{F} \text{ and } \vec{s}")
                }
            },
            new EquationItem("Work Done on a Curved Path", 180)
            {
                EquationLatex = @"W = \int_{P_{start}}^{P_{end}} \vec{F}\cdot d\vec{l} \\ \\ \\ \text{for any smooth path } P",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} F \ cos\theta \ dl", 80),
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} F _{\parallel} \ l ", 80),
                    new DerivationStep(@"\text{(amount of force parallel to l).}"),
                    new DerivationStep(@"W = \int_{P_{start}}^{P_{end}} \vec{F}\cdot d\vec{l}")
                }
            },
            new EquationItem("Kinetic Energy") {EquationLatex = @"K = \frac{1}{2}mv^2"},
            new EquationItem("Power", 70)
            {
                EquationLatex = @"P_{average} = \frac{\Delta W}{\Delta t}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"P = \frac{dW}{dt}"),
                    new DerivationStep(@"P = \vec{F} \cdot \vec{v}"),
                }
            },
            new EquationItem("Conservation of Energy") {EquationLatex = @"K_1 + U_1 = K_2 + U_2"},
            new EquationItem("Work done by Potential Energy")
            {
                EquationLatex = @"W = U_1 - U_2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W_g = mgh_1 - mgh_2"),
                    new DerivationStep(@"\text{gravitational potential}"),
                    new DerivationStep(@"W_{el} = \frac{1}{2}kx_1^2 - \frac{1}{2}kx_2^2"),
                    new DerivationStep(@"\text{elastic potential potential}"),
                }
            },
            new EquationItem("Momentum on a point")
            {
                EquationLatex = @"\vec{p} = m \vec{v}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Net force equals rate \\ of change of momentum}", 100),
                    new DerivationStep(@"\sum \vec{F} = \frac{d \vec{p}}{dt} \ \  \left( = m\frac{d\vec{v}}{dt} \right)"),
                }
            },
            new EquationItem("Conservation of Momentum")
            {
                EquationLatex = @"m_1 u_1 + m_2 u_2 = m_1v_1 + m_2v_2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"u = \text{velocity before}"),
                    new DerivationStep(@"u = \text{velocity after}"),
                }
            },
            new EquationItem("Elastic Collisions")
            {
                EquationLatex = @"\frac{1}{2}m_1 u_1^2 + \frac{1}{2} m_2 u_2^2 = \frac{1}{2} m_1v_1^2 + \frac{1}{2}m_2v_2^2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{One Dimensional Elastic Collision}}"),
                    new DerivationStep(@"\text{Combine with momentum conservation:}"),
                    new DerivationStep(@"m_1 u_1 + m_2 u_2 = m_1v_1 + m_2v_2"),
                    new DerivationStep(@"\text{Then solve to find}"),
                    new DerivationStep(@"v_1 = \frac{m_1-m_2}{m_1+m_2}u_1+\frac{2m_2}{m_1+m_2}u_2"),
                    new DerivationStep(@"v_2 = \frac{2m_1}{m_1+m_2}u_1+\frac{m_2-m_1}{m_1+m_2}u_2"),
                }
            },
            new EquationItem("Centre of Mass")
            {
                EquationLatex = @"\vec{r}_{cm} = \frac{\sum m_i \vec{r}_{i}}{\sum m_i}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{r}_{cm} = \frac{m_1 \vec{r}_{1} + m_2 \vec{r}_{2} + m_3 \vec{r}_{3} + ...}{m_1 + m_2 + m_3 + ...}"),
                }
            },
            new EquationItem("Rotational Motion")
            {
                EquationLatex = @"\omega_z = \frac{d \theta}{dt}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Analogy with Linear Motion}}"),
                    new DerivationStep(@"v = \frac{d s}{d t}"),
                    new DerivationStep(@"\omega_z = \frac{d \theta}{dt}"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"s = s_0 + ut + \frac{1}{2}a t ^2"),
                    new DerivationStep(@"\theta = \theta_0 + \omega_{0_z} t + \frac{1}{2}\alpha_z t ^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"v = u +at"),
                    new DerivationStep(@"\omega_z = \omega_{0_z} + \alpha_z t"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"v^2 = u^2 +2a(s - s_0)"),
                    new DerivationStep(@"\omega_z^2 = \omega_{0_z}^2 +2\alpha_z(\theta - \theta_0)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{(all for constant \alpha_z only)}"),
                }
            },
            new EquationItem("Relating Angular and Linear Motion")
            {
                EquationLatex = @"v = r \omega",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"a_{tangential} = \frac{dv}{dt} = r \frac{d \omega}{dt} = r \alpha"),
                    new DerivationStep(@"a_{radial} = \frac{v^2}{r} = \omega^2 r"),
                }
            },
            new EquationItem("Moment of Inertia")
            {
                EquationLatex = @"I = \sum_i m_i {r_i}^2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Two point masses separated \\ by distance x}", 40, 25),
                    new DerivationStep(@"I = \frac{m_1 m_2}{m_1 + m_2} x^2 = \mu x^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Thin cylindrical shell with open ends,\\ radius r and mass m}", 40, 25),
                    new DerivationStep(@"I \approx m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Solid cylinder, radius r,\\ height h, mass m}", 40, 25),
                    new DerivationStep(@"I_z = \frac{1}{2}mr^2"),
                    new DerivationStep(@"I_x = I_y = \frac{1}{12}m(3r^2 + h^2)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Hollow sphere,\\ radius r and mass m}", 40, 25),
                    new DerivationStep(@"I = \frac{2}{3} m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Solid sphere,\\ radius r and mass m}", 40, 25),
                    new DerivationStep(@"I = \frac{2}{5} m r^2"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                }
            },
            new EquationItem("Rotational Kinetic Energy") {EquationLatex = @"K = \frac{1}{2}I \omega^2"},
            new EquationItem("Torque") {EquationLatex = @"\vec{\tau} = \vec{r} \times \vec{F}"},
            new EquationItem("Newton's 2nd Law (rotational)") {EquationLatex = @"\sum \tau_z = I \alpha_z"},
            new EquationItem("Kinetic Energy of Rotational\nand Linear Motion") {EquationLatex = @"K = \frac{1}{2}Mv^2 + \frac{1}{2}I \omega^2"},
            new EquationItem("Work Done by a Torque")
            {
                EquationLatex = @"W = \int_{\theta_1}^{\theta_2} \tau_z \ d \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"W_{total} = \frac{1}{2} I {\omega_{2}}^2 - \frac{1}{2} I {\omega_{1}}^2"),
                }
            },
            new EquationItem("Angular Momentum")
            {
                EquationLatex = @"\vec{L} = I \vec{\omega}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Relation to torque}", 40),
                    new DerivationStep(@"\sum \vec{\tau} = \frac{d \vec{L}}{dt}"),
                }
            },
            new EquationItem("Gyroscopic Precession Angular Speed")
            {
                EquationLatex = @"\Omega = \frac{wr}{I\omega}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\Omega = \frac{d \phi}{dt} = \frac{|d \vec{L}|/|\vec{L}|}{dt} = \frac{\tau_z}{L_z} = \frac{wr}{I\omega}"),
                }
            },
            new EquationItem("Equilibrium") {EquationLatex = @"\sum \vec{F} = \sum \vec{\tau} = 0"},
            new EquationItem("Hooke's Law") {EquationLatex = @"\frac{\text{stress}}{\text{strain}} = \text{elastic modulus}"},
            new EquationItem("Young's Modulus")
            {
                EquationLatex = @"Y = \frac{\text{tensile stress}}{\text{tensile strain}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"Y = \frac{F_{\perp} / A}{\Delta l / l_0} = \frac{F_{\perp} \ l_0}{A \ \Delta l}")
                }
            },
            new EquationItem("Shear Modulus")
            {
                EquationLatex = @"Y = \frac{\text{shear stress}}{\text{shear strain}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"Y = \frac{F_{\parallel} / A}{x / h} = \frac{F_{\parallel} \ h}{A \ x}")
                }
            },
            new EquationItem("Newton's Law of Gravitation") {EquationLatex = @"F = \frac{G m_1 m_2}{r^2}"},
            new EquationItem("Gravitational Potential")
            {
                EquationLatex = @"U = - \frac{G m_E m}{r}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Derivation}}"),
                    new DerivationStep(@"\text{Work done by gravity:}", 30, 30),
                    new DerivationStep(@"W = \int_{r_1}^{r_2} F_r \ dr"),
                    new DerivationStep(@"W = - \int_{r_1}^{r_2} \frac{G m_E m}{r^2} \ dr"),
                    new DerivationStep(@"\text{(negative as gravity \\ acts toward earth)}", 25),
                    new DerivationStep(@"W = -\frac{G m_E m}{r_1} + \frac{G m_E m}{r_2}"),
                    new DerivationStep(@"\text{Potential energy U \\ is defined by W = U_1 - U_2}",50, 25),
                    new DerivationStep(@"\text{Thus, } U = - \frac{G m_E m}{r}"),
                }
            },
            new EquationItem("Escape Velocity")
            {
                EquationLatex = @"v_{escape} = \sqrt{\frac{2GM}{R}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Derivation}}"),
                    new DerivationStep(@"\text{Kinetic energy must equal work done}", 30, 25),
                    new DerivationStep(@"\text{to escape to infinite distance}", 30, 25),
                    new DerivationStep(@"\frac{1}{2}mv^2 = -(-\frac{G M m}{r_1} + \frac{G M m}{r_2})"),
                    new DerivationStep("", 0, 0, true, "Gravitational Potential"),
                    new DerivationStep(@"\frac{1}{2}mv^2 = -(-\frac{G M m}{R} + \frac{G M m}{\infty})"),
                    new DerivationStep(@"\frac{1}{2}mv^2 = \frac{G M m}{R}"),
                    new DerivationStep(@"v_{escape} = \sqrt{\frac{2GM}{R}}"),
                    new DerivationStep(@"\text{For any body mass M, at radius R}", 30, 25),
                }
            },
            new EquationItem("Kepler's 1st Law", 80, 25) {EquationLatex = @"\text{All planets move in an elliptical orbit \\ with one focus about a star}"},
            new EquationItem("Kepler's 2nd Law")
            {
                EquationLatex = @"\frac{dA}{dt} = \frac{1}{2} \ r^2 \ \frac{d \theta}{dt}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{A line connecting a planet to its}", 30, 25),
                    new DerivationStep(@"\text{central star sweeps an equal area}", 30, 25),
                    new DerivationStep(@"\text{for all changes in time.}", 30, 25),
                    new DerivationStep(@"\text{(Conservation of angular momentum)}", 30, 25),
                }
            },
            new EquationItem("Kepler's 3rd Law") {EquationLatex = @"T = \frac{2 \pi a^{\frac{3}{2}}}{\sqrt{G M_s}}"},
            new EquationItem("Schwarzchild Radius") {EquationLatex = @"R_S = \frac{2GM}{c^2}"},
            new EquationItem("Periodic Motion")
            {
                EquationLatex = @"f = \frac{1}{T} \ \ \ \ \ \ T = \frac{1}{f}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = 2 \pi f = \frac{2 \pi}{T}")
                }
            },
            new EquationItem("Simple Harmonic Motion")
            {
                EquationLatex = @"\ddot{x} = - \omega^2 x",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"x = A e^{i \omega t}"),
                    new DerivationStep(@"\text{\underline{\ \ \ \ \ \ \ \ \ \ \ \ }}"),
                    new DerivationStep(@"\omega = \sqrt{\frac{k}{m}}"),
                    new DerivationStep(@"f = \frac{\omega}{2 \pi} = \frac{1}{2 \pi}\sqrt{\frac{k}{m}}"),
                    new DerivationStep(@"T = \frac{2 \pi}{\omega} = 2 \pi \sqrt{\frac{m}{k}}"),
                    new DerivationStep("", 60, 30, true, "Periodic Motion"),
                }
            },
            new EquationItem("Energy in Simple Harmonic Motion") {EquationLatex = @"E = \frac{1}{2}mv_x^2 + \frac{1}{2}k x^2 = \frac{1}{2}k A^2 = constant"},
            new EquationItem("The Simple Pendulum")
            {
                EquationLatex = @"\ddot{\theta} = - \omega^2 \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = \sqrt{\frac{k}{m}} = \sqrt{\frac{g}{L}}"),
                    new DerivationStep(@"f = \frac{\omega}{2 \pi} = \frac{1}{2 \pi}\sqrt{\frac{g}{L}}"),
                    new DerivationStep(@"T = \frac{2 \pi}{\omega} = 2 \pi \sqrt{\frac{L}{g}}"),
                    new DerivationStep("",60, 30, true, "Periodic Motion"),
                }
            },
            new EquationItem("The Physical Pendulum")
            {
                EquationLatex = @"\ddot{\theta} = - \frac{mgd}{I} \theta",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega = \sqrt{\frac{mgd}{I}}"),
                    new DerivationStep(@"T = 2 \pi \sqrt{\frac{I}{mgd}}"),
                    new DerivationStep(@"\text{Where } I \text{ is the moment of inertia}", 30, 35),
                    new DerivationStep("", 60, 30, true, "Moment of Inertia"),
                }
            },
            new EquationItem("Damped Oscillation")
            {
                EquationLatex = @"x = Ae^{-(\frac{b}{2m} + i \omega')t}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega' = \sqrt{\frac{k}{m} - \frac{b^2}{4m^2}}"),
                    new DerivationStep(@"b = \text{damping factor}"),
                    new DerivationStep(@"b < 2\sqrt{km} \ \ \text{underdamping}"),
                    new DerivationStep(@"b = 2\sqrt{km} \ \ \text{critical damping}"),
                    new DerivationStep(@"b > 2\sqrt{km} \ \ \text{overdamping}"),
                }
            },
            new EquationItem("Driven (Forced) oscillation")
            {
                EquationLatex = @"A = \frac{F_{max}}{\sqrt{(k - m \omega_d^2)^2 + b^2 \omega_d^2}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\omega_d = \text{driving frequency}"),
                    new DerivationStep(@"b= \text{damping factor}"),
                    new DerivationStep("",60, 30,true, "Damped Oscillation"),
                }
            },
        };

        #endregion Public Fields
    }
}