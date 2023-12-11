﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Attendance
	{
        public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public Guid PersonId { get; set; }
		public Person Person { get; set; }
    }
}
