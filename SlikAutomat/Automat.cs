using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlikAutomat
{
    internal class Automat
    {
        //Bruger dictionary til at holde produkterne, deres antal og priser
        private Dictionary<int, (string navn, int antal, decimal pris)> produkter = new Dictionary<int, (string, int, decimal)>()
        {
            {1, ("Cola", 10, 15.0m) }, // Giver hver produkt et produktnummer som skal bruges i automaten
                                       // 10 colaer til 15 kroner 
            {2, ("Chokoladebar", 10, 10.0m) },
            {3, ("Chips", 10, 12.5m) }
        };

       
        //Metode til at vise tilgængelige produkter (Kun navn og pris)
        public void VisProdukter()
        {
            Console.WriteLine("Tilgængelige produkter: ");
            foreach (var produkt in produkter)
            {
                Console.WriteLine($"{produkt.Key}. {produkt.Value.navn} - Pris: {produkt.Value.pris} kr.");
            }
        }

        //Metode til køb af produkter (kun produktnummer, navn og pris)
        public void KøbProdukt(int produktNummer, decimal betaltBeløb)
        {
            if (produkter.ContainsKey(produktNummer)) //hvis det valgte nummer indeholder et produkt 
            {
                var (navn, antal, pris) = produkter[produktNummer];

                if (antal > 0)
                {
                    if (betaltBeløb >= pris) 
                    {
                        decimal byttepenge = betaltBeløb - pris;
                        produkter[produktNummer] = (navn, antal - 1, pris); //Reducer antalet af produkter med 1. 
                        Console.WriteLine($"Du har købt en {navn}. Byttepenge: {byttepenge} kr.");
                    }
                    else
                    {
                        Console.WriteLine($"Ikke nok penge. {navn} koster {pris} kr.");
                        decimal rest = pris - betaltBeløb;
                        Console.WriteLine($"Du mangler {rest} kr.");
                    }
                }
                else
                {
                    Console.WriteLine($"Produktet {navn} er udsolgt.");

                }
                
            }
            else
            {
                Console.WriteLine("Ugyldigt nummer.");
            }
        }

        //Metode til at tilføje flere produkter 
        public void TilføjProdukt(int produktNummer, int antal)
        {
            
            


                if (produkter.ContainsKey(produktNummer))
                {
                    var (navn, eksisterendeAntal, eksisterendePris) = produkter[produktNummer]; //Antal nye produkter tilføjes til dictionaryen

                    //Sprøger brugern om de ønsker at ændre prisen 
                    Console.WriteLine($"Nuværende pris for {navn} er {eksisterendePris} kr. Vil du ændre prisen? (JA/NEJ)");

                    string svar = Console.ReadLine();
                    svar = svar.ToUpper();

                    decimal nyPris = eksisterendePris; //Standard ved ændring af eksisterende pris

                    if (svar == "JA") //nyPris bliver kun aktiveret hvis brugern svare ja!
                    {
                        Console.WriteLine("Indtast pris:");
                        nyPris = decimal.Parse(Console.ReadLine());
                        produkter[produktNummer] = (navn, eksisterendeAntal + antal, nyPris);
                        Console.WriteLine($"Prisen for {navn} er nu {nyPris} kr.");
                    }
                    else
                    {
                        produkter[produktNummer] = (navn, eksisterendeAntal + antal, eksisterendePris);
                        Console.WriteLine($"{antal} stk {navn} er blevet tilføjet til automaten.");
                    }
                }
                else
                {
                    Console.WriteLine(" Ugyldigt produktnummer.");
                }
           

            
        }

        // *Fremtidige metoder*

        // - Admin adgang 
        // - Status på produktantal metode : Bool kode = true / kode == 1234;
        // - status på omsætning metode 
    }

   
}
