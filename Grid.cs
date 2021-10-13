using System;
using System.Collections.Generic;

namespace Jeu_de_la_vie
{
	public class Grid
	{
		int _n;
		Cell[,] tabCell;
		public Grid(int nbCells, List<Coords> aliveCellsCoords)
		{
			_n = nbCells;
			tabCell = new Cell[_n, _n];

			for (int i = 0; i < _n; i++)
			{
				for (int j = 0; j < _n; j++)
				{
					tabCell[i, j] = new Cell(false);
				}
			}

			foreach (Coords coord in aliveCellsCoords)
			{
				tabCell[coord._x, coord._y] = new Cell(true);
			}
		}
		public int getNbAliveNeighboor(int i, int j)
		{
			int nbAliveNeighboor = 0;
			List<Coords> coordsNeighboor = GetCoordsNeighboor(i, j);
			foreach (Coords coord in coordsNeighboor)
			{
				try
				{
					if (tabCell[coord._x, coord._y]._isAlive)
					{
						nbAliveNeighboor++;
					}
				}
				catch (Exception)
				{
					continue;
				}
			}
			return nbAliveNeighboor;
		}

		public List<Coords> GetCoordsNeighboor(int i, int j)
		{
			List<Coords> coordsNeighboor = new List<Coords>();
			for (int x = -1; x < 2; x++)
			{
				for (int y = -1; y < 2; y++)
				{
					if ((x != 0 || y != 0))
					{
						coordsNeighboor.Add(new Coords(i + x, j + y));
					}
				}
			}
			return coordsNeighboor;
		}
		public List<Coords> GetCoordsCellsAlive()
		{
			List<Coords> cellsAlive = new List<Coords>();
			for (int x = 0; x < _n; x++)
			{
				for (int y = 0; y < _n; y++)
				{
					if ((x != 0 || y != 0))
					{
						cellsAlive.Add(new Coords(x, y));
					}
				}
			}
			return cellsAlive;
		}

		public void DisplayGrid()
        {
			Console.Clear();

			string barre = "+";
            for (int i = 0; i < _n; i++)
            {
				barre += "---+";
            }

            for (int i = 0; i < _n; i++)
            {

				string ligne = "|";
				for (int j = 0; j < _n; j++)
				{
					ligne += String.Format(" {0} |",tabCell[i,j]._isAlive ? "X": " ");
				}
				Console.WriteLine($"{barre}\n{ligne}");
			}
			Console.WriteLine(barre);
        }

		public void UpdateGrid()
        {
			DisplayGrid();
			for (int i = 0; i < _n; i++)
            {
				for (int j = 0; j < _n; j++)
				{
					Cell cell = tabCell[i, j];
                    if (!cell._isAlive && getNbAliveNeighboor(i,j) == 3)
                    {
						cell.ComeAlive();
					}
					else if(cell._isAlive && (getNbAliveNeighboor(i,j) < 2 || getNbAliveNeighboor(i,j) > 3))
                    {
						cell.PassAway();
                    }
				}
			}
			foreach(Cell cell in tabCell)
            {
				cell.Update();
            }

        }
	}
}

