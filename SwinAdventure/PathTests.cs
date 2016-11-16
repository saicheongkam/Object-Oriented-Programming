using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class PathTests
	{
		[Test ()]
		public void TestMovePlayer ()
		{
			Player p = new Player ("Fred", "description");
			Location l1 = new Location (new string[] { "l1", "location1" }, "Location 1", "Location 1");
			Location l2 = new Location (new string[] { "l2", "location2" }, "Location 2", "Location 2");

			p.Location = l1;
			Path pth = new Path(new string[] {"e", "east"}, l2);
			pth.Move (p);

			Assert.AreEqual(l2, pth.Destination);
		}

		[Test ()]
		public void TestGetPath ()
		{
			Location l1 = new Location (new string[] { "l1", "location1" }, "Location 1", "Location 1");
			Path pth = new Path(new string[] {"e", "east"}, l1);
			l1.Path.Add(pth);

			Assert.AreEqual(true, pth.AreYou ("e"));
			Assert.AreEqual(true, pth.AreYou ("east"));
		}
	}
}

