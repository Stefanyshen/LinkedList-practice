using System.Collections;

namespace AlgoritmsLab5
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public LinkedList()
        {
            count = 0;
        }

        public LinkedList(LinkedList<T> list)
        {
            head = list.head;
            tail = list.tail;
            count = list.count;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                head = tail = new Node<T>(item, null, null);
            }
            else
            {
                var temp = new Node<T>(item, tail, null);
                tail.Next = temp;
                tail = temp;
            }
            count++;
        }

        public void AddAt(T item, int index)
        {
            var previous = this[index - 1];
            var next = this[index];
            var temp = new Node<T>(item, previous, next);
            previous.Next = temp;
            next.Previous = temp;
            count++;
        }

        public void Delete(int index)
        {
            if (index + 1 < count)
                this[index + 1].Previous = this[index].Previous;
            else 
                tail = this[index].Previous;

            if (index != 0)
                this[index - 1].Next = this[index].Next;
            else
                head = head.Next;

            count--;
        }

        public void SwapNextTwo(int index)
        {
            var first = this[index + 1];
            var second = this[index + 2];
            (first.Value, second.Value) = (second.Value, first.Value);
        }

        public T GetValue(int index) => this[index].Value;

        public static LinkedList<T> Concat(LinkedList<T> first, LinkedList<T> second)
        {
            var result = new LinkedList<T>(first);
            second.head.Previous = result.tail;
            result.tail.Next = second.head;
            result.tail = second.tail;
            result.count += second.count;
            return result;
        }

        public void Divide(int index, out LinkedList<T> first, out LinkedList<T> second)
        {
            first = new LinkedList<T>(this[..index]);
            second = new LinkedList<T>(this[index..count]);
        }

        public int Count { get { return count; } }

        private Node<T> this[int i]
        {
            get
            {
                if (i >= count) throw new IndexOutOfRangeException();
                var result = head;
                for (int j = 0; j < i; j++)
                    result = result.Next;
                return result;
            }
        }

        public LinkedList<T> this[Range range]
        {
            get
            {
                if (range.End.Value > count || range.Start.Value < 0)
                    throw new IndexOutOfRangeException();
                var result = new LinkedList<T>();
                result.Add(this[range.Start.Value].Value);
                for (int i = range.Start.Value + 1; i < range.End.Value; i++)
                    result.Add(this[i].Value);
                return result;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var elem = head;
            while (elem != null)
            {
                yield return elem.Value;
                elem = elem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T value, Node<T> previous, Node<T> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            public Node(Node<T> node)
            {
                Value = node.Value;
                Previous = node.Previous;
                Next = node.Next;
            }
        }
    }
}
