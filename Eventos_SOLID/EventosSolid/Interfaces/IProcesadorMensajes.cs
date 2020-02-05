using EventosSolid.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosSolid.Interfaces
{
    public interface IProcesadorMensajes
    {
        string ProcesadorMensajeEventos(Evento evento, DTOEvento dtoEvento, bool estatusEvento);
    }
}

