// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
	public class Coord {
		public readonly double X;
	    public readonly double Y;

		public Coord(double coordX, double coordY) {
			X = coordX;
			Y = coordY;
		}
		
		public override string ToString(){
			return $"({X},{Y})";
		}
	}
}