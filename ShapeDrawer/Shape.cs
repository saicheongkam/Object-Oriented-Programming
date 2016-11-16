using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public abstract class Shape
	{
		private Color _color;
		public Color color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		private float _x, _y;
		public float X
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

		public float Y
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

		private bool _selected;

		public bool selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}

		public Shape ()
		{
			color = Color.Green;
			//_color = color;
			X = 0;
			//_x = X;
			Y = 0;
			//_y = Y;
		}

		public Shape (Color color)
		{
			_color = color;
			_x = X;
			_y = Y;
		}

		public abstract void Draw ();

		public abstract bool IsAt (Point2D pt);

		public abstract void DrawOutline ();

	}
}

