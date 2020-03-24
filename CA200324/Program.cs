using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200324
{
    struct Jatekos
    {
        public int Mez;
        public string Nev;
        public string Nemzet;
        public string Poszt;
        public int Ev;
    }
    class Program
    {
        static List<Jatekos> juventus;
        static void Main(string[] args)
        {
            Beolvas();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            //----
            F09();
            Console.ReadKey();
        }

        private static void F09()
        {
            Console.Write("Mez: ");
            int m = int.Parse(Console.ReadLine());

            int i = 0;

            while (i < juventus.Count && juventus[i].Mez != m)
            {
                i++;
            } 

            if(i < juventus.Count)
            {
                Console.WriteLine($"A {m}-es mezt {juventus[i].Nev} viseli");
            }
            else Console.WriteLine("nincs ilyen mezszámú játékos");
        }

        private static void F08()
        {
            var dic = new Dictionary<int, int>();

            foreach (var j in juventus)
            {
                if (!dic.ContainsKey(j.Ev))
                    dic.Add(j.Ev, 1);
                else dic[j.Ev]++;
            }

            Console.Write("3 jatekos született a köv. években: ");
            foreach (var kvp in dic)
            {
                if (kvp.Value == 3) Console.Write(kvp.Key + ", ");
            }
            Console.WriteLine("\n");
        }

        private static void F07()
        {
            var lics = new Jatekos() { Ev = DateTime.Now.Year };
            foreach (var j in juventus)
            {
                if (j.Poszt == "csatár" && j.Ev < lics.Ev) lics = j;
            }
            Console.WriteLine($"A legöregebb csatár: {lics.Nev}");
        }

        private static void F06()
        {
            var dic = new Dictionary<string, int>();
            foreach (var j in juventus)
            {
                if (!dic.ContainsKey(j.Poszt))
                    dic.Add(j.Poszt, 1);
                else dic[j.Poszt]++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine("{0, -12} {1}", kvp.Key, kvp.Value);
            }
        }

        private static void F05()
        {
            int sum = 0;
            foreach (var j in juventus)
            {
                sum += (DateTime.Now.Year - j.Ev);
            }
            Console.WriteLine("átlagéletkor: {0}", sum / (float)juventus.Count);
        }

        private static void F04()
        {
            int maxi = 0;
            for (int i = 1; i < juventus.Count; i++)
            {
                if (juventus[i].Ev > juventus[maxi].Ev) maxi = i;
            }
            Console.WriteLine($"a legfiatalabb játékos: {juventus[maxi].Nev}");
        }

        private static void F03()
        {
            int db = 0;
            foreach (var j in juventus)
            {
                if (j.Nemzet == "olasz") db++;
            }
            Console.WriteLine($"{db} db olasz játékos van");
        }

        private static void F02()
        {
            int i = 0;
            while (i < juventus.Count && juventus[i].Nemzet != "magyar")
            {
                i++;
            }
            if (i < juventus.Count) Console.WriteLine("van magyar játékos");
            else Console.WriteLine("nincs magyar játékos");
        }

        private static void F01()
        {
            Console.WriteLine($"igazolt játékosok száma: {juventus.Count}");
        }

        private static void Beolvas()
        {
            juventus = new List<Jatekos>();
            var sr = new StreamReader(@"..\..\Res\juve.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] darabok = sr.ReadLine().Split(';');

                juventus.Add(
                    new Jatekos()
                    {
                        Mez = int.Parse(darabok[0]),
                        Nev = darabok[1],
                        Nemzet = darabok[2],
                        Poszt = darabok[3],
                        Ev = int.Parse(darabok[4]),
                    });
            }
            sr.Close();
        }
    }
}
