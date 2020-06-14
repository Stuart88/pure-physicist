using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurePhysicist.Views.Topics.ClassicalMechanics
{
    public static class Equations
    {
        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Net Force on a Body")
            {
                EquationLatex = @"\vec{F}_{total}= \sum \ \vec{F}_n",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    (DerivationStep)@"\vec{F}_1 + \vec{F}_2 + \vec{F}_3 + ... + \vec{F}_i= \sum_{n=1}^{i} \ \vec{F}_n"
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
                    (DerivationStep)@"Fs \ cos\theta",
                    (DerivationStep)@"\theta = \text{angle between } \vec{F} \text{ and } \vec{s}"
                }
            },
        };


    }
}
