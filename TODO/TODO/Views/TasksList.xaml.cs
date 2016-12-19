using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TODO.Entities;
using TODO.Interfaces;
using Xamarin.Forms;

namespace TODO.Views {

	public partial class TasksList : ContentPage {
		public TasksList() {
			InitializeComponent();

			SetImages();
		}

		private void SetImages() {
			AddItem.Icon = Device.OS == TargetPlatform.Windows ? "plus.png" : "plus";
			DeleteItem.Icon = Device.OS == TargetPlatform.Windows ? "delete.png" : "delete";
			EditItem.Icon = Device.OS == TargetPlatform.Windows ? "edit.png" : "edit";
			NoToDoImage.Source = Device.OS == TargetPlatform.Windows ? "noTodo.png" : "noTodo";
		}

		private async void Add(object sender, EventArgs e) {
			var page = new AddTask { BindingContext = new TodoItem {DeadLine = DateTime.Now} };
			var nav = new NavigationPage(page) { BarBackgroundColor = Color.White };
			await Navigation.PushAsync(nav);
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			IList<TodoItem> toDoItems = App.Database.GetItems().ToList();
			SetVisibility(toDoItems);
			TasksView.ItemsSource = toDoItems.OrderBy(x => x.DeadLine);
		}

		private void SetVisibility(IList<TodoItem> toDoItems) {
			NoToDoImage.IsVisible = toDoItems.Count == 0;
		}

		private async void Delete(object sender, EventArgs e) {
			var item = TasksView.SelectedItem as TodoItem;

			if (item == null) return;
			var answer = await DisplayAlert("Usunięcie zadania", "Czy na pewno chcesz usunąć zadanie?", "Tak", "Nie");
			if (!answer) return;
			App.Database.DeleteItem(item.Id);
			OnAppearing();
		}

		private  void Edit(object sender, EventArgs e) {
			var toDoItem = TasksView.SelectedItem as TodoItem;
			var toDoPage = new AddTask();
			toDoPage.BindingContext = toDoItem;
			Navigation.PushAsync(toDoPage);
		}

		private async void ShowDetails(object sender, EventArgs e) {
			var item = (MenuItem)sender;
		
			var todoItem = item.BindingContext as TodoItem;
			if (todoItem != null) {
				var message = $"Nazwa: {todoItem.Name}\nKategoria: {todoItem.Category}\nOpis: {todoItem.Description}\nNa kiedy: {todoItem.DeadLine}";
				await DisplayAlert("Szczegóły", message, "OK");
			}
		}

		private async void Speech(object sender, EventArgs e) {
			var item = (MenuItem)sender;
			var toDoItem = item.BindingContext as TodoItem;
			if (toDoItem != null) {
				var text = $"Nazwa: {toDoItem.Name}\nKategoria: {toDoItem.Category}\nOpis: {toDoItem.Description}\nNa kiedy: {toDoItem.DeadLine}";
				try {
					DependencyService.Get<ITextToSpeech>().Speak(text);
				}
				catch (Exception ex) {
					var message = ex.Message;
					await DisplayAlert("Błąd", message, "OK");
				}
			}

		}
	}

}
