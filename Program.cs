using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    
    
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string player1, player2;
            GussingGameBase playAgent;
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter your choice: ");
                Console.WriteLine("Enter 1 for watching (Novice/Inexperienced) Computer VS Computer game.");
                Console.WriteLine("Enter 2 for playing Human VS Novice Computer game.");
                Console.WriteLine("Enter 3 for playing Human VS (Expert) AI Computer game.");
                Console.WriteLine("Enter 4 for playing Human VS Human game.");
                Console.WriteLine("Enter 5 for watching AI Computer VS AI Computer game.");
                Console.WriteLine("Enter 6 for Exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    playAgent = new GussingGame();   //Computer VS Computer
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please enter human player name: ");
                    player1 = Console.ReadLine();
                    playAgent = new OnePlayerGussingGame(player1); //Human VS Novice Computer
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Please enter human player name: ");
                    player1 = Console.ReadLine();
                    playAgent = new OnePlayerAIComputerGussingGame(player1);  //Human VS AI Computer
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Please enter player-01 name: ");
                    player1 = Console.ReadLine();
                    Console.WriteLine("Please enter player-02 name: ");
                    player2 = Console.ReadLine();
                    playAgent = new TwoPlayerGussingGame(player1, player2); //Human VS Human
                }
                else if (choice == "5")
                {
                    playAgent = new AIComputerAIComputerGussingGame(); //AI Computer VS AI Computer
                }

                else if (choice == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Selection. Please enter correctly! ");
                    Console.ReadKey();
                    continue;
                }

                int currentGuess;
                playAgent.Reset();
                Console.WriteLine("Assume The Hidden Number: " + GussingGame.guessMe + ", is unknown to all players!");
                Thread.Sleep(3000);
                do
                {
                    Console.Clear();
                    Console.WriteLine("Guess a number in range {0} to {1}: ", GussingGameBase.LOW, GussingGameBase.HIGH);
                    Console.WriteLine("Now playing player: {0}: {1}", playAgent.WhoesTurn(), playAgent.GetPlayerName());

                    Thread.Sleep(1500);
                    currentGuess = playAgent.Play();
                    playAgent.GiveHints(currentGuess);
                    Thread.Sleep(1000);

                } while (playAgent.CheckWin(currentGuess) != 0);
                Console.WriteLine("Congratulations! Player {0}: {1} Wins...", playAgent.GetPlayerId(1), playAgent.GetPlayerName(1));
                Console.WriteLine("Do you want to play again? (Y/N): ");
                choice = Console.ReadLine();
                if (choice == "n" || choice == "N") break;
            } while (true);
            Console.Read();
        }
    }
}