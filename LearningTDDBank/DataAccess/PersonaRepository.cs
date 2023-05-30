using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly MiDbContext _contexto;

        public PersonaRepository(MiDbContext contexto)
        {
            _contexto = contexto;
        }

        public void AgregarPersona(Persona persona, Direccion direccion)
        {
            persona.Direccion = direccion;
            _contexto.Personas.Add(persona);
            _contexto.SaveChanges();
        }

        public ICollection<Persona> ObtenerPersonasConDireccion()
        {
            return _contexto.Personas.Include("Direccion").ToList();
        }

        public void EliminarPersona(int personaId)
        {
            var persona = _contexto.Personas.FirstOrDefault(p => p.PersonaId == personaId);
            if (persona != null)
            {
                _contexto.Personas.Remove(persona);
                _contexto.SaveChanges();
            }
        }

        public void ModificarPersona(int personaId, string nombre)
        {
            var persona = _contexto.Personas.SingleOrDefault(p => p.PersonaId == personaId);
            if (persona != null)
            {
                persona.Nombre = nombre;
                _contexto.SaveChanges();
            }
        }

        public void ModificarPersonaOtraOpcion(Persona persona)
        {
            _contexto.Entry(persona).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }
}
