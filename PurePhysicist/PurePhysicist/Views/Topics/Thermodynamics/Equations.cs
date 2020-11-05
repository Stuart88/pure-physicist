using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.Thermodynamics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Temperature Conversions", 80)
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"T_F = \frac{9}{5}T_C + 32^o"),
                    new DerivationStep(@"T_C = \frac{5}{9}(T_F - 32^o)"),
                    new DerivationStep(@"T_K = T_C + 273.15"),
                    new DerivationStep(@"\frac{T_2}{T_1} = \frac{P_2}{P_1}"),
                }
            },
            new EquationItem("Thermal Expansion (length)")
            {
                EquationLatex = @"\Delta L = \alpha L_0 \Delta T",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\alpha = \text{ Linear Expansion Coefficient}"),
                }
            },
            new EquationItem("Thermal Expansion (volume)")
            {
                EquationLatex = @"\Delta V = \beta V_0 \Delta T",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\beta = \text{ Linear Expansion Coefficient}"),
                }
            },
            new EquationItem("Thermal Stress")
            {
                EquationLatex = @"\frac{F}{A} = -Y \alpha \Delta T",
            },
            new EquationItem("Heat")
            {
                EquationLatex = @"Q = mc \Delta t",
            },
            new EquationItem("Conduction")
            {
                EquationLatex = @"H = \frac{dQ}{dt}",
            },
            new EquationItem("Equation of State")
            {
                EquationLatex = @"pV = nRT",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For uniform } p \text{ and } T"),
                    new DerivationStep(@"n = \text{ number of moles}"),
                    new DerivationStep(@"R =  8.3134Jmol^{-1}K^{-1}", 40),
                    new DerivationStep(@"\text{(The Gas Constant)}", 30)
                }
            },
            new EquationItem("Kinetic Energy (translational)")
            {
                EquationLatex = @"K_{Tr} = \frac{3}{2} nRT",
            },
            new EquationItem("Average Velocity of Gas Molecule")
            {
                EquationLatex = @"\frac{1}{2}m(v^2)_{av} = \frac{3}{2} kT",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"k = 1.38 \times 10^{-23}m^2kgs^{-2}K^{-1}", 40),
                    new DerivationStep(@"\text{(the Boltzmann Constant)}", 30)
                }
            },
            new EquationItem("RMS Velocity")
            {
                EquationLatex = @"V_{rms} = \sqrt{(v^2)_{av}} = \sqrt{\frac{3kT}{m}}",
            },
            new EquationItem("Mean Free Path")
            {
                EquationLatex = @"\lambda = v t_{mean} = \frac{V}{4 \pi \sqrt{2}r^2 N}",
            },
            new EquationItem("Heat Capacities")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Monatomic Gas: } C_V = \frac{3}{2}R"),
                    new DerivationStep(@"\text{Diatomic Gas: } C_V = \frac{5}{2}R"),
                    new DerivationStep(@"\text{Monatomic Solid: } C_V = 3R"),
                }
            },
            new EquationItem("Molecular Speed Distribution")
            {
                EquationLatex = @"f(v) = 4\pi (\frac{m}{2 \pi k T})^{\frac{3}{2}}v^2 e^{-\frac{mv^2}{2kT}}",
            },
            new EquationItem("Heat and Work")
            {
                EquationLatex = @"W = \int_V_1^V_2 p \ dV",
            },
            new EquationItem("1st Law of Thermodynamics")
            {
                EquationLatex = @"\Delta U = Q - W",
            },
            new EquationItem("2nd Law of Thermodynamics", 120)
            {
                EquationLatex = @"\text{Natural processes cannot be reversed\\without adding extra energy\\back into the system}",
            },
            new EquationItem("3rd Law of Thermodynamics", 120)
            {
                EquationLatex = @"\text{Entropy of a system tends to\\a constant value as\\its temperature approaches zero}",
            },
            new EquationItem("Molar Heat Capacities of an Ideal Gas")
            {
                EquationLatex = @"C_p = C_V + R",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\gamma = \frac{C_p}{C_V}"),
                }
            },
            new EquationItem("Adiabatic Processes in an Ideal Gas")           
            {
                EquationLatex = @"W = nC_V(T_1 - T_2)",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@" = \frac{C_V}{R}(p_1V_1 - p_2V_2)"),
                    new DerivationStep(@" = \frac{1}{\gamma - 1}(p_1V_1 - p_2V_2)"),
                }
            },
            new EquationItem("The Heat Engine")
            {
                EquationLatex = @"e = \frac{W}{Q_H}",
            },
            new EquationItem("The Otto Cycle")
            {
                EquationLatex = @"e = 1 - \frac{1}{r^{\gamma - 1}}",
            },
            new EquationItem("The Carnot Cycle")
            {
                EquationLatex = @"e_{Carnot} = 1 - \frac{T_C}{T_H} = \frac{T_H - T_C}{T_H}",
            },
            new EquationItem("Entropy")
            {
                EquationLatex = @"\Delta S = \int_1^2 \frac{dQ}{T}",
            },
            new EquationItem("Entropy for Microscopic States")
            {
                EquationLatex = @"S = k \ ln\Omega",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\Omega = \text{ Number of possible states}"),
                }
            },
        };

        #endregion Public Fields
    }
}