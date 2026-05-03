using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
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
				insertCommand.Parameters.AddWithValue("muscle", exercise.PrimaryMuscle.ToString());
				insertCommand.Parameters.AddWithValue("set", exercise.SetNumber);
				insertCommand.Parameters.AddWithValue("rep", exercise.RepetationNumber);

				insertCommand.ExecuteNonQuery();
			}

		}

		public void DeleteLastRecord()
		{
			var connectionString = $"Data Source ={_dbPath}";
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();
				var command = connection.CreateCommand();
				// ID'si en büyük olan (yani en son eklenen) satırı bul ve sil
				command.CommandText = "DELETE FROM Exercises WHERE Id = (SELECT MAX(Id) FROM Exercises)";
				command.ExecuteNonQuery();
			}
		}
		public void DeleteById(int id)
		{
			var connectionString = $"Data Source ={_dbPath}";
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();
				var command = connection.CreateCommand();
				command.CommandText = "DELETE FROM Exercises Where Id =@id";
				command.Parameters.AddWithValue("@id", id);

				command.ExecuteNonQuery();
			}
			Console.WriteLine("Delete by Id is successfully! \a");
		}
		public void DeleteByName(string name)
		{
			var connectionString = $"Data Source ={_dbPath}";
			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();
				var command = connection.CreateCommand();
				command.CommandText = "DELETE FROM Exercises Where Name =@name";

				command.ExecuteNonQuery();
			}
			
		}

		public void DeleteAll()
		{
			string connectionString = $"Data Source={_dbPath}";

			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						var command = connection.CreateCommand();
						command.Transaction = transaction;

						// 1. ADIM: Tablodaki tüm verileri siler
						command.CommandText = "DELETE FROM Exercises;";
						command.ExecuteNonQuery();

						// 2. ADIM: SQLite'ın iç sayacını sıfırlar (ID'lerin tekrar 1'den başlaması için)
						// Eğer bu komutu yazmazsan, yeni eklediğin kayıt eski ID'den devam eder.
						command.CommandText = "DELETE FROM sqlite_sequence WHERE name = 'Exercises';";
						command.ExecuteNonQuery();

						// Her şey yolundaysa işlemi onayla
						transaction.Commit();

					}
					catch (System.Exception ex)
					{
						// Bir hata olursa işlemleri geri al
						transaction.Rollback();
					}
				}
			}
		}

		public IEnumerable<WorkoutInfo> GetAll()
		{
			var workoutList = new List<WorkoutInfo>();
			string connectionString = $"Data Source ={_dbPath}";
			int counter = 1;

			using (var connection = new SqliteConnection(connectionString))
			{
				connection.Open();
				var command = connection.CreateCommand();
				command.CommandText = "SELECT Id, Name, PrimaryMuscle, SetNumber, Repetation FROM Exercises";

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var workout = new WorkoutInfo
						{
							Id = reader.GetInt32(0),
							DisplayId =counter++,
							Name = reader.GetString(1),
							PrimaryMuscle = Enum.Parse<MuscleGroup>(reader.GetString(2)),
							SetNumber = reader.GetInt32(3),
							RepetationNumber = reader.GetInt32(4)

						};

						workoutList.Add(workout);
					}
				}
			}
			return workoutList;
		}


		public void Update(WorkoutInfo before,WorkoutInfo after)
		{
			
		}

		
	}
}
