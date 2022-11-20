using System.Drawing;

namespace VariousList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Title = "PENTAGON HACKING";
            //Console.ForegroundColor = ConsoleColor.Green;
            //var rnd = new Random();
            //for (int i = 0; i <= 100; i++)
            //{
            //    Console.Write($"{i}%");
            //    Thread.Sleep(rnd.Next(20, 300));
            //    i += rnd.Next(0, 5);
            //    Console.Write("\r");
            //}

            //Console.Beep();
            //Console.Beep();

            Console.WriteLine("Testing list on array base:");
            var testArrayList = new ArrayList<int>();
            var testArrayList2 = new ArrayList<int>();
            testArrayList.Add(1);
            testArrayList.Add(2);
            testArrayList.Add(3);
            testArrayList.Add(4);
            testArrayList.Delete(2);
            testArrayList.Print();
            testArrayList.Add(5);
            testArrayList.Insert(0, 2);
            testArrayList.Print();
            testArrayList.SortBy(x => x);
            testArrayList.Print();
            testArrayList2.Add(1);
            testArrayList2.Add(2);
            ArrayList<int>.Merge(testArrayList, testArrayList2, x => x).Print();

            var pointArray = new ArrayList<Point>
            {
                new Point(1, 2),
                new Point(2, 3),
                new Point(3, 4),
                new Point(4, 5)
            };
            pointArray.Delete(2);
            pointArray.Delete(1);
            pointArray.Insert(new Point(7, 4), 2);
            pointArray.Insert(new Point(8, 2), 1);
            pointArray.Insert(new Point(2, 7), 4);
            pointArray.SortBy(x => x.X);
            pointArray.Print();
            pointArray.SortBy(x => x.Y);
            pointArray.Print();

            Console.WriteLine("\nTesting solo linked list on nodes:");
            var testSLinkedList = new SLinkedList<int>();
            testSLinkedList.Add(1);
            testSLinkedList.Add(2);
            testSLinkedList.Print();
            testSLinkedList.AddFirst(0);
            testSLinkedList.Print();

            Console.WriteLine("\nTesting linked list on nodes:");
            var linkedList = new LinkedList<int>{1, 2, 3, 4};
            linkedList.AddAt(5, 3);
            linkedList.SwapNextTwo(2);
            var newList = linkedList[0..3];
            newList.Delete(1);

            LinkedList<int> first, second;
            linkedList.Divide(2, out first, out second);
            foreach (var item in first)
                Console.Write($"{item} ");
            Console.WriteLine();
            foreach (var item in second)
                Console.Write($"{item} ");
            Console.WriteLine();
            foreach (var item in linkedList)
                Console.Write($"{item} ");
        }
    }
}