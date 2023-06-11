using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Test
{
    [TestClass]
    public class PersonaLogicTests
    {
        private LogicaPersona logic = new LogicaPersona();

        [TestInitialize]
        public void TestInit()
        {
            logic.Repository.DeleteAll();
        }

        [TestCleanup]
        public void TestClean()
        {
            logic.Repository.DeleteAll();
        }

        [TestMethod]
        public void AgregarPersonaConDireccionTest()
        {
            // Arrange
            Persona persona1 = new Persona { Nombre = "Persona 1" };
            Direccion direccion1 = new Direccion { Calle = "Calle 1", Ciudad = "Ciudad 1" };

            // Act
            logic.AgregarPersonaConDireccion(persona1, direccion1);

            // Assert
            var personas = logic.ObtenerPersonasConDireccion();
            var persona = personas.Count > 0 ? personas.FirstOrDefault() : null;

            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona1.Nombre, persona.Nombre);
        }
    }
}
