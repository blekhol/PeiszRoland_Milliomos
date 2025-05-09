using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace millionos
{
	internal class Sorkerdes
	{
		private string kerdesSzoveg;
		private List<string> valaszok;
		private Dictionary<int, string> helyesSorrend;
		private string kategoria;

		public Sorkerdes(string kerdesSzoveg, List<string> valaszok, Dictionary<int, string> helyesSorrend, string kategoria)
		{
			this.kerdesSzoveg = kerdesSzoveg;
			this.valaszok = valaszok;
			this.helyesSorrend = helyesSorrend;
			this.kategoria = kategoria;
		}

		public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
		public List<string> Valaszok { get => valaszok; set => valaszok = value; }
		public Dictionary<int, string> HelyesSorrend { get => helyesSorrend; set => helyesSorrend = value; }
		public string Kategoria { get => kategoria; set => kategoria = value; }
	}
}
