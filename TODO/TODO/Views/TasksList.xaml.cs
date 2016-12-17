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
			IList<TodoItem> toDoItems = App.Database.GetItems().ToList();
			SetImage(toDoItems);
			TasksView.ItemsSource = toDoItems.OrderBy(x=>x.DeadLine);
		}

		private void SetImage(IList<TodoItem>  toDoItems) {
			if (toDoItems.Count == 0) {
				NoToDoImage.Source = Device.OS == TargetPlatform.Windows ? "noTodo.png" : "noTodo";
				NoToDoImage.IsVisible = true;
			}
			else NoToDoImage.IsVisible = false;
		}

		private async void Delete(object sender, EventArgs e) {
			var item = TasksView.SelectedItem as TodoItem;
			var answer = await DisplayAlert("Usunięcie zadania", "Czy na pewno chcesz usunąć zadanie?", "Tak", "Nie");
			if (item != null && answer) {
				App.Database.DeleteItem(item.Id);
			}
			OnAppearing();
		}

		private void Edit(object sender, EventArgs e) {
		}
	}
}
