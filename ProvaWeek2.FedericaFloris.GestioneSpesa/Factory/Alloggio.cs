﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Factory
{
    public class Alloggio : ISpesa
    {
        public double CalcolaRimborso(Spesa spesa)
        {
            return spesa.Importo;
        }
    }
}
