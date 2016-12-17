using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TODO.Entities;
using TODO.Models;
using TODO.Views;
using Xamarin.Forms;

namespace TODO {
	public class App : Application {
	
		static TodoItemDatabase _database;
		public int ResumeAtTodoId { get; set; }
		public static TodoItemDatabase Database => _database ?? (_database = new TodoItemDatabase());

		public App() {
			// The root page of your application
			var navigationPage = new NavigationPage(new Home()) {
				BarBackgroundColor = Color.Aqua
			};
			MainPage = navigationPage;
		}


		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
