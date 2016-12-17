using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TODO.Views {
	public partial class Home : MasterDetailPage {
		public Home() {
			InitializeComponent();
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			HowManyTodo.Text = App.Database.GetItems().Count().ToString();
		}
	}
}
