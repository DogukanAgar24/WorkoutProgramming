using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutControlling.Core.Interfaces
{
	public interface IMemberRepository<T> where T : class
	{

		IEnumerable<T> GetAll();
		void Add(T entity);
		void Update(T before, T after);
		void DeleteLastRecord();
		void DeleteByName(string name);
		void DeleteById(int id);
		void DeleteAll();
	}
}
