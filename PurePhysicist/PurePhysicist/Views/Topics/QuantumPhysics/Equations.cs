using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.QuantumPhysics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Heisenberg Uncertainty Principle\n(Position, Momentum)")
            {
                EquationLatex = @"\Delta x \Delta p_x \geq \frac{\hbar}{2}"
            },
            new EquationItem("Heisenberg Uncertainty Principle\n(Energy, Time)")
            {
                EquationLatex = @"\Delta t \Delta E \geq \geq \frac{\hbar}{2}"
            },
            new EquationItem("Probability Density")
            {
                EquationLatex = @"P(x) = |\Psi(x)|^2"
            },
            new EquationItem("Normalisation Condition")
            {
                EquationLatex = @"\int_{-\infty}^{\infty} |\Psi(x)|^2 \ dx = 1"
            },
            new EquationItem("Expectation (Average) Value")
            {
                EquationLatex = @"[f(x)]_{av} = \int_{-\infty}^{\infty} |\Psi(x)|^2 \ f(x) \ dx"
            },
            new EquationItem("Wave Function")
            {
                EquationLatex = @"\Psi(\vec{r}, t) = \Psi(\vec{r}) e^{-i E t/ \hbar}"
            },
            new EquationItem("Infinite Potential Energy Well")
            {
                EquationLatex = @"\Psi_n (x)  =\sqrt{\frac{2}{L}} \ sin(\frac{n \pi x}{L})",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"E_n = \frac{h^2 n^2 }{8 m L^2}"),
                    new DerivationStep(@"n = 1, 2, 3, ..."),
                }
            },
            new EquationItem("Two-Dimensional Infinite Well (2D)")
            {
                EquationLatex = @"\Psi(x,y)  =\frac{2}{L} \ sin(\frac{n_x \pi x}{L})sin(\frac{n_y \pi y}{L})",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"E_n = \frac{h^2 n^2 }{8 m L^2}"),
                    new DerivationStep(@"n = 1, 2, 3, ..."),
                }
            },
            new EquationItem("Harmonic Oscillator (ground state)")
            {
                EquationLatex = @"\Psi(x)  = (\frac{m \omega_0}{\hbar \pi})^{\frac{1}{4}} \ e^{-(\frac{\sqrt{km}}{2\hbar})x^2}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"E_n = (n + \frac{1}{2})\ \hbar \omega_0"),
                    new DerivationStep(@"n = 0, 1, 2, ..."),
                }
            },
            new EquationItem("Time-Dependent Schrödinger Equation\n(general)")
            {
                EquationLatex = @"i \hbar \frac{d}{dt}|\Psi(t)\rangle = \hat{H}|\Psi(t)\rangle"
            },
            new EquationItem("Time-Dependent Schrödinger Equation\n(position basis)")
            {
                EquationLatex = @"i \hbar \frac{\partial}{\partial t} \Psi(\vec{r},t) = [\frac{- \hbar^2}{2m}\nabla^2 + V(\vec{r}, t)] \ \Psi(\vec{r},t)"
            },
            new EquationItem("Time-Independent Schrödinger Equation")
            {
                EquationLatex = @"\hat{H} |\Psi\rangle = E|\Psi\rangle"
            },
            new EquationItem("Time-independent Schrödinger Equation\n(single non-relativistic particle)")
            {
                EquationLatex = @"[\frac{- \hbar^2}{2m}\nabla^2 + V(\vec{r})] \ \Psi(\vec{r}) =  \ E \Psi(\vec{r})"
            },
            new EquationItem("Quantum Tunnelling Probability")
            {
                EquationLatex = @"T = G e^{-2\kappa L}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"G = 16 \frac{E}{U_0}(1 - \frac{E}{U_0})", 80),
                    new DerivationStep(@"\kappa = \frac{\sqrt{2m(U_0) - E)}}{\hbar}", 80),
                    new DerivationStep(@"E = \text{ Particle Energy}", 60),
                    new DerivationStep(@"U_0 = \text{ Barrier Energy ('height')}"),
                    new DerivationStep(@"L = \text{ Barrier Width}", 60),
                }
            },
            new EquationItem("Orbital Angular Momentum")
            {
                EquationLatex = @"|\vec{L}| = \sqrt{l(l+1)}\hbar",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"l = 0, 1, 2, ..."),
                }
            },
            new EquationItem("Orbital Magnetic Quantum Number")
            {
                EquationLatex = @"L_z = m_l \hbar",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"m_l = 0, \pm 1, \pm 2,  ..., \pm l"),
                }
            },
            new EquationItem("Angular Momentum Uncertainty")
            {
                EquationLatex = @"\Delta L_z \Delta \phi \geq \hbar"
            },
            new EquationItem("Hydrogen Quantum Numbers")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"n = 1, 2, 3, ...", 60),
                    new DerivationStep(@"l = 0, 1, 2, ..., n-l"),
                    new DerivationStep(@"m_l = 0, \pm 1, \pm 2,  ..., \pm l"),
                }
            },
            new EquationItem("Hydrogen Energy Levels")
            {
                EquationLatex = @"E_n = - \frac{me^4}{32\pi^2 \ \epsilon_0^2 \ \hbar^2} \ \frac{1}{n^2}"
            },
            new EquationItem("Hydrogen Wave Function")
            {
                EquationLatex = @"\Psi_{n,l,m_l}(r, \theta, \phi)= R_{n,l}(r)\  \Theta_{l, m_l}(\theta)\  \Phi_{m,l}(\phi)"
            },
            new EquationItem("Radial Probability Density")
            {
                EquationLatex = @"P(r) = r^2 |R_{n,l}(r)|^2"
            },
            new EquationItem("Angular Probability Density")
            {
                EquationLatex = @"P(\theta, \phi) =|\Theta_{l, m_l}(\theta)\  \Phi_{m,l}(\phi)|^2"
            },
            new EquationItem("Spin Angular Momentum")
            {
                EquationLatex = @"|\vec{S}| = \sqrt{s(s_1)}\hbar"
            },
            new EquationItem("Spin Magnetic Quantum Number")
            {
                EquationLatex = @"S_z = m_s \hbar \ \ , \ \  ( m = \pm\frac{1}{2})"
            },
        };

        #endregion Public Fields
    }
}