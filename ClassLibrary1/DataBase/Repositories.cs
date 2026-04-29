using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using WorkoutControlling.Core.Interfaces;
using WorkoutProgramming.Core.Entities;

namespace WorkoutControlling.DataBase
{
	public class Repositories : IRepository<WorkoutInfo>
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

			string createExercisesTable= @"CREATE TABLE IF NOT EXISTS Exercises (
										Id INTEGER PRIMARY KEY AUTOINCREMENT,
										Name TEXT NOT NULL,
										PrimaryMuscle TEXT NOT NULL,
										SetNumber INTEGER NOT NULL,
										Repetation INTEGER NOT NULL
									);";

			using var createTableCommand = new SqliteCommand(createExercisesTable, connection);
			createTableCommand.ExecuteNonQuery();
		}
	}
		public void Add(WorkoutInfo entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(WorkoutInfo entity)
		{
			throw new NotImplementedException();
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
