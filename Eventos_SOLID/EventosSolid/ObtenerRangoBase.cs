using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ObtenerRangoBase: ICalculadorRangoBase
    {
        #region [Miembros de ICalculadorRangoBase]
        public TimeSpan CalcularRangoBase(DateTime fechaEvento)
        {
            DateTime fechaHoy = DateTime.Now;
            TimeSpan rangoBase = fechaHoy.Subtract(fechaEvento);
            return rangoBase;
        }
        #endregion
    }
}
