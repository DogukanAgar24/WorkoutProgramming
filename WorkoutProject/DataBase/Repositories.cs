using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Interfaces;


namespace WorkoutControlling.DataBase
{
	public class Repositories : IRepository<WorkoutInfo>
	{
		private readonly string _dbPath = "workoutControlling.db";

		public Repositories()
		{
			InitializeDataBase();
		}



		private void InitializeDataBase()
		{
			using var connection = new SqliteConnection($"Data Source={_dbPath}");
			connection.Open();

			string createExercisesTable = @"CREATE TABLE IF NOT EXISTS Exercises (
										Id INTEGER PRIMARY KEY AUTOINCREMENT,
										Name TEXT NOT NULL,
										PrimaryMuscle TEXT NOT NULL,
										SetNumber INTEGER NOT NULL,
										Repetation INTEGER NOT NULL
									);";

			using var createTableCommand = new SqliteCommand(createExercisesTable, connection);
			createTableCommand.ExecuteNonQuery();
		}

		public void Add(WorkoutInfo exercise)
		{
			string connectionString = $"Data Source={_dbPath}";
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var insertCommand = connection.CreateCommand();
				insertCommand.CommandText =
					@"INSERT INTO Exercises (Name,PrimaryMuscle,SetNumber,Repetation)
				VALUES ($name,$muscle,$set,$rep)";

				insertCommand.Parameters.AddWithValue("$name", exercise.Name);
				insertCommand.Parameters.AddWithValue("muscle", exercise.PrimaryMuscle);
				insertCommand.Parameters.AddWithValue("set", exercise.SetNumber);
				insertCommand.Parameters.AddWithValue("rep", exercise.RepetationNumber);

				insertCommand.ExecuteNonQuery();
			}


		}

		public void Delete(int id)
		{
			string connectionString=$"DataSource={_dbPath}";
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();

				var deleteCommand = connection.CreateCommand();

				deleteCommand.CommandText = "DELETE FROM Exercises WHERE Id= $id";
				deleteCommand.Parameters.AddWithValue("$id", id);

				deleteCommand.ExecuteNonQuery();

				Console.WriteLine("Record has deleted.");
			}
		}
		public void Delete(WorkoutInfo exercise)
		{
			Delete(exercise.Id);
		}

		public IEnumerable<WorkoutInfo> GetAll()
		{
			throw new NotImplementedException();
		}

		public WorkoutInfo GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(WorkoutInfo entity)
		{
			throw new NotImplementedException();
		}
	}
}
