using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GussingGame : GussingGameBase   //Novice Computer Vs Novice Computer class
    {
        // A novice computer can only remember last given hint.

        private string Player2;   //second player name
        protected int guessMin = LOW;
        protected int guessMax = HIGH;
        protected int prevGuess = 0; //A Novice computer only remembers last guess

        public GussingGame() : base("Novice Computer-01")
        {
            Player2 = "Novice Computer-02";
        }
        public GussingGame(string name1) : base(name1)
        {
            Player2 = name1;
        }
        public GussingGame(string name1, string name2) : base(name1)
        {
            Player2 = name2;
        }
        public override string GetPlayerName(int winCondition = 0)
        {
            if (winCondition == 1) steps--;  //at step-1 we have a winner.  
            if (steps % 2 == 1)
                return Player2;
            return base.GetPlayerName();
        }
        public override int Play()
        {
            int computerGuess;
            steps++;
            if (CheckWin(prevGuess) > 0)
            {
                guessMin = prevGuess + 1;
                guessMax = HIGH;
            }
            else if (CheckWin(prevGuess) < 0)
            {

                guessMin = LOW;
                guessMax = prevGuess; //do not need +1 since max value is range-1
            }


            computerGuess = r.Next(guessMin, guessMax);
            Console.WriteLine(computerGuess);
            prevGuess = computerGuess;
            return computerGuess;
        }
        public override void GiveHints(int guess)
        {
            if (CheckWin(guess) > 0)
            {
                Console.WriteLine("Guess Higher >>>");
            }
            else if (CheckWin(guess) < 0)
            {
                Console.WriteLine("Guess Lower <<<");
            }
        }
        public override void Reset()
        {
            base.Reset();
            guessMin = LOW;
            guessMax = HIGH;
            prevGuess = 0;

        }
    }
}
