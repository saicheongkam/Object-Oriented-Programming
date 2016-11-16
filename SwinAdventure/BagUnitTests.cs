using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class BagUnitTests
	{
		[Test ()]
		public void TestBagLocatesItems ()
		{
			Bag b = new Bag (new string[] {"bag", "sack"}, "a bag", "description");
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			b.Inventory.Put(itm);

			b.Locate ("shovel");
			Assert.AreEqual (itm, b.Locate ("shovel"));
		}

		[Test ()]
		public void TestBagLocatesItself ()
		{
			Bag b = new Bag (new string[] {"bag", "sack"}, "a bag", "description");

			Assert.AreEqual (b, b.Locate ("bag"));
			Assert.AreEqual (b, b.Locate ("sack"));
		}

		[Test ()]
		public void TestBagLocatesNothing ()
		{
			Bag b = new Bag (new string[] {"bag", "sack"}, "a bag", "description");
			Item itm = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			b.Inventory.Put(itm);

			Assert.AreEqual (null, b.Locate ("sword"));
		}


		[Test ()]
		public void TestBagFullDescription ()
		{
			Bag b = new Bag (new string[] {"bag", "sack"}, "a bag", "description");
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			b.Inventory.Put(itm1);
			b.Inventory.Put(itm2);

			Assert.AreEqual ("In the a bag you can see:\n\tshovel (a shovel)\n\tsword (a sword)\n", b.FullDescription);
		}

		[Test ()]
		public void TestBagInBag ()
		{
			Bag b1 = new Bag (new string[] {"bag1", "sack1"}, "a bag1", "description1");
			Bag b2 = new Bag (new string[] {"bag2", "sack2"}, "a bag2", "description2");
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			b1.Inventory.Put(itm1);
			b1.Inventory.Put(itm2);
			b1.Inventory.Put (b2);

			Item itm3 = new Item (new string[] {"pc", "computer"}, "a computer", "description");
			Item itm4 = new Item (new string[] {"gem", "jewel"}, "a red gem", "description");
			b2.Inventory.Put(itm3);
			b2.Inventory.Put(itm4);

			Assert.AreEqual (itm1, b1.Locate ("shovel"));
			Assert.AreEqual (itm2, b1.Locate ("sword"));
			Assert.AreEqual (b2, b1.Locate ("bag2"));
			Assert.AreEqual (null, b1.Locate ("pc"));
			Assert.AreEqual (null, b1.Locate ("gem"));
		}
	}
}

