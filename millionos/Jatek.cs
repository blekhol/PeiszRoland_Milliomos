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
		static Random rnd = new Random();	

		public void SorkerdesGeneralas(List<Sorkerdes> sorkerdesek)
		{
			Sorkerdes sk = sorkerdesek[rnd.Next(0, sorkerdesek.Count - 1)];

            Console.WriteLine(sk.KerdesSzoveg);
        }
	}	
}
