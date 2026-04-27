using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace WorkoutControlling.DataBase
{
	public class Repositories
	{
		private readonly string _dbPath= "workoutControlling.db";

		public Repositories()
		{
			InitializeDataBase();
		}

		private void InitializeDataBase()
		{
			using var connection = new SqliteConnection($"Data Source={_dbPath}");
			connection.Open();

			string createExercisesTable=@"CREATE TABLE IF NOT EXISTS Exercises (
										Id INTEGER PRIMARY KEY AUTOINCREMENT,
										Name TEXT NOT NULL,
										PrimaryMuscle TEXT NOT NULL
									);";

			using var createTableCommand = new SqliteCommand(createExercisesTable, connection);
			createTableCommand.ExecuteNonQuery();
		}
	}
}
