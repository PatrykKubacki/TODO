using System;
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
			if (string.IsNullOrEmpty(Name.Text)  || string.IsNullOrEmpty(Category.Text))
				await DisplayAlert("Błąd", "Wypełnij wszystkie wymagane pola", "OK");
			else {
				var toDoItem = (TodoItem)BindingContext;
				App.Database.SaveItem(toDoItem);
				await Navigation.PushAsync(new Home());
			}
		}
	}

}
