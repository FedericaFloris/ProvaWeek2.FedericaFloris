using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Handler
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa richiesta)
        {
            if (richiesta.Importo >= 401 && richiesta.Importo <= 1000)
                return $"Operational Manager";
            else
                return base.Handle(richiesta);
        }
    }
}
