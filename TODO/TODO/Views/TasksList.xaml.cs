using System;
using System.Collections;
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
			
			AddItem.Icon = Device.OS == TargetPlatform.Windows ? "plus.png" : "plus";
			DeleteItem.Icon = Device.OS == TargetPlatform.Windows ? "delete.png" : "delete";
			EditItem.Icon = Device.OS == TargetPlatform.Windows ? "edit.png" : "edit";
		}

		private async void Add(object sender, EventArgs e) {
			await Navigation.PushAsync(new AddTask());
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			IList<TodoItem> toDoItems = App.Database.GetItems().Where(i => !i.Done).ToList();
			IList<TodoItem> doneItems = App.Database.GetItems().Where(i => i.Done).ToList();
			TasksView.ItemsSource = toDoItems.OrderBy(x=>x.DeadLine);
			TasksView2.ItemsSource = doneItems.OrderBy(x => x.DeadLine);
		}

		private void Delete(object sender, EventArgs e) {
			var item = TasksView.SelectedItem as TodoItem;
			if (item != null)
				App.Database.DeleteItem(item.Id);
		}

		private void Edit(object sender, EventArgs e) {
		}
	}
}
