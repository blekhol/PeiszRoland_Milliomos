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
        private bool[] segitsegek = [true, true, true];

        static Random rnd = new Random();

        public int Pont { get => pont; }
        public int[] Nyeremenyek { get => nyeremenyek; }
        public bool[] Segitsegek { get => segitsegek; set => segitsegek = value; }

        public bool SorkerdesGeneralas(List<Sorkerdes> sorkerdesek)
		{
			Sorkerdes sk = sorkerdesek[rnd.Next(0, sorkerdesek.Count - 1)];

			Console.WriteLine(sk.KerdesSzoveg);
			Console.WriteLine(sk.HelyesSorrend);
			int leghosszabbElso = Math.Max(sk.Valaszok[0].Length, sk.Valaszok[2].Length);
            Console.WriteLine($"a) {sk.Valaszok[0].PadRight(leghosszabbElso + 6)}b) {sk.Valaszok[1]}");
            Console.WriteLine($"c) {sk.Valaszok[2].PadRight(leghosszabbElso + 6)}d) {sk.Valaszok[3]}");
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
            Segitseg();
            Kerdes k = kerdesek[pont][rnd.Next(0, kerdesek[pont].Count)];
            Console.WriteLine($"{pont+1}. " + k.KerdesSzoveg);
            Console.WriteLine(k.Helyes);
            int leghosszabbElso = Math.Max(k.Valaszok[0].Length, k.Valaszok[2].Length);

			(int Left, int Top)[] valaszHelyek = new (int Left, int Top)[4];

			valaszHelyek[0] = (Console.CursorLeft, Console.CursorTop);
			Console.Write($"a) {k.Valaszok[0].PadRight(leghosszabbElso + 6)}");
			valaszHelyek[1] = (Console.CursorLeft, Console.CursorTop);
			Console.WriteLine($"b) { k.Valaszok[1]}");
			valaszHelyek[2] = (Console.CursorLeft, Console.CursorTop);
			Console.Write($"c) {k.Valaszok[2].PadRight(leghosszabbElso + 6)}");
			valaszHelyek[3] = (Console.CursorLeft, Console.CursorTop);
			Console.WriteLine($"d) {k.Valaszok[3]}");
            Console.WriteLine("\nÍrja be a helyes válasz betűjelét (pl: A)");

            string valasz = "";
            bool valaszNezes = true;

			while (valaszNezes)
            {
				(int Left, int Top) userValasz = (Console.CursorLeft, Console.CursorTop);
				valasz = Console.ReadLine().Trim().ToUpper();
				Console.SetCursorPosition(userValasz.Left, userValasz.Top);
                Console.Write(new string(' ', valasz.Length));

                if (valasz.Equals(k.Helyes))
				{
					valaszNezes = false;
					pont++;
					if (pont == 5 || pont == 10)
					{
						Console.WriteLine($"Helyes válasz! Továbbmehet a következő kérdésre VAGY elmehet annyival amennyit eddig összegyüjtött. Eddig összegűjtött pénz: {nyeremenyek[pont]}\nKilép? Igen(i) Nem(n)");
						string kilep = "";
						bool fut = true;
						while (fut)
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
				else if (valasz.Equals("Q") || valasz.Equals("W") || valasz.Equals("E")) 
				{
					switch (valasz)
					{
						case "Q":
							if (segitsegek[0])
							{
								segitsegek[0] = false;

								string[] betuValaszIndex = ["A", "B", "C", "D"];
								int helyesIndex = Array.IndexOf(betuValaszIndex, k.Helyes);

                                int randomRossz = rnd.Next(0, 4);
								while (randomRossz == helyesIndex)
								{
									randomRossz = rnd.Next(0, 4);
								}
								for (int i = 0; i < 4; i++)
								{
                                    if (i != helyesIndex && i != randomRossz)
									{
										Console.SetCursorPosition(valaszHelyek[i].Left, valaszHelyek[i].Top);

                                        Console.Write(new string(' ', k.Valaszok[i].Length + 3));
									}
								}
								Console.SetCursorPosition(userValasz.Left, userValasz.Top);
                            }
							else
							{
                                Console.WriteLine("Már elhasználta ezt a segítséget");
								Console.ReadKey(true);
								Console.SetCursorPosition(userValasz.Left, userValasz.Top);
								Console.Write(new string(' ', 50));
                                Console.SetCursorPosition(userValasz.Left, userValasz.Top);
                            }

							break;
						default: break;
					}
				}
				else
				{
					valaszNezes = false;
					Console.WriteLine($"Helytelen válasz! Helyes: {k.Helyes}\nVége a játéknak");
					Console.ReadKey();
					Console.Clear();
					return false;
				}
			}
			return false;
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

        public void Segitseg()
        {
			string masik = "Segítség használatához írja be a betűjelét";
			Console.SetCursorPosition(119 - masik.Length, 27);
			Console.Write(masik);
			string szoveg = "Segítségek:";
            if (segitsegek[0])
			{
				szoveg += " 50 / 50(q) |";
            }
            if (segitsegek[1])
            {
                szoveg += " Telefon(w) |";
            }
            if (segitsegek[2])
            {
                szoveg += " Közönség(e)";
            }
            Console.SetCursorPosition(119 - szoveg.Length, 28);
            Console.Write(szoveg);
            Console.SetCursorPosition(0, 0);
        }
	}	
}
