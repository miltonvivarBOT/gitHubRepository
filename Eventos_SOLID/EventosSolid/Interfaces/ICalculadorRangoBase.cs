﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosSolid.Interfaces
{
    public interface ICalculadorRangoBase
    {
        TimeSpan CalcularRangoBase(DateTime fechaEvento);
    }
}
