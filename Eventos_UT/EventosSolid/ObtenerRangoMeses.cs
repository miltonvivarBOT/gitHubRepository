using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ObtenerRangoMeses : ICalculadorRangoEvento
    {
        private readonly ICalculadorRangoBase _rangoBase;
        private ICalculadorRangoEvento _rangoOtroPeriodo;

        #region [Constructor]
        public ObtenerRangoMeses(ICalculadorRangoBase rangoBase)
        {
            _rangoBase = rangoBase;
        }
        #endregion

        #region[Miembros de ICalculadorRangoEvento]
        public DTOEvento CalcularRangoEvento(DateTime fechaEvento)
        {
            int Meses = 0;
            int Dias = 0;
            TimeSpan DiferenciaBase = _rangoBase.CalcularRangoBase(fechaEvento);
            Dias = ObtenerDiferenciaDias(DiferenciaBase);
            Meses = ObtenerDiferenciaMes(Dias, fechaEvento);

            if (Meses > 0)
            {
                DTOEvento dtoEvento = GenerarInstanciaDTOEvento(Meses);
                return dtoEvento;
            }
            else
            {
                return _rangoOtroPeriodo.CalcularRangoEvento(fechaEvento);
            }
        }
        public void CalcularOtroPeriodo(ICalculadorRangoEvento rangoEvento) {
            _rangoOtroPeriodo = rangoEvento;
        }
        #endregion

        #region [Privados]
        private int ObtenerDiferenciaMes(int DiasBase, DateTime fechaEvento)
        {
            int Meses = 0;
            int DiasMes = 0;
            DiasMes = ObtenerDiasMes(fechaEvento);
            Meses = Math.Abs(Convert.ToInt32(DiasBase / DiasMes));
            return Meses;
        }
        private int ObtenerDiferenciaDias(TimeSpan DiferenciaBase)
        {
            int Dias = 0;
            Dias = Convert.ToInt32(DiferenciaBase.TotalDays);
            return Dias;
        }
        private int ObtenerDiasMes(DateTime fechaEvento)
        {
            int DiasMes = 0;
            DiasMes = DateTime.DaysInMonth(fechaEvento.Year, fechaEvento.Month);
            return DiasMes;
        }
        private DTOEvento GenerarInstanciaDTOEvento(int Diferencia)
        {
            DTOEvento dtoEvento = new DTOEvento
            {
                Diferencia = Diferencia,
                Periodo = "Meses"
            };
            return dtoEvento;
        }
        #endregion
    }
}
