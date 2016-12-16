using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TODO.Views {
	public partial class AddTask : ContentPage {
		public AddTask() {
			InitializeComponent();
		}

		private async void refresh(object sender, EventArgs e) {
			await Navigation.PushAsync(new Home());
		}
	}
}
