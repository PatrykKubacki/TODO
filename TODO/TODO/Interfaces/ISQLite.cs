using SQLite.Net;

namespace TODO.Interfaces {

	public interface ISQLite {
		SQLiteConnection GetConnection();
	}

}