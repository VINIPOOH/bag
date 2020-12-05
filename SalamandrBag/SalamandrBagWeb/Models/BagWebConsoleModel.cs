﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

 namespace WEB.Models
{
	public class BagWebConsoleModel
	{
		public string name { get; set; }
		public int animalFoodPerDay { get; set; }
		public int animalTypeNumber { get; set; }
		public string Info { get; set; }
	}
}
