using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class LookCommand : Command
	{
		public LookCommand (string[] ids) : base(ids)
		{
		}

		public override string Execute (Player p, string[] text)
		{
			if ((text.Length == 3) || (text.Length == 5)) 
			{
				if (text [0] == "look") 
				{
					if (text [1] == "at") 
					{
						if (text.Length == 5) 
						{
							if (text [3] == "in")
								return this.LookAtIn (p, text [2], text [4]);
							else
								return "What do you want to look in?";
						}
						else
							return this.LookAtIn (p, text [2], "inventory");
					} 
					else
						return "Where do you want to look at?";
				} 
				else
					return "Error in look input";
			} 
			return "I don't know how to look like that";
		}

		private string LookAtIn (Player p, string thingID, string containerID)
		{
			if (containerID != "inventory")
			{
				IHaveInventory container = (IHaveInventory)p.Locate (containerID);
				if ((thingID == "inventory") || (thingID == "me")) 
				{
					Player thing = p;
					return p.FullDescription;
				} 
				else 
				{
					GameObject thing = (Item)container.Locate (thingID);
					if (container.Inventory.HasItem (thingID))
						return thing.FullDescription;
					else
						return "I can't find the " + thingID + " in the " + containerID;
				}
			}
			else
			{
				Inventory container = p.Inventory;
				if ((thingID == "inventory") || (thingID == "me")) 
				{
					Player thing = p;
					return p.FullDescription;
				} 
				else 
				{
					GameObject thing = (Item)container.Fetch (thingID);
					if (container.HasItem (thingID))
						return thing.FullDescription;
					else
						return "I can't find the " + thingID + " in the " + containerID;
				}
			}
		}
	}
}