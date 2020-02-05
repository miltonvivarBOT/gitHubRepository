using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ProcesadorMensajes : IProcesadorMensajes
    {
        #region [Miembros de IProcesadorMensajes]
        public string ProcesadorMensajeEventos(Evento evento, DTOEvento dtoEvento, bool estatusEvento)
        {
            string mensaje = "";
            mensaje = string.Format("{0} {1} {2} {3}", evento.NombreEvento, DeterminarMensajeEvento(estatusEvento), dtoEvento.Diferencia.ToString(), dtoEvento.Periodo.ToString());
            return mensaje;
        }
        #endregion

        #region Privados
        private string DeterminarMensajeEvento(bool tipoEvento)
        {
            if (tipoEvento)
            {
                return "ocurrió hace";
            }
            else
            {
                return "ocurrirá en";
            }
        }
        #endregion  
    }
}
