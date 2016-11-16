using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class PowerUp
	{
		protected int _x;
		public int X
		{
			get
			{
				return _x;
			}
		}

		protected int _y;
		public int Y
		{
			get
			{
				return _y;
			}
		}

		protected int _dx;
		protected int _dy;

		protected string _name;
		public string Name
		{
			get
			{
				return _name;
			}
		}

		protected Bitmap _bitmap;
		public Bitmap Bitmap
		{
			get
			{
				return _bitmap;
			}
		}

		public PowerUp ()
		{
			_x = SwinGame.Rnd (100) + 350;
			_y = SwinGame.Rnd (100) + 250;

			do
			{
				_dx = SwinGame.Rnd (5) - 2;
				_dy = SwinGame.Rnd (5) - 2;
			}
			while ((_dx == 0) && (_dy == 0));
		}

		public void Draw()
		{
			_x += _dx;
			_y += _dy;
			SwinGame.DrawBitmap (_bitmap, _x, _y);
		}
	}
}

