using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventosSolid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EventosSolid.Interfaces;
using EventosSolid.Entidad;

namespace EventosSolid.Tests
{
    [TestClass()]
    public class ProcesadorArchivoTxtUTests
    {
        [TestMethod()]
        public void RecuperarEventos_RecuperarUnEvento_UnEventoEnLista()
        {
            //ARRANGE
            List<Evento> lstEventos;
            string rutaArchivo = "C:\\Proyectos\\EventoFechas.txt";
            var SUT = new ProcesadorArchivoTxt();

            //ACT
            lstEventos = SUT.RecuperarEventos(rutaArchivo);

            //ASSERT
            Assert.AreEqual(1, lstEventos.Count);
        }
    }
}