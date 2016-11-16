using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class InventoryUnitTests
	{
		[Test ()]
		public void TestFindItem ()
		{
			Inventory inv = new Inventory();
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			inv.Put(itm);

			Assert.AreEqual (true, inv.HasItem("shovel"));
		}

		[Test ()]
		public void TestNoItemFind ()
		{
			Inventory inv = new Inventory();
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			inv.Put(itm);

			Assert.AreEqual (false, inv.HasItem("sword"));
		}

		[Test ()]
		public void TestFetchItem ()
		{
			Inventory inv = new Inventory();
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			inv.Put(itm);
			inv.Fetch ("shovel");
			Assert.AreEqual (true, inv.HasItem("shovel"));
		}

		[Test ()]
		public void TestTakeItem ()
		{
			Inventory inv = new Inventory();
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			inv.Put(itm);
			inv.Take ("shovel");
			Assert.AreEqual (false, inv.HasItem("shovel"));
		}

		[Test ()]
		public void TestItemList ()
		{
			Inventory inv = new Inventory();
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			inv.Put(itm1);
			inv.Put(itm2);
			Assert.AreEqual ("\tshovel (a shovel)\n\tsword (a sword)\n", inv.ItemList);
		}
	}
}

