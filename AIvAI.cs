using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AIComputerAIComputerGussingGame : OnePlayerAIComputerGussingGame   //AI Computer vs AI Computer
    {
        private string Player2;
        public AIComputerAIComputerGussingGame() : base("AI Computer 01")
        {
            Player2 = "AI Computer 02";
        }
        public AIComputerAIComputerGussingGame(string name) : base("AI Computer 01")
        {
            Player2 = name;
        }
        public override string GetPlayerName(int winCondition = 0)
        {
            if (winCondition == 1) steps--; //at step-1 we have a winner
            if (steps % 2 == 1)
                return Player2;
            return base.GetPlayerName();
        }

        public override int Play()
        {
            int currGuess; //AI player plays at every even or odd step
            if (steps % 2 == 1) //AI player playing for odd steps 
            {
                return base.Play();
            }

            //AI player playing for odd steps
            steps++;
            UpdateGuessRange();   //update guess based on other players number
            currGuess = r.Next(guessMin, guessMax);
            Console.WriteLine(currGuess);
            prevGuess = currGuess;
            UpdateGuessRange();  //update guess based on computer's current number
            return currGuess;
        }
    }
}
