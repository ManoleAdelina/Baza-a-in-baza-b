using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_a_in_baza_b
{
    internal class Program
    {
        
        static double ConvertireBaza10(string numar, int bazaOrigine)
        {
            double rezultat = 0;
            bool fractionar = false;
            double inmultitorFractionar = 1;

            for (int i = 0; i < numar.Length; i++)
            {
                char cifra = numar[i];
                if (cifra == '.')
                {
                    fractionar = true;
                    continue;

                }
                int valoareCifra;

                if (cifra >= '0' && cifra <= '9')
                {
                    valoareCifra = cifra - '0'; //in ASCII '0' e 48 --> '3'-'0=51-48=3 (valoarea numerica)
                }
                else if (cifra >= 'A' && cifra <= 'F')
                {
                    valoareCifra = cifra - 'A' + 10; //in ASCII 'A' e 65 --> 'A'-'A'=65-65=0, 'B'-'A'=66-65=1, 'C'-'A'=67-65=2, etc.
                }
                else
                {
                    throw new Exception("Numarul nu este valid pentru baza aleasa.");
                }
                if (fractionar == true)
                {
                    inmultitorFractionar /= bazaOrigine;
                    rezultat = rezultat + valoareCifra * inmultitorFractionar;

                }
                else
                {
                    rezultat = rezultat * bazaOrigine + valoareCifra;
                }
            }
            return rezultat;
            }

        static string ConvertesteInBazab(double numar, int inBaza)
        {
            string rezultat = "";
            long parteaIntreaga = (long)numar;
            while (parteaIntreaga > 0)
            {
                int rest = (int)(parteaIntreaga % inBaza);
                if (rest < 10)
                {
                    rezultat = (char)(rest + '0') + rezultat;//ex: 3+48=51='3'
                }
                else
                {
                    rezultat = (char)(rest - 10 + 'A') + rezultat;// ex:10 - 10 + 'A'='A' 
                }
                parteaIntreaga = parteaIntreaga / inBaza;


            }

           
            double parteaFractionara = numar - (long)numar;
           
            if (parteaFractionara != 0)
            {
                rezultat += ".";
               for (int i = 0; i <5; i++)//afisam maxim 5 zecimale
               {
                parteaFractionara = parteaFractionara * inBaza;
                int cifra = (int)parteaFractionara;
                if (cifra < 10)
                {
                    rezultat = rezultat + (char)(cifra + '0');
                }
                else
                {
                    rezultat = rezultat + (char)(cifra - 10 + 'A');
                }

                parteaFractionara = parteaFractionara - cifra;
                    if (parteaFractionara == 0)
                    {
                        break;
                    }
               }
        }

            return rezultat;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti baza numarului (intre 2 si 16).");
            int bA = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti baza in care doriti sa convertiti numarul (intre 2 si 16).");
            int bB = int.Parse(Console.ReadLine());

            Console.WriteLine($"Introduceti numarul in baza {bA}.");
            string numar = Console.ReadLine();

            double numarBaza10 = ConvertireBaza10(numar, bA);

            string rezultat = ConvertesteInBazab(numarBaza10, bB);
            Console.WriteLine($"Numarul {numar} in baza {bA} este echivalent cu numarul {rezultat} in baza {bB}.");
        }
    }
}
