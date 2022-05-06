// See https://aka.ms/new-console-template for more information
using ProvaWeek2.FedericaFloris.GestioneSpesa;
using ProvaWeek2.FedericaFloris.GestioneSpesa.Factory;
using ProvaWeek2.FedericaFloris.GestioneSpesa.Handler;

Console.WriteLine("====Gestione Spesa====");

List<Spesa> listaDaFile = LeggiDaFile();
if (listaDaFile.Count == 0)  //Controllo se il file è vuoto 
{
    Console.WriteLine("Non c'è nulla nel file");
}
else
{
    foreach(var item in listaDaFile)
    {
        Console.WriteLine(item.Info()); //faccio apparire a console tutto quello che ho nella mia lista

        //CHAIN

        IHandler manager = new ManagerHendler();
        IHandler operationalManager = new OperationalManagerHandler();
        IHandler ceo = new CEO();

        manager.SetNext(operationalManager).SetNext(ceo);

       
      //Se quello che restituisce è nullo vuol dire che nessuno ha saputo gestire la mia richiesta ossia ho una spesa >2500  
            if (manager.Handle(item) == null)
            {
                item.LvlApprov = null;
                item.Approvata = false;
                Console.WriteLine($"Spesa non approvata, il suo importo supera i 2500 euro ");

      //SCRIVO SU UN FILE spesa_elaborate.txt

                SriviDaFile(item);



            }
            else //se la mia spesa non supera i 2500
            {
                item.LvlApprov = manager.Handle(item); //salvo in item.LvLApprov il return della mia chain
                item.Approvata = true;

                Console.WriteLine($"Spesa approvata, livello di approvazione {manager.Handle(item)} ");

            //FACTORY
            //solo per la spesa approvata come richiesto

                FactorySpesa spesa = new FactorySpesa();
                ISpesa categoria = spesa.CreateCategoria(item.Categoria);
                item.ImportoRimborsato = categoria.CalcolaRimborso(item); //salvo in item.ImportoRimborsato il rimborso calcolato

            //SCRIVO SU UN FILE spesa_elaborate.txt


            SriviDaFile(item);

            }
        
        Console.WriteLine("-------------------------------------");
    }
}








 void SriviDaFile(Spesa spesa)
{
    string path = @"C:\Users\federica.floris\Desktop\ProvaWeek2.FedericaFloris\ProvaWeek2.FedericaFloris.GestioneSpesa\spesa_elaborate.txt";

    using (StreamWriter sw = new StreamWriter(path, true))
    {
        if (spesa.Approvata == true)
            sw.WriteLine($"{spesa.DataSpesa.ToShortDateString()};{spesa.Categoria};{spesa.Descrizione};APPROVATA;{spesa.LvlApprov};{spesa.ImportoRimborsato}");
        else
            sw.WriteLine($"{spesa.DataSpesa.ToShortDateString()};{spesa.Categoria};{spesa.Descrizione};RESPINTA;-;-");
    }
   
}
List<Spesa> LeggiDaFile()
{
    string path = @"C:\Users\federica.floris\Desktop\ProvaWeek2.FedericaFloris\ProvaWeek2.FedericaFloris.GestioneSpesa\spesa.txt";


    List<Spesa> listaRecuperata = new List<Spesa>();

    using (StreamReader sr = new StreamReader(path))
    {
        string contenutoFile = sr.ReadToEnd();
        if (string.IsNullOrEmpty(contenutoFile))
        {
            return new List<Spesa>();
        }
        else
        {
            var righeDelFile = contenutoFile.Split("\r\n");
            for (int i = 0; i < righeDelFile.Length - 1; i++)
            {
                //spilto la singola riga del mio file
                var campiDellaRiga = righeDelFile[i].Split(";");
                
                Spesa s = new Spesa();
                s.DataSpesa = DateTime.Parse(campiDellaRiga[0]);
                s.Categoria = campiDellaRiga[1];
                s.Descrizione = campiDellaRiga[2];
                s.Importo = double.Parse(campiDellaRiga[3]);
                listaRecuperata.Add(s);
                
            }
        }
        return listaRecuperata;
    }
}
