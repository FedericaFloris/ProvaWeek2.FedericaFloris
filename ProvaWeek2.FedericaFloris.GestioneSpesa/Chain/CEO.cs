using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Handler
{
    public class CEO : AbstractHandler
    {
        public override string Handle(Spesa richiesta)
        {
            if (richiesta.Importo > 1000 && richiesta.Importo<2500)
                return $"CEO";
            else
                return base.Handle(richiesta);
        }
    }
}
