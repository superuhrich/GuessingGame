using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public abstract class GussingGameBase //base class for all 
    { //abstract class cannot instantiate objects of its own, but can be used as a super class
        public static int guessMe { get; protected set; }
        public static int LOW = 0;
        public static int HIGH = 100;  //change me to change the number range
        //public field, every subclass objects and external methods needs to access this field, including the main method


        protected static Random r;
        protected static int steps;
        protected string playerName; //default field for a single player game
        //protected fileds will be shared in subclasses

        public GussingGameBase() //base class constructor
        {
            r = new Random(); //instantiate random object
            SetupANewGame();  //initialize game variables
            playerName = "Computer";  //default player name is computer
        }
        public GussingGameBase(string name) : this()
        {
            playerName = name;   //if player name is given, update player name
        }
        protected static void SetupANewGame()  //initialize variables for a new game
        {
            steps = 0;
            guessMe = r.Next(LOW, HIGH);
        }
        public int CheckWin(int currentGuess)  //check for a winning condition
        {
            if (guessMe == currentGuess)
                return 0;
            else if (guessMe > currentGuess)
                return 1;
            else return -1;
        }
        public virtual void Reset() //reset the game
        {
            SetupANewGame();
        }
        public virtual int GetPlayerId(int winCondition = 0)
        {
            if (winCondition == 1)
                return (steps - 1) % 2 + 1;
            //a player wins at step-1, a player plays at current step, 
            return steps % 2 + 1;
        }
        public virtual int WhoesTurn()
        {
            return steps % 2 + 1; //check who will play next
        }
        public virtual string GetPlayerName(int winCondition = 0)
        {
            return playerName;  //get the default player name
        }
        public abstract int Play(); //abstract method, must override in the derived classes
        public abstract void GiveHints(int guess);
    }
 
}
