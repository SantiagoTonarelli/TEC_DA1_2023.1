using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Direccion
    {
        [ForeignKey("Persona")]
        public int DireccionId { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
