using NUnit.Framework;
using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	[TestFixture ()]
	public class ShapeTests
	{
		[Test ()]
		public void TestShapeAt ()
		{
			Rectangle s = new Rectangle ();

			s.X = 25;
			s.Y = 25;
			s.width = 50;
			s.height = 50;

			//Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50), s.X, s.Y, s.width, s.height));
			//Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25), s.X, s.Y, s.width, s.height));
			//Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50), s.X, s.Y, s.width, s.height));
			//Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10), s.X, s.Y, s.width, s.height));
		}

		[Test ()]
		public void TestShapeAtWhenMoved ()
		{
			Rectangle s = new Rectangle ();

			s.X = 0;
			s.Y = 0;
			s.width = 100;
			s.height = 100;

			//Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50), s.X, s.Y, s.width, s.height));

			s.X = 100;
			s.Y = 100;
			s.width = 100;
			s.height = 100;

			//Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 50), s.X, s.Y, s.width, s.height));
		}

		[Test ()]
		public void TestShapeAtWhenResized ()
		{
			Rectangle s = new Rectangle ();

			s.X = 0;
			s.Y = 0;
			s.width = 200;
			s.height = 200;

			//Assert.IsTrue (s.IsAt (SwinGame.PointAt (150, 150), s.X, s.Y, s.width, s.height));

			s.X = 0;
			s.Y = 0;
			s.width = 100;
			s.height = 100;

			//Assert.IsFalse (s.IsAt (SwinGame.PointAt (150, 150), s.X, s.Y, s.width, s.height));
		}

		[Test ()]
		public void TestShapeSelectedValue ()
		{
			Shape r = new Rectangle ();
			Shape c = new Circle ();

			r.selected = true;
			Assert.IsTrue (r.selected == true);
			c.selected = true;
			Assert.IsTrue (c.selected == true);

			r.selected = false;
			Assert.IsFalse (r.selected == true);
			c.selected = false;
			Assert.IsFalse (r.selected == true);
		}

		[Test ()]
		public void TestSecondShapeConstructor ()
		{
			Rectangle s = new Rectangle (Color.Red, 55, 55, 90, 90);
			Assert.AreEqual (Color.Red, s.color);
			Assert.AreEqual (55, s.X);
			Assert.AreEqual (55, s.Y);
			Assert.AreEqual (90, s.width);
			Assert.AreEqual (90, s.height);
		}
	}
}