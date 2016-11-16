using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class CommandProcessorUnitTests
	{
		[Test ()]
		public void TestLookCommand ()
		{
			Player p = new Player ("Fred", "description");
			CommandProcessor cp = new CommandProcessor ();

			Assert.AreEqual(p.FullDescription, cp.Execute(p, new string[] {"look", "at", "inventory"}));
		}

		[Test ()]
		public void TestMoveCommand ()
		{
			Player p = new Player ("Fred", "description");
			Location l1 = new Location (new string[] { "l1", "location1" }, "Location 1", "Location 1");
			Location l2 = new Location (new string[] { "l2", "location2" }, "Location 2", "Location 2");
			Path pth = new Path(new string[] {"n", "north"}, l2);
			l1.Path.Add (pth);
			p.Location = l1;
			CommandProcessor cp = new CommandProcessor ();

			Assert.AreEqual(l2.FullDescription, cp.Execute(p, new string[] {"move", "north"}));
		}
	}
}

