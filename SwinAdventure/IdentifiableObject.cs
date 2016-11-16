using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class IdentifiableObject
	{
		private List<string> _identifiers;

		/// <summary>
		/// Initializes a new Identifiable Object
		/// </summary>
		/// <param name="idents">Idents.</param>
		public IdentifiableObject (string[] idents)
		{
			_identifiers = new List<string> ();
			foreach (string i in idents)
				AddIdentifier(i);
		}

		/// <summary>
		/// Checks whether an object's id is contained in
		/// the list of object identifiers
		/// </summary>
		/// <returns><c>true</c>, if object's id matches, <c>false</c> otherwise.</returns>
		/// <param name="id">Identifier.</param>
		public bool AreYou(string id)
		{
			return _identifiers.Contains (id.ToLower());
		}

		/// <summary>
		/// Returns the value of the first element in
		/// an object's id array.
		/// </summary>
		/// <value>The first identifier.</value>
		public string FirstId 
		{
			get 
			{
				return _identifiers.First ();
			}
		}

		/// <summary>
		/// Adds the object's id into the list of ids.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddIdentifier (string id)
		{
			_identifiers.Add (id.ToLower());
		}
	}
}