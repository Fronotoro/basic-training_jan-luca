using System;

namespace spiel1
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hallo Spieler! Bitte gib deinen Namen ein: ");
            var playerName = Console.ReadLine();

            while (String.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Ich habe Zeit... ;)");
                playerName = Console.ReadLine();
            }

            Console.WriteLine($"Wir spielen {string.Join(", ", Move.allMoves)}!");
            Console.WriteLine("Wenn du nicht mehr spielen möchtest, tippe 'Ende' bei der Aufforderung, deinen Zug zu wählen.");

            var playerScoreCount = 0;
            var pcScoreCount = 0;
            var moveRequestIndicator = true;
            var exit = false;

            while (exit == false)
            {
                if (moveRequestIndicator == true)
                {
                    Console.WriteLine($"Wähle deinen Zug, {playerName}:");
                }

                moveRequestIndicator = true;
                var playerMoveUnformatted = Console.ReadLine();
                var playerMove = playerMoveUnformatted.Substring(0, 1).ToUpper() + playerMoveUnformatted.Substring(1).ToLower();
                
                if (playerMove == "Ende") 
                {
                    exit = true;
                    break;
                }

                var playerMoveIndex = Array.IndexOf(Move.allMoves, playerMove);

                if (playerMoveIndex >= 0)
                {
                    Random rand = new Random();
                    var pcMoveIndex = rand.Next(Move.allMoves.Length);

                    Console.WriteLine($"Der Computer wählt: {Move.allMoves[pcMoveIndex]}");

                    if (pcMoveIndex == playerMoveIndex)
                    {
                        Console.WriteLine("Unentschieden!");
                    }
                    else
                    {
                        var finalResult = FindingResultPhrase(playerMoveIndex, pcMoveIndex);
                        Console.WriteLine(finalResult);

                        if (finalResult.StartsWith(playerMove)) 
                        {
                            playerScoreCount++;
                        }
                        else
                        {
                            pcScoreCount++;
                        }
                    }

                    if (pcScoreCount < playerScoreCount)
                    {
                        Console.WriteLine($"Es steht  {playerScoreCount} zu {pcScoreCount} für Dich!");
                    }
                    else if (pcScoreCount > playerScoreCount)
                    {
                        Console.WriteLine($"Es steht {playerScoreCount} zu {pcScoreCount} für den Computer!");
                    }
                    else
                    {
                        Console.WriteLine($"Es steht {playerScoreCount} zu {pcScoreCount}, Gleichstand!");
                    }
                }
                else
                {
                    Console.WriteLine("Wie war das?");
                    moveRequestIndicator = false;
                    continue;
                }
            }
        }

        private static string FindingResultPhrase(int playerMoveIndex, int pcMoveIndex)
        {
            return Results.resultMatrix[Math.Max(playerMoveIndex, pcMoveIndex), Math.Min(playerMoveIndex, pcMoveIndex)];
        }
    }

    class Move
    {
        public static string[] allMoves = { "Schere", "Stein", "Papier", "Echse", "Spock" };
    }

    class Results
    {
        private static string[] resultTemplates =
            { "Stein zetrümmert Schere", 
            "Schere schneidet Papier", 
            "Schere köpft Echse", 
            "Spock zertrümmert Schere",
            "Papier bedeckt Stein",
            "Stein zerquetscht Echse",
            "Spock verdampft Stein",
            "Echse frisst Papier",
            "Papier widerlegt Spock",
            "Echse vergiftet Spock" };

        public static string[,] resultMatrix = FormatResults(resultTemplates);

        private static string[,] FormatResults(string[] resultTemplate)
        {
            string[,] resultMatrixScaffold = new string[Move.allMoves.Length, Move.allMoves.Length];
            var runningIndex = 0;
 
            for (var i = 0; i <= Move.allMoves.Length - 2; i++)
            {
                for (var j = i + 1; j <= Move.allMoves.Length - 1; j++)
                {
                    resultMatrixScaffold[j, i] = resultTemplate[runningIndex];
                    runningIndex++;
                }
            }

            return resultMatrixScaffold;
        }
    }
}
