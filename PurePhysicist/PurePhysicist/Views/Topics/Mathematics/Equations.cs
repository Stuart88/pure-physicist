using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.Mathematics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Fourier Wave Equation")
            {
                EquationLatex = @"f(x) = \frac{1}{2} A_0 + \sum_{n=1}^{\infty}[A_n cos(\frac{2 \pi n}{L} x) + B_n sin(\frac{2 \pi n}{L} x)]",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"A_n = \frac{2}{L} \int_{x_1}^{x_2} f(x) \ cos(\frac{2 \pi n}{L} x) \ dx", 60),
                    new DerivationStep(@"B_n = \frac{2}{L} \int_{x_1}^{x_2} f(x) \ sin(\frac{2 \pi n}{L} x) \ dx", 60),
                    new DerivationStep(@"A_0 = \frac{2}{L} \int_{x_1}^{x_2} f(x)  \ dx", 60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Examples:}", 60, 45),
                    new DerivationStep(@"\text{Square Wave}"),
                    new DerivationStep( @"f(x) = \frac{h}{2} + \sum_{n=1}^{\infty}[\frac{2 h}{n \pi} \ sin(\frac{n \pi}{2}) \ cos(\frac{2 \pi n}{L} x)]"),
                    new DerivationStep(@"\text{Sawtooth Wave}"),
                    new DerivationStep(@"f(x) = \frac{h}{2} - \frac{h}{\pi} \sum_{n=1}^{\infty}[\frac{1}{n} \ sin(\frac{n \pi}{L} x)]"),
                    new DerivationStep(@"\text{Triangle Wave}"),
                    new DerivationStep(@"f(x) = \frac{8h}{\pi^2} \sum_{n=1,3,5...}^{\infty}[\frac{(-1)^{(n-1)/2}}{n^2} \ sin(\frac{n \pi}{L} x)]"),

                }
            },
            new EquationItem("Square Wave Equation (Fourier)")
            {
                EquationLatex = @"f(x) = \frac{h}{2} + \sum_{n=1}^{\infty}[\frac{2 h}{n \pi} \ sin(\frac{n \pi}{2}) \ cos(\frac{2 \pi n}{L} x)]",
            },
            new EquationItem("Sawtooth Wave Equation (Fourier)")
            {
                EquationLatex = @"f(x) = \frac{h}{2} - \frac{h}{\pi} \sum_{n=1}^{\infty}[\frac{1}{n} \ sin(\frac{n \pi}{L} x)]",
            },
            new EquationItem("Triangle Wave Equation (Fourier)")
            {
                EquationLatex = @"f(x) = \frac{8h}{\pi^2} \sum_{n=1,3,5...}^{\infty}[\frac{(-1)^{(n-1)/2}}{n^2} \ sin(\frac{n \pi}{L} x)]",
            },

        };

        #endregion Public Fields
    }
}