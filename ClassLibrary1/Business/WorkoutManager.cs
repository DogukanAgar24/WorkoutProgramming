using System;
using System.Collections.Generic;
using System.Text;
using WorkoutControlling.Business.Utilities;
using WorkoutControlling.Core.Entities;
using WorkoutControlling.DataBase;

namespace WorkoutControlling.Business
{
	public class WorkoutManager
	{
		private readonly WorkoutRepositories _repository;

		public WorkoutManager()
		{
			_repository = new WorkoutRepositories();
		}

		public BusinessResult AddWorkout(WorkoutInfo info)
		{
			//Validation(doğrulama)
			if (string.IsNullOrEmpty(info.Name))
				return BusinessResult.Error("Exercise name can not be null");

			if (info.Name.Length < 2 || info.Name.Length>40)
				return BusinessResult.Error("Exercise name must be valid string and smaller than 40 chars");
			

			if (info.SetNumber <= 0 || info.SetNumber>10)
				return BusinessResult.Error("Set number must be between 1 to 10");

			if (info.RepetationNumber <= 0 || info.RepetationNumber>30)
				return BusinessResult.Error("Repeat number must be between 1 to 30");

			//Record Check
			var existingWorkout = _repository.GetAll();

			if (existingWorkout.Any(w => w.Name.Equals(info.Name, StringComparison.OrdinalIgnoreCase)))
			{
				return BusinessResult.Error($"{info.Name} is already exist");
			}

			try
			{
				_repository.Add(info);
				return BusinessResult.Success();

			}
			catch(Exception ex)
			{
				return BusinessResult.Error("An error occured while saving to database" + ex.Message);
			}
			
		}

		public BusinessResult DeleteWorkoutById(int id)
		{
			if (id <= 0)
				return BusinessResult.Error("Invalid Id, Id must be greater than 0");

			try
			{
				_repository.DeleteById(id);
				return BusinessResult.Success("Deleted succesfully.");
			}
			catch (Exception ex)
			{
				return BusinessResult.Error("There is a mistake while deleting by Id: " + ex.Message); 
			}
		}

		public BusinessResult DeleteWorkoutByName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return BusinessResult.Error("Deleting name can not be null.");

			try
			{
				_repository.DeleteByName(name);
				return BusinessResult.Success($"{name} records are deleted.");
			}
			catch (Exception ex)
			{
				return BusinessResult.Error("Error: " + ex.Message); 
			}
		}

		public BusinessResult ClearAllWorkouts()
		{
			try
			{
				_repository.DeleteAll();
				return BusinessResult.Success("All training session are deleted");
			}
			catch (Exception ex)
			{
				return BusinessResult.Error("there is an error while deleting all session." + ex.Message);
			}
		}

		public List<WorkoutInfo> GetAllWorkouts()
		{
			var workouts= _repository.GetAll();
			return workouts.OrderBy(w => w.Id).ToList();
		}


		public BusinessResult UpdateWorkout(WorkoutInfo before, WorkoutInfo after)
		{
			// 1. Validation for the new data (after)
			if (after == null || before == null)
				return BusinessResult.Error("Workout data cannot be null.");

			if (string.IsNullOrWhiteSpace(after.Name))
				return BusinessResult.Error("Exercise name cannot be empty.");

			if (after.Name.Length < 3 || after.Name.Length > 40)
				return BusinessResult.Error("Exercise name must be between 3 and 40 characters.");

			if (after.SetNumber <= 0 || after.SetNumber > 10)
				return BusinessResult.Error("Set number must be between 1 and 10.");

			if (after.RepetationNumber <= 0 || after.RepetationNumber > 30)
				return BusinessResult.Error("Repetition number must be between 1 and 30.");

			// 2. Database Operation
			try
			{
				// Calling your repository method from the screenshot
				_repository.Update(before, after);
				return BusinessResult.Success("Workout updated successfully.");
			}
			catch (Exception ex)
			{
				// Handling database-related errors (e.g., file lock, SQL syntax)
				return BusinessResult.Error("Database error: " + ex.Message);
			}
		}

		public double CalculateOneRepMax(WorkoutInfo info)
		{
			if (info.ExerciseWeight <= 0 || info.RepetationNumber <= 0)
				return 0;

			// Epley Formula implementation
			double oneRepMax = info.ExerciseWeight * (1 + (double)info.RepetationNumber / 30);

			return Math.Round(oneRepMax, 2);
		}

		public void AddWorkoutToMember(Member member,WorkoutInfo workout)
		{
			workout.MemberId = member.Id;

			member.WorkoutHistory.Add(workout);
		}

		public double CalculateStrenght(Member member,WorkoutInfo workout)
		{
			double oneRepMax = CalculateOneRepMax(workout);

			return Math.Round(oneRepMax / member.Weight,2);
		}
	}
}
