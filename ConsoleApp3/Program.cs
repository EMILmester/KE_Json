using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp3
{
    class Adat
    {
        public List<string> nevek { get; set; }
        public List<int> korok { get; set; }
    }

    class Diak
    {
        [JsonPropertyName("nev")]
        public string nev { get; set; }

        public List<int> jegyek { get; set; }
    }

    class Munkavallalo
    {
        public string nev { get; set; }
        public int fizetes { get; set; }
        public bool jogositvany { get; set; }
        public string munkarend { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Adat.json ---
            string fajl = File.ReadAllText("Adat.json", System.Text.Encoding.Latin1);
            Adat adat = JsonSerializer.Deserialize<Adat>(fajl);

            foreach (var nev in adat.nevek)
                Console.WriteLine(nev);

            Console.WriteLine($" {adat.nevek[0]} életkor: {adat.korok[0]}");

            // --- diakok.json ---
            fajl = File.ReadAllText("diakok.json", System.Text.Encoding.Latin1);
            List<Diak> diakok = JsonSerializer.Deserialize<List<Diak>>(fajl);

            Console.WriteLine("Keresett név:");
            string neve = Console.ReadLine().Trim();
            bool megvan = false;

            Console.WriteLine("\n--- Diákok a listában ---");
            foreach (var d in diakok)
                Console.WriteLine(d.nev);

            foreach (var diak in diakok)
            {
                if (string.Equals(diak.nev.Trim(), neve, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Átlag: " + diak.jegyek.Average());
                    megvan = true;
                }
            }

            if (!megvan)
                Console.WriteLine("Nincs ilyen nevű diák!");

            // --- munkavallalok.json ---
            Console.WriteLine("\n--- Munkavállalók betöltése ---");

            fajl = File.ReadAllText("munkavallalok.json", System.Text.Encoding.Latin1);
            List<Munkavallalo> mvk = JsonSerializer.Deserialize<List<Munkavallalo>>(fajl);

            Munkavallalo uj = new Munkavallalo()
            {
                nev = "Szabó Júlia",
                fizetes = 380000,
                jogositvany = false,
                munkarend = "10:00-18:00"
            };

            mvk.Add(uj);

            Console.WriteLine("\nJogosítvánnyal rendelkező munkavállalók:");
            foreach (var m in mvk)
            {
                if (m.jogositvany)
                {
                    Console.WriteLine($"{m.nev} - {m.fizetes} Ft - {m.munkarend}");
                }
            }

            string ujJson = JsonSerializer.Serialize(mvk, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("munkavallalok.json", ujJson, System.Text.Encoding.Latin1);

            Console.WriteLine("\nFrissített adatok visszaírva a munkavallalok.json fájlba!");

            // --- Program ne záródjon be ---
            Console.WriteLine("\nNyomj meg egy gombot a kilépéshez...");
            Console.ReadKey();
        }
    }
}