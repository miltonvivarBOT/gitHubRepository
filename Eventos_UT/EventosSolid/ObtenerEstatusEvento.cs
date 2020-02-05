using EventosSolid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosSolid
{
    public class ObtenerEstatusEvento: IRecuperarEstatusEvento
    {
        private readonly ICalculadorRangoBase _calculadorRangoBase;

        #region [Miembros de IRecuperarEstatusEvento]
        public ObtenerEstatusEvento(ICalculadorRangoBase calculadorRangoBase)
        {
            this._calculadorRangoBase = calculadorRangoBase;
        }
        public bool RecuperarEstatus(DateTime fechaEvento)
        {
            TimeSpan rangoBase = _calculadorRangoBase.CalcularRangoBase(fechaEvento);
            if (rangoBase.TotalMilliseconds > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
