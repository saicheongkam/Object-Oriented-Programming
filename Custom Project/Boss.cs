using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Boss : Character
	{
		private Timer _shootTimer;

		public Boss ()
		{
			_x = 315;
			_y = 10;
			_dx = 1;
			_dy = -1;
			_health = 2000;
			_bitmap = SwinGame.LoadBitmap ("Boss.png");

			_shootTimer = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_shootTimer);
		}

		public override void Reset()
		{
			_x = 315;
			_y = 10;
			_dx = 1;
			_dy = -1;
			_health = 2000;
			_bitmap = SwinGame.LoadBitmap ("Boss.png");
		}

		public override void Draw ()
		{
			_x += _dx;
			_y += _dy;
			SwinGame.DrawBitmap (_bitmap, _x, _y);
			foreach (Bullet b in _bullets)
				b.Draw ();

			if (_health >= 1300)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Green, _x+77, _y+30);
			else if (_health >= 600)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Gold, _x+77, _y+30);
			else if (_health > 0)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Red, _x+77, _y+30);
		}

		public override void Shoot (int dx, int dy)
		{
			Bullet b = new Bullet ("EnemyBullet.png", _x + 95, _y + 94, dx, dy);
			_bullets.Add (b);
		}

		public bool CollisionPlayerBullet ()
		{
			foreach (Character p in Game.Characters)
			{
				if (p is Player)
				{
					if ((SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X, p.Y - 10)) 
						&& (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X, p.Y + 10) == false))   //Bump Up
					{
						if (_dy > 0)
						{
							_dy *= -1;
							_health -= 5;
						}
					}

					if (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X, p.Y + 10)
						&& (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X, p.Y - 10) == false))   //Bump Down
					{
						if (_dy < 0)
						{
							_dy *= -1;
							_health -= 5;
						}
					}

					if (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X + 10, p.Y)
						&& (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X - 10, p.Y) == false))   //Bump Right
					{
						if (_dx < 0)
						{
							_dx *= -1;
							_health -= 5;
						}
					}

					if (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X - 10, p.Y)
						&& (SwinGame.BitmapCollision (_bitmap, _x, _y, SwinGame.LoadBitmap ("Player.png"), p.X + 10, p.Y) == false))   //Bump left
					{
						if (_dx > 0)
						{
							_dx *= -1;
							_health -= 5;
						}
					}

					foreach (Bullet b in p.Bullets)
					{
						if (SwinGame.BitmapCollision (_bitmap, _x, _y, b.Bitmap, b.X, b.Y))
						{
							p.Bullets.Remove (b);
							return true;
						}
					}
				}
			}
			return false;
		}

		public void Bounce ()
		{
			if ((_x < 1) || ((_x + SwinGame.BitmapWidth(_bitmap)) > (SwinGame.ScreenWidth() - 1)))
				_dx *= -1;

			if ((_y < 1) || ((_y + SwinGame.BitmapHeight(_bitmap)) > 299))
				_dy *= -1;
		}


		public override void Update ()
		{
			if (CollisionPlayerBullet())
				_health -= 20;

			foreach (Bullet b in _bullets)
			{
				if ((b.X < -41) || (b.X > 810) || (b.Y < -25) || (b.Y > 610))
				{
					b.Dx = 0;
					b.Dy = 0;
				}
			}

			if ((_shootTimer.Ticks > 499) && (_health > 0))
			{
				foreach (Character c in Game.Characters)
				{
					if (c is Player)
						Shoot (((c.X - 100) - _x)/20, ((c.Y - 60) - _y)/20);
				}
				SwinGame.ResetTimer (_shootTimer);
			}

			Bounce ();

			//if Method() == true then doSomething.
			//e.g. check all Collision methods.
		}
	}
}

