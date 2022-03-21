using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiel1
{
    internal class Program //internal oder nicht macht für uns glaube ich erstmal keinen Unterschied
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Spieler! Bitte gib deinen Namen ein: ");
            string name = Console.ReadLine();

            Console.WriteLine("Wir spielen so lange Schere, Stein, Papier, Echse, Spock, bis du nicht mehr möchtest.");

            int spielercount = 0;
            int pccount = 0;

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Wähle deinen Zug, " + name + ":");
                string zug = Console.ReadLine();
                string spielerstring = zug;
                int spielerzug = SpielZug(zug);
                string unentschieden = "Unentschieden";

                if(spielerzug <= 4)
                {
                    string[] pclist = { "Schere", "Stein", "Papier", "Echse", "Spock" };
                    Random rand = new Random();
                    int pcindex = rand.Next(pclist.Length);
                    zug = pclist[pcindex];

                    Console.WriteLine("Der Computer wählt: " + zug);

                    int pczug = SpielZug(zug);


                    Console.WriteLine(SchereStein(spielerzug, pczug));
                    string ergebnis = SchereStein(spielerzug, pczug);

                    if (spielerstring == ergebnis.Substring(0, spielerstring.Length)) {
                        spielercount++;
                    } else if (unentschieden == ergebnis.Substring(0, unentschieden.Length)) {
                        continue;
                    } else
                    {
                        pccount++;
                    }

                    if (pccount < spielercount)
                    {
                        Console.WriteLine("Es steht " + spielercount + " zu " + pccount + " für dich!");
                    } else if (pccount > spielercount)
                    {
                        Console.WriteLine("Es steht " + spielercount + " zu " + pccount + " für den Computer!");
                    } else
                    {
                        Console.WriteLine("Es steht " + spielercount + " zu " + pccount + "!");
                    }

                } else
                {
                    Console.WriteLine("Bitte achte auf die richtige Schreibweise.");
                    continue;
                }

                Console.WriteLine("Möchtest du weiterspielen? Antworte mit <Ja> oder <Nein>.");
                
                bool exit1 = false;
                while (exit1 == false)
                {
                    string weiter = Console.ReadLine();
                    if (weiter == "Ja")
                    {
                        exit1 = true;
                        exit = false;
                    }
                    else if (weiter == "Nein")
                    {
                        exit1 = true;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Wie war das?");
                        continue;
                    }
                }



            }



            Console.ReadLine();
        }

        static int SpielZug (string zug)
        {
            int result;
            if (zug == "Schere")
            {
                result = 0;
            }
            else if (zug == "Stein")
            {
                result = 1;
            }
            else if (zug == "Papier")
            {
                result = 2;
            }
            else if (zug == "Echse")
            {
                result = 3;
            }
            else if (zug == "Spock")
            {
                result = 4;
            } else
            {
                result = 5;
            }

            return result;
        }

        static string SchereStein(int spielerzug, int pczug)
        {
            string satz;
            string[,] ergmat = new string[5, 5];
            ergmat[0, 0] = ergmat[1, 1] = ergmat[2, 2] = ergmat[3, 3] = ergmat[4, 4] = "Unentschieden, nochmal.";
            ergmat[0, 1] = ergmat[1, 0] = "Stein zertrümmert Schere";
            ergmat[0, 2] = ergmat[2, 0] = "Schere schneidet Papier";
            ergmat[0, 3] = ergmat[3, 0] = "Schere köpft Echse";
            ergmat[0, 4] = ergmat[4, 0] = "Spock zertrümmert Schere";
            ergmat[1, 2] = ergmat[2, 1] = "Papier bedeckt Stein";
            ergmat[1, 3] = ergmat[3, 1] = "Stein zerquetscht Echse";
            ergmat[1, 4] = ergmat[4, 1] = "Spock verdampft Stein";
            ergmat[2, 3] = ergmat[3, 2] = "Echse frisst Papier";
            ergmat[2, 4] = ergmat[4, 2] = "Papier widerlegt Spock";
            ergmat[3, 4] = ergmat[4, 3] = "Echse vergiftet Spock";

            satz = ergmat[ spielerzug, pczug];
            return satz;
        }
    }
}
