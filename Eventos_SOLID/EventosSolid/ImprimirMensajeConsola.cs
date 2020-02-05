using EventosSolid.Interfaces;
using System;

namespace EventosSolid
{
    public class ImprimirMensajeConsola: IImprimirMensajes
    {
        #region[Miembros de IImprimirMensajes]
        public void ImprimirMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        #endregion
    }
}
