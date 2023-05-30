using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Estudiante> MisEstudiantes { get; set; }
    }
}
