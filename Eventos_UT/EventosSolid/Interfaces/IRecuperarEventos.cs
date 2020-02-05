using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventosSolid.Entidad;

namespace EventosSolid.Interfaces
{
    public interface IRecuperarEventos
    {
        List<Evento> RecuperarEventos(string rutaArchivo);
    }
}
