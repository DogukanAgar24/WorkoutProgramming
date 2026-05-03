namespace WorkoutControlling.Core.Interfaces
{
	public interface IRepository<T> where T : class
	{
		
		IEnumerable<T> GetAll();
		void Add(T entity);
		void Update(T before,T after);
		void DeleteLastRecord();
		void DeleteByName(string name);
		void DeleteById(int id);
		void DeleteAll();
	}
}