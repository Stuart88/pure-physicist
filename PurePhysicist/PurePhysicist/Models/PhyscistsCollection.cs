using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace PurePhysicist.Models
{
    public static class PhyscistsCollection
    {
        public static List<Physicist> Physicists = new List<Physicist>
        {
            new Physicist("Isaac Newton", "isaacnewton.jpg", "Laws of Motion, Law of Gravitation, Calculus",
                TopicsEnum.Astrophysics & TopicsEnum.ClassicalMechanics & TopicsEnum.Mathematics),

            new Physicist("Niels Borh", "nielsbohr.jpg", "Atomic Structure, Quantum Theory", 
                TopicsEnum.QuantumPhysics),

            new Physicist("Albert Einstein", "alberteinstein.jpg", "Relativity, Photoelectric Effect", 
                TopicsEnum.ModernPhysics & TopicsEnum.QuantumPhysics),

            new Physicist("Enrico Fermi", "enricofermi.jpg", "Nuclear Physics, Fermi Paradox", 
                TopicsEnum.QuantumPhysics & TopicsEnum.ModernPhysics),

            new Physicist("Richard Feynman", "richardfeynman.jpg", "Quantum Electrodynamics, Feynman Lectures", 
                TopicsEnum.QuantumPhysics),

            new Physicist("Galileo Galilei", "galileo.jpg", "\"The Father of Modern Science\"", 
                TopicsEnum.Astrophysics & TopicsEnum.ClassicalMechanics & TopicsEnum.Mathematics),

            new Physicist("Paul Dirac", "pauldirac.jpg", "Quantum Mechanics, Quantum Electrodynamics", 
                TopicsEnum.QuantumPhysics & TopicsEnum.ModernPhysics),

            new Physicist("James Clerk Maxwell", "jamesclerkmaxwell.jpg", "The Maxwell Equations",
                TopicsEnum.ElectroMagnetism),

            new Physicist("Ernest Rutherford", "ernestrutherford.jpg", "\"The Father of Nuclear Physics\"", 
                TopicsEnum.ModernPhysics),

            new Physicist("Erwin Schrodinger", "erwinschrodinger.jpg", "The Schrodinger Equation", 
                TopicsEnum.QuantumPhysics),

            new Physicist("Marie Curie", "mariecurie.jpg", "Radioactivity", 
                TopicsEnum.ModernPhysics),

            new Physicist("Werner Heisenberg", "wernerheisenberg.jpg", "Heisenberg Uncertainty Principle", 
                TopicsEnum.ModernPhysics & TopicsEnum.QuantumPhysics),

            new Physicist("Stephen Hawking", "stephenhawking.jpg", "Theoretical Cosmology", 
                TopicsEnum.Astrophysics),

            new Physicist("Max Planck", "maxplanck.jpg", "Quantisation of Energy", 
                TopicsEnum.QuantumPhysics),

            new Physicist("Michael Faraday", "michaelfaraday.jpg", "Electromagnetic Induction, Diamagnetism, Electrolysis", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("Enrico Fermi", "enricofermi.jpg", "\"The Architect of the Nuclear Age\", First Nuclear Reactor, The Fermi Paradox", 
                TopicsEnum.ModernPhysics & TopicsEnum.QuantumPhysics),

            new Physicist("Wolfgang Pauli", "wolfgangpauli.jpg", "Pauli Exclusion Principle", 
                TopicsEnum.QuantumPhysics),

            new Physicist("J. J. Thompson", "jjthompson.jpg" ,"Discovery of the Electron", 
                TopicsEnum.ModernPhysics),

            new Physicist("Robert Oppenheimer", "robertoppenheimer.jpg", "\"The Father of the Atomic Bomb\"", 
                TopicsEnum.ModernPhysics),

            new Physicist("Murray Gell-Mann", "murraygelman.jpg", "Theory of Elementary Particles", 
                TopicsEnum.ModernPhysics),

            new Physicist("James Chadwick", "jameschadwick.jpg", "Discovery of the Neutron", 
                TopicsEnum.ModernPhysics),

            new Physicist("Wilhelm Röntgen", "wilhelmdontgen.jpg", "Nobel Prize for Detection of X-Rays", 
                TopicsEnum.ModernPhysics),

            new Physicist("William Thompson (Lord Kelvin)", "williamthompson.jpg", "Definition of the Kelvin", 
                TopicsEnum.ThermoDynamics),

            new Physicist("Louis de Broglie", "louisdebroglie.jpg", "Wave-Particle Duality", 
                TopicsEnum.ThermoDynamics),

            new Physicist("Carl Sagan", "carlsagan.jpg", "Planetary Science, Cosmology, Science Communication", 
                TopicsEnum.Astrophysics),

            new Physicist("Ludwig Boltzmann", "ludwigboltzmann.jpg", "Statistical Mechanics", 
                TopicsEnum.ClassicalMechanics & TopicsEnum.ThermoDynamics),

            new Physicist("Pierre Curie", "pierrecurie.jpg", "Crystallography, Piezoelectricity, Radioactivity", 
                TopicsEnum.ModernPhysics),

            new Physicist("Antoine Henri Becquerel", "becquerel.jpg", "Discvoery of Radioactivity", 
                TopicsEnum.ModernPhysics),

            new Physicist("Sheldon Lee Glashow", "sheldonleeglashow.jpg", "Electroweak Unification Theory, The Charm Quark", 
                TopicsEnum.ModernPhysics),

            new Physicist("Max Born", "maxborn.jpg", "Quantum Mechanics, Solid State Physics", 
                TopicsEnum.ModernPhysics),

            new Physicist("Hendrik Lorentz", "hendriklorentz.jpg", "Special Theory of Relativity, Zeeman Effect", TopicsEnum.ModernPhysics),

            new Physicist("Abdus Salam", "abdussalam.jpg", "Electroweak Unification Theory",
                TopicsEnum.ModernPhysics),

            new Physicist("Hans Bethe", "hansbethe.jpg", "stellar nucleosynthesis", 
                TopicsEnum.Astrophysics),

            new Physicist("Carl Friedrich Gauss", "gauss.jpg", "Mathematics, Astronomy", 
                TopicsEnum.Mathematics & TopicsEnum.Astrophysics),

            new Physicist("Arthur Compton", "arthurcompton.jpg", "The Compton Effect", 
                TopicsEnum.ModernPhysics),

            new Physicist("Robert Hooke", "roberthooke.jpg", "Early Astronomy, Hooke's Law", 
                TopicsEnum.Astrophysics & TopicsEnum.ClassicalMechanics),

            new Physicist("Christiaan Huygens", "christiaanhuygens.jpg", "Mathematics, Probability Theory, Early Physics", 
                TopicsEnum.Astrophysics & TopicsEnum.ClassicalMechanics & TopicsEnum.Mathematics),

            new Physicist("Guglielmo Marconi", "guglielmomarconi.jpg", "Long Distance Radio Transmission, Marconi's Law", 
                TopicsEnum.ModernPhysics),

            new Physicist("Steven Weinberg", "stevenweinberg.jpg", "Electroweak Unification Theory", 
                TopicsEnum.ModernPhysics),

            new Physicist("André-Marie Ampère", "andremarieampere.jpg", "Early Electrodynamics, The Ampere Unit of Measurement", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("John Cockroft", "johncockroft.jpg", "Splitting the Atom, Nuclear Energy", 
                TopicsEnum.ModernPhysics),

            new Physicist("George Ohm", "georgeohm.jpg", "Early electrodynamics, The Ohm unit of Measurement", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("Heinrich Hertz", "heinrichhertz.jpg", "First Conclusive Demonstration of Electromagnetic Waves, The Hertz Unit of Measurement", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("Charles H. Townes", "charlestownes.jpg", "The Laser, The Maser", 
                TopicsEnum.ModernPhysics & TopicsEnum.QuantumPhysics),

            new Physicist("Ernest Walton", "ernestwalton.jpg", "Splitting the Atom", 
                TopicsEnum.ModernPhysics),

            new Physicist("Hermann von Helmholtz", "hermannvonhelmholtz.jpg", "Conservation of Energy, Thermodynamics", 
                TopicsEnum.ThermoDynamics),

            new Physicist("John Bardeen", "johnbardeen.jpg", "Invention of the Transistor, Superconductivity (BCS Theory)", 
                TopicsEnum.ModernPhysics),

            new Physicist("George Gamov", "georgegamov.jpg", "Big Bang Theory", 
                TopicsEnum.Astrophysics),

            new Physicist("Leonhard Euler", "leonhardeuler.jpg", "Euler's Number, Euler's Identity", 
                TopicsEnum.Mathematics),

            new Physicist("Nikola Tesla", "nikolatesla.jpg", "Alternating Current, The Tesla Unit of Measurement", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("Henry Cavendish", "henrycavendish.jpg", "Early Electromagnetism", 
                TopicsEnum.ElectroMagnetism),

            new Physicist("Subrahmanyan Chandrasekhar", "subrahmanyanchandrasekhar.jpg", "Stellar Evolution, The Chandrasekhar Limit", 
                TopicsEnum.Astrophysics),

            new Physicist("Emmy Noether", "emmynoether.jpg", "Abstract Algebra, Noether's Theorem", 
                TopicsEnum.Mathematics & TopicsEnum.ClassicalMechanics),

            new Physicist("Peter Higgs", "peterhiggs.jpg", "The Higgs Particle", 
                TopicsEnum.ModernPhysics),

            new Physicist("C. V. Raman", "cvraman.jpg", "Light Scattering", 
                TopicsEnum.ModernPhysics),

            new Physicist("Satyendra Nath Bose", "satyendrabose.jpg", "Bose-Einstein Statistics", 
                TopicsEnum.QuantumPhysics),

            new Physicist("Daniel Bernoulli", "danielbernoulli.jpg", "The Bernoulli Equation", 
                TopicsEnum.FluidDynamics),

            new Physicist("Saint-Venant", "saintvenant.jpg", "The Shallow Water Equations", 
                TopicsEnum.FluidDynamics),

            new Physicist("Joseph Valentin Boussinesq", "josephboussinesq.jpg", "The Boussinesq Approximation for Water Waves", 
                TopicsEnum.FluidDynamics),

            new Physicist("George Stokes", "georgestokes.jpg", "Mathematics, Fluid Dynamics, The Navier-Stokes Equations", 
                TopicsEnum.FluidDynamics),

            new Physicist("Claude-Louis Navier", "navier.jpg", "Continuum Mechanics, The Navier-Stokes Equations", 
                TopicsEnum.FluidDynamics)

        };
    }
}
