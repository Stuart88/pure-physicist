using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.Mathematics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("The Quadratic Formula")
            {
                EquationLatex = @"x = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a} ",
            },
            new EquationItem("Trigonometric Identities")
            {
                EquationLatex = @"\text{View Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"cos^2(x) + sin^2(x) = 1"),
                    new DerivationStep(@"1 + tan^2(x) = sec^2(x)"),
                    new DerivationStep(@"cot^2(x) + 1 = cosec^2(x)"),
                    new DerivationStep(@"sin^2(x) = \frac{1}{2} [1 - 2cos(2x)]"),
                    new DerivationStep(@"cos^2(x) = \frac{1}{2}[1 + 2cos(2x)]"),
                    new DerivationStep(@"sin(A+B) = sinA \ cosB \ + \ cosA \ sinB"),
                    new DerivationStep(@"cos(A+B) = cosA \ cosB \ - \ sinA \ sinB"),
                }
            },
            new EquationItem("Standard Derivatives")
            {
                EquationLatex = @"f(x)  \ \rightarrow  \  \frac{df}{dx}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"x^n  \ \rightarrow  \  nx^{n-1}"),
                    new DerivationStep(@"e^x \ \rightarrow  \  e^x"),
                    new DerivationStep(@"e^kx \ \rightarrow  \  ke^kx"),
                    new DerivationStep(@"a^x \ \rightarrow  \  a^x ln(a)"),
                    new DerivationStep(@"ln(x) \ \rightarrow  \  \frac{1}{x}"),
                    new DerivationStep(@"log_a x \ \rightarrow  \  \frac{1}{x ln(a)}"),
                    new DerivationStep(@"sin(x) \ \rightarrow  \  cos(x)"),
                    new DerivationStep(@"cos(x) \ \rightarrow  \  -sins(x)"),
                    new DerivationStep(@"tax(x) \ \rightarrow  \  sec^2(x)"),
                    new DerivationStep(@"cot(x) \ \rightarrow  \  -cosec^2(x)"),
                    new DerivationStep(@"sec(x) \ \rightarrow  \  sec(x) \ tan(x)"),
                    new DerivationStep(@"cosec(x) \ \rightarrow  \  -cosec(x) \ cot(x)"),
                    new DerivationStep(@"sinh(x) \ \rightarrow  \  cosh(x)"),
                    new DerivationStep(@"cosh(x) \ \rightarrow  \  sinh(x)"),
                    new DerivationStep(@"tanh(x) \ \rightarrow  \  \frac{1}{cosh^2(x)}"),
                    new DerivationStep(@"sin^{-1}(x) \ \rightarrow  \  \frac{1}{\sqrt{1-x^2}}"),
                    new DerivationStep(@"cos^{-1}(x) \ \rightarrow  \  \frac{-1}{\sqrt{1-x^2}}"),
                    new DerivationStep(@"tan^{-1}(x) \ \rightarrow  \  \frac{1}{1+x^2}"),
                    new DerivationStep(@"sinh^{-1}(x) \ \rightarrow  \  \frac{1}{\sqrt{x^2 + 1}}"),
                    new DerivationStep(@"cosh^{-1}(x) \ \rightarrow  \  \frac{1}{\sqrt{x^2 - 1}}"),
                    new DerivationStep(@"tanh^{-1}(x) \ \rightarrow  \  \frac{1}{1-x^2}"),
                }
            },
            new EquationItem("The Chain Rule")
            {
                EquationLatex = @"\frac{d}{dx} f(u(x)) = \frac{df}{du} \frac{du}{dx}"
            },
            new EquationItem("The Product Rule")
            {
                EquationLatex = @"\frac{d}{dx} u(x)v(x) = v \frac{du}{dx} + u \frac{dv}{dx}"
            },
            new EquationItem("The Quotient Rule")
            {
                EquationLatex = @"\frac{d}{dx} \frac{u(x)}{v(x)} = \frac{v \frac{du}{dx} - u \frac{dv}{dx}}{v^2}"
            },
            new EquationItem("Polar Co-ordindates", 100)
            {
                EquationLatex = @"x = r \ cos(\theta) \\ y = r \ sin(\theta)"
            },
            new EquationItem("Spherical Co-ordindates", 100)
            {
                EquationLatex = @"x = r \ sin(\theta) \ cos(\phi) \\ y = r \ sin(\theta) \ sin(\phi) \\ z = r \ cos(\theta) "
            },
            new EquationItem("Arithmetic Progression")
            {
                EquationLatex = @"\sum_{i=0}^{i=n-1} \ a + id",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"S_n = \frac{n}{2}(2a + [n-1]d)")
                }
            },
            new EquationItem("Geometric Progression")
            {
                EquationLatex = @"\sum_{i=0}^{i=n-1} \ an^i",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"S_n = \frac{a(1-r^n)}{1-r}")
                }
            },
            new EquationItem("D'Alembert's Ratio Test")
            {
                EquationLatex = @"R_n = \lim_{n \to \infty}\frac{U_{n+1}}{U_n}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"R_n < 1 \ \rightarrow \ Convergent Series"),
                    new DerivationStep(@"R_n > 1 \ \rightarrow \ Divergent Series"),
                    new DerivationStep(@"R_n = 1 \ \rightarrow \ Unknown"),
                }
            },
            new EquationItem("Taylor Series")
            {
                EquationLatex = @"\sum_{n-0}^\infty \frac{f^{(n)}(a)}{n!}(x-a)^n"
            },
            new EquationItem("Euler's Formula")
            {
                EquationLatex = @"e^{i\pi} + 1 = 0"
            },
            new EquationItem("Integration by Parts")
            {
                EquationLatex = @"\int u \frac{dv}{dx} \ dx = uv - \int v \frac{du}{dx} \ dx"
            },
            new EquationItem("Fourier Wave Equation", 80, 25)
            {
                EquationLatex = @"f(x) = \frac{1}{2} A_0 + \ \sum_{n=1}^{\infty}[A_n cos(\frac{2 \pi n}{L} x) + B_n sin(\frac{2 \pi n}{L} x)]",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"A_n = \frac{2}{L} \int_{x_1}^{x_2} f(x) \ cos(\frac{2 \pi n}{L} x) \ dx", 60),
                    new DerivationStep(@"B_n = \frac{2}{L} \int_{x_1}^{x_2} f(x) \ sin(\frac{2 \pi n}{L} x) \ dx", 60),
                    new DerivationStep(@"A_0 = \frac{2}{L} \int_{x_1}^{x_2} f(x)  \ dx", 60),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Examples:}", 60, 45),
                    new DerivationStep(@"\text{Square Wave}"),
                    new DerivationStep(@"f(x) = \frac{h}{2} + \sum_{n=1}^{\infty}[\frac{2 h}{n \pi} \ sin(\frac{n \pi}{2}) \ cos(\frac{2 \pi n}{L} x)]"),
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
            new EquationItem("Vector Dot Product")
            {
                EquationLatex = @"\vec{u} \cdot \vec{v} = u_xv_x + u_yv_y + u_zv_z"
            },
            new EquationItem("Vector Cross Product")
            {
                EquationLatex = @"\vec{u} \times \vec{v} = \begin{vmatrix} \hat{i} & \hat{j} & \hat{k} \\  u_x & u_y & u_z \\ v_x & v_y & v_z \end{vmatrix}"
            },
            new EquationItem("Gradient of Scalar Field")
            {
                EquationLatex = @"\nabla \phi(x,y,z) = (\frac{\partial \phi}{\partial x}, \frac{\partial \phi}{\partial y}, \frac{\partial \phi}{\partial z})"
            },
            new EquationItem("Divergence of a Vector Field")
            {
                EquationLatex = @"\nabla \cdot \vec{a} = \frac{\partial a_x}{\partial x} + \frac{\partial a_y}{\partial y} + \frac{\partial a_z}{\partial z}"
            },
            new EquationItem("Curl of a Vector",120)
            {
                EquationLatex = @"\nabla \times \vec{F} = \begin{vmatrix} \hat{i} & \hat{j} & \hat{k} \\ \frac{\partial}{\partial x} & \frac{\partial}{\partial y} & \frac{\partial}{\partial z} \\ F_x & F_y & F_z \end{vmatrix}"
            },
            new EquationItem("Stokes' Theorom")
            {
                EquationLatex = @"\int_C \vec{F} \cdot d \vec{r} = \iint_S \nabla \times \vec{F} \cdot d \vec{S}"
            },
            new EquationItem("Matrix Inner Product", 160)
            {
                EquationLatex = @"\vec{u}\cdot \vec{v} \\ = (u_x \ u_y \ u_z) \cdot \begin{pmatrix} v_x \\ v_y \\ v_z \end{pmatrix} \\ \\ = u_x v_x + u_y v_y + u_z v_z"
            },
            new EquationItem("Rotation Matrix (2D)", 100)
            {
                EquationLatex = @"\begin{pmatrix} v'_x \\ v'_y \end{pmatrix} = \begin{pmatrix} cos(\theta) & sin(\theta) \\ -sin(\theta) & cos(\theta) \end{pmatrix} \begin{pmatrix} v_x \\ v_y \end{pmatrix}"
            },
            new EquationItem("Matrix Transpose", 100)
            {
                EquationLatex = @"A \rightarrow A^T  \ \ , \ \ \begin{pmatrix} a_1 & a_2 & a_3 \\ b_1 & b_2 & b_3 \end{pmatrix} \rightarrow \begin{pmatrix} a_1 & b_1 \\ a_2 & b_2 \\ a_3 & b_3 \end{pmatrix}"
            },
            new EquationItem("Complex Conjugate")
            {
                EquationLatex = @"A = \begin{pmatrix} e^{i \theta} & 0 \\ 0 & e^{-i \theta} \end{pmatrix} \rightarrow A^* =  \begin{pmatrix} 0 & e^{-i \theta} \ \\ e^{i \theta} \ & 0 \end{pmatrix}",
            },
            new EquationItem("Hermitian Conjugate")
            {
                EquationLatex = @"A^{\dagger} = (A^*)^T",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Take transpose and complex conjugate}"),
                    new DerivationStep(@"\text{If }A^{\dagger} = A"),
                    new DerivationStep(@"A = \begin{pmatrix} 0 & e^{i \theta} \ \\ e^{-i \theta} & 0 \end{pmatrix} \ , \  A^{\dagger} = \begin{pmatrix} 0 & e^{-i \theta} \\ e^{i \theta} \ & 0  \end{pmatrix}"),
                    new DerivationStep(@"\text{Matrix is Hermitian}"),
                }
            },
            new EquationItem("Eigenvalue Equation")
            {
                EquationLatex = @"Ax = \lambda x",
            },
            new EquationItem("Fourier Transform (forward)")
            {
                EquationLatex = @"F(k) = \frac{1}{\sqrt{2 \pi}} \int_{-\infty}^{\infty} f(t) e^{ikt} \ dt",
            },
            new EquationItem("Fourier Transform (back)")
            {
                EquationLatex = @"F(t) = \frac{1}{\sqrt{2 \pi}} \int_{-\infty}^{\infty} f(k) e^{ikt} \ dk",
            },
        };

        #endregion Public Fields
    }
}