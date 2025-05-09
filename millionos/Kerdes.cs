using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace millionos
{
	internal class Kerdes
	{
		private string kerdesSzoveg;
		private List<string> valaszok;
		private int helyes;
		private string kategoria;

		public Kerdes(string kerdes, List<string> valaszok, int helyes, string kategoria)
		{
			this.kerdesSzoveg = kerdes;
			this.valaszok = valaszok;
			this.helyes = helyes;
			this.kategoria = kategoria;
		}

		public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
		public List<string> Valaszok { get => valaszok; set => valaszok = value; }
		public int Helyes { get => helyes; set => helyes = value; }
		public string Kategoria { get => kategoria; set => kategoria = value; }
	}
}
