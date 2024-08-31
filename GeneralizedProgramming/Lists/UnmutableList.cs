using GeneralizedProgramming.Exceptions;
using System.Collections;

namespace GeneralizedProgramming.Lists
{
    public class UnmutableList<T> : Interfaces.IList<T>
    {
        public int Count => _underlyingList.Count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _underlyingList.Count)
                {
                    throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
                }
                return _underlyingList[index];
            }
            set
            {
                throw new UnmutableListException("Нельзя изменять элементы в неизменяемом списке!");
            }
        }

        private readonly Interfaces.IList<T> _underlyingList;

        public UnmutableList(Interfaces.IList<T> list)
        {
            _underlyingList = list ?? throw new ArgumentNullException(nameof(list));
        }

        public int Add(T value)
        {
            throw new UnmutableListException("В неизменяемый список нельзя добавлять элементы!");
        }

        public void Clear()
        {
            throw new UnmutableListException("Неизменяемый список нельзя очистить!");
        }

        public bool Contains(T value)
        {
            return _underlyingList.Contains(value);
        }

        public int IndexOf(T value)
        {
            return _underlyingList.IndexOf(value);
        }

        public void Insert(int index, T value)
        {
            throw new UnmutableListException("Неизменяемый список нельзя добавлять элементя!");
        }

        public void Remove(T value)
        {
            throw new UnmutableListException("Из неизменяемого списка нельзя удалять элементы!");
        }

        public void RemoveAt(int index)
        {
            throw new UnmutableListException("Из неизменяемого списка нельзя удалять элементы!");
        }

        public Interfaces.IList<T> SubList(int fromIndex, int toIndex)
        {
            return _underlyingList.SubList(fromIndex, toIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _underlyingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _underlyingList.GetEnumerator();
        }
    }
}
