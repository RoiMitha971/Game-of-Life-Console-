using System;

namespace Jeu_de_la_vie
{
	public struct Coords
	{
		public readonly int _x;
		public readonly int _y;
		public Coords(int X, int Y)
		{
			_x = X;
			_y = Y;
		}
		public override string ToString()
		{
			string toString = $"{_x}{_y}";
			return toString;
		}
	}
}
