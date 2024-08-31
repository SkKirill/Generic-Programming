using GeneralizedProgramming.Exceptions;
using System.Collections;

namespace GeneralizedProgramming.Lists.Linked
{
    public class LinkedList<T> : Interfaces.IList<T>
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

                LinkedListNode<T>? current = _head;
                for (int i = 0; i < index && current != null; i++)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    throw new MyNullReferenceException($"Текущий узел пустой!");
                }

                return current.Value;
            }
        }

        private LinkedListNode<T>? _head;
        private int _count;

        public LinkedList()
        {
            _head = null;
            _count = 0;
        }
        public int Add(T value)
        {
            LinkedListNode<T>? newNode = new LinkedListNode<T>(value);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                LinkedListNode<T>? current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            newNode.Next = null;
            _count++;

            return _count-1; // индекс элемента
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T>? current = _head;
            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(T value)
        {
            LinkedListNode<T>? current = _head;
            int index = 0;
            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return index;
                }
                index++;
                current = current.Next;
            }
            throw new MyNotFoundException("Элемента с таким значением нет!");
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > _count)
            {
                throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
            }

            if (index == _count)
            {
                Add(value);
                return;
            }

            LinkedListNode<T>? newNode = new LinkedListNode<T>(value);
            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                LinkedListNode<T>? current = _head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }

                newNode.Next = current!.Next;
                current.Next = newNode;
            }
            _count++;
        }

        public void Remove(T value)
        {
            if (_head == null)
            {
                throw new MyNullReferenceException("Список пуст!");
            }
            else
            {
                LinkedListNode<T>? current = _head;
                if (Equals(value, current.Value))
                {
                    _head = _head.Next;
                    return;
                }
                else
                {
                    while (current.Next != null)
                    {
                        if (Equals(current.Next.Value, value))
                        {
                            current.Next = current.Next.Next;
                            return;
                        }
                        current = current.Next;
                    }
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new MyIndexOutOfRangeException($"Индекс {index} находится за пределами допустимого значения!");
            }

            if (_head == null)
            {
                throw new MyNullReferenceException("Список пуст!");
            }

            if (index == 0)
            {
                _head = _head.Next;
                _count--;
            }
            else
            {
                LinkedListNode<T>? current = _head;
                for (int i = 0; i < index - 1 && current != null; i++)
                {
                    current = current.Next;
                }
                if (current.Next != null)
                {
                    current.Next = current.Next.Next;
                    _count--;
                }
            }
        }

        public Interfaces.IList<T> SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex >= _count || fromIndex > toIndex)
            {
                throw new MyIndexOutOfRangeException($"Индексы {fromIndex}, {toIndex} находятся за пределами допустимого значения!");
            }

            var subList = new LinkedList<T>();
            LinkedListNode<T>? current = _head;
            for (int i = 0; i <= toIndex && current != null; i++)
            {
                if (i >= fromIndex)
                {
                    subList.Add(current.Value);
                }
                current = current.Next;
            }
            return subList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T>? current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
