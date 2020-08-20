using System;
using System.Collections.Generic;
using System.Text;

namespace PurePhysicist.Models
{
    [Flags]
    public enum TopicsEnum
    {
        Astrophysics = 0,
        ClassicalMechanics = 1 << 0,
        ElectroMagnetism = 1 << 1,
        FluidDynamics = 1 << 2,
        Mathematics = 1 << 3,
        QuantumPhysics = 1 << 4,
        ThermoDynamics = 1 << 5,
        ModernPhysics = 1 << 6
    }
}
