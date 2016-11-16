using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Circle : Shape
	{
		private int _radius;
		public int radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public Circle () : this(50)
		{
		}

		public Circle(int radius)
		{
			_radius = radius;
		}

		public override void Draw ()
		{
			if (selected)
				DrawOutline ();
			SwinGame.FillCircle (color, X, Y, _radius);
		}

		public override void DrawOutline ()
		{
			SwinGame.FillCircle (Color.Black, X, Y, _radius + 2);
		}

		public override bool IsAt(Point2D pt)
		{
			return SwinGame.PointInCircle (pt, X, Y, _radius);
		}
	}
}

