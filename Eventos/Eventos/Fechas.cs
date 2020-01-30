using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Fechas
    {
        public Fechas()
        {
        }

        public const char Separador = ',';

        public string ObtenerFechaEvento(string cadenaEvento)
        {
            string fechaEvento;
            fechaEvento = cadenaEvento.Split(Separador)[1];
            return fechaEvento;
        }

        public int CalcularRango(string cadenaEvento, out string formatoEvento)
        {
            TimeSpan diferencia;
            diferencia = ObtenerDiferenciaFecha(cadenaEvento);

            int RangoFecha = 0;

            RangoFecha = ObtenerDiferenciaMeses(diferencia);
            if (RangoFecha > 0)
            {
                formatoEvento = "Meses";
                return RangoFecha;
            }
            else {
                RangoFecha = ObtenerDiferenciaDias(diferencia);
                if (RangoFecha > 0)
                {
                    formatoEvento = "Días";
                    return RangoFecha;
                }
                else
                {
                    RangoFecha = ObtenerDiferenciaHoras(diferencia);
                    if (RangoFecha > 0)
                    {
                        formatoEvento = "Horas";
                        return RangoFecha;
                    }
                    else
                    {
                        formatoEvento = "Minutos";
                        RangoFecha = ObtenerDiferenciaMinutos(diferencia);
                        return RangoFecha;
                    }
                }
            }
        }

        public bool ObtenerEstatusEvento(string cadenaEvento)
        {
            if (TipoEvento(cadenaEvento) > 0)
                return true;
            else
                return false;
        }

        public int TipoEvento(string cadenaEvento) {
            int tipoEvento;
            tipoEvento = Convert.ToInt32(ObtenerDiferenciaFecha(cadenaEvento).TotalSeconds);
            return tipoEvento;
        }

        private TimeSpan ObtenerDiferenciaFecha(string cadenaEvento)
        {
            DateTime fechaEvento = Convert.ToDateTime(cadenaEvento);
            DateTime fechaHoy = DateTime.Now;
            TimeSpan diferencia = fechaHoy.Subtract(fechaEvento);
            return diferencia;
        }
        private int ObtenerDiferenciaMeses(TimeSpan diferencia)
        {
            int Meses = 0;
            Meses = Convert.ToInt32(ObtenerDiferenciaDias(diferencia) / 30);
            return Math.Abs(Meses);
        }
        private int ObtenerDiferenciaDias(TimeSpan diferencia)
        {
            int Dias = 0;
            Dias = Convert.ToInt32(diferencia.TotalDays);
            return Math.Abs(Dias);
        }
        private int ObtenerDiferenciaHoras(TimeSpan diferencia)
        {
            int Horas = 0;
            Horas = Convert.ToInt32(Math.Truncate(diferencia.TotalHours));
            return Math.Abs(Horas);
        }
        private int ObtenerDiferenciaMinutos(TimeSpan diferencia)
        {
            int Minutos = 0;
            Minutos = Convert.ToInt32(diferencia.TotalMinutes);
            return Math.Abs(Minutos);
        }
        
    }


}
