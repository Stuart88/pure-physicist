using PurePhysicist.Models;
using System.Collections.Generic;

namespace PurePhysicist.Views.Topics.FluidDynamics
{
    public class Equations
    {
        #region Public Fields

        public static readonly List<EquationItem> EquationsList = new List<EquationItem>
        {
            new EquationItem("Pathlines")
            {
                EquationLatex = @"\frac{d \vec{x}(t)}{dt} = \vec{u}(\vec{x}, t)",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For} x = x_0 \text{ at } t = t_0"),
                    new DerivationStep(@"\text{The physical path a particle}", 30),
                    new DerivationStep(@"\text{will follow in a flow}", 30),
                }
            },
            new EquationItem("Streamlines")
            {
                EquationLatex = @"\frac{d \vec{x}_s}{ds} \times \vec{u}(\vec{x}_s) = 0",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{The contours of the velocity field}", 30),
                    new DerivationStep(@"\text{that represents the movement of}", 30),
                    new DerivationStep(@"\text{a particle in the flow}", 30),
                }
            },
            new EquationItem("Streaklines")
            {
                EquationLatex = @"\frac{d \vec{x}(t_0, t)}{dt} = \vec{u}(\vec{x}(t_0, t), t)",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For} x = x_0 \text{ at } t = t_0"),
                    new DerivationStep(@"\text{The path that would be drawn out}", 30),
                    new DerivationStep(@"\text{if a moving particle were to leave}", 30),
                    new DerivationStep(@"\text{a dot of ink behind at each point}", 30),
                }
            },
            new EquationItem("Lagrangian (Material) Derivative")
            {
                EquationLatex = @"\frac{D\rho}{Dt} = \frac{\partial \rho}{\partial t} + (\vec{u} \cdot \nabla) \rho",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Analogous to } F = ma", 30),
                    new DerivationStep(@"\text{Therefore acceleration of fluid particle is}", 30),
                    new DerivationStep(@"\frac{D\vec{u}}{Dt} = \frac{\partial \vec{u}}{\partial t} + (\vec{u} \cdot \nabla) \vec{u}"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{For steady flow, } \frac{\partial \vec{u}}{\partial t} = 0"),
                    new DerivationStep(@"\text{Therefore rate of change } f \text{ becomes}", 30),
                    new DerivationStep(@"\frac{D f}{Dt} = (\vec{u} \cdot \nabla) f"),
                }
            },
            new EquationItem("The Continuity Equation")
            {
                EquationLatex = @"\frac{\partial \rho}{\partial t} + \nabla \cdot (\rho \vec{u}) = 0",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Use the identity: }", 30),
                    new DerivationStep(@"\nabla \cdot (\rho \vec{u}) = \rho \nabla \cdot \vec{u} + \vec{u} \cdot \nabla \rho"),
                    new DerivationStep(@"\text{to derive Lagrangian form: }", 30),
                    new DerivationStep(@"\frac{D \rho}{D t} + \rho \nabla \cdot \vec{u} = 0"),
                }
            },
            new EquationItem("Incompressible Flow")
            {
                EquationLatex = @"\nabla \cdot \vec{0} = 0",
            },
            new EquationItem("Stream Function")
            {
                EquationLatex = @"S = \psi(x,y,z) \ \hat{e}_z",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"u = \frac{\partial \psi}{\partial y} \ \ \ , \ \  v = -\frac{\partial \psi}{\partial x}"),
                    new DerivationStep(@"\text{Stream function is constant}", 30),
                    new DerivationStep(@"\text{along stream lines}", 30),
                }
            },
            new EquationItem("Stokes Stream Function")
            {
                EquationLatex = @"S = \frac{1}{r} \Psi(r,z,t) \ \hat{e}_{\theta}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"u_z = \frac{1}{r} \frac{\partial \Psi}{\partial r} \ \ \ , \ \  u_r = - \frac{1}{r} \frac{\partial \Psi}{\partial z}"),
                    new DerivationStep(@"\text{Stokes stream function is constant}", 30),
                    new DerivationStep(@"\text{along stream lines}", 30),
                }
            },
            new EquationItem("Vorticity")
            {
                EquationLatex = @"\vec{\omega} = \nabla \times \vec{u}",
            },
            new EquationItem("Stream Function and Vorticity")
            {
                EquationLatex = @"\omega = \ - \frac{\partial^2 \psi}{\partial x^2} - \frac{\partial^2 \psi}{\partial y^2} \ = - \nabla^2 \psi",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For 2D flow, } \frac{\partial \psi}{\partial z} = 0"),
                    new DerivationStep(@"\text{Therefore:}"),
                    new DerivationStep(@"\vec{\omega} = - \nabla^2 \psi \hat{e}_z"),
                }
            },
            new EquationItem("Circulation")
            {
                EquationLatex = @"\Gamma = \oint_c \vec{u} \cdot d \vec{l} = \int_S \vec{\omega} \cdot \vec{n} \ dS",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\Gamma = \text{ circulation rate}"),
                    new DerivationStep(@"\vec{n} = \text{ normal to surface}")
                }
            },
            new EquationItem("Velocity Potential")
            {
                EquationLatex = @"\vec{u} = \nabla \phi",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For incompressible flow:}"),
                    new DerivationStep(@"\nabla^2 \phi = 0")
                }
            },
            new EquationItem("Euler's Equation")
            {
                EquationLatex = @"\rho \ [\ \frac{\partial \vec{u}}{\partial t} + (\vec{u} \cdot \nabla)\vec{u} \ ] = - \nabla p + \rho \vec{g}",
            },
            new EquationItem("Navier-Stokes Equation (incompressible)")
            {
                EquationLatex = @"\rho \ [\ \frac{\partial \vec{u}}{\partial t} + (\vec{u} \cdot \nabla)\vec{u} \ ] = - \nabla p + \rho \vec{g} + \mu \nabla^2 \vec{u}",
            },
            new EquationItem("Hydrostatic Balance")
            {
                EquationLatex = @"\nabla P = \rho \vec{g} \cdot \vec{x} + C",
            },
            new EquationItem("The Vorticity Equation")
            {
                EquationLatex = @"\frac{\partial \vec{\omega}}{\partial t} + (\vec{u} \cdot \nabla) \vec{\omega} \ = \ (\vec{\omega} \cdot \nabla) \vec{u}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{For 2D planar flow:}"),
                    new DerivationStep(@"\frac{\partial \vec{\omega}}{\partial t} + (\vec{u} \cdot \nabla) \vec{\omega} \ = \ 0")
                }
            },
            new EquationItem("Kelvin's Circulation Theorem")
            {
                EquationLatex = @"\frac{d \Gamma}{dt}= \ \frac{d}{dt}\oint_{C(t)} \vec{u} \cdot s \vec{l} \ = 0",
            },
            new EquationItem("The Bernoulli Equation")
            {
                EquationLatex = @"H(x) = \frac{u^2}{2} + g z + \frac{p}{\rho} =  \text{ constant}"
            },
            new EquationItem("Froud Number")
            {
                EquationLatex = @"F = \frac{U}{\sqrt{g H}}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"H = \text{ depth of flow}"),
                    new DerivationStep(@"F < 1 \text{ : Subcritical Flow}"),
                    new DerivationStep(@"F = 1 \text{ : Critical Flow}"),
                    new DerivationStep(@"F > 1 \text{ : Supercritical Flow}"),
                }
            },
            new EquationItem("Kutta-Joukowski Theorem (lift)")
            {
                EquationLatex = @"F = -\rho U \ \Gamma \ , \text{  where  } \Gamma = \oint_C \vec{u} \cdot d \vec{l}"
            },
            new EquationItem("Common Flows")
            {
                EquationLatex = @"\text{See Details}",
                DerivationStepsLatex = new List<DerivationStep>
                {
                    new DerivationStep(@"\text{Uniform Flow}", 35),
                    new DerivationStep(@"\vec{U}(x,y) = (U,0)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Shear Flow}", 35),
                    new DerivationStep(@"\vec{U}(x,y) = (Uy,0)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Stagnation Point Flow}", 35),
                    new DerivationStep(@"\vec{U}(x,y) = (Ux,-Uy)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Flow Past a Sphere}", 35),
                    new DerivationStep(@"\phi(r,z) = Uz \ ( 1 + \frac{a^3}{2(r^2+z^2)^{3/2}} )"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Basic Vortex}", 35),
                    new DerivationStep(@"\vec{U}(r,\theta) = (-U,\Omega)"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Rankine Vortex}", 35),
                    new DerivationStep(@"\text{(a.k.a. Bathplug Vortex)}", 35),
                    new DerivationStep(@" U_r = -U"),
                    new DerivationStep(@" \text{For } r \leq a \ , \  U_{\theta} = \frac{\Omega r}{2}"),
                    new DerivationStep(@" \text{For } r > a \ , \  U_{\theta} = \frac{\Omega a^2}{2r}"),
                    new DerivationStep(@"\underline{\ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ \ }"),
                    new DerivationStep(@"\text{Flow Past a Rotating Cylinder}", 35),
                    new DerivationStep(@"\text{(a.k.a. The Magnus Effect)}", 35),
                    new DerivationStep(@"\phi(r,z) = U ( r + \frac{a^2}{r} cos(\theta) + \frac{\Gamma}{2 \pi} \theta )"),
                    new DerivationStep(@"\Gamma =  \text{cylinder circulation}", 35),
                }
            },
        };

        #endregion Public Fields
    }
}