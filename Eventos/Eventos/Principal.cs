using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Principal
    {
        public static void Main(string[] args)
        {
            Archivos ar = new Archivos();
            Evento ev = new Evento();
            Fechas fch = new Fechas();
            Mensajes mj = new Mensajes();

            List<string> lstAarchivos = ar.LeerArchivo(@"C:\Proyectos\EventoFechas.txt");

            string NombreEvento ="";
            string FechaEvento ="";
            bool EstatusEvento=false;
            string Mensaje = "";
            string FormatoEvento = "";
            int Rango = 0;

            foreach (string _evento in lstAarchivos)
            {
                NombreEvento = ev.ObtenerNombreEvento(_evento);
                FechaEvento = fch.ObtenerFechaEvento(_evento);

                Rango = fch.CalcularRango(FechaEvento, out FormatoEvento);
                EstatusEvento = fch.ObtenerEstatusEvento(FechaEvento);
                Mensaje = mj.MensajePantalla(NombreEvento, Rango.ToString(), FormatoEvento, EstatusEvento);

                Console.WriteLine(Mensaje);
            }
            Console.ReadKey();

        }
    }
}
