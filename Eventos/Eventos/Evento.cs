using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Evento
    {
        private const char Separator = ',';

        public Evento()
        {
        }

        public string ObtenerNombreEvento(string cadenaEvento)
        {
            string nombreEvento;
            nombreEvento = cadenaEvento.Split(Separator)[0].ToString();

            return nombreEvento;

        }
    }
}
