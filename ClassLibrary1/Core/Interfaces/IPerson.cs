namespace WorkoutControlling.Core.Interfaces
{
	public interface IPerson
	{
		//Sadece veriler

		int Id { get; set; }
		string FullName { get; set; }
		string Email { get; set; }
		int PhoneNumber { get; set; }

	}
}