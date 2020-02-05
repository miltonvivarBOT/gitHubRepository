using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ProcesadorEventos
    {
        private readonly IRecuperarEventos _recuperarEventos;
        private readonly ICalculadorRangoEvento _calculadorRangoEvento;
        private readonly IRecuperarEstatusEvento _recuperarEstatusEvento;
        private readonly IProcesadorMensajes _procesadorMensaje;
        private readonly IImprimirMensajes _imprimirMensajes;
        
        #region [Constructor]
        public ProcesadorEventos(IRecuperarEventos recuperarEventos, ICalculadorRangoEvento calculadorRangoEvento,
                                    IRecuperarEstatusEvento recuperarEstatusEvento, IProcesadorMensajes procesadorMensaje,
                                        IImprimirMensajes imprimirMensajes)
        {
            this._recuperarEventos = recuperarEventos;
            this._calculadorRangoEvento = calculadorRangoEvento;
            this._recuperarEstatusEvento = recuperarEstatusEvento;
            this._procesadorMensaje = procesadorMensaje;
            this._imprimirMensajes = imprimirMensajes;
        }
        #endregion

        #region [Principales]
        public void InciarProcesoEventos(string rutaArchivo)
        {
            var Eventos = _recuperarEventos.RecuperarEventos(rutaArchivo);
            foreach (var evento in Eventos)
            {
                var DTOEvento = _calculadorRangoEvento.CalcularRangoEvento(evento.FechaEvento);
                var estatusEvento = _recuperarEstatusEvento.RecuperarEstatus(evento.FechaEvento);
                var mensaje = _procesadorMensaje.ProcesadorMensajeEventos(evento,DTOEvento, estatusEvento);

                _imprimirMensajes.ImprimirMensaje(mensaje);
            }
        }
        #endregion
    }
}
