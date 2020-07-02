using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class TwoPlayerGussingGame : OnePlayerGussingGame   //human vs human class
    {
        private string Player2;
        public TwoPlayerGussingGame(string name1, string name2) : base(name1)
        {
            Player2 = name2;
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
            if (steps % 2 == 1)  //human player playing for the odd step 
            {
                steps++;
                Console.WriteLine("Please enter your guess: ");
                return int.Parse(Console.ReadLine()); //input for human player
            }
            return base.Play(); //in the base class human player also plays for even step
        }
    }
}
