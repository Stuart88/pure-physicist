using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.ModernPhysics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Lorentz factor", 120)
            {
                EquationLatex = @"\gamma = \frac{1}{\sqrt{1 - \frac{v^2}{c^2}}}",
            },
            new EquationItem("Time Dilation", 120)
            {
                EquationLatex = @"\Delta t =  \frac{\Delta T_0}{\sqrt{1 - \frac{v^2}{c^2}}} = \gamma \Delta t_0",
            },
            new EquationItem("Length Conctraction")
            {
                EquationLatex = @"l =  l_0 \sqrt{1 - \frac{v^2}{c^2}} = \frac{l_0}{\gamma}",
            },
            new EquationItem("The Lorentz Transformations (1D)")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"x' = \frac{x - vt}{\sqrt{1-\frac{v^2}{c^2}}} = \gamma(x - vt))"),
                    new DerivationStep(@"y' = y"),
                    new DerivationStep(@"z' = z"),
                    new DerivationStep(@"t' = \frac{t - \frac{vx}{c^2}}{\sqrt{1-\frac{v^2}{c^2}}} = \gamma(t-\frac{vx}{c^2})"),
                }
            },
            new EquationItem("Doppler Effect in Electromagnetic Waves")
            {
                EquationLatex = @"f = \sqrt{\frac{c + v}{c-v}}f_0",
            },
            new EquationItem("Relativistic Momentum and Energy")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\vec{p} = \frac{m \vec{v}}{\sqrt{1-\frac{v^2}{c^2}}} = \gamma m \vec{v}"),
                    new DerivationStep(@"K = \frac{m c^2}{\sqrt{1-\frac{v^2}{c^2}}} - mc^2 = (\gamma - 1) mc^2"),
                    new DerivationStep(@"E = K + mc^2 = \frac{m c^2}{\sqrt{1-\frac{v^2}{c^2}}} = \gamma mc^2"),
                    new DerivationStep(@"E^2 = (mc^2)^2 + (pc)^2"),
                }
            },
            new EquationItem("Photon Energy")
            {
                EquationLatex = @"E = hf = \frac{hc}{\lambda}",
            },
            new EquationItem("Photon Momentum")
            {
                EquationLatex = @"p = \frac{E}{c} = \frac{hf}{c} = \frac{h}{\lambda}",
            },
            new EquationItem("The Photoelectric Effect")
            {
                EquationLatex = @"eV_0 = hf - \phi",
            },
            new EquationItem("Compton Scattering")
            {
                EquationLatex = @"\lambda' - \lambda = \frac{h}{m_e c}(1 - cos\theta)",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\frac{1}{E'} - \frac{1}{E}= \frac{1}{m_e c}(1 - cos\theta)", 80),
                    new DerivationStep(@"\text{Electron Energy: } K_e = E - E'"),
                    new DerivationStep(@"\text{Electron Scatter: } tan \phi = \frac{E' sin\theta}{E - E'cos\theta}"),
                }
            },
            new EquationItem("Bremsstrahlung")
            {
                EquationLatex = @"eV_{AC} = hf_{max}= \frac{hc}{\lambda_{min}}",
            },
            new EquationItem("De Broglie Wavelength")
            {
                EquationLatex = @"\lambda = \frac{h}{p} = \frac{h}{mv}",
            },
            new EquationItem("Blackbody Radiation")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Stefan-Boltzmann Law}", 30),
                    new DerivationStep(@"I = \sigma T^4"),
                    new DerivationStep(@"\text{Wien Displacement Law}", 30),
                    new DerivationStep(@"\lambda_m  T = 2.90 \times 10^{-3} \ m \cdot K"),
                    new DerivationStep(@"\text{Planck Radiation Law}", 30),
                    new DerivationStep(@"I(\lambda) = \frac{2 \pi h c^2}{\lambda^5(e^{hc/\lambda k T} - 1)}"),
                }
            },
            new EquationItem("Density of States")
            {
                EquationLatex = @"g(E) = \frac{(2m)^{\frac{3}{2}}V}{2 \pi^2 \hbar^3} \sqrt{E}",
            },
            new EquationItem("Fermi-Dirac Distribution")
            {
                EquationLatex = @"f(E) = \frac{1}{e^{(E-E_F)/kT} + 1}",
            },
            new EquationItem("Nuclear Binding Energy")
            {
                EquationLatex = @"E_B = (ZM_H + Nm_n - {}^{A}_{Z}M)c^2",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"E_B = \text{ Binding Energy}", 30),
                    new DerivationStep(@"Z = \text{ Proton Number}", 30),
                    new DerivationStep(@"M_H = \text{ Mass of Hydrogen}", 30),
                    new DerivationStep(@"N = \text{ Neutron Number}", 30),
                    new DerivationStep(@"m_n = \text{ Neutron mass}", 30),
                    new DerivationStep(@"A = \text{ Mass Number}", 30),
                    new DerivationStep(@"{}^{A}_{Z}M = \text{ Mass of the Nuetral Atom}", 30),
                }
            },
            new EquationItem("Radioactive Decay")
            {
                EquationLatex = @"N(t) = N_0 e^{-\lambda t}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"T_{mean} = \frac{1}{\lambda} = \frac{T_{\frac{1}{2}}}{ln2}")
                }
            },
        };

        #endregion Public Fields
    }
}