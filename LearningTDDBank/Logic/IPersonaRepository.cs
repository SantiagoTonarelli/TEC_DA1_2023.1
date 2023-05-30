using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IPersonaRepository
    {
        void AgregarPersona(Persona persona, Direccion direccion);
        ICollection<Persona> ObtenerPersonasConDireccion();
        void EliminarPersona(int personaId);
        void ModificarPersona(int personaId, string nombre);
        void ModificarPersonaOtraOpcion(Persona persona);
    }
}
