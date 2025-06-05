using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace millionos
{
	internal class Kerdes
	{
		private int szint;
		private string kerdesSzoveg;
		private List<string> valaszok;
		private string helyes;
		private string kategoria;
		private int helyesIndex;

		public Kerdes(int szint, string kerdes, List<string> valaszok, string helyes, string kategoria)
		{
			this.szint = szint;
			this.kerdesSzoveg = kerdes;
			this.valaszok = valaszok;
			this.helyes = helyes;
			this.kategoria = kategoria;

            helyesIndex = Array.IndexOf(["A", "B", "C", "D"], helyes);
        }

		public string KerdesSzoveg { get => kerdesSzoveg; set => kerdesSzoveg = value; }
		public List<string> Valaszok { get => valaszok; set => valaszok = value; }
		public string Helyes { get => helyes; set => helyes = value; }
		public string Kategoria { get => kategoria; set => kategoria = value; }
		public int Szint { get => szint; set => szint = value; }
        public int HelyesIndex { get => helyesIndex; set => helyesIndex = value; }
    }
}
