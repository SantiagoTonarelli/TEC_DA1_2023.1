using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicaPersona
    {
        private readonly IPersonaRepository _repository;

        public LogicaPersona()
        {
            _repository = new PersonaRepository();
        }
        
        public LogicaPersona(IPersonaRepository repository)
        {
            _repository = repository;
        }

        // En esta clase hay errores Que seran vistos y discutidos en clase
        // Correspondientes a las validaciones y el manejo de exepciones 

        public void AgregarPersonaConDireccion(Persona persona, Direccion direccion)
        {
            // Validar que la persona y la dirección no sean nulas
            if (persona == null)
            {
                throw new ArgumentNullException(nameof(persona), "La persona no puede ser nula");
            }

            if (direccion != null)
            {
                // Validar que la dirección tenga valores válidos
                if (string.IsNullOrWhiteSpace(direccion.Calle))
                {
                    throw new ArgumentException("La calle de la dirección no puede estar vacía");
                }

                if (string.IsNullOrWhiteSpace(direccion.Ciudad))
                {
                    throw new ArgumentException("La ciudad de la dirección no puede estar vacía");
                }
            }

            // Agregar la persona con la dirección al repositorio
            _repository.AgregarPersona(persona, direccion);
        }

        public ICollection<Persona> ObtenerPersonasConDireccion()
        {
            return _repository.ObtenerPersonasConDireccion();
        }

        public void EliminarPersona(int personaId)
        {
            // Validar que la persona exista antes de eliminarla
            var persona = _repository.ObtenerPersonasConDireccion().FirstOrDefault(p => p.PersonaId == personaId);
            if (persona == null)
            {
                throw new ArgumentException("La persona no existe");
            }

            _repository.EliminarPersona(personaId);
        }

        public void ModificarPersona(int id, string nombre)
        {
            // Validar que el ID no sea negativo
            if (id <= 0)
            {
                throw new ArgumentException("El ID de la persona debe ser un valor positivo");
            }

            // Validar que el nombre no sea nulo o vacío
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la persona no puede estar vacío");
            }

            // Validar que la persona exista antes de modificarla
            // No es correcto deberian utilizar un existe en el repositorio!!!!!!
            var existingPersona = _repository.ObtenerPersonasConDireccion().FirstOrDefault(p => p.PersonaId == id);
            if (existingPersona == null)
            {
                throw new ArgumentException("La persona no existe");
            }

            _repository.ModificarPersona(id, nombre);
        }

    }

}
