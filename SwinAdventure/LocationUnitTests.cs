using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class LocationUnitTests
	{
		[Test ()]
		public void TestIdentifySelf ()
		{
			Location l = new Location (new string[] { "here", "location1" }, "location1", "description");

			Assert.AreEqual (true, l.AreYou ("here"));
			Assert.AreEqual (true, l.AreYou ("location1"));
		}

		[Test ()]
		public void TestIdentifyItems ()
		{
			Location l = new Location (new string[] { "here", "location1" }, "location1", "description");
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			l.Add (itm1);
			l.Add (itm2);

			Assert.AreEqual (itm1, l.Locate ("shovel"));
			Assert.AreEqual (itm2, l.Locate ("sword"));
		}

		[Test ()]
		public void PlayerIdentifyLocationItems ()
		{
			Location l = new Location (new string[] { "here", "location1" }, "location1", "description");
			Item itm1 = new Item (new string[] {"shovel", "spade"}, "a shovel", "description");
			Item itm2 = new Item (new string[] {"sword", "blade"}, "a sword", "description");
			l.Add (itm1);
			l.Add (itm2);

			Player p = new Player ("Fred", "description");
			p.Location = l;

			Assert.AreEqual (itm1, p.Locate ("shovel"));
			Assert.AreEqual (itm2, p.Locate ("sword"));
		}
	}
}

