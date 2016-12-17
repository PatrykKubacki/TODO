using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Entities;
using Xamarin.Forms;

namespace TODO.Views {
	public partial class AddTask : ContentPage {
		public AddTask() {
			InitializeComponent();
		}

		private async void Cancel(object sender, EventArgs e) {
			await Navigation.PushAsync(new Home());
		}

		private async void Save(object sender, EventArgs e) {
			App.Database.SaveItem(new TodoItem {
				Name = Name.Text,
				Category = Category.Text,
				DeadLine = DeadLine.Date + DateTime.Now.TimeOfDay,
				Description = Description.Text,
				Done = Done.IsToggled
			});
			await Navigation.PushAsync(new Home());
		}
	}
}
