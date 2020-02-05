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
    public class ProcesadorMensajeUTests
    {
        [TestMethod()]
        public void ProcesadorMensajeEventos_ProcesarCadena_CadenaMensaje()
        {
            //ARRANGE
            Evento evento = new Evento();
            evento.FechaEvento = new DateTime(2020, 02, 05, 13, 00, 00);
            evento.NombreEvento = "Constitución Política";
            DTOEvento dtoEvento = new DTOEvento();
            dtoEvento.Diferencia = 1;
            dtoEvento.Periodo = "Día";
            bool estatusEvento = true;
            var SUT = new ProcesadorMensajes();

            //ACT
            string cadenaMensaje = SUT.ProcesadorMensajeEventos(evento, dtoEvento, estatusEvento);

            //ASSERT
            Assert.Equals(cadenaMensaje, "");
        }
    }
}