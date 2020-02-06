using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventosSolid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventosSolid.Interfaces;
using Moq;

namespace EventosSolid.Tests
{
    [TestClass()]
    public class ProcesadorEventosUTests
    {
        [TestMethod()]
        public void ProcesadorEventos_ValidarConstructor_ConstructorCorrecto()
        {
            var DOCIRecuperarEventos = new Mock<IRecuperarEventos>();
            var DOCICalculadorRangoEvento = new Mock<ICalculadorRangoEvento>();
            var DOCIRecuperarEstatusEvento = new Mock<IRecuperarEstatusEvento>();
            var DOCIProcesadorMensajes = new Mock<IProcesadorMensajes>();
            var DOCIImprimirMensajes = new  Mock<IImprimirMensajes>();
            var SUT = new ProcesadorEventos(DOCIRecuperarEventos.Object, DOCICalculadorRangoEvento.Object, DOCIRecuperarEstatusEvento.Object, DOCIProcesadorMensajes.Object, DOCIImprimirMensajes.Object);

            Assert.IsNotNull(SUT);
        }
    }
}