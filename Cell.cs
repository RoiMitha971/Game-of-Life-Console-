using System;

namespace Jeu_de_la_vie
{
	public class Cell
	{
		public bool _isAlive { get; private set; } = false;
		bool nextState { get; set; } = false;
		public Cell(bool state)
		{
			_isAlive = state;

			//La cellule conservera son état jusqu'a ce qu'on l'update
			nextState = state;
		}
		public void ComeAlive()
		{
			nextState = true;
		}
		public void PassAway()
		{
			nextState = false;
		}
		public void Update()
		{
			_isAlive = nextState;
		}
	}

}
