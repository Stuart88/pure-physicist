using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.ModernPhysics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
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
        };

        #endregion Public Fields
    }
}