using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class PlayerUnitTests
	{
		[Test ()]
		public void TestPlayerIdentifiable ()
		{
			Player p = new Player ("Fred", "description");
			Assert.AreEqual (true, p.AreYou ("me"));
			Assert.AreEqual (true, p.AreYou ("inventory"));
		}

		[Test ()]
		public void TestPlayerLocatesItems ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			p.Inventory.Put(itm);

			p.Locate ("shovel");
			Assert.AreEqual (itm, p.Locate ("shovel"));
		}

		[Test ()]
		public void TestPlayerLocatesItself ()
		{
			Player p = new Player ("Fred", "description");

			Assert.AreEqual (p, p.Locate ("me"));
			Assert.AreEqual (p, p.Locate ("inventory"));
		}

		[Test ()]
		public void TestPlayerLocatesNothing ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			p.Inventory.Put(itm);

			Assert.AreEqual (null, p.Locate ("sword"));
		}

		[Test ()]
		public void TestPlayerFullDescription ()
		{
			Player p = new Player ("Fred", "description");
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			p.Inventory.Put(itm1);
			p.Inventory.Put(itm2);

			Assert.AreEqual ("You are carrying:\n\tshovel (a shovel)\n\tsword (a sword)\n", p.FullDescription);
		}
	}
}

