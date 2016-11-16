using NUnit.Framework;
using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture ()]
	public class CharacterUnitTests
	{
		[Test ()]
		public void TestStartingHealth ()
		{
			Player p = new Player ();
			Enemy e = new Enemy (200, 80, 3);

			Assert.AreEqual (100, p.Health);
			Assert.AreEqual (80 + 3 * 20, e.Health);
		}

		[Test ()]
		public void TestPlayerStartingXY ()
		{
			Player p = new Player ();

			Assert.AreEqual (380, p.X);
			Assert.AreEqual (500, p.Y);
		}

		[Test ()]
		public void TestShoot ()
		{
			Player p = new Player ();
			Enemy e = new Enemy (200, 80, 1);

			p.Shoot (0, -10);
			p.Shoot (10, 0);
			e.Shoot (0, -10);

			Assert.AreEqual (2, p.Bullets.Count);
			Assert.AreEqual (1, e.Bullets.Count);
		}

		[Test ()]
		public void TestCollisionBullet ()
		{
			Player p = new Player (0, 0);
			Enemy e = new Enemy (0, 0, 1);
			Game.Characters.Add (p);
			Game.Characters.Add (e);

			foreach (Character c in Game.Characters)
			{
				c.Shoot (0, 0);
				c.Update ();
			}

			Assert.AreEqual (0, p.Bullets.Count);
			Assert.AreEqual (0, e.Bullets.Count);
			Assert.AreEqual (90, p.Health);
			Assert.AreEqual (80, e.Health);
		}

		[Test ()]
		public void TestPlayerCollisionPowerUp ()
		{
			Player p = new Player (0, 0);
			PowerUp s = new SpeedBoost ();
			Game.Characters.Add (p);
			Game.PowerUps.Add (s);

			p.X = s.X;
			p.Y = s.Y;

			foreach (Character c in Game.Characters)
			{
				c.Update ();
			}

			Assert.AreEqual (1, p.PowerUps.Count);

		}

		[Test ()]
		public void TestReset ()
		{
			Player p = new Player (0, 0);
			Enemy e = new Enemy (0, 0, 1);
			Game.Characters.Add (p);
			Game.Characters.Add (e);
			//Game.Level = 1;

			foreach (Character c in Game.Characters)
			{
				c.Reset ();
			}

			Assert.IsTrue ((p.X == 380) && (p.Y == 500));
			Assert.AreEqual (30, p.Ammo);
			Assert.AreEqual (100, p.Health);
			Assert.AreEqual (0, p.PowerUps.Count);
			Assert.AreEqual (0, p.Bullets.Count);
			Assert.AreEqual (80 + Game.Level * 20, e.Health);
			Assert.AreEqual (0, e.Bullets.Count);
		}
	}
}

