using System.Collections.Generic;
using System.Linq;
using SQLite;
using TODO.Entities;
using TODO.Interfaces;
using Xamarin.Forms;

namespace TODO.Models {

	public class TodoItemDatabase {

		 static object locker = new object();
		 SQLiteConnection connection;

		public TodoItemDatabase() {
			connection = DependencyService.Get<ISQLite>().GetConnection();
			connection.CreateTable<TodoItem>();
		}

		public IEnumerable<TodoItem> GetItems() {
			lock (locker)
				return (from i 
						in connection.Table<TodoItem>()
						select i).ToList();
		}

		public IEnumerable<TodoItem> GetItemsNotDone() {
			lock (locker)
				return connection.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0 ");
		}

		public TodoItem GetItem(int id) {
			lock (locker)
				return connection.Table<TodoItem>().FirstOrDefault(x => x.Id == id);
		}

		public int DeleteItem(int id) {
			lock (locker)
				return connection.Delete<TodoItem>(id);
		}

		 public int SaveItem(TodoItem item) {
			 lock (locker) {
				 if (item.Id != 0) {
					 connection.Update(item);
					 return item.Id;
				 }
				 else {
					 return connection.Insert(item);
				 }
			 }
		 }

	}

}
