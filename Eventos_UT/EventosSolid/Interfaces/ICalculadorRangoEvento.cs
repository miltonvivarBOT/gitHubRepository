using EventosSolid.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosSolid.Interfaces
{
    public interface ICalculadorRangoEvento
    {
        DTOEvento CalcularRangoEvento(DateTime fechaEvento);
        void CalcularOtroPeriodo(ICalculadorRangoEvento rangoEvento);
    }
}
