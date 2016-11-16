using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class Path : IdentifiableObject
	{
		private Location _destination;
		public Location Destination 
		{
			get 
			{
				return _destination;
			}
		}

		public Path (string[] idents, Location destination) : base (idents)
		{
			_destination = destination;
		}

		public void Move (Player p)
		{
			p.Location = _destination;
		}
	}
}

