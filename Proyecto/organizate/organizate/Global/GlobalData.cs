using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizate.Global
{
    public static class GlobalData
    {
        static String usuario = "yolo";
        static public String Usuario {
            get {
                return usuario;
            }
            set {
                usuario = value;
            }
        }
    }
}
