using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace millionos
{
	internal class Jatek
	{
		private int pont = 0;
        private int[] nyeremenyek = [0, 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 15000000, 25000000, 50000000];

        static Random rnd = new Random();

        public int Pont { get => pont; }
        public int[] Nyeremenyek { get => nyeremenyek; }

        public bool SorkerdesGeneralas(List<Sorkerdes> sorkerdesek)
		{
			Sorkerdes sk = sorkerdesek[rnd.Next(0, sorkerdesek.Count - 1)];

			Console.WriteLine(sk.KerdesSzoveg);
            int leghosszabbElso = Math.Max(sk.Valaszok[0].Length, sk.Valaszok[2].Length);
            Console.WriteLine($"{sk.Valaszok[0].PadRight(leghosszabbElso + 6)}{sk.Valaszok[1]}");
            Console.WriteLine($"{sk.Valaszok[2].PadRight(leghosszabbElso + 6)}{sk.Valaszok[3]}");
            Console.WriteLine("\nÍrja be a helyes válasz sorrendjét(pl: ABCD): ");
			string valasz = Console.ReadLine().Trim().ToUpper();

			if (valasz.Equals(sk.HelyesSorrend))
			{
				Console.WriteLine("\nHelyes válasz! továbbléphet az első kérdésre!");
                Console.ReadKey();
                Console.Clear();
				return true;
            }
			else
			{
				Console.WriteLine($"\nHelytelen válasz. Helyes:\n{sk.HelyesSorrend}");
                Console.ReadKey();
                Console.Clear();
				return false;
            }
        }

		public bool KerdesGeneralas(List<List<Kerdes>> kerdesek)
		{
			Kerdes k = kerdesek[pont][rnd.Next(0, kerdesek[pont].Count)];
            Console.WriteLine($"{pont+1}. " + k.KerdesSzoveg);
            int leghosszabbElso = Math.Max(k.Valaszok[0].Length, k.Valaszok[2].Length);
            Console.WriteLine($"{k.Valaszok[0].PadRight(leghosszabbElso + 6)}{k.Valaszok[1]}");
            Console.WriteLine($"{k.Valaszok[2].PadRight(leghosszabbElso + 6)}{k.Valaszok[3]}");
            Console.WriteLine("\nÍrja be a helyes válasz betűjelét (pl: A)");

            string valasz = Console.ReadLine().Trim().ToUpper();
			if (valasz.Equals(k.Helyes))
			{
				pont++;
                if (pont == 5 || pont == 10)
				{
                    Console.WriteLine($"Helyes válasz! Továbbmehet a következő kérdésre VAGY elmehet annyival amennyit eddig összegyüjtött. Eddig összegűjtött pénz: {nyeremenyek[pont]}\nKilép? Igen(i) Nem(n)");
                    string kilep = "";
                    bool fut = true;
                    while(fut)
                    {
                        kilep = Console.ReadLine().Trim().ToUpper();
                        if (kilep.Equals("I"))
                        {
                            fut = false;
                            return false;
                        }
                        else if (kilep.Equals("N"))
                        {
                            fut = false;
                            Console.Clear();
                            return true;
                        }
                        else
                        {
                            {
                                Console.WriteLine("Nincs ilyen opció");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Helyes válasz! Továbbmehet a következő kérdésre. Eddig összegűjtött pénz: {nyeremenyek[pont]}");
                }

                Console.ReadKey();
                Console.Clear();
                return true;
            }
			else
			{
                Console.WriteLine($"Helytelen válasz! Helyes: {k.Helyes}\nVége a játéknak");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
        }

		public void JatekVege()
		{
            if (pont == 15)
			{
                Console.WriteLine("\nSikeresen megválaszolta az összes kérdést helyesen! Öné az 50 millió foirnt");
            }
			else
			{
                Console.WriteLine($"\nSikeresen megválaszolt {pont} kérdést és eljutott {nyeremenyek[pont]}Ft-ig, de sajnos kiesett.");
			}
            Console.ReadKey();
        }
	}	
}
