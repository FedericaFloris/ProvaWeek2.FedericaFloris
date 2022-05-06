using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa.Handler
{
    public interface IHandler
    {
        //Serve per settare l anello successivo della catena
        IHandler SetNext(IHandler handler);

        //Mi serve per gestire la richiesta
        string Handle(Spesa richiesta);
    }
}
