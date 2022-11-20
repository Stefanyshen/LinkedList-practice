using System.Collections;

namespace VariousList
{
    /// <summary>
    /// Array-based list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T> : IEnumerable<T>
    {
        private T[] list;
        private int length = 0;

        public ArrayList()
        {
            list = new T[4];
        }

        public ArrayList(int length)
        {
            list = new T[length];
        }

        public void Clear()
        {
            list = new T[list.Length];
        }

        public void Delete(int position)
        {
            list = list[..position].Concat(list[(position + 1)..]).ToArray();
            length--;
        }

        public void Insert(T elem, int position)
        {
            list = list[..position].Append(elem).ToArray().Concat(list[position..]).ToArray();
            length++;
        }

        public void Add(T elem)
        {
            if (length == list.Length)
                list = list.Concat(new T[list.Length]).ToArray();
            list[length] = elem;
            length++;
        }

        public void Print()
        {
            Console.Write("{ ");
            for (int i = 0; i < length; i++)
                Console.Write($"{list[i]} ");
            Console.WriteLine("}");
        }

        public void SortBy<T2>(Func<T, T2> selector) where T2 : IComparable
        {
            var key = list.Select(selector).ToArray();
            for (int i = 1; i < length; i++)
                for (int j = i; j > 0; j--)
                    if (key[j - 1].CompareTo(key[j]) > 0)
                    {
                        (key[j], key[j - 1]) = (key[j - 1], key[j]);
                        (list[j], list[j - 1]) = (list[j - 1], list[j]);
                    }
                    else break;
        }

        public int Count { get { return length; } }

        public int Capacity() => list.Length;

        public T this[int i]
        {
            get 
            { 
                if (i > length) throw new IndexOutOfRangeException();
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }

        public static ArrayList<T> Merge<T, T2>(ArrayList<T> first, ArrayList<T> second, Func<T, T2> selector) 
            where T2 : IComparable
        {
            first.SortBy(selector);
            second.SortBy(selector);
            var firstKeys = first.Select(selector).ToArray();
            var secondKeys = second.Select(selector).ToArray();
            var result = new ArrayList<T>();
            int firstIndexer = 0, secondIndexer = 0;
            
            while(firstIndexer < first.Count && secondIndexer < second.Count)
            {
                if (firstKeys[firstIndexer].CompareTo(secondKeys[secondIndexer]) < 0)
                    result.Add(first[firstIndexer++]);
                else
                    result.Add(second[secondIndexer++]);
            }

            if (firstIndexer == first.Count)
                for (int i = secondIndexer; i < second.Count; i++)
                    result.Add(second[i]);
            else
                for (int i = firstIndexer; i < first.Count; i++)
                    result.Add(first[i]);

            return result;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return list[i];
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
