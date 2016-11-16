using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	[TestFixture ()]
	public class IdentifiableObjectTests
	{
		[Test ()]
		public void TestCreation ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "A", "B" });
		}

		[Test ()]
		public void TestAreYou ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "Thing1", "Thing2" });
			Assert.AreEqual (true, id.AreYou ("Thing1"));
			Assert.AreEqual (true, id.AreYou ("Thing2"));
		}

		[Test ()]
		public void TestNotAreYou ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "Thing1", "Thing2" });
			Assert.AreEqual (false, id.AreYou ("Thing3"));
			Assert.AreEqual (false, id.AreYou ("Thing4"));
		}

		[Test ()]
		public void TestCaseSensitive ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "Thing1", "Thing2" });
			Assert.AreEqual (true, id.AreYou ("tHING1"));
			Assert.AreEqual (true, id.AreYou ("tHING2"));
		}

		[Test ()]
		public void TestFirstID ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "Item1", "Item2", "Item3" });
			Assert.AreEqual ("item1", id.FirstId);
		}

		[Test ()]
		public void TestAddID ()
		{
			IdentifiableObject id = new IdentifiableObject (new string[] { "A", "B" });
			id.AddIdentifier ("C");
			Assert.AreEqual(true, id.AreYou("C"));
		}
	}
}