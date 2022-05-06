using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Handler
{
    public class ManagerHendler : AbstractHandler
    {
        public override string Handle(Spesa richiesta)
        {
            if (richiesta.Importo <= 400)
                return $"Manager";
            else
                return base.Handle(richiesta);
        }
    }
}
