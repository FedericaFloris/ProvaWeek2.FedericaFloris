using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek2.FedericaFloris.GestioneSpesa
{
    public class Spesa
    {
        public DateTime DataSpesa { get; set; }

        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public bool Approvata { get; set; }
        public string LvlApprov { get; set; }
        public double ImportoRimborsato { get; set; }
        public double Importo { get; set; }

        public Spesa()
        {

        }

        public Spesa(DateTime dataSpesa,string categoria,string descrizione,bool approvata,string lvlApprov,double importoRimborsato,double importo)
        {
            DataSpesa = dataSpesa;
            Categoria = categoria;
            Descrizione = descrizione;
            Approvata = approvata;
            LvlApprov = lvlApprov;
            ImportoRimborsato = importoRimborsato;
            Importo = importo;
        }

        public string Info() //mi serve per prendere le info dal file spesa e visualizzarle a console
        {
            return $"Data: {DataSpesa.ToShortDateString()} Categoria: {Categoria}  Descrizione: {Descrizione}  Importo:{Importo}";
        }
    }
}
