using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Entities;
using Xamarin.Forms;

namespace TODO.Views {
	public partial class TasksList : ContentPage {

		public TasksList() {
			InitializeComponent();
			TasksView.ItemsSource = App.Database.GetItems();
			MyToolBarItem.Icon = Device.OS == TargetPlatform.Windows ? "plus.png" : "plus";
		}

		private async void Add(object sender, EventArgs e) {
			await Navigation.PushAsync(new AddTask());
		}
	}
}
