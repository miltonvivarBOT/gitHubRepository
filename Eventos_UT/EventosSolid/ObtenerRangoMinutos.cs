using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ObtenerRangoMinutos: ICalculadorRangoEvento
    {
        private readonly ICalculadorRangoBase calculadorRangoBase;
        private ICalculadorRangoEvento _rangoOtroPeriodo;
        #region Constructor
        public ObtenerRangoMinutos(ICalculadorRangoBase calculadorRangoBase)
        {
            this.calculadorRangoBase = calculadorRangoBase;
        }
        #endregion

        #region [Miembros de ICalculadorRangoEvento]
        public DTOEvento CalcularRangoEvento(DateTime fechaEvento)
        {
            int Minutos = 0;
            TimeSpan rangoBase = calculadorRangoBase.CalcularRangoBase(fechaEvento);
            Minutos = ObtenerDiferenciaMinutos(rangoBase);
            if (Minutos > 0)
            {
                DTOEvento dtoEvento = this.GenerarInstanciaDTOEvento(Minutos);
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
        private DTOEvento GenerarInstanciaDTOEvento(int minutos)
        {
            DTOEvento dtoEvento = new DTOEvento
            {
                Diferencia = minutos,
                Periodo = "minutos"
            };
            return dtoEvento;
        }
        private int ObtenerDiferenciaMinutos(TimeSpan rangoBase)
        {
            int Minutos = 0;
            Minutos = Math.Abs(Convert.ToInt32(rangoBase.TotalMinutes));
            return Minutos;
        }
        #endregion
    }
}
