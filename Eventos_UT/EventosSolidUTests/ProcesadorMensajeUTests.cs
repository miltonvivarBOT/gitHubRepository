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
        public void ProcesadorMensajeEventos_VerificarEventoPasado_MensajeEventoPasado()
        {
            //ARRANGE
            Evento evento = new Evento();
            evento.FechaEvento = new DateTime(2020, 02, 05, 12, 00, 00);
            evento.NombreEvento = "Constitución Política";
            DTOEvento dtoEvento = new DTOEvento();
            dtoEvento.Diferencia = 6;
            dtoEvento.Periodo = "horas";
            bool estatusEvento = true;
            var SUT = new ProcesadorMensajes();

            //ACT
            string cadenaMensaje = SUT.ProcesadorMensajeEventos(evento, dtoEvento, estatusEvento);

            //ASSERT
            Assert.AreEqual(expected: cadenaMensaje, actual: "Constitución Política ocurrió hace 6 horas");
        }

        [TestMethod()]
        public void ProcesadorMensajeEventos_VerificarEventoFuturo_MensajeEventoFuturo()
        {
            //ARRANGE
            Evento evento = new Evento();
            evento.FechaEvento = new DateTime(2020, 02, 05, 20, 00, 00);
            evento.NombreEvento = "Constitución Política";
            DTOEvento dtoEvento = new DTOEvento();
            dtoEvento.Diferencia = 1;
            dtoEvento.Periodo = "horas";
            bool estatusEvento = false;
            var SUT = new ProcesadorMensajes();

            //ACT
            string cadenaMensaje = SUT.ProcesadorMensajeEventos(evento, dtoEvento, estatusEvento);

            //ASSERT
            Assert.AreEqual(expected: cadenaMensaje, actual: "Constitución Política ocurrirá en 1 horas");
        }
    }
}