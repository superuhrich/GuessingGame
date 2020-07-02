using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class OnePlayerAIComputerGussingGame : GussingGame   //Human vs Expert AI Computer
    {
        //An AI computer not only considers given hint, but also updates the possible solution range.
        private string Player2;
        public OnePlayerAIComputerGussingGame(string name) : base("Expert AI Computer")
        {
            Player2 = name;
        }
        public override string GetPlayerName(int winCondition = 0)
        {
            if (winCondition == 1) steps--; //at step-1 we have a winner
            if (steps % 2 == 0)
                return Player2;
            return base.GetPlayerName();
        }
        protected void UpdateGuessRange()
        {
            //AI computer not only monitors last guess, but also updates the range 

            if (CheckWin(prevGuess) > 0)
            {
                if (guessMin <= prevGuess)
                    guessMin = prevGuess + 1;
            }
            else if (CheckWin(prevGuess) < 0)
            {
                if (guessMax > prevGuess)//do not need to check equal this value is range-1
                    guessMax = prevGuess - 1;
            }
        }
        public override int Play()
        {
            int currGuess;
            if (steps % 2 == 0) //human player plays at even steps
            {
                steps++;
                Console.WriteLine("Please enter your guess: ");
                prevGuess = int.Parse(Console.ReadLine());
                return prevGuess;
            }

            //AI computer plays at every odd step

            steps++;
            UpdateGuessRange();   //update guess based on previous players number
            currGuess = r.Next(guessMin, guessMax);
            Console.WriteLine(currGuess);
            prevGuess = currGuess;
            UpdateGuessRange();  //update guess based on computer's current number
            return currGuess;

        }
    }
}
