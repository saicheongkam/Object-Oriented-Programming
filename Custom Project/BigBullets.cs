using System;
using SwinGameSDK;

namespace MyGame
{
	public class BigBullets : PowerUp
	{
		public BigBullets ()
		{
			_bitmap = SwinGame.LoadBitmap ("BigBullets.png");
			_name = "BigBullets";
		}
	}
}

