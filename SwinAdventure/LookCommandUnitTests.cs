using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class LookCommandUnitTests
	{
		[Test ()]
		public void TestLookAtMe ()
		{
			Player p = new Player ("Fred", "description");
			LookCommand c = new LookCommand (new string[] {"look", "at", "inventory"});

			Assert.AreEqual(p.FullDescription, c.Execute (p, new string[] {"look", "at", "inventory"}));
		}

		[Test ()]
		public void TestLookAtGem ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] { "gem", "jewel" }, "a gem", "description");
			p.Inventory.Put (itm);
			LookCommand c = new LookCommand (new string[] {"look", "at", "gem"});

			Assert.AreEqual(itm.FullDescription, c.Execute (p, new string[] {"look", "at", "gem"}));
		}

		[Test ()]
		public void TestLookAtUnk ()
		{
			Player p = new Player ("Fred", "description");
			LookCommand c = new LookCommand (new string[] {"look", "at", "gem"});

			Assert.AreEqual("I can't find the gem in the inventory", c.Execute (p, new string[] {"look", "at", "gem"}));
		}

		[Test ()]
		public void TestLookAtGemInMe ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] { "gem", "jewel" }, "a gem", "description");
			p.Inventory.Put (itm);
			LookCommand c = new LookCommand (new string[] {"look", "at", "gem", "in", "inventory"});

			Assert.AreEqual(itm.FullDescription, c.Execute (p, new string[] {"look", "at", "gem", "in", "inventory"}));
		}

		[Test ()]
		public void TestLookAtGemInNoBag ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] { "gem", "jewel" }, "a gem", "description");
			p.Inventory.Put (itm);
			LookCommand c = new LookCommand (new string[] {"look", "at", "gem", "in", "bag"});

			Assert.AreEqual("I can't find the gem in the bag", c.Execute (p, new string[] {"look", "at", "gem", "in", "bag"}));
		}

		[Test ()]
		public void TestLookAtNoGemInBag ()
		{
			Player p = new Player ("Fred", "description");
			Item itm = new Item (new string[] { "gem", "jewel" }, "a gem", "description");
			Bag b = new Bag (new string[] { "bag", "sack" }, "a bag", "description");
			p.Inventory.Put (itm);
			p.Inventory.Put (b);
			LookCommand c = new LookCommand (new string[] {"look", "at", "gem", "in", "bag"});

			Assert.AreEqual("I can't find the gem in the bag", c.Execute (p, new string[] {"look", "at", "gem", "in", "bag"}));
		}

		[Test ()]
		public void TestInvalidLook ()
		{
			Player p = new Player ("Fred", "description");
			LookCommand c = new LookCommand (new string[] {"look", "at", "object"});

			Assert.AreEqual("I don't know how to look like that", c.Execute (p, new string[] {"look", "around"}));
			Assert.AreEqual("Error in look input", c.Execute (p, new string[] {"check", "around", "here"}));
			Assert.AreEqual("Where do you want to look at?", c.Execute (p, new string[] {"look", "in", "hole"}));
			Assert.AreEqual("What do you want to look in?", c.Execute (p, new string[] {"look", "at", "gem", "on", "ground"}));
		}
	}
}

