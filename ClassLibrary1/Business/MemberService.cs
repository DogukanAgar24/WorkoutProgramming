using System;
using System.Collections.Generic;
using System.Text;
using WorkoutControlling.Core.Entities;

namespace WorkoutControlling.Business
{
	public class MemberService
	{
		public double FatPercentage(Member member)
		{
			double BMI = (member.Weight / Math.Pow(member.Height, 2));

			double gender = member.Gender ? 1 : 0;

			double age = member.Age;

			double result = (1.20 * BMI) + (0.23 * age) - (10.8 * gender) - 5.4;

			return Math.Round(result, 2);
		}
	}
}
