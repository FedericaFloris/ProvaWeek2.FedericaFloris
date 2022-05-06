using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Factory
{
    public class FactorySpesa
    {
        public ISpesa CreateCategoria(string categoria)
        {
            ISpesa spesaMia = null;
            if (categoria == "Viaggio")
                return new Viaggio();
            else if (categoria == "Alloggio")
                return new Alloggio();
            else if (categoria == "Vitto")
                return new Vitto();
            else if (categoria == "Altro")
                return new Altro();
            return spesaMia;
        }
    }
}
