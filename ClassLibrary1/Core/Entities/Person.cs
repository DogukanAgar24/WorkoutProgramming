using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public abstract class Person : IPerson
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public long PhoneNumber { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		protected Person(int id, string fullName, string email, long phoneNumber)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			PhoneNumber = phoneNumber;
		}
	}
}