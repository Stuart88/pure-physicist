using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.FluidDynamics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Common Flows")
            {
                EquationLatex = @"\text{See Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Uniform Flow}"),
                    new DerivationStep(@"\vec{}"),
                }
            },
        };

        #endregion Public Fields
    }
}