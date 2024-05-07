using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_projet_IA
{
    class Program
    {
        static string Rechercher(string H1, string H2)
        {
            string p = "abcdefghijklmnopqrstuvwxyz",
                   q = "abcdefghijklmnopqrstuvwxyz",
                   r = "abcdefghijklmnopqrstuvwxyz";

            for (int i=0; i < 26; i++)
            {
            // Modus Ponnens
                for (int j=0; j < 26; j++)
                {
                  if ( (H1 == p[i].ToString()) && (H2 == (p[i] + "=>" + q[j])) )
                       return q[j].ToString() + "  Modus Ponnens";
                }

            // Modus Tollens
                 for (int j=0; j < 26; j++)
                 {
                   if (H1 == "!" + q[j] && H2 == (p[i] + "=>" + q[j]))
                        return "!" + p[i].ToString() + "  Modus Tollens" ;
                 }

            // Règle de Syllorgisme
                  for (int j=0; j < 26; j++)
                  { 
                    for (int k=0; k < 26; k++)
                        {
                        if ((H1 == (p[i] + "=>" + q[j])) && (H2 == (q[j] + "=>" + r[k])))
                            return p[i] + "=>" + r[k] + "  Modus Règle de Syllorgisme";
                         }
                  }
            //Règle de Conjonction 
                for (int j=0; j < 26; j++)
                 {
                   if (H1 == p[i].ToString() && H2 == q[j].ToString())
                        return p[i] + "&&" + q[j] + "  Règle de Conjonction";
                 }
             
             //Règle de Simplification
                for (int j=0; j < 26; j++)
                 {
                   if (H1 == p[i].ToString() + "&&" + q[j])
                        return p[i].ToString() + "  Règle de Simplification";
                 } 

              //Règle de d'Addition
                for (int j=0; j < 26; j++)
                 {
                   if (H1 == p[i].ToString() )
                        return p[i] + "||" + q[j] + "  Règle de d'Addition"; 
                 }       
 
              //Règle de d'Implication
                for (int j=0; j < 26; j++)
                 {
                   if (H1 == (p[i] + "=>" + q[j]) )
                        return "!" + p[i] + "||" + q[j] + "  Règle de d'Implication"; 
                 }           
            }
        return null;
    }

        static void Main(string[] args)
        {
            Console.Write("Entrez les nombres d'HYPOTHÈSES : ");
            int nbHypothese = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("NOTATIONS :");
            Console.WriteLine("OU est égale à (p||q)");
            Console.WriteLine("ET est égale à (p&&q)");
            Console.WriteLine("NON est égale à !");
            Console.WriteLine("Implication est égale à => ");
            Console.WriteLine("l'EQUIVALENCE est <=>");
            Console.WriteLine();

            Console.WriteLine("*écrire les variables en MINISCULES, surtout n'est pas utiliser l'INDENTATTION");
            string[] H = new string[nbHypothese];
            for (int i = 0; i < nbHypothese; i++)
            {
                Console.Write("H" + (i + 1) + ": ");
                H[i] = Console.ReadLine();
            }

            /*input conséquence
            Console.Write("Puis entrez la Conséquence : ");
            string C = Console.ReadLine();*/

            for (int i= 0; i < nbHypothese; i++)
            {
                 for (int j= 0; i < nbHypothese; j++)
                     {
                        if (i != j )
                              {
                                string somme = Rechercher(H[i], H[j]);
                                Console.WriteLine("somme des valeurs " + "H" + (i+1) + " et " + "H" + (j+1) + ": " + somme);
                                if (somme == null)
                                    {
                                       string sommeInverse = Rechercher(H[j], H[i]);
                                        Console.WriteLine("somme des valeurs " + "H" + (j+1) + " et " + "H" + (i+1) + ": " + sommeInverse); 
                                        Console.WriteLine(Rechercher(somme, sommeInverse));
                                     }   
                               }
                      }
            }
            /*string resultat = Rechercher(H[0], H[1]);
            if (resultat == C)
            {
                Console.WriteLine("l'Argumentation " + H[0] + " et " + H[1] + " est VRAI" );
            }
              else 
               {
                     Console.WriteLine("l'Argumentation " + H[0] + " et " + H[1] + " est FAUX"  );
                }*/            


            Console.ReadKey();
        }
    }
}





