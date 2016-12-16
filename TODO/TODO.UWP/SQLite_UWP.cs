
using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using SQLite;
using TODO.Interfaces;
using TODO.UWP;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace TODO.UWP {
	class SQLite_UWP :ISQLite { 

		public SQLite_UWP() {
		}

		public SQLiteConnection GetConnection() {
			var sqliteFileName = "TodoSQLite.db3";
			string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFileName);

			var conn = new SQLiteConnection(path);

			return conn;
		}
	}
}
