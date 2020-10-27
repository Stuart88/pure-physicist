using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.Electromagnetism
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Coulomb's Law", 80)
            {
                EquationLatex = @"F=\frac{1}{4 \pi \epsilon_0}\frac{|q_1 q_2|}{r^2}",
            },
            new EquationItem("Electric Field")
            {
                EquationLatex = @"\vec{E} = \frac{\vec{F}_0}{q_0}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{E} = \frac{1}{4 \pi \epsilon_0}\frac{q}{r^2}\hat{r}")
                }
            },
            new EquationItem("Electric Dipoles")
            {
                EquationLatex = @"\tau = p E \ sin(\phi)",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{\tau} = \vec{p} \times \vec{E}"),
                    new DerivationStep(@"U = -\vec{p} \cdot \vec{E}"),
                }
            },
            new EquationItem("Electric Flux")
            {
                EquationLatex = @"\Phi_E = \int \vec{E} \cdot d\vec{A}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\Phi_E = \int E \ cos(\phi) \ dA"),
                    new DerivationStep(@"\  = \int E_\perp \ dA"),
                    new DerivationStep(@"\  = \int \vec{E} \cdot d\vec{A}"),
                }
            },
            new EquationItem("Gauss's Law for E Fields")
            {
                EquationLatex = @"\Phi_E = \frac{Q_{enclosed}}{\epsilon_0}",
            },
            new EquationItem("Electric Potential Energy")
            {
                EquationLatex = @"U = \frac{q_0}{4 \pi \epsilon_0} \sum_i \frac{q_i}{r_i}",
            },
            new EquationItem("Electric potential")
            {
                EquationLatex = @"V = \frac{U}{q_0}  = \frac{1}{4 \pi \epsilon_0} \sum_i \frac{q_i}{r_i}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"V_a - V_b = \int_a^b \vec{E} \cdot d\vec{l}"),
                }
            },
            new EquationItem("Electric Field from Potential")
            {
                EquationLatex = @"\vec{E} = ( \frac{\partial V}{\partial x},\frac{\partial V}{\partial y},\frac{\partial V}{\partial z} )",
            },
            new EquationItem("Capacitance")
            {
                EquationLatex = @"C = \frac{Q}{V_{ab}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"C = \frac{Q}{V_{ab}} = \epsilon_0 \frac{A}{d}"),
                }
            },
            new EquationItem("Capacitors in Series")
            {
                EquationLatex = @"\frac{1}{C_{eq}} = \frac{1}{C_1} + \frac{1}{C_2} + \frac{1}{C_3} + ...",
            },
            new EquationItem("Capacitors in Parallel")
            {
                EquationLatex = @"C_{eq} = C_1 + C_2 + C_3 + ...",
            },
            new EquationItem("Energy in a Capacitor")
            {
                EquationLatex = @"U = \frac{Q^2}{2C} = \frac{1}{2}CV^2 = \frac{1}{2}QV",
            },
            new EquationItem("Energy Density of a Capacitor")
            {
                EquationLatex = @"u = \frac{1}{2} \epsilon_0 E^2",
            },
            new EquationItem("Current")
            {
                EquationLatex = @"I = \frac{dQ}{dt}  = nqv_dA",
            },
            new EquationItem("Current Density")
            {
                EquationLatex = @"\vec{J} = nq\vec{v}_d",
            },
            new EquationItem("Resistivity")
            {
                EquationLatex = @"\rho = \frac{E}{J}",
            },
            new EquationItem("Resistance")
            {
                EquationLatex = @"V = IR",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"R = \frac{\rho L}{A}"),
                }
            },
            new EquationItem("Electromotive Force (emf)")
            {
                EquationLatex = @"V_{ab} = \xi - Ir",
            },
            new EquationItem("Power in Circiuits")
            {
                EquationLatex = @"P = V_{ab}I",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"P = V_{ab}I"),
                    new DerivationStep(@"\ = I^2 R"),
                    new DerivationStep(@"\ = \frac{{V_{ab}}^2}{R}"),
                }
            },
            new EquationItem("Resistors in Series")
            {
                EquationLatex = @"R_{eq} = R_1 + R_2 + R_3 + ...",
            },
            new EquationItem("Resistors in Parallel")
            {
                EquationLatex = @"\frac{1}{R_{eq}} = \frac{1}{R_1} + \frac{1}{R_2} + \frac{1}{R_3} + ...",
            },
            new EquationItem("Kirchoff's Rules")
            {
                EquationLatex = @"View Details",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Junction Rule}", 50),
                    new DerivationStep(@"\sum I = 0"),
                    new DerivationStep(@"\text{Loop Rule}", 50),
                    new DerivationStep(@"\sum V = 0"),
                }
            },
            new EquationItem("Capacitor Charging")
            {
                EquationLatex = @"q = C \xi (1 - e^{\frac{-t}{RC}})",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Current}", 50),
                    new DerivationStep(@"i = \frac{dq}{dt} = \frac{\xi}{R} e^{\frac{-t}{RC}}"),
                    new DerivationStep(@"=  I_0  e^{\frac{-t}{RC}}"),
                }
            },
            new EquationItem("Capacitor Discharging")
            {
                EquationLatex = @"q = Q_0  e^{\frac{-t}{RC}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Current}", 50),
                    new DerivationStep(@"i = \frac{dq}{dt} = \frac{Q_0}{RC} e^{\frac{-t}{RC}}"),
                    new DerivationStep(@"=  I_0  e^{\frac{-t}{RC}}"),
                }
            },
            new EquationItem("Magnetic Force")
            {
                EquationLatex = @"\vec{F}_B = q\vec{v} \times \vec{B}",
            },
            new EquationItem("Magnetic Field Lines and Flux")
            {
                EquationLatex = @"\Phi_B = \int \vec{B} \cdot d \vec{A}",
            },
            new EquationItem("Gauss' Law for Magnetism")
            {
                EquationLatex = @"\oint \vec{B} \cdot d \vec{A} = 0",
            },
            new EquationItem("Motion in a Magnetic Field")
            {
                EquationLatex = @" r = \frac{mv}{qB} ",
            },
            new EquationItem("Velocity Selector")
            {
                EquationLatex = @"v = \frac{E}{B}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Charge in E and B fields}}", 60),
                    new DerivationStep(@"\text{Force from B field}", 50),
                    new DerivationStep(@"\vec{F}_B = q\vec{v} \times \vec{B}"),
                    new DerivationStep(@"\text{Force from E field}", 50),
                    new DerivationStep(@"\vec{F}_E = q\vec{E}"),
                    new DerivationStep(@"\text{Circular path in B field}", 50),
                    new DerivationStep(@"r = \frac{mv}{qB}"),
                }
            },
            new EquationItem("Magnetic Force on a Conductor")
            {
                EquationLatex = @"\vec{F} = I \ \vec{l} \times \vec{B}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"d\vec{F} = I \ d\vec{l} \times \vec{B}", 60),
                }
            },
            new EquationItem("Magnetic Torque")
            {
                EquationLatex = @" \vec{\tau} = \vec{\mu} \times \vec{B} ",
            },
            new EquationItem("Potential of Magnetic Moment")
            {
                EquationLatex = @" U = - \vec{\mu} \cdot \vec{B} ",
            },
            new EquationItem("The Hall Effect")
            {
                EquationLatex = @"nq = \frac{-J_x B_y}{E_z}",
            },
            new EquationItem("Magnetic field of a Moving Charge")
            {
                EquationLatex = @"\vec{B} = \frac{\mu_0}{4\pi}\frac{q \vec{v} \times \hat{r}}{r^2}",
            },
            new EquationItem("Magnetic field of a Current-Carrying Conductor")
            {
                EquationLatex = @"d\vec{B} = \frac{\mu_0}{4\pi}\frac{I d\vec{l} \times \hat{r}}{r^2}",
            },
            new EquationItem("Magnetic field of an infinite current-carrying wire")
            {
                EquationLatex = @"B = \frac{\mu_0 I}{2 \pi r}",
            },
            new EquationItem("Magnetic force between two parallel current-carrying wires")
            {
                EquationLatex = @"\frac{F}{L} = \frac{\mu_0 I_1 I_2}{2 \pi r}",
            },
            new EquationItem("Magnetic field of a loop of current")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Single Loop}", 50),
                    new DerivationStep(@"B_x = \frac{\mu_0 I a^2}{2(x^2 + a^2)^{\frac{3}{2}}}"),
                    new DerivationStep(@"\text{Centre of N loops}", 50),
                    new DerivationStep(@"B_x = \frac{\mu_0 N I}{2a}"),
                }
            },
            new EquationItem("Ampere's Law")
            {
                EquationLatex = @"\oint \vec{B} \cdot d\vec{l} = \mu_0 I_{enclosed}",
            },
            new EquationItem("Faraday's Law")
            {
                EquationLatex = @"\epsilon = -\frac{d \Phi_b}{dt}",
            },
            new EquationItem("Induced Electric Field (emf)")
            {
                EquationLatex = @"\oint \vec{E} \cdot d \vec{l} = - \frac{d\Phi_B}{dt}",
            },
            new EquationItem("Displacement Current")
            {
                EquationLatex = @"i_D = \epsilon \frac{d \Phi_E}{dt}",
            },
            new EquationItem("Maxwell's Equations")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{Displacement Current}}", 50),
                    new DerivationStep(@"i_D = \epsilon \frac{d \Phi_E}{dt}"),
                    new DerivationStep(@"\text{\underline{Gauss's Law for E Fields}}", 50),
                    new DerivationStep(@"\Phi_E = \frac{Q_{enclosed}}{\epsilon_0}"),
                    new DerivationStep(@"\text{\underline{Gauss's Law for B Fields}}", 50),
                    new DerivationStep(@"\oint \vec{B} \cdot d \vec{A} = 0"),
                    new DerivationStep(@"\text{\underline{Ampere's Law + Displacement Current}}", 50),
                    new DerivationStep(@"\oint \vec{B} \cdot d\vec{l} = \mu_0(i_C + \epsilon_0 \frac{d\Phi_E}{dt})_{enclosed}"),
                    new DerivationStep(@"\text{\underline{Faraday's Law}}", 50),
                    new DerivationStep(@"\oint \vec{E} \cdot d \vec{l} = - \frac{d\Phi_B}{dt}"),
                }
            },
            new EquationItem("Mutual Inductance")
            {
                EquationLatex = @"M = \frac{N_2 \Phi_{B2}}{i_1} = \frac{N_1 \Phi_{B1}}{i_2}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\epsilon_1 = -M \frac{di_1}{dt}"),
                    new DerivationStep(@"\epsilon_2 = -M \frac{di_2}{dt}"),
                }
            },
            new EquationItem("Self Inductance")
            {
                EquationLatex = @"L = \frac{N \Phi_{B}}{i}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\epsilon = -L \frac{d i}{dt}"),
                }
            },
            new EquationItem("Energy in a Magnetic Field")
            {
                EquationLatex = @"U = \frac{1}{2} L I2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{In Vacuum}}", 50),
                    new DerivationStep(@"u = \frac{B^2}{2 \mu_0}"),
                    new DerivationStep(@"\text{\underline{In a material}}", 50),
                    new DerivationStep(@"u = \frac{B^2}{2 \mu}"),
                    new DerivationStep(@"(\text{with magnetic permeability} \ \mu)", 50),
                }
            },
            new EquationItem("RL Circuit")
            {
                EquationLatex = @"\tau = \frac{L}{R}",
            },
            new EquationItem("LC Circuit")
            {
                EquationLatex = @"\omega = \sqrt{\frac{1}{LC}}",
            },
            new EquationItem("LRC Series Circuit")
            {
                EquationLatex = @"\omega' = \sqrt{\frac{1}{LC} - \frac{R^2}{4L^2}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Differential equation for LRC circuit}", 50),
                    new DerivationStep(@"\text{is the same format as the equation}", 50),
                    new DerivationStep(@"\text{for mechanical oscillation}", 50),
                    new DerivationStep(@"\frac{d^2 q}{dt^2} + \frac{R}{L}\frac{dq}{dt} + \frac{1}{LC}q=0"),
                }
            },
            new EquationItem("RMS Current")
            {
                EquationLatex = @"I_{RMS} = \frac{I}{\sqrt{2}}",
            },
            new EquationItem("RMS Voltage")
            {
                EquationLatex = @"V_{RMS} = \frac{V}{\sqrt{2}}",
            },
            new EquationItem("Impedance")
            {
                EquationLatex = @"V = IZ",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{\underline{For LRC Circuit}}", 50),
                    new DerivationStep(@"Z = \sqrt{R^2 + (\omega L - \frac{1}{\omega C})^2}"),
                    new DerivationStep(@"\text{Phase Angle}", 50),
                    new DerivationStep(@"tan \phi = \frac{\omega L - 1 / \omega C}{R}"),
                }
            },
            new EquationItem("Power in an AC Circuit")
            {
                EquationLatex = @"P_{average} = \frac{1}{2}V I cos \phi",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"P_{average} =  V_{RMS} I_{RMS} \ cos \phi"),
                }
            },
            new EquationItem("Resonance in an AC Circuit")
            {
                EquationLatex = @"\omega_0 = \frac{1}{\sqrt{LC}}",
            },
            new EquationItem("Transformers")
            {
                EquationLatex = @"\frac{V_2}{V_1} = \frac{N_2}{N_1} \ \ , \ \ V_1 I_1 = V_2 I_2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"P_{average} =  V_{RMS} I_{RMS} cos \phi"),
                }
            },
            new EquationItem("Electromagnetic Wave Propagation")
            {
                EquationLatex = @"c= \frac{1}{\sqrt{\epsilon_0 \mu_0}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Faraday's and Ampere's Laws}", 50),
                    new DerivationStep(@"\text{relate E and B}", 50),
                    new DerivationStep(@"E = cB"),
                    new DerivationStep(@"B = \epsilon_0 \mu_0 cE"),
                    new DerivationStep(@"\text{Therefore:}", 50),
                    new DerivationStep(@"c= \frac{1}{\sqrt{\epsilon_0 \mu_0}}"),
                }
            },
            new EquationItem("Poynting Vector")
            {
                EquationLatex = @"\vec{S} = \frac{1}{\mu_0} \vec{E} \times \vec{B}",
            },
            new EquationItem("Electromagnetic Wave Intensity")
            {
                EquationLatex = @"I = \frac{1}{2}\epsilon_0 c {E_{max}}^2",
            },
        };

        #endregion Public Fields
    }
}