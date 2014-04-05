using System;
using divisioneuclide;
namespace divisioneuclide
{
    class Program
    {
        static void Main(string[] args)
        {
			menu ();
        }
		static void menu()
		{
			bool erreur;
			string reponse;
			do {
				erreur = false;
				Console.WriteLine ("########### MENU ###########\n1) Division d'Euclide\n2) Inverse Division d'Euclide\n");
				Console.Write ("Votre Choi?");
				reponse = Console.ReadLine ();
			} while(reponse!="1" && reponse!="2");
			if (reponse == "1") {
				DivisionEuclide ();
			} else if (reponse=="2") {
				InverseDivisionEuclide ();
			}
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
		static void InverseDivisionEuclide()
		{
			int q;
			int a;
			int b;
			int c;
			ValeurInverseDivisionEuclide (out a, out b, out c);
			q = a * b + c;
			AfficherDivison (q, b, c, a);
		}
		static void ValeurInverseDivisionEuclide(out int a, out int b, out int c)
		{
			a=0;
			b=0;
			c=0;
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
			}
		}
	}
}