using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items;

		/// <summary>
		/// Returns the short description of
		/// each item in the inventory
		/// </summary>
		/// <value>The item list.</value>
		public string ItemList
		{
			get
			{
				string s = "";
				foreach (Item i in _items)
					if (_items.Contains (i))
						s += "\t" + i.ShortDescription + "\n";
				return s;
			}
		}

		/// <summary>
		/// Initializes a new Inventory and creates
		/// a new list of Item objects
		/// </summary>
		public Inventory ()
		{
			_items = new List<Item> ();
		}

		/// <summary>
		/// Determines whether an item exists in the Inventory
		/// </summary>
		/// <returns><c>true</c> if the Inventory has an item with the specified id; otherwise, <c>false</c>.</returns>
		/// <param name="id">Identifier.</param>
		public bool HasItem (string id)
		{
			foreach (Item i in _items) 
			{
				if (i.AreYou (id))
					return _items.Contains (i);	
			}
			return false;
		}

		/// <summary>
		/// Adds the item into the Inventory
		/// </summary>
		/// <param name="itm">Itm.</param>
		public void Put (Item itm)
		{
			_items.Add (itm);
		}

		/// <summary>
		/// Takes the item out of the Inventory
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Item Take (string id)
		{
			foreach (Item i in _items) 
			{
				if (i.AreYou (id)) 
				{
					_items.Remove (i);
					return i;
				} 
			}
			return null;
		}

		/// <summary>
		/// Returns the Inventory item specified
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Item Fetch (string id)
		{
			foreach (Item i in _items) 
			{
				if (i.AreYou (id))
					return i;
			}
			return null;
		}
	}
}