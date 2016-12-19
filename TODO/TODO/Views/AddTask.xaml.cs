using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Entities;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TODO.Views {
	public partial class AddTask : ContentPage {
		public AddTask() {
			InitializeComponent();
		}

		private async void Cancel(object sender, EventArgs e) {
			await Navigation.PushAsync(new Home());
		}

		private async void Save(object sender, EventArgs e) {
			var toDoItem = (TodoItem)BindingContext;
			App.Database.SaveItem(toDoItem);
			await Navigation.PushAsync(new Home());
		}
	}
}
