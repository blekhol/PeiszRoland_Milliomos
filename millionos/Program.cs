namespace millionos
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<List<Kerdes>> kerdesek = KerdesOlvasas();
			List<Sorkerdes> sorkerdesek = SorkerdesOlvasas();
			

		}

		static List<Sorkerdes> SorkerdesOlvasas()
		{
			List<Sorkerdes> sorkerdesek = [];

			StreamReader sr = new StreamReader("kerdes.txt");
			string[] sorok = sr.ReadToEnd().Split("\n");

			foreach (string sor in sorok)
			{
				string[] reszek = sor.Split(";");

				List<string> valaszok = [reszek[1], reszek[2], reszek[3], reszek[4]];

				Sorkerdes sk = new Sorkerdes(reszek[0], valaszok, reszek[5], reszek[6]);

				sorkerdesek.Add(sk);
			}

			return sorkerdesek;
		}

		static List<List<Kerdes>> KerdesOlvasas()
		{
			List<List<Kerdes>> kerdesek = [];

			//minden szint külön lista, egy nagy listán belül
			for(int i = 0; i < 15; i++)
			{
				kerdesek.Add(new List<Kerdes>());
			}
			
			StreamReader sr = new StreamReader("kerdes.txt");
			string[] sorok = sr.ReadToEnd().Split("\n");

			foreach(string sor in sorok)
			{
				string[] reszek = sor.Split(";");

				List<string> valaszok = [reszek[2], reszek[3], reszek[4], reszek[5]];

				int helyes = 0;

				switch (reszek[6])
				{
					case "A": helyes = 0; break;
					case "B": helyes = 1; break;
					case "C": helyes = 2; break;
					case "D": helyes = 3; break;
					default: break;
				}
									  //szint de indexként
				Kerdes k = new Kerdes(int.Parse(reszek[0]) - 1, reszek[1], valaszok, helyes, reszek[7]);

				kerdesek[k.Szint].Add(k);
			}

			return kerdesek;
		}
	}
}
