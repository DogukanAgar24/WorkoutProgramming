using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using WorkoutControlling.Business;
using WorkoutControlling.Core.Entities;

namespace WorkoutControlling.DataBase
{
	public class MemberRepositories
	{
		private readonly string _dbPath = "workoutControlling.db";
		public MemberRepositories()
		{
			InıtializeDataBase();

		}

		private void InıtializeDataBase()
		{
			using var connection = new SqliteConnection($"Data Source={_dbPath}");
			connection.Open();
			Console.WriteLine("VERİTABANI BURADA: " + System.IO.Path.GetFullPath(_dbPath));
			string createExercisesTable = @"CREATE TABLE IF NOT EXISTS Member (
										Id INTEGER PRIMARY KEY AUTOINCREMENT,
										MemberId INTEGER NOT NULL,
										FUllName TEXT NOT NULL,
										Weight REAL DEFAULT 0,
										Height REAL DEFAULT 0,
										FatPercentage REAL DEFAULT 0,
										TargetWeight REAL DEFAULT 0,
										DateTime TEXT NOT NULL
									);";

			using var createTableCommand = new SqliteCommand(createExercisesTable, connection);
			createTableCommand.ExecuteNonQuery();
		}

		public void AddMember(Member member)
		{
			string connectionString = $"Data Source: {_dbPath}";
			using(var connection=new SqliteConnection(connectionString))
			{
				connection.Open();

				var insertCommand = connection.CreateCommand();
				insertCommand.CommandText =
					@"INSERT INTO Exercises (MemberId,Full,Email,PhoneNumber,Weight,Height,FatPercentage,TagetWeight,DateTime)
					Values($memberId,$fullName,$email,$phoneNumber,$weight,$height,$fatPercentage,$dateTime)";

				insertCommand.Parameters.AddWithValue("$memberId", member.MemberId);
				insertCommand.Parameters.AddWithValue("$name", member.FullName);
				insertCommand.Parameters.AddWithValue("$email", member.Email);
				insertCommand.Parameters.AddWithValue("$phoneNumber", member.PhoneNumber);
				insertCommand.Parameters.AddWithValue("$weight", member.Weight);
				insertCommand.Parameters.AddWithValue("$height", member.Height);
				insertCommand.Parameters.AddWithValue("$fatPercentage",member.FatPercentage );
				insertCommand.ExecuteNonQuery();
			}
		}

	}
}
