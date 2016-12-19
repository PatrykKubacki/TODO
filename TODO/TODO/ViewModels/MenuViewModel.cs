using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModels {
	class MenuViewModel {

		private bool _done;

		public bool Done {
			get { return _done; }
			set { _done = value; }
		}

		private string _name;

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		private int _howMuch;

		public int HowMuch {
			get { return _howMuch; }
			set { _howMuch = value; }
		}

		public MenuViewModel(bool done, string name, int howMuch) {
			_done = done;
			_name = name;
			_howMuch = howMuch;
		}

		public MenuViewModel() {}

	}
}
