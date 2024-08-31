using GeneralizedProgramming.Exceptions;
using GeneralizedProgramming.Lists;

namespace GeneralizedProgramming.Utilites
{
    public class ListUtils
    {
        public delegate bool CheckDelegate<T>(T item);
        public delegate void ActionDelegate<T>(T item);
        public delegate int CompareDelegate<T>(T x, T y);
        public delegate Interfaces.IList<T> ListConstructorDelegate<T>();
        public delegate TO ConvertDelegate<TI, TO>(TI input);

        public static Interfaces.IList<T> ArrayListConstructor<T>() => new ArrayList<T>();

        public static Interfaces.IList<T> LinkedListConstructor<T>() => new Lists.Linked.LinkedList<T>();

        public static bool Exists<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T item in list)
            {
                if (checkDelegate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static T Find<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T item in list)
            {
                if (checkDelegate(item))
                {
                    return item;
                }
            }
            throw new MyNotFoundException("Элемент не найден!");
        }

        public static T FindLast<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (checkDelegate(list[i]))
                {
                    return list[i];
                }
            }
            throw new MyNotFoundException("Элемент не найден!");
        }

        public static int FindIndex<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (checkDelegate(list[i]))
                {
                    return i;
                }
            }
            throw new MyNotFoundException("Элемента с таким значением нет!");
        }

        public static int FindLastIndex<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (checkDelegate(list[i]))
                {
                    return i;
                }
            }
            throw new MyNotFoundException("Элемента с таким значением нет!");
        }

        public static Interfaces.IList<T> FindAll<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate, ListConstructorDelegate<T> listConstructor)
        {
            Interfaces.IList<T> result = listConstructor();
            foreach (T item in list)
            {
                if (checkDelegate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static Interfaces.IList<TO> ConvertAll<TI, TO>(Interfaces.IList<TI> list, ConvertDelegate<TI, TO> converter, ListConstructorDelegate<TO> listConstructor)
        {
            Interfaces.IList<TO> result = listConstructor();
            foreach (TI item in list)
            {
                result.Add(converter(item));
            }
            return result;
        }

        public static void ForEach<T>(Interfaces.IList<T> list, ActionDelegate<T> actionDelegate)
        {
            foreach (T item in list)
            {
                actionDelegate(item);
            }
        }

        public static void Sort<T>(Interfaces.IList<T> list, CompareDelegate<T> compareDelegate)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (compareDelegate(list[i], list[j]) > 0)
                    {
                        T temp = list[i];
                        list.RemoveAt(i);
                        list.Insert(i, list[j - 1]);
                        list.RemoveAt(j);
                        list.Insert(j, temp);
                    }
                }
            }
        }

        public static bool CheckForAll<T>(Interfaces.IList<T> list, CheckDelegate<T> checkDelegate)
        {
            foreach (T item in list)
            {
                if (!checkDelegate(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
