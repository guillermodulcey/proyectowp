using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizate.Models
{
    public class Usuario
    {
        public Oid _id { get; set; }
        public String Login { get; set; }
        public String Contrasenia { get; set; }
    }
}
