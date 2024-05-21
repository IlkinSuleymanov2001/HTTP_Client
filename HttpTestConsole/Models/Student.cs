using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTestConsole.Models
{
	public class Student
	{
		
			public string name { get; set; }
			public string address { get; set; }
			public string city { get; set; }
			public string state { get; set; }
			public string postalCode { get; set; }
			public string phoneNumber { get; set; }
			public string email { get; set; }
			public string website { get; set; }
			public string establishedDate { get; set; }
			public int numberOfStudent { get; set; }

		public override string ToString()
		{
			return $"{name} - {email} - {address} - {state} - {phoneNumber} -  {website} - {establishedDate} - {numberOfStudent}... ";
		}
	}
}
