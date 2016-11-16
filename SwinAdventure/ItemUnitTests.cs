using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class ItemUnitTests
	{
		[Test ()]
		public void TestItemisIdentifiable ()
		{
			Item itm = new Item(new string[] {"shovel", "spade"}, "a shovel", "description");
			Assert.AreEqual (true, itm.AreYou ("shovel"));
		}

		[Test ()]
		public void TestShortDescription ()
		{
			Item itm = new Item(new string[] {"shovel", "spade"}, "a shovel", "description");
			Assert.AreEqual ("shovel (a shovel)", itm.ShortDescription);
		}

		[Test ()]
		public void TestFullDescription ()
		{
			Item itm = new Item(new string[] {"shovel", "spade"}, "a shovel", "description");
			Assert.AreEqual ("description", itm.FullDescription);
		}
	}
}

