using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class MoveCommandTests
	{
		[Test ()]
		public void TestInvalidPath ()
		{
			Player p = new Player ("Fred", "description");
			Location l1 = new Location (new string[] { "l1", "location1" }, "Location 1", "Location 1");
			Location l2 = new Location (new string[] { "l2", "location2" }, "Location 2", "Location 2");
			Path pth = new Path(new string[] {"e", "east"}, l2);

			p.Location = l1;
			l1.Path.Add(pth);
			MoveCommand m = new MoveCommand (new string[] { "move", "here" });
			m.Execute (p, new string[] { "move", "here" });

			Assert.AreEqual (l1, p.Location);
		}
	}
}

