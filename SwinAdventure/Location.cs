using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
	{
		private string _description;
		private Inventory _inventory;

		public Inventory Inventory 
		{
			get {
				return _inventory;
			}
		}

		private List<Path> _path;
		public List<Path> Path 
		{
			get 
			{
				return _path;
			}
		}

		public string ItemList
		{
			get
			{
				return _inventory.ItemList;
			}
		}


		public Location (string[] idents, string name, string desc) : base (idents, name, desc)
		{
			_path = new List<Path> ();
			_description = desc;
			_inventory = new Inventory ();
		}
			
		public override string FullDescription
		{
			get
			{
				return _description + "\n" +
					"This place contains:\n" +
					ItemList;
			}
		}

		public GameObject Locate (string id)
		{
			if (_inventory.HasItem (id))
				return _inventory.Fetch (id);
			else
				return null;
		}

		public void Add (Item itm)
		{
			_inventory.Put (itm);
		}

		public void Remove (string id)
		{
			if (_inventory.HasItem (id))
				_inventory.Take (id);
		}
	}
}

