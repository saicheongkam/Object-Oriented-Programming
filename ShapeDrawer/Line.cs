using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Line : Shape
	{

		private float _endX, _endY;
		public float endX
		{
			get
			{
				return _endX;
			}
			set
			{
				_endX = value;
			}
		}

		public float endY
		{
			get
			{
				return _endY;
			}
			set
			{
				_endY = value;
			}
		}

		public Line () : this(SwinGame.Rnd(800), SwinGame.Rnd(600))
		{
		}

		public Line (float endX, float endY)
		{
			_endX = endX;
			_endY = endY;
		}

		public override void Draw ()
		{
			if (selected)
				DrawOutline ();
			SwinGame.DrawLine (color, X, Y, _endX, _endY);
		}

		public override void DrawOutline ()
		{
			SwinGame.FillCircle (Color.Black, X, Y, 4);
			SwinGame.FillCircle (Color.Black, _endX, _endY, 4);
		}

		public override bool IsAt(Point2D pt)
		{
			return SwinGame.PointOnLine (pt, X, Y, _endX, _endY);
		}
	}
}

