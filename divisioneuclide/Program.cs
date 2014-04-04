using System;
using divisioneuclide;
namespace divisioneuclide
{
    class Program
    {
        static void Main(string[] args)
        {
			DivisionEuclide();
        }
		static void DivisionEuclide()
		{
			int a;
			int m;
			int r;
			int q;
			ValeurDivisionEuclide (out a, out m);
			if (m != 0) {
				CalculDivisionEuclide (a, m, out r, out q);
				AfficherDivison (a, m, r, q);
			}
			AfficherOperationImpossible ();
		}
		static public void ValeurDivisionEuclide(out int a, out int m)
		{
			bool erreur;
			a = 0;
			m = 0;
			do {
				erreur = false;
				try {
					Console.WriteLine ("Division d'euclide : a=r[m]");
					Console.Write ("a : ");
					a = int.Parse (Console.ReadLine ());
					Console.Write ("m : ");
					m = int.Parse (Console.ReadLine ());
				} catch (Exception) {
					erreur = true;
				}
			} while(erreur);
		}

		static void CalculDivisionEuclide (int a, int m, out int r, out int q)
		{
			r = 0;
			q = 0;
			Console.WriteLine ("Calcul en cours :");
			if (m != 0) {
				if (a < 0) { // cas negatif
					if (a % m == 0) { // si r=0
						q = a / m;
					} else { // si r !=0
						q = a / m - 1; //-1 pour "depasser" la valeur et obtenir le reste
						r = a - m * q;
					}
				} else if (a >= m) { // cas positif
					r = a % m;
					q = (a - r) / m;
				} else if (m > a) {
					r = a;
				}
			}
		}
		static void AfficherDivison(int a, int m, int r, int q) {
			Console.WriteLine (a + "|" + m); // separateur entre dividende et diviseur
			string b;
			if (m > q) { // choisi le nombre de "-" si le diviseur est plus grand que le quotient
				b = a.ToString () + m.ToString ();
			} else { // choisi le nombre de "-" si le quotient est plus grand que le diviseur
				b = a.ToString () + q.ToString ();
			}
			for (int i = 0; i <= b.Length; i++) { // genere les "-"
				Console.Write ("-");
			}
			Console.WriteLine (""); // passe a la ligne
			b = a.ToString ();
			for (int i = (r.ToString ()).Length; i < b.Length; i++) { // aligne le reste
				Console.Write (" ");
			}
			Console.Write (r + "|" + q);
			Console.WriteLine ("");
		}
		static void AfficherOperationImpossible()
		{
			Console.WriteLine ("Opération impossible");
		}
		static void operationinverse()
		{
			int a = 0;
			int b = 0;
			int c = 0;
			Console.WriteLine("q=a*b[c]");
			try
			{
				Console.Write("a : ");
				a = int.Parse(Console.ReadLine());
				Console.Write("b : ");
				b = int.Parse(Console.ReadLine());
				Console.Write("c : ");
				c = int.Parse(Console.ReadLine());
			}
			catch(Exception)
			{
				Console.WriteLine ("erreur");
				operationinverse ();
			}
			int q = a * b + c;
			Console.WriteLine (q + "=" + a + "*" + b + "+" + c);
		}
	}
}