using System;
using Mazzoni.Alex._5H.Scaffolding.Models;

namespace Mazzoni.Alex._5H.Scaffolding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("© – Copyright. - Alex Mazzoni ® - All rights reserved - V^H Scaffolding™.\n");


            Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db = new(); //Apro il db
            bool uscire = false; //Variabile che permette all'utente di uscire dal menù premendo "0".
            string vocescelta = "Nessuna voce scelta";
            do
            {
                //Stampa delle voci del menu
                Console.WriteLine("\nMenu\n");
                Console.WriteLine($"Voce precedentemente scelta: {vocescelta}\n");

                Console.WriteLine($"Premere: {0} - Per uscire dal menu");
                Console.WriteLine($"Premere: {1} - Per Aggiungere Un nuovo Elemento nel Db Studente.");
                Console.WriteLine($"Premere: {2} - Per Aggiungere Un nuovo Elemento nel Db Classe.");
                Console.WriteLine($"Premere: {3} - Per Aggiungere Un nuovo Elemento nel Db Studente (input).");
                Console.WriteLine($"Premere: {4} - Per Aggiungere Un nuovo Elemento nel Db Classe (input).");
                Console.WriteLine($"Premere: {5} - Per Cancellare tutti gli elementi del Db Studente.");
                Console.WriteLine($"Premere: {6} - Per Cancellare tutti gli elementi del Db Classe.");
                Console.Write("\n Quale voce vuole selezionare: ");
                vocescelta = Console.ReadLine();//prende la voce
                Console.WriteLine("\n\n");

                Console.Clear();

                switch (vocescelta)
                {
                    case "0":
                        uscire = true;
                        break;
                    case "1":
                        AggiungiStudente(db);
                        break;
                    case "2":
                        AggiungiClasse(db);
                        break;
                    case "3":
                        AggiungiInputStudente(db);//Studente
                        break;
                    case "4":
                        AggiungiInputClasse(db);//Classe
                        break;
                    case "5":
                        EliminaTuttoStudente(db);//Studente
                        break;
                    case "6":
                        EliminaTuttoClasse(db);//Classe
                        break;
                }

            }
            while (!uscire); //Uscire se si(true) esce, senno se no(false) non esce
        
            db.SaveChanges();

        }

        static void AggiungiStudente(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            db.Studentes.Add(new Studente{ Nome="Alex", Cognome="Mazzoni", CodiceFiscale="MZZLXA", FkIdclasse=1 });
            db.SaveChanges();
        }
        static void AggiungiClasse(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            db.Classes.Add(new Classe{ As="21-22", Anno=5, Sezione="H"});
            db.SaveChanges();
        }
        static void AggiungiInputStudente(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            Console.Write("\nInserisci il Nome dello studente: ");
            string nome = Console.ReadLine();
            Console.Write("\nInserisci il Cognome dello studente: ");
            string cognome = Console.ReadLine();
            Console.Write("\nInserisci il Codice Fiscale dello studente: ");
            string CF = Console.ReadLine();
            Console.Write("\nInserisci la classe dello studente: ");
            string c = Console.ReadLine();

            db.Studentes.Add(new Studente{ Nome=nome, Cognome=cognome, CodiceFiscale=CF,FkIdclasse=Convert.ToInt32(c)});
            db.SaveChanges();
        }
        static void AggiungiInputClasse(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            Console.Write("\nInserisci l'anno scolastico della classe: ");
            string a = Console.ReadLine();
            Console.Write("\nInserisci l'anno della classe(da 1 a 5): ");
            string anno = Console.ReadLine();
            Console.Write("\nInserisci la sezione della classe: ");
            string sezione = Console.ReadLine();


            db.Classes.Add(new Classe{ As=a, Anno=Convert.ToInt32(anno), Sezione=sezione});
            db.SaveChanges();
        }
        static void EliminaTuttoStudente(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            db.Studentes.RemoveRange(db.Studentes);
            db.SaveChanges();
        }
        
        static void EliminaTuttoClasse(Mazzoni.Alex._5H.Scaffolding.Models.StudentiClassi db)
        {
            db.Classes.RemoveRange(db.Classes);
            db.SaveChanges();
        }
    }
}
