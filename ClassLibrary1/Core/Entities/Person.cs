using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public abstract class Person : IPerson
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public bool Gender { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public long PhoneNumber { get; set; }
		

		protected Person(int id, string fullName,bool gender,int age, string email, long phoneNumber)
		{
			Id = id;
			FullName = fullName;
			Gender = gender;
			Age = age;
			Email = email;
			PhoneNumber = phoneNumber;
		}
	}
}