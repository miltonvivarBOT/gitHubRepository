using EventosSolid.Entidad;
using EventosSolid.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosSolid
{
    public class ProcesadorArchivoTxt:IRecuperarEventos
    {
        private const char Separador = ',';

        #region [Miembros del Manejador]
        public List<Evento> RecuperarEventos(string rutaArchivo)
        {
            List<Evento> lstEventos;
            string[] LineasArchivo = System.IO.File.ReadAllLines(rutaArchivo);
            lstEventos = ProcesarArchivo(LineasArchivo);
            return lstEventos;
        }
        #endregion

        #region [Privados]
        private List<Evento> ProcesarArchivo(string[] LineasArchivo)
        {
            List<Evento> lstEventos = new List<Evento>();
            foreach (string linea in LineasArchivo)
            {
                lstEventos.Add(CrearObjetoEvento(linea));
            }
            return lstEventos;
        }
        private Evento CrearObjetoEvento(string lineaArchivo)
        {
            Evento ObjEvento = new Evento
            {
                NombreEvento = SepararLinea(lineaArchivo, 0),
                FechaEvento = Convert.ToDateTime(SepararLinea(lineaArchivo, 1))
            };
            return ObjEvento;
        }
        private string SepararLinea(string lineaArchivo, int posicion)
        {
            string DatoLinea = "";
            DatoLinea = lineaArchivo.Split(Separador)[posicion];
            return DatoLinea;
        }
        #endregion

    }
}
