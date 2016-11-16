using System;
using SwinGameSDK;

namespace MyGame
{
	public class SpeedBoost : PowerUp
	{
		public SpeedBoost ()
		{
			_bitmap = SwinGame.LoadBitmap ("Speed.png");
			_name = "SpeedBoost";
		}
	}
}

