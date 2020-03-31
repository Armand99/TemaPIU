using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
	//clasa Telefon
    public class Telefon
	{ 
		int nrtel = 0 ;
		string marca;
		string model;
		string memin;
		double pret;

		//Constructor fara parametrii
		public Telefon()
		{
			marca = string.Empty;
			model = string.Empty;
			memin = string.Empty;
			pret = 0;
		}

		//constructor cu parametrii
		public Telefon(string _marca, string _model, string _memin , double _pret)
		{
			marca = _marca;
			model = _model;
			memin = _memin;
			pret = _pret;
			nrtel++;
		}

		//constructor ce primeste un sir de caractere
		public Telefon(string tel)
		{
			string[] b = tel.Split(',');
			marca = b[0];
			model = b[1];
			memin = b[2];
			pret = int.Parse(b[3]);
			nrtel++;
		}

		//conversia la sir
		public string Info()
		{
			return string.Format("Telefonul este un {0} {1} , memoria interna de {2} , la pretul de {3} lei ",marca,model,memin,pret);
		}

		//functia ce compara preturile celor doua obiecte de tip Telefon
		public void comp ( Telefon t )
		{
			if (pret > t.pret)
				Console.WriteLine("{0} {1} mai scump decat {2} {3}",marca,model,t.marca,t.model);
			else if ( pret < t.pret )
				Console.WriteLine("{0} {1} mai scump decat {2} {3}",t.marca,t.model,marca,model);
			else
				Console.WriteLine("Telefoanele au acelasi pret");
		}

		//Enumeratii
		public enum Culoare
		{
			Alb = 1 ,
			Negru = 2 ,
			Gold = 3 , 
			Silver = 4
		};
		private Culoare cul = Culoare.Alb;

		public enum Sim
		{
			Single = 1 ,
			Dual = 2 
		};
		private Sim cart = Sim.Single;

		public Culoare _Culoare
		{
			get { return cul; }
			set { cul = value; }
		}

		public Sim _Sim
		{
			get { return cart; }
			set { cart = value; }
		}

		//Functia pentru salvarea datelor in fisier
		public void AF()
		{
			string NumeFisier = "Telefoane.txt";
			using (StreamWriter fisier = new StreamWriter(NumeFisier,true))
			{
				fisier.WriteLine(this.ConvFisier());
			}
		}

		public string ConvFisier ()
		{
			string OUT = string.Format("{0},{1},{2},{3}", marca, model, memin, pret);
			return OUT;
		}
	}
}
