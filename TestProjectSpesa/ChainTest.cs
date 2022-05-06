using ProvaWeek2.FedericaFloris.GestioneSpesa;
using System;
using Xunit;

namespace TestProjectSpesa
{
    public class ChainTest
    {
        [Fact]
        public void ShouldHaveImporto500AndLvLOPS()
        {
            Spesa spesa = new Spesa()
            {
                DataSpesa = new DateTime(2020, 8, 5),
                Categoria = "Viaggio",
                Descrizione = "Aereo",
                Approvata = true,
                LvlApprov = "Operational Manager",
                ImportoRimborsato = 550,
                Importo = 500
            };

            IHandler 

        }
    }
}