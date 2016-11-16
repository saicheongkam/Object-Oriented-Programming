using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;

		/// <summary>
		/// Returns the Player's Inventory
		/// </summary>
		/// <value>The inventory.</value>
		public Inventory Inventory 
		{
			get 
			{
				return _inventory;
			}
		}

		private Location _location;
		public Location Location
		{
			get 
			{
				return _location;
			}

			set 
			{
				_location = value;
			}
		}

		/// <summary>
		/// Initializes a new Player object
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public Player (string name, string desc) : base (new string[] {"me", "inventory"}, name, desc)
		{
			_inventory = new Inventory();
			_location = new Location (new string[] { "here", "location1" }, "location1", "the starting location");
		}

		/// <summary>
		/// Allows the Player to locate and find out about
		/// himself and the items in his inventory
		/// </summary>
		/// <param name="id">Identifier.</param>
		public GameObject Locate (string id)
		{
			if (AreYou (id))
				return this;
			else if (_inventory.HasItem (id))
				return _inventory.Fetch (id);
			else
				return _location.Locate (id);
		}

		/// <summary>
		/// Returns the Player's description
		/// and a list of items he holds
		/// </summary>
		/// <value>The full description.</value>
		public override string FullDescription
		{
			get
			{
				return "You are carrying:\n" +
					_inventory.ItemList;
			}
		}
	}
}

