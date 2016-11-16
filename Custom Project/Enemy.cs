using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Enemy : Character
	{
		private int _level;
		public int Level
		{
			get
			{
				return _level;
			}

			set
			{
				_level = value;
			}
		}

		private Timer _timer;

		public Enemy (int x, int y, int l)
		{
			_x = x;
			_y = y;
			_level = l;
			double rnd = SwinGame.Rnd ();

			if (rnd < 0.25 )
			{
				_dx = 3;
				_dy = -3;
			}
			else if (rnd < 0.5)
			{
				_dx = 3;
				_dy = 3;
			}
			else if (rnd < 0.75)
			{
				_dx = -3;
				_dy = 3;
			}
			else if (rnd >= 0.75)
			{
				_dx = -3;
				_dy = -3;
			}


			_health = 80 + _level * 20;
			_bitmap = SwinGame.LoadBitmap ("Enemy.png");

			_timer = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_timer);
		}

		public override void Reset()
		{
			if (_level == Game.Level)
			{
				if (_health < 1)
					Game.EnemyCount++;
				_x = SwinGame.Rnd (800 - 40);
				_y = SwinGame.Rnd (200 - 31);
				_health = 80 + _level * 20;
				_bitmap = SwinGame.LoadBitmap ("Enemy.png");
				double rnd = SwinGame.Rnd ();

				if (rnd < 0.25 )
				{
					_dx = 3;
					_dy = -3;
				}
				else if (rnd < 0.5)
				{
					_dx = 3;
					_dy = 3;
				}
				else if (rnd < 0.75)
				{
					_dx = -3;
					_dy = 3;
				}
				else if (rnd >= 0.75)
				{
					_dx = -3;
					_dy = -3;
				}

				SwinGame.ResetTimer (_timer);
			}
		}

		public override void Draw ()
		{
			_x += _dx;
			_y += _dy;
			SwinGame.DrawBitmap (_bitmap, _x, _y);
			foreach (Bullet b in _bullets)
				b.Draw ();

			if (_health >= 70)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Green, _x+7, _y-10);
			else if (_health >= 40)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Gold, _x+7, _y-10);
			else if (_health > 0)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Red, _x+7, _y-10);
		}

		public override void Shoot (int dx, int dy)
		{
			Bullet b = new Bullet ("EnemyBullet.png", _x + 5, _y + 23, dx, dy);
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

			if ((_y < 1) || ((_y + SwinGame.BitmapHeight(_bitmap)) > (SwinGame.ScreenHeight() - 1)))
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

			if ((_timer.Ticks > 1999) && (_health > 0))
			{
				Shoot (0, -10);
				Shoot (10, 0);
				Shoot (0, 10);
				Shoot (-10, 0);
				SwinGame.ResetTimer (_timer);
			}

			Bounce ();

			//if Method() == true then doSomething.
			//e.g. check all Collision methods.
		}
	}
}

