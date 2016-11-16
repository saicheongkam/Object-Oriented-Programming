using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Game
	{
		private static int _level;
		public static int Level
		{
			get
			{
				return _level;
			}
		}

		private int _playerDead;

		private static int _enemyCount;
		public static int EnemyCount
		{
			get
			{
				return _enemyCount;
			}
			set
			{
				_enemyCount = value;
			}
		}

		private static List<Character> _characters;
		public static List<Character> Characters
		{
			get
			{
				return _characters;
			}
		}


		private static List<PowerUp> _powerups;
		public static List<PowerUp> PowerUps
		{
			get
			{
				return _powerups;
			}
		}

		private Timer _resetTimer;
		private Timer _pwrupTimer;


		public Game ()
		{
			_characters = new List<Character> ();
			_level = 1;
			_playerDead = 0;
			_enemyCount = 0;
			for (int i = 0; i < _level; i++)
			{
				_characters.Add (new Enemy (SwinGame.Rnd (798 - 40) + 1, SwinGame.Rnd (198 - 31) + 1, _level));
				_enemyCount++;
			}
			_powerups = new List<PowerUp> ();
			_resetTimer = SwinGame.CreateTimer ();
			_pwrupTimer = SwinGame.CreateTimer ();
			_pwrupTimer.Start ();
		}

		public void Reset()
		{
			if (_level < 10)
			{
				if (_enemyCount == -1)
					_enemyCount = 0;
				 
				foreach (Character c in _characters)
					c.Reset ();

				while (_enemyCount < _level)
				{
					_characters.Add (new Enemy (SwinGame.Rnd (798 - 40) + 1, SwinGame.Rnd (198 - 31) + 1, _level));
					_enemyCount++;
				}

				_powerups.Clear ();
			}
			else if (_level == 10)
			{
				if (_enemyCount == -1)
				{
					_enemyCount = 0;
					Game.Characters.Add (new Boss ());
					_enemyCount++;

					for (int i = 0; i < 4; i++)
					{
						_characters.Add (new Enemy (SwinGame.Rnd (798 - 40) + 1, SwinGame.Rnd (198 - 31) + 1, _level));
						_enemyCount++;
					}
				}

				foreach (Character c in _characters)
				{
					if (c is Boss)
					{
						if (c.Health < 1)
							_enemyCount++;
					}
				}
				foreach (Character c in _characters)
					c.Reset ();
				_powerups.Clear ();
			}
		}

			
		public void Draw ()
		{
			foreach (Character c in _characters)
				c.Draw ();
			foreach (PowerUp p in _powerups)
				p.Draw ();
		}


		public void Update()
		{
			foreach (Character c in _characters)
			{
				c.Update ();
				if ((c.Health < 1) && (c.Bitmap != SwinGame.LoadBitmap ("Blank 2.png")))
					c.Bitmap = SwinGame.LoadBitmap("Blank.png");   //"Kill" the Character

				if (c is Player)
				{
					if ((c.Health < 1) && (_playerDead == 0))
						_playerDead = 1;
				}

				if ((c is Enemy) || (c is Boss))
				{
					if (c.Bitmap == SwinGame.LoadBitmap ("Blank.png"))   //Reduce number of enemies for each Enemy killed
					{
						_enemyCount -= 1;
						c.Bitmap = SwinGame.LoadBitmap ("Blank 2.png");
					}
				}
			}

			if (_enemyCount < 1)   //If all enemies are dead, increase level and Reset for new level.
			{
				if (_enemyCount == 0)
				{
					_level++;
					SwinGame.StartTimer (_resetTimer);
					_enemyCount = -1;
				}

				if (SwinGame.TimerTicks (_resetTimer) > 2999)
				{
					SwinGame.StopTimer (_resetTimer);
					SwinGame.ResetTimer (_resetTimer);
					Reset ();
				}
			}

			if (_playerDead == 1)   //if Player is dead
			{
				SwinGame.StartTimer(_resetTimer);
				_playerDead = 2;
			}

			if (SwinGame.TimerTicks(_resetTimer) > 2999)   //Restarts level 3 seconds after Player dies
			{
				SwinGame.StopTimer (_resetTimer);
				SwinGame.ResetTimer (_resetTimer);
				_playerDead = 0;
				Reset ();
			}

			if (_pwrupTimer.Ticks > (4999))
			{
				SwinGame.StopTimer (_pwrupTimer);
				SwinGame.ResetTimer (_pwrupTimer);

				int rnd = SwinGame.Rnd (100);   //Randomizing the PowerUp to be spawned
				if (rnd <= 24)
					_powerups.Add(new HealthPack ());
				else if ((rnd > 24) && (rnd <= 49))
					_powerups.Add(new AmmoPack ());
				else if ((rnd > 49) && (rnd <= 74))
					_powerups.Add(new SpeedBoost ());
				else if (rnd > 74)
					_powerups.Add(new BigBullets ());

				SwinGame.StartTimer (_pwrupTimer);
			}
		}
	}
}

