using System;
using HomeWork3._1.Collection.Abstractions;

namespace HomeWork3._1.Collection
{
    public class PersonalisedCollection<T> : System.Collections.ObjectModel.Collection<T>, IPersonalisedCollection<T>
    {
        private T[] collection = new T[0];

        public int Count()
        {
            int counter = 0;
            for (int idx = 0; idx < collection.Length; idx++)
            {
                if (collection[idx] != null)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void Sort()
        {
            if (collection.Length > 0 && collection[0] is IComparable<T>)
            {
                Array.Sort(collection, (x, y) => ((IComparable<T>)x).CompareTo(y));
            }
            else
            {
                throw new InvalidOperationException("can't sort");
            }
        }

        public void Add(T item)
        {
            Array.Resize(ref collection, collection.Length + 1);
            collection[collection.Length - 1] = item;
        }

        public void SetDefaultAt(int index)
        {
            if (index >= 0 && index < collection.Length)
            {
                collection[index] = default(T);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "can't delete");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return collection.Take(Count()).GetEnumerator();
        }
    }
}

