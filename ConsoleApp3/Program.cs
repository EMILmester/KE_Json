using System.Text.Json;

namespace ConsoleApp3
{
    class Adat
    {
        public List<string> nevek { get; set; }
        public List<int> korok { get; set; }
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
        }
    }
}
