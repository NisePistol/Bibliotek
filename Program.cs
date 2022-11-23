using System;
using System.Collections.Generic;

namespace Bibliotek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registrera boklån!");

            // Lista med boklån
            List<Boklån> listaLån = new List<Boklån>();

            // Programloop
            while (true)
            {
                Console.Write("Bok: ");
                string bokNamn = Console.ReadLine();

                Console.Write("Låntagare: ");
                string låntagarensNamn = Console.ReadLine();

                // Skapa ett nytt lån
                Boklån lån = new Boklån(bokNamn, låntagarensNamn);
                lån.datum = DateTime.Now;

                // Lägg till lånet i listan
                listaLån.Add(lån);

                //Avsluta inmatning
                Console.WriteLine("Vill du mata in ett till lån? (j/n)");
                string svar = Console.ReadLine().ToLower();
                if (svar == "n")
                {
                    break;
                }
            }

            //Skriv ut alla boklån
            foreach (var lån in listaLån)
            {
                lån.SkrivUt();
            }
        }
    }

    class Boklån
    {
        //Klassens interna variabler
        public string bok;
        public string låntagare;
        public DateTime datum;

        public Boklån(string bokIn, string låntagareIn)
        {
            bok = bokIn;
            låntagare = låntagareIn;
        }

        //Klassens metoder
        //När ska boken lämnas tillbaka?
        public DateTime LämnasTillbaka()
        {
            return datum.AddDays(30);
        }

        //Antal dagar på lånet
        public int DagarKvar()
        {
            return (int)(LämnasTillbaka() - DateTime.Now).TotalDays;
        }

        public void SkrivUt()
        {
            Console.WriteLine("Bokens namn: " + bok);
            Console.WriteLine("Lånetagre: " + låntagare);

            //När ska boken lämnas tillbaka (30 dagar)
            Console.WriteLine("Datum att lämna tillbaka: " + LämnasTillbaka());
            Console.WriteLine(DagarKvar() + " dagar kvar till boken måste lämnas in");
        }

        // Förläng lånet med 30 dagar
        public void FörlängLån()
        {
            datum = datum.AddDays(30);
        }
    }
}
