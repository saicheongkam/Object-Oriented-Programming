using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Item : GameObject
	{
		/// <summary>
		/// Initializes a new Item object
		/// </summary>
		/// <param name="idents">Idents.</param>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public Item (string[] idents, string name, string desc) : base (idents, name, desc)
		{
		}
	}
}

