using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public abstract class Character
	{
		protected int _x;
		public int X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		protected int _y;
		public int Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		protected int _dx;
		public int Dx
		{
			get
			{
				return _dx;
			}

			set
			{
				_dx = value;
			}
		}

		protected int _dy;
		public int Dy
		{
			get
			{
				return _dy;
			}

			set
			{
				_dy = value;
			}
		}

		protected int _health;
		public int Health
		{
			get
			{
				return _health;
			}
		}

		protected Bitmap _bitmap;
		public Bitmap Bitmap
		{
			get
			{
				return _bitmap;
			}
			set
			{
				_bitmap = value;
			}
		}

		protected List<Bullet> _bullets;
		public List<Bullet> Bullets
		{
			get
			{
				return _bullets;
			}
		}

		public Character ()
		{
			_bullets = new List<Bullet> ();
		}

		public abstract void Reset ();
		public abstract void Draw ();
		public abstract void Shoot(int dx, int dy);
		public abstract void Update ();
	}
}

