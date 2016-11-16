using System;
using SwinGameSDK;

namespace MyGame
{
	public class Bullet
	{
		private int _x;
		public int X
		{
			get
			{
				return _x;
			}
		}

		private int _y;
		public int Y
		{
			get
			{
				return _y;
			}
		}
		private int _dx;
		public int Dx
		{
			set
			{
				_dx = value;
			}
		}

		private int _dy;
		public int Dy
		{
			set
			{
				_dy = value;
			}
		}

		private Bitmap _bitmap;
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

		public Bullet (string bmp, int x, int y, int dx, int dy)
		{
			_x = x;
			_y = y;
			_dx = dx;
			_dy = dy;
			_bitmap = SwinGame.LoadBitmap (bmp);
		}

		public void Draw()
		{
			SwinGame.DrawBitmap (_bitmap, _x, _y);
			_x += _dx;
			_y += _dy;
		}
	}
}

