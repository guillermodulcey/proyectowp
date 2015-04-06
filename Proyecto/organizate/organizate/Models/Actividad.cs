using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizate.Models
{
    public class Actividad
    {
        public Oid _id { get; set; }
        public String Usuario { get; set; }
        public String Nombre { get; set; }        
        public String HoraInicio { get; set; }
        public String HoraFin { get; set; }
        public String Fecha { get; set; }
    }
}
