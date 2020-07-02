using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class OnePlayerGussingGame : GussingGame  //human vs novice computer
    {
        private string Player2;
        public OnePlayerGussingGame(string name) : base("Novice Computer")
        {
            Player2 = name; //player 2 is human, player 1 is computer
        }
        public override string GetPlayerName(int winCondition = 0)
        {
            if (winCondition == 1) steps--;  //at step-1 we have a winner.  
            if (steps % 2 == 0)  //human player plays at every even step
                return Player2;
            return base.GetPlayerName();  // computer plays at every odd step
        }
        public override int Play()
        {
            int currentGuess;
            if (steps % 2 == 0) //human player plays at every even step
            {
                steps++;
                Console.WriteLine("Please enter your guess: ");//Human player given input
                currentGuess = int.Parse(Console.ReadLine());
                prevGuess = currentGuess;
                return currentGuess;
            }

            return base.Play(); //computer player predicts a move
        }

    }
}
