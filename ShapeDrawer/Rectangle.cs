using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Rectangle : Shape
	{
		private int _width, _height;
		public int width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public int height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public Rectangle() : this(Color.Green, 0, 0, 100, 100)
		{
		}

		public Rectangle (Color clr, float x, float y, int width, int height) : base(clr)
		{
			color = clr;
			X = x;
			Y = y;
			_width = width;
			_height = height;
		}

		public override void Draw ()
		{
			if (selected)
				DrawOutline ();
			SwinGame.FillRectangle (color, X, Y, _width, _height);
		}

		public override void DrawOutline ()
		{
			SwinGame.FillRectangle (Color.Black, X-2, Y-2, _width + 4, _height + 4);
		}

		public override bool IsAt(Point2D pt)
		{
			return SwinGame.PointInRect (pt, X, Y, _width, _height);
		}
	}
}

