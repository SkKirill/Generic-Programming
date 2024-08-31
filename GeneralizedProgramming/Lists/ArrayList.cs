using GeneralizedProgramming.Exceptions;
using System.Collections;

namespace GeneralizedProgramming.Lists
{
    public class ArrayList<T> : Interfaces.IList<T>
    {
        public int Count => _count;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
                }
                return _array[index];
            }
        }

        private T[] _array;
        private int _count;
        
        public ArrayList()
        {                           
            _array = new T[5]; //  для начала выделяется место для первых 5 элементов - это дефолтное значение
            _count = 0;
        }

        public int Add(T value)
        {
            if (_count == _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2); // если массив полностью заполнился, то расширяем его в 2 раза
            }
            _array[_count] = value;
            _count++;
            return _count - 1;
        }

        public void Clear()
        {
            _array = new T[5];
            _count = 0;
        }

        public bool Contains(T value)
        {
            if (_array == null)
            {
                throw new MyNullReferenceException("Список пуст!");
            }

            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i], value))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T value)
        {
            if (_array == null)
            {
                throw new MyNullReferenceException("Список пуст!");
            }

            for (int i = 0; i < _count; i++)
            {
                if (Equals(_array[i], value))
                {
                    return i;
                }
            }
            throw new MyNotFoundException("Элемента с таким значением нет!");
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
            }
            if (_count == _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2);
            }
            Array.Copy(_array, index, _array, index + 1, _count - index);
            _array[index] = value;
            _count++;
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
            }
            Array.Copy(_array, index + 1, _array, index, _count - index - 1);
            _count--;
        }

        public Interfaces.IList<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex >= _count || fromIndex > toIndex)
            {
                throw new MyIndexOutOfRangeException($"Индексы {fromIndex}, {toIndex} находятся за пределами допустимого значения!");
            }

            var subList = new ArrayList<T>();
            for (int i = fromIndex; i <= toIndex; i++)
            {
                subList.Add(_array[i]);
            }

            return subList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
