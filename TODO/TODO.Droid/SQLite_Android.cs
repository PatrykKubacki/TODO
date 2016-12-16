using System;
using System.IO;
using SQLite;
using TODO.Droid;
using TODO.Interfaces;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLite_Android))]

namespace TODO.Droid {

	public class SQLite_Android : ISQLite {
		public SQLite_Android() {
		}

		#region ISQLite implementation
		public SQLiteConnection GetConnection() {
			var sqliteFilename = "TodoSQLite.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);

			var conn = new SQLiteConnection(path);

			// Return the database connection 
			return conn;
		}
		#endregion

		/// <summary>
		/// helper method to get the database out of /raw/ and into the user filesystem
		/// </summary>
		private void ReadWriteStream(Stream readStream, Stream writeStream) {
			var Length = 256;
			var buffer = new Byte[Length];
			var bytesRead = readStream.Read(buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0) {
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}
	}

}
