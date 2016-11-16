using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public interface IHaveInventory
	{
		Inventory Inventory 
		{
			get;
		}

		GameObject Locate (string id);

		string FullDescription
		{
			get;
		}
	}
}

