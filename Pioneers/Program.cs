using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Catan
{
	private List<player> players;
	private theMap map;

	public enum resources
	{ Desert, Brick, Wheat, Ore, Wood, Sheep };

	public class tile
	{
		int roll;
		resources type;

		public tile(int r, resources t)
		{
			roll = r;
			type = t;
		}
	}

	public class segments
	{
		int a; // todo: I don't like this. 
		int b;

		public segments(int end1, int end2)
		{
			a = end1;
			b = end2;
		}
	}

	public class theMap
	{
		List<tile> tiles;
		List<segments> roads;

		public theMap()
		{
			tiles = new List<tile>(19);
			roads = new List<segments>(72);

			segments[] z = { new segments(1, 2), new segments(1, 3), new segments(1, 5) }; // repeat * infinity
			roads.AddRange(z);

			//3 brick, 4 wheat, 3 ore, 4 wood, 4 sheep, 1 desert = 19 tiles
			//2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12 = 19 rolls = 7 is robber

			List<resources> r = new List<resources> { resources.Brick, resources.Brick, resources.Brick, resources.Ore, resources.Ore, resources.Ore, resources.Sheep, resources.Sheep, resources.Sheep, resources.Sheep, resources.Wheat, resources.Wheat, resources.Wheat, resources.Wheat, resources.Wood, resources.Wood, resources.Wood, resources.Wood, resources.Desert };
			List<int> s = new List<int> { 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12 };

			Random rtile = new Random();
			Random rroll = new Random();

			while (r.Count() > 0)
			{ // Pick random resource type and roll out of the array. Once done, remove those from array (so we don't get duplicates)
				int theroll = rroll.Next(s.Count);
				resources resourcetype = (resources)r[rtile.Next(r.Count)];
				tile newTile;

				if (theroll == 7 || resourcetype == resources.Desert)
				{
					newTile = new tile(7, resources.Desert);
				}
				else
				{
					newTile = new tile(theroll, resourcetype);
				}

				tiles.Add(newTile);

				r.Remove(resourcetype);
				s.Remove(theroll);
			} // End While

		}
	}
	public class cities
	{
		bool isCity;
		int jct;
	}

	public class player
	{
		List<segments> roads;
		List<int> cards;
		List<cities> cities;

	}

	public Catan(int numberOfPlayers)
	{
		players = new List<player>(numberOfPlayers);
		map = new theMap();
	}
}