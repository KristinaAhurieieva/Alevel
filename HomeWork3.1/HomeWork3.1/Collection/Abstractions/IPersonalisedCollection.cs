using System;
using HomeWork3._1.Collection.Abstractions;
namespace HomeWork3._1.Collection.Abstractions
{
	public interface IPersonalisedCollection<T>
	{
        int Count();
        void Sort();
       void Add(T item);
        void SetDefaultAt(int index);

    }
}

