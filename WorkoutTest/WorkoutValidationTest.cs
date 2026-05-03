using System;
using System.Linq;
using WorkoutControlling.Business;
using WorkoutControlling.Core.Entities;

namespace WorkoutTest
{
	public class WorkoutValidationTests
	{
		private readonly WorkoutManager _manager = new WorkoutManager();

		// --- VALIDATION TESTS (Beklenen Hatalar) ---
		public void Should_Fail_When_Name_Is_Empty()
		{
			var workout = new WorkoutInfo { Name = "", SetNumber = 3, RepetationNumber = 10 };
			var result = _manager.AddWorkout(workout);
			PrintResult("Empty Name Test", !result.IsSuccess, result.Message);
		}

		public void Should_Fail_When_Sets_Too_High()
		{
			var workout = new WorkoutInfo { Name = "Bench Press", SetNumber = 99, RepetationNumber = 10 };
			var result = _manager.AddWorkout(workout);
			PrintResult("High Set Count Test", !result.IsSuccess, result.Message);
		}

		// --- CRUD TESTS (Başarılı Senaryolar) ---
		public void Should_Add_And_Check_Duplicate()
		{
			var workout = new WorkoutInfo { Name = "Deadlift", SetNumber = 3, RepetationNumber = 5 };

			// İlk ekleme (Başarılı olmalı)
			var result1 = _manager.AddWorkout(workout);
			PrintResult("Add Valid Workout", result1.IsSuccess, result1.Message);

			// Aynı isimle ikinci ekleme (Hata vermeli)
			var result2 = _manager.AddWorkout(workout);
			PrintResult("Duplicate Name Test", !result2.IsSuccess, result2.Message);
		}

		public void Should_Update_Workout()
		{
			var all = _manager.GetAllWorkouts();
			if (all.Count > 0)
			{
				var before = all[0];
				var after = new WorkoutInfo
				{
					Id = before.Id,
					Name = before.Name + " - Updated",
					SetNumber = 5,
					RepetationNumber = 8
				};

				var result = _manager.UpdateWorkout(before, after); //
				PrintResult("Update Operation Test", result.IsSuccess, result.Message);
			}
		}

		public void Should_Delete_Operations()
		{
			// Geçersiz ID Testi
			var failResult = _manager.DeleteWorkoutById(-1);
			PrintResult("Invalid ID Delete Test", !failResult.IsSuccess, failResult.Message);

			// Başarılı Silme Testi
			var all = _manager.GetAllWorkouts();
			if (all.Count > 0)
			{
				var result = _manager.DeleteWorkoutById(all.Last().Id);
				PrintResult("Valid ID Delete Test", result.IsSuccess, result.Message);
			}
		}

		// --- HELPER METOT ---
		private void PrintResult(string testName, bool success, string message)
		{
			Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
			Console.WriteLine($"[{(success ? "PASS" : "FAIL")}] {testName}: {message}");
			Console.ResetColor();
		}
		public void Should_Calculate_1RM_Correctly()
		{
			// Senaryo: 100 kg ile 10 tekrar yapan birinin 1RM'i ~133.33 kg olmalı
			var testWorkout = new WorkoutInfo
			{
				ExerciseWeight = 100,
				RepetationNumber = 10
			};

			double expected = 133.33;
			double result = _manager.CalculateOneRepMax(testWorkout);

			// Hata payı kontrolü (Double değerlerde küçük farklar olabilir)
			bool isCorrect = Math.Abs(result - expected) < 0.1;

			PrintResult("1RM Calculation Test", isCorrect, $"Result: {result} kg (Expected: {expected} kg)");
		}

	}
}