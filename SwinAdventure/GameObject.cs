using System;

namespace SwinAdventure
{
	public abstract class GameObject : IdentifiableObject
	{
		private string _description;

		/// <summary>
		/// Returns the shorter description of an object
		/// </summary>
		/// <value>The short description.</value>
		public string ShortDescription 
		{
			get 
			{
				return this.FirstId + " (" + _name + ")";
			}
		}

		/// <summary>
		/// Returns an object's description
		/// Can be overridden by child classes
		/// </summary>
		/// <value>The full description.</value>
		public virtual string FullDescription 
		{
			get 
			{
				return _description;
			}
		}

		private string _name;

		/// <summary>
		/// Returns the value of the _name field
		/// </summary>
		/// <value>The name.</value>
		public string Name 
		{
			get 
			{
				return _name;
			}
		}

		/// <summary>
		/// Initializes a new Game Object.
		/// </summary>
		/// <param name="ids">Identifiers.</param>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public GameObject (string[] ids, string name, string desc) : base (ids)
		{
			_name = name;
			_description = desc;
			foreach (string i in ids)
				AddIdentifier(i);
		}
	}
}

