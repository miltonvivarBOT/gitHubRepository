using System;

namespace EventosSolid
{
    public class Principal
    {
        private const string RutaArchivo = "C:\\Proyectos\\EventoFechas.txt";

        public static void Main(string[] args)
        {
            ProcesadorArchivoTxt archivotxt = new ProcesadorArchivoTxt();
            ProcesadorMensajes procesadorMensaje = new ProcesadorMensajes();
            ImprimirMensajeConsola imprimirMensajeConsola = new ImprimirMensajeConsola();
            ObtenerRangoBase rgBase = new ObtenerRangoBase();
            ObtenerRangoMeses mes = new ObtenerRangoMeses(rgBase);
            ObtenerRangoDias dia = new ObtenerRangoDias(rgBase);
            ObtenerRangoHoras horas = new ObtenerRangoHoras(rgBase);
            ObtenerRangoMinutos minutos = new ObtenerRangoMinutos(rgBase);
            ObtenerEstatusEvento estatusEvento = new ObtenerEstatusEvento(rgBase);

            mes.CalcularOtroPeriodo(dia);
            dia.CalcularOtroPeriodo(horas);
            horas.CalcularOtroPeriodo(minutos);

            ProcesadorEventos procesadorEventos = new ProcesadorEventos(archivotxt, mes, estatusEvento, procesadorMensaje, imprimirMensajeConsola);
            procesadorEventos.InciarProcesoEventos(RutaArchivo);

            Console.ReadKey();
        }
    }
}
