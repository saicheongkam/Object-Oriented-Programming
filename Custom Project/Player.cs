using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Player : Character
	{
		List<PowerUp> _powerUp;
		public List <PowerUp> PowerUps
		{
			get
			{
				return _powerUp;
			}
		}

		private int _ammo;
		public int Ammo
		{
			get
			{
				return _ammo;
			}
		}

		private int _boost;
		public int Boost
		{
			get
			{
				return _boost;
			}
		}

		private bool _big;

		private Timer _speedTimer;

		private Timer _bigTimer;

		public Player () : this (380, 500)
		{
		}

		public Player (int x, int y)
		{
			_x = x;
			_y = y;
			_health = 100;
			_ammo = 20 + 10 * Game.Level;
			_boost = 0;
			_big = false;
			_speedTimer = SwinGame.CreateTimer ();
			_bigTimer = SwinGame.CreateTimer ();
			_bitmap = SwinGame.LoadBitmap ("Player.png");
			_powerUp = new List<PowerUp> ();
		}

		public override void Reset()
		{
			_x = 380;
			_y = 500;
			_health = 100;
			_ammo = 20 + 10 * Game.Level;
			_boost = 0;
			_big = false;
			_bitmap = SwinGame.LoadBitmap ("Player.png");
			_bullets.Clear ();
		}

		public override void Draw ()
		{
			SwinGame.DrawBitmap (_bitmap, _x, _y);
			foreach (Bullet b in _bullets)
				b.Draw ();
				
			if (_health >= 70)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Green, _x+7, _y-10);
			else if (_health >= 40)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Gold, _x+7, _y-10);
			else if (_health > 0)
				SwinGame.DrawText (_health.ToString(), SwinGameSDK.Color.Red, _x+7, _y-10);

			SwinGame.DrawText ("Ammo: " + _ammo.ToString (), SwinGameSDK.Color.Blue, 2, 590);
		}

		public override void Shoot (int dx, int dy)
		{
			_ammo -= 1;
			if (_ammo < 0)
				_ammo = 0;
			if (_big == true)
				{
				Bullet b = new Bullet ("BigBullet.png", _x - 10, _y + 14, dx, dy);
					_bullets.Add (b);
				}
				else
				{
				Bullet b = new Bullet ("Bullet.png", _x + 5, _y + 21, dx, dy);
					_bullets.Add (b);
				}
		}
			
		public PowerUp CollisionPowerUp ()
		{
			foreach (PowerUp p in Game.PowerUps)
			{
				if (SwinGame.BitmapCollision (_bitmap, _x, _y, p.Bitmap, p.X, p.Y))
				{
					Game.PowerUps.Remove (p);
					return p;
				}
			}
			return null;
		}

		public bool CollisionEnemyBullet ()
		{
			foreach (Character e in Game.Characters)
			{
				if ((e is Enemy) || (e is Boss))
				{
					foreach (Bullet b in e.Bullets)
					{
						if (SwinGame.BitmapCollision (_bitmap, _x, _y, b.Bitmap, b.X, b.Y))
						{
							e.Bullets.Remove (b);
							return true;
						}
					}
				}
			}
			return false;
		}


		public override void Update ()
		{
			PowerUp PwrUp = CollisionPowerUp ();

			if (PwrUp != null)
			{
				switch (PwrUp.Name)
				{
				case "HealthPack":
					if ((_health > 0) && (_health <= 50))
						_health += 50;
					else if (_health > 50)
						_health = 100;
					break;

				case "AmmoPack":
					_ammo += 30;
					break;

				case "SpeedBoost":
					_boost = 2;
					_powerUp.Clear ();
					_powerUp.Add (PwrUp);
					SwinGame.ResetTimer (_speedTimer);
					SwinGame.StartTimer (_speedTimer);
					break;

				case "BigBullets":
					_big = true;
					_powerUp.Clear ();
					_powerUp.Add (PwrUp);
					SwinGame.ResetTimer (_bigTimer);
					SwinGame.StartTimer (_bigTimer);
					break;
				}
			}

			if (CollisionEnemyBullet ())
				_health -= 10;

			if (SwinGame.TimerTicks (_speedTimer) > 6999)
			{
				_boost = 0;
				_powerUp.Clear ();
			}

			if (SwinGame.TimerTicks (_bigTimer) > 9999)
			{
				_big = false;
				_powerUp.Clear ();
			}


			//if Method() == true then doSomething.
			//e.g. check all Collision methods.
		}
	}
}

