using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.MobileApp.Models
{
	public class Product
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Double Price { get; set; }
		public DateTime Creation { get; set; }
		public DateTime Modification { get; set; }
	}
}
