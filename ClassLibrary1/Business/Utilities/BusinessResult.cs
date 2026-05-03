using System;
using System.Collections.Generic;
using System.Text;


namespace WorkoutControlling.Business.Utilities
{
	public class BusinessResult
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; } = string.Empty;

		public static BusinessResult Success(string message = "") => new() { IsSuccess = true, Message = message };
		public static BusinessResult Error(string message) => new() { IsSuccess = false, Message = message };
	}
}
