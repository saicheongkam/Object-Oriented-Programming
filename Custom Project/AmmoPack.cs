using System;
using SwinGameSDK;

namespace MyGame
{
	public class AmmoPack : PowerUp
	{
		public AmmoPack ()
		{
			_bitmap = SwinGame.LoadBitmap ("Ammo.png");
			_name = "AmmoPack";
		}
	}
}

