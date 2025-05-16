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
		private int pont = -1;
		private int[] nyeremenyek = [10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 15000000, 25000000, 50000000];

        static Random rnd = new Random();

        public int Pont { get => pont; }
        public int[] Nyeremenyek { get => nyeremenyek; }

        public bool SorkerdesGeneralas(List<Sorkerdes> sorkerdesek)
		{
			Sorkerdes sk = sorkerdesek[rnd.Next(0, sorkerdesek.Count - 1)];

			Console.WriteLine(sk.KerdesSzoveg);
			Console.WriteLine($"\na) {sk.Valaszok[0]}\t\t\tb) {sk.Valaszok[1]}\nc) {sk.Valaszok[2]}\t\t\td) {sk.Valaszok[3]}");
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
	}	
}
