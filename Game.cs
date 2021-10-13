using System;
using System.Collections.Generic;

namespace Jeu_de_la_vie
{
	public class Game
	{
		int n;
		int iter;
		public Grid grid;
		List<Coords> aliveCellsCoords = new List<Coords>();
		Random random = new Random();
		public Game(int nbCells, int nbIterations)
		{
			n = nbCells;
			iter = nbIterations;
			int total = random.Next(n, n*n);
            for (int i = 0; i < total; i++)
            {
				aliveCellsCoords.Add(new Coords(random.Next(n), random.Next(n)));
            }
			grid = new Grid(nbCells, aliveCellsCoords);
		}

		public void RunGameConsole()
        {
            for (int i = 0; i < iter; i++)
            {
				grid.UpdateGrid();
				System.Threading.Thread.Sleep(1300);
            }
        }
	}
}

