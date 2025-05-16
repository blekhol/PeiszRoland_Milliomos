namespace millionos
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<List<Kerdes>> kerdesek = KerdesOlvasas();
			List<Sorkerdes> sorkerdesek = SorkerdesOlvasas();
			
			Jatek jatek = new Jatek();

			if (jatek.SorkerdesGeneralas(sorkerdesek))
			{
				bool fut = true;
				while(jatek.Pont < 15 && fut)
				{
					fut = jatek.KerdesGeneralas(kerdesek);
				}
			}
		}

		static List<Sorkerdes> SorkerdesOlvasas()
		{
			List<Sorkerdes> sorkerdesek = [];

			StreamReader sr = new StreamReader("sorkerdes.txt");
			string[] sorok = sr.ReadToEnd().Split("\n");

			foreach (string sor in sorok)
			{
				if (sor.Equals(""))
				{
					return sorkerdesek;
				}
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
                if (sor.Equals(""))
                {
                    return kerdesek;
                }
                string[] reszek = sor.Split(";");

				List<string> valaszok = [reszek[2], reszek[3], reszek[4], reszek[5]];

									  //szint de indexként
				Kerdes k = new Kerdes(int.Parse(reszek[0]) - 1, reszek[1], valaszok, reszek[6], reszek[7]);

				kerdesek[k.Szint].Add(k);
			}

			return kerdesek;
		}
	}
}
