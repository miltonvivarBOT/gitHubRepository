using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ObtenerRangoHoras: ICalculadorRangoEvento
    {
        private readonly ICalculadorRangoBase _rangoBase;
        private ICalculadorRangoEvento _rangoOtroPeriodo;

        #region[Constructor]
        public ObtenerRangoHoras(ICalculadorRangoBase rangoBase)
        {
            this._rangoBase = rangoBase;
        }
        #endregion

        #region[Miembros de ICalculadorRangoEvento]
        public DTOEvento CalcularRangoEvento(DateTime fechaEvento)
        {
            int Horas = 0;
            TimeSpan rangoBase = _rangoBase.CalcularRangoBase(fechaEvento);
            Horas = ObtenerDifrenciaHora(rangoBase);
            if (Horas > 0)
            {
                DTOEvento dtoEvento = this.GenerarInstanciaDTOEvento(Horas);
                return dtoEvento;
            }
            else
                return _rangoOtroPeriodo.CalcularRangoEvento(fechaEvento);
        }
        public void CalcularOtroPeriodo(ICalculadorRangoEvento rangoEvento)
        {
            _rangoOtroPeriodo = rangoEvento;
        }
        #endregion

        #region [Privados]
        private int ObtenerDifrenciaHora(TimeSpan rangoBase)
        {
            int Horas = 0;
            Horas = Math.Abs(Convert.ToInt32(rangoBase.TotalHours));
            return Horas;
        }
        private DTOEvento GenerarInstanciaDTOEvento(int horas)
        {
            DTOEvento dtoEvento = new DTOEvento
            {
                Diferencia = horas,
                Periodo = "Horas"
            };
            return dtoEvento;
        }
        #endregion

    }
}
