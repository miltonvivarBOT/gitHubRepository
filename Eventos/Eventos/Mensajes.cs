using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Mensajes
    {
        public Mensajes()
        {
        }

        public string MensajePantalla(string nombreEvento, string rangoEvento, string formatoEvento, bool estatusEvento)
        {
            string mensaje = "";
            if (estatusEvento)
                mensaje = string.Format("{0} ocurrió hace {1} {2}", nombreEvento, rangoEvento, formatoEvento);
            else
                mensaje = string.Format("{0} ocurrirá en {1} {2}", nombreEvento, rangoEvento, formatoEvento);
            return mensaje;
        }

    }
}
