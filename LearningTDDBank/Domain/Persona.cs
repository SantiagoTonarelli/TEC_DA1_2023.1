﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}
