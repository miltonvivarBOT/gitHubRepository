using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ObtenerRangoDias: ICalculadorRangoEvento
    {
        private readonly ICalculadorRangoBase _rangoBase;
        private ICalculadorRangoEvento _rangoOtroPeriodo;

        #region Constructor
        public ObtenerRangoDias(ICalculadorRangoBase rangoBase)
        {
            this._rangoBase = rangoBase;
        }
        #endregion

        #region [Miembros de ICalculadorRangoEvento]
        public DTOEvento CalcularRangoEvento(DateTime fechaEvento)
        {
            int Dias = 0;
            TimeSpan rangoBase = _rangoBase.CalcularRangoBase(fechaEvento);
            Dias = ObtenerDiferenciaDias(rangoBase);
            if (Dias > 0)
            {
                DTOEvento dtoEvento = this.GenerarInstanciaDTOEvento(Dias);
                return dtoEvento;
            }
            else
            {
                return _rangoOtroPeriodo.CalcularRangoEvento(fechaEvento);
            }
        }
        public void CalcularOtroPeriodo(ICalculadorRangoEvento rangoEvento)
        {
            _rangoOtroPeriodo = rangoEvento;
        }
        #endregion

        #region [Privados]
        private DTOEvento GenerarInstanciaDTOEvento(int dias)
        {
            DTOEvento dtoEvento = new DTOEvento
            {
                Diferencia = dias,
                Periodo = "dias"
            };
            return dtoEvento;
        }
        private int ObtenerDiferenciaDias(TimeSpan rangoBase) {
            int Dias = 0;
            Dias = Math.Abs(Convert.ToInt32(Math.Truncate(rangoBase.TotalDays)));
            return Dias;
        }
        #endregion
    }
}
