using System;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
			SwinGame.OpenGraphicsWindow("ChickenKill", 800, 600);
			//SwinGame.ShowSwinGameSplashScreen ();
            
			Game game = new Game ();
			Player p = new Player ();
			Game.Characters.Add (p);


            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				//Clear the screen and draw the framerate
				SwinGame.ClearScreen(SwinGameSDK.Color.White);
				if (Game.Level < 11)
				{
					SwinGame.DrawBitmap (SwinGame.LoadBitmap ("Level " + Game.Level.ToString () + ".png"), 0, 0);
					if (Game.EnemyCount == -1)
						SwinGame.DrawBitmap (SwinGame.LoadBitmap ("Level " + (Game.Level - 1).ToString () + ".png"), 0, 0);
				}
				else
					SwinGame.DrawBitmap (SwinGame.LoadBitmap ("You Win.png"), 0, 0);

				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents();

				if (SwinGame.KeyDown (KeyCode.vk_UP) && ((SwinGame.ScreenHeight () - p.Y) < 600) && (p.Health > 0))
				{
					p.Y -= 4 + p.Boost;
				}			
				if (SwinGame.KeyDown (KeyCode.vk_RIGHT) && ((SwinGame.ScreenWidth () - SwinGame.BitmapWidth (p.Bitmap) - p.X) > 0) && (p.Health > 0))
				{
					p.X += 4 + p.Boost;
				}
				if (SwinGame.KeyDown (KeyCode.vk_DOWN) && ((SwinGame.ScreenHeight () - SwinGame.BitmapHeight (p.Bitmap) - p.Y) > 0) && (p.Health > 0))
				{
					p.Y += 4 + p.Boost;
				}
				if (SwinGame.KeyDown (KeyCode.vk_LEFT) && ((SwinGame.ScreenWidth () - p.X) < 800) && (p.Health > 0))
				{
					p.X -= 4 + p.Boost;
				}


				if ((p.Ammo > 0) && (p.Health > 0))
				{
					if (SwinGame.KeyTyped (KeyCode.vk_w))
						p.Shoot (0, -10);
					if (SwinGame.KeyTyped (KeyCode.vk_d))
						p.Shoot (10, 0);
					if (SwinGame.KeyTyped (KeyCode.vk_s))
						p.Shoot (0, 10);
					if (SwinGame.KeyTyped (KeyCode.vk_a))
						p.Shoot (-10, 0);
				}
				if (SwinGame.KeyTyped (KeyCode.vk_b))
					game.Reset();
					
				game.Draw ();
				game.Update ();

                //Draw onto the screen
				SwinGame.RefreshScreen(60);
            }
        }
    }
}