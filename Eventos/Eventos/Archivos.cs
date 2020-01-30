using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Archivos
    {
        public Archivos() {

        }

        public List<string> LeerArchivo(string rutaArchivo)
        {
            string[] Lineas = System.IO.File.ReadAllLines(rutaArchivo);
            return Lineas.ToList();
        }
    }
}
