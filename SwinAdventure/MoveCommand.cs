using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class MoveCommand : Command
	{
		public MoveCommand (string[] ids) : base(ids)
		{
		}

		public override string Execute (Player p, string[] text)
		{
			if (text.Length == 2)
			{
				if ((text [0] == "move") || (text [0] == "go") || (text [0] == "head"))
				{	
					foreach (Path pth in p.Location.Path) 
					{
						if (pth.AreYou (text [1]))
							return Move (p, text [1]);
						else
							return "Where do you want to go?";
					}
					return "Where do you want to go?";
				}
				else
					return "Error in move input?";
			}
			else
				return "I don't know how to move like that";
		}

		private string Move (Player p, string text)
		{
			foreach (Path pth in p.Location.Path)
			{
				if (pth.AreYou(text))
				{
					pth.Move (p);
					return pth.Destination.FullDescription;
				}
				return null;
			}
			return null;
		}
	}
}

