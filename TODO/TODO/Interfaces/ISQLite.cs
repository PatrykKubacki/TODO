using SQLite;

namespace TODO.Interfaces {

	public interface ISQLite {
		SQLiteConnection GetConnection();
	}

}