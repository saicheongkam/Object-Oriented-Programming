using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Bag : Item, IHaveInventory
	{
		private Inventory _inventory;

		/// <summary>
		/// Returns the Bag's Inventory
		/// </summary>
		/// <value>The inventory.</value>
		public Inventory Inventory 
		{
			get {
				return _inventory;
			}
		}

		/// <summary>
		/// Initializes a new Bag object
		/// </summary>
		/// <param name="ids">Identifiers.</param>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public Bag (string[] ids, string name, string desc) : base (ids, name, desc)
		{
			_inventory = new Inventory ();
		}

		/// <summary>
		/// Allows the Bag to find out about itself
		/// and items in its Inventory
		/// </summary>
		/// <param name="id">Identifier.</param>
		public GameObject Locate (string id)
		{
			if (AreYou (id))
				return this;
			else
				return _inventory.Fetch(id);
		}

		/// <summary>
		/// Returns the Bag's description and
		/// a list of items it holds
		/// </summary>
		/// <value>The full description.</value>
		public override string FullDescription
		{
			get
			{
				return "In the " + this.Name + " you can see:\n" +
					_inventory.ItemList;
			}
		}
	}
}

