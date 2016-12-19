using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Entities;
using TODO.ViewModels;
using Xamarin.Forms;

namespace TODO.Views {

	public partial class Home : MasterDetailPage {
		IList<MenuViewModel> _model = new List<MenuViewModel>();
		public Home() {
			InitializeComponent();

			OnAppearing();
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			IList<TodoItem> _todos = App.Database.GetItems().ToList();
			var howMuchDo = _todos.Count(x => x.Done);
			var howMuchToDo = _todos.Count(x => !x.Done);

			_model.Add(new MenuViewModel(false, "Do zrobienia:", howMuchToDo));
			_model.Add(new MenuViewModel(true, "Zrobione:", howMuchDo));

			MenuListView.ItemsSource = _model;
		}

		private void SetToDoList(object sender, EventArgs e) {
		}

		private void Refresh(object sender, EventArgs e) {
			OnAppearing();
		}
	}

}
