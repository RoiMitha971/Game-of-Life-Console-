using System;

namespace Jeu_de_la_vie
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = AskNumber("Choisissez la taille de la grille");
            int iteration = AskNumber("Combien d'itérations souhaitez-vous effectuer ?");

            Game game = new Game(dimension, iteration);
            game.RunGameConsole();
            Console.ReadLine();
        }

        public static int AskNumber(string question)
        {
            int i;
            while (true)
            {
                Console.WriteLine(question);
                try
                {
                    i = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return i;
        }
    }
}
