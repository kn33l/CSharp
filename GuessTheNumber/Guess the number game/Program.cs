using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string playing = "";

            Console.WriteLine("Guess the Number game");
            Console.WriteLine("\nThe computer will think of a number between 1 & 10, can you guess it?");
            Console.WriteLine("\nWhat is your name?");

            Player p1 = new Player(Console.ReadLine());

            Console.WriteLine("\nOk, {0} lets play! You have {1} goes at guessing the number"         
                , p1.Name
                , p1.Lives);

            do
            {
                Random rnd = new Random();
                int computer = rnd.Next(1, 10);

                Game.Play(p1.Lives, computer);

                Console.WriteLine("\nDo you want to play again (Y or N)??");

                playing = string.Format(Console.ReadLine().ToUpper());
                
            } while (playing == "Y");

                
                    
        }
    }

    class Player
    {
        public string Name { get; set; }
        public int Lives { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Lives = 5;
        }

        /* Replaced this method with the constructor above
        public void createPlayer(string name)
        {
            this.Name = name;
            this.Lives = 5;
        }
        */
    }

    class Game
    {
        public static void Play(int plrLives, int comNumber)
        {
            Console.WriteLine("\nWhat do you think the computers number is? ");

            do
            {
                    int guess = int.Parse(Console.ReadLine());

                    if (guess == comNumber)
                    {
                        Console.WriteLine("\nWell done, the computers number was {0}", comNumber);
                        break;
                    }
                    else if (guess != comNumber)
                    {
                        plrLives = --plrLives;

                        if (plrLives > 1)
                        {
                            Console.WriteLine("\nNope, try again! You have {0} guesses left"
                                , plrLives);
                        }
                        else if (plrLives == 1)
                        {
                            Console.WriteLine("\nLast try, only {0} guess left!", plrLives);
                        }
                        else
                        {
                            Console.WriteLine("\nAw man, you didn't guess it!");                       
                        }

                    }
                    
            } while (plrLives > 0);

        }
    }
}
