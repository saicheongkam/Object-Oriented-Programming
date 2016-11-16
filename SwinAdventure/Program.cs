using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
			Console.WriteLine ("Enter your player's name: ");
			string PlayerName = Console.ReadLine ();

			Console.WriteLine ("Enter your player's description: ");
			string PlayerDesc = Console.ReadLine ();
		
			Player player = new Player (PlayerName, PlayerDesc);
			Location garden = new Location (new string[] { "garden", "grassland" }, "a small garden", "flowers pop up above the lush, green grass in this little garden");
			Location cave = new Location (new string[] { "cave", "dungeon" }, "a dark cave", "you hear echoes coming from the end of this cave as rocks crumble away from the walls");
			Path pth = new Path(new string[] {"e", "east"}, cave);
			player.Location = garden;

			Item shovel = new Item(new string[] {"shovel", "spade"}, "a shovel", "Discover hidden treasures beneath the ground with this shovel!");
			Item sword = new Item(new string[] {"sword", "blade"}, "a sword", "Slay the most fearsome monsters with this incredibly sharp sword!");

			Item gem = new Item (new string[] {"gem", "jewel"}, "a red gem", "A big, shiny red Ruby. You'd better keep this safe.");

			Item gold = new Item (new string[] {"gold", "goldium"}, "a gold nugget", "A small gold nugget. This will be useful later.");
			Item club = new Item (new string[] {"club", "bat"}, "a wooden club", "Knock out monsters with a swing of this chunky, wooden club!");
			Item shield = new Item (new string[] {"shield", "defense"}, "a metal shield", "Protect yourself from attacks with this shield!");

			Bag bag = new Bag (new string[] {"bag", "sack"}, "a bag", "Keep your items safe and secure inside this leather bag!");

			bag.Inventory.Put(gem);
			player.Inventory.Put(bag);
			player.Inventory.Put(shovel);
			player.Inventory.Put(sword);

			garden.Add (gold);
			garden.Add (club);
			garden.Add (shield);
			garden.Path.Add (pth);

			Console.WriteLine ("Enter your commands");

			int i = 0;
			while (i == 0)
			{
				string word = Console.ReadLine ();
				string [] words = word.Split (new char[] {' '});
				CommandProcessor cp = new CommandProcessor();
				Console.WriteLine(cp.Execute (player, words));
				Console.ReadLine ();
			}
		}
	}
}
