using System.Text.Json;

namespace ConsoleApp3
{
    class Adat
    {
        public List<string> nevek { get; set; }
        public List<int> korok { get; set; }
    }

    class Diak
    {
        public String nev { get; set; }
        public List<int> jegyek { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           String fajl = File.ReadAllText("Adat.json", System.Text.Encoding.Latin1);
            Console.WriteLine(fajl);
            Adat adat = JsonSerializer.Deserialize<Adat>(fajl);
            foreach (var nev in adat.nevek)
            {
                Console.WriteLine(nev);
            }
            //első eletkor
            Console.WriteLine($" {adat.nevek[0]} életkor: {adat.korok[0]}");

            //diakok.json
            fajl = File.ReadAllText("diakok.json", System.Text.Encoding.Latin1);
            Console.WriteLine(fajl);
            List<Diak> diakok = JsonSerializer.Deserialize<List<Diak>>(fajl);
            Console.WriteLine("Keresett név:");
            String neve = Console.ReadLine();
            bool megvan = false;
            foreach (var diak in diakok)
            {
                if (diak.nev == neve)
                {
                    Console.WriteLine("Átlag:" + diak.jegyek.Average());
                    megvan = true;
                }
            }
            if(megvan == false)
                Console.WriteLine("Nincs ilyen nevű diák!");
        }
    }
}
