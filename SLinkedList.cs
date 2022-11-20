using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousList
{
    /// <summary>
    /// Singly linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public SLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public SLinkedList(SLinkedList<T> stack)
        {
            head = stack.head;
            tail = stack.tail;
            count = stack.count;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                head = tail = new Node<T>(item, null);
            }
            else
            {
                var temp = new Node<T>(item, null);
                tail.Next = temp;
                tail = temp;
            }
            count++;
        }

        public void Print()
        {
            var elem = head;
            Console.Write("{ ");
            while (elem != null)
            {
                Console.Write($"{elem.Value} ");
                elem = elem.Next;
            }
            Console.WriteLine("}");
        }

        public void AddFirst(T item)
        {
            var temp = new Node<T>(item, head);
            head = temp;
            count++;
        }

        public int Count{ get { return count; } }

        public void Clear()
        {
            head = tail = null;
            count = 0;
        }

        public T GetValue()
        {
            return tail.Value;
        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }

            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
