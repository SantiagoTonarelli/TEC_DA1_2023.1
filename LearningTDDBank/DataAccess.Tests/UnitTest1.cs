﻿using Domain;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Tests
{
    [TestClass]
    public class RepositoryPersona
    {
        private IPersonaRepository _repository;

        [TestInitialize]
        public void TestInit()
        {
            _repository = new PersonaRepository();
            _repository.DeleteAll();
        }

        [TestCleanup]
        public void TestClean()
        {
            _repository = new PersonaRepository();
            _repository.DeleteAll();
        }

        [TestMethod]
        public void AgregarPersonaConDireccion()
        {
            // Arrange
            var persona = new Persona() { Nombre = "Persona 1" };
            var direccion = new Direccion() { Calle = "Calle 1", Ciudad = "Ciudad 1" };

            // Act
            _repository.AgregarPersona(persona, direccion);

            // Assert
            var personasConDireccion = _repository.ObtenerPersonasConDireccion(); ;
            var personaResultante = personasConDireccion.First();
            //MUCHOS EQUALS, QUE SE DEBERIA HACER?
            Assert.AreEqual(1, personasConDireccion.Count);
            Assert.AreEqual(persona.PersonaId, personaResultante.PersonaId);
            Assert.AreEqual(persona.Nombre, personaResultante.Nombre);
            Assert.AreEqual(direccion.Calle, personaResultante.Direccion.Calle);
            Assert.AreEqual(direccion.Ciudad, personaResultante.Direccion.Ciudad);
        }

        [TestMethod]
        public void AgregarPersonaConDireccion2()
        {
            // Arrange
            var persona = new Persona() { Nombre = "Persona 1" };
            var direccion = new Direccion() { Calle = "Calle 1", Ciudad = "Ciudad 1" };

            // Act
            _repository.AgregarPersona(persona, direccion);

            // Assert
            var personasConDireccion = _repository.ObtenerPersonasConDireccion();
            var personaResultante = personasConDireccion.First();
            //MUCHOS EQUALS, QUE SE DEBERIA HACER?
            Assert.AreEqual(1, personasConDireccion.Count);
            Assert.AreEqual(persona.PersonaId, personaResultante.PersonaId);
            Assert.AreEqual(persona.Nombre, personaResultante.Nombre);
            Assert.AreEqual(direccion.Calle, personaResultante.Direccion.Calle);
            Assert.AreEqual(direccion.Ciudad, personaResultante.Direccion.Ciudad);
        }
    }
}
