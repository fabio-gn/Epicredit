using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicredit
{
    internal class Epicredit
    {
        private static List<ContoCorrente> contiCorrente = new List<ContoCorrente>();
        private static List<Movimento> listaMovimenti = new List<Movimento>();
        public static void CreaConti()
        {
            ContoCorrente conto1 = new ContoCorrente("Giuseppe", "Cifarelli", new DateTime(2023, 07, 05), 1, 10000);
            ContoCorrente conto2 = new ContoCorrente("Imad", "Mohamed", new DateTime(2023, 02, 04), 2, 5000);
            ContoCorrente conto3 = new ContoCorrente("Fabio", "Giannasi", new DateTime(2022, 04, 12), 3, 10000);
            ContoCorrente conto4 = new ContoCorrente("Federico", "Maso", new DateTime(2021, 10, 23), 4, 7500);
            ContoCorrente conto5 = new ContoCorrente("Francesco", "Lettieri", new DateTime(2022, 03, 17), 5, 15000);
            contiCorrente.Add(conto1);
            contiCorrente.Add(conto2);
            contiCorrente.Add(conto3);
            contiCorrente.Add(conto4);
            contiCorrente.Add(conto5);
        }

        private static string menuPage = "" +
                                                " ------------------EPICREDIT-------------------------\r\n" +
                                                "1) Crea un nuovo conto \r\n" +
                                                "2) Preleva/Versa Denaro \r\n" +
                                                "3) Vedi lista dei movimenti \r\n" +
                                                "4) Vedi i saldi di tutti i contocorrenti \r\n" +
                                                "-------------------------------------------------";

        private static string paginaCreaConto = "----------Crea Conto-----------------";

        private static string paginaMovimenti = "---------------------------------------\r\n" +
                                                " LISTA MOVIMENTI \r\n" +
                                                "--------------------------------------";
        private static string paginaNuovoMovimento = "---------------------------------------------\r\n" +
                                                    "FAI UN MOVIMENTO: \r\n" +
                                                    "---------------------------------------------\r\n" +
                                                    "1)Preleva Denaro \r\n" +
                                                    "2)Versa Denaro";
        private static string paginaSaldi = "---------------------------------------\r\n" +
                                                " LISTA SALDI \r\n" +
                                                "--------------------------------------";

        public static void Home()
        {
            Console.Clear();
            printPage(menuPage);

            try
            {
                int scelta = Convert.ToInt32(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        CreaConto();
                        break;
                    case 2:
                        AddMovimento();
                        break;
                    case 3:
                        PrintListaMoviementi();
                        //PrintContiCorrente();
                        break;
                    case 4:
                        PrintSaldi();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. inserisci numeri da 1 a 4");
                        Home();

                        break;


                }
            }
            catch(Exception ex) 
            {   

                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Home();
            }


        }
        
        private static void printPage(string textPage)
        {
            Console.WriteLine(textPage);
        }
        private static void CreaConto()
        {
            Console.Clear();
            printPage(paginaCreaConto);
            try
            {
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Cognome: ");
                string cognome = Console.ReadLine();

              
                
                

                //crea nuovo conto corrente e aggiungi alla lista statica dei conti corrente
                ContoCorrente nuovoConto = new ContoCorrente(nome, cognome);
                nuovoConto.NrDiConto = contiCorrente.Count + 1;
                contiCorrente.Add(nuovoConto);

                Console.Clear();
                printPage(paginaCreaConto);
                Console.WriteLine("Operazione riuscita con successo. premi invio per continuare");
                Console.ReadLine();
                Home();
                
                //Console.WriteLine();
                //Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); Console.WriteLine("premi invio per tornare alla home");

            }
        }
        private static void AddMovimento()
        {
            Console.Clear();
            printPage(paginaNuovoMovimento);
            try
            {
                int scelta = Convert.ToInt32(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Quanto desideri prelevare?");
                        double denaroPrelevato = Convert.ToDouble( Console.ReadLine());
                        Console.WriteLine("inserisci il numero di conto corrente" );
                        int numeroConto = Convert.ToInt32(Console.ReadLine()); 
                        if (contiCorrente.Count > 0)
                        {
                            foreach(ContoCorrente item in contiCorrente)
                            {
                                if (numeroConto == item.NrDiConto && denaroPrelevato < item.Saldo) {
                                    item.Saldo -= denaroPrelevato;
                                    Movimento nuovoMovimento = new Movimento(numeroConto, denaroPrelevato);
                                    listaMovimenti.Add(nuovoMovimento);
                                }
                                //else
                                //{   
                                //    Console.WriteLine(item.Saldo);
                                //    Console.WriteLine("si è verificato un errore, premi invio per tornare in home");
                                //    Console.ReadLine();
                                //    Home();
                                //}
                            }
                            Console.WriteLine("Operazione avvenuta con successo. premi invio per tornare in home.");
                            Console.ReadLine();
                            Home();
                        }
                        else
                        {
                            Console.WriteLine("Non c'è ancora nessun conto corrente. premi invio e riprova");
                            Console.ReadLine();
                            AddMovimento();

                        }
                        break;
                    case 2:
                        Console.WriteLine("Quanto desideri versare?");
                        double denaroVersato = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inserisci il numero di conto corrente");
                        int numerConto = Convert.ToInt32(Console.ReadLine());
                        foreach (ContoCorrente item in contiCorrente)
                        {
                            if (numerConto == item.NrDiConto)
                            {
                                item.Saldo += denaroVersato;
                                Movimento newMovimento = new Movimento(numerConto, denaroVersato);
                                listaMovimenti.Add(newMovimento);
                            }
                        }
                        Console.WriteLine("Operazione avvenuta con successo. premi invio per tornare in home.");
                        Console.ReadLine();
                        Home();
                        break;
                    default:
                        Console.WriteLine("Scelta non Valida. premi invio e riprova");
                        Console.ReadLine();
                        AddMovimento();
                        break;




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("premi invio per tornare alla home");
                Home();
            }
            

            
        }
        private static void PrintContiCorrente()
        {
            if (contiCorrente.Count == 0)
            {
                Console.WriteLine("Non è ancora stato aperto nessun conto, premi invio per continuare");
            } else
            {
                foreach (ContoCorrente item in contiCorrente)
                {
                    Console.WriteLine($"nome: {item.NomeCorrentista} cognome: {item.CognomeCorrentista} data di apertura: {item.DataDiApertura} numero di conto: {item.NrDiConto}");
                }

            }
            Console.WriteLine("premi invio per tornare in home");
            Console.ReadLine();
            Home();
            
        }
        private static void PrintListaMoviementi()
        {
            Console.Clear();
            printPage(paginaMovimenti);
            foreach(Movimento item in listaMovimenti)
            {
                Console.WriteLine($"N° CONTO: {item.NrConto} MOVIMENTO: {item.MovimentoDenaro}");
            }
            Console.WriteLine("premi invio per tornare in home");
            Console.ReadLine();
            Home();

        }
        private static void PrintSaldi()
        {
            Console.Clear();
            printPage(paginaSaldi);
            foreach(ContoCorrente item in contiCorrente)
            {
                Console.WriteLine($"{item.NrDiConto}) \r\n Nome: {item.NomeCorrentista} \r\n Cognome: {item.CognomeCorrentista}\r\n Saldo: {item.Saldo}\r\n ---------------------------");
            }
            Console.WriteLine("premi invio per tornare in home");
            Console.ReadLine();
            Home();
        }
    }
    
}
