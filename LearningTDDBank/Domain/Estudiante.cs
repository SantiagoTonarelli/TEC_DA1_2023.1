﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Curso> MisCursos { get; set; }
    }
}
