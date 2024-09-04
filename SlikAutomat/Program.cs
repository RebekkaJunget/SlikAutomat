namespace SlikAutomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Automat automat = new Automat();

            bool kører = true;
            while(kører)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Velkommen! Vælg en mulighed:");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Vis produkter");
                Console.WriteLine("2. Køb et produkt");
                Console.WriteLine("3. Tilføj et produkt");
                Console.WriteLine("4. Afslut");

                string valg = Console.ReadLine();   

                switch (valg) 
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine(">>");
                        automat.VisProdukter();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine(">>");
                        automat.VisProdukter();
                        Console.WriteLine();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Indtast produktnúmmer:");

                        int produktNummer = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Indtast beløb");
                        decimal beløb = decimal.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("----------------------");
                        automat.KøbProdukt(produktNummer, beløb);
                        break;
                    case "3":
                        Console.WriteLine("------------------------");
                        Console.WriteLine("**Enter kode til admin**");
                        Console.WriteLine("------------------------");
                        int kode = int.Parse(Console.ReadLine());

                        if (kode == 1234)
                        {
                            Console.WriteLine();
                            Console.WriteLine(">>");
                            automat.VisProdukter();
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Indtast produktnummer:");
                            int nytProduktNummer = int.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Indtast antal:");
                            int antal = int.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------");
                            automat.TilføjProdukt(nytProduktNummer, antal);
                        }
                        else
                        { Console.WriteLine("**Forkert kode. Prøv igen**"); }
                        break;
                    case "4":
                        kører = false;
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("Tak for at bruge automaten!");
                        Console.WriteLine("---------------------------");
                        break;
                    default:
                        Console.WriteLine("**Ugyldigt valg, prøv igen.**");
                        break;

                }

            }
        }
    }
}
