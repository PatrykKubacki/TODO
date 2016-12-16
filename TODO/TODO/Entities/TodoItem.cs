using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TODO.Entities {

	public class TodoItem {

		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public bool Done { get; set; }
		public string Category { get; set; }
		public DateTime DeadLine { get; set; }


	}
}
