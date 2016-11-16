using System;
using SwinGameSDK;

namespace MyGame
{
	public class HealthPack : PowerUp
	{
		public HealthPack ()
		{
			_bitmap = SwinGame.LoadBitmap ("Health.png");
			_name = "HealthPack";
		}
	}
}

