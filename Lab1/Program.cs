using System;

namespace Lab1
{
    internal class Program
    {
        private const int N = 10;
        public static void TestList()
        {
            var list = new List<int>();
            for (var i = 0; i < N; i++)
                list.AddLast(i);
            Console.Write("Original list: " + list.PrintList());
            
            int pos = 5, data = 11;

            list.AddFirst(data);
            Console.Write("Add the first element " + data + ": " + list.PrintList());

            data = -12;
            list.AddLast(data);
            Console.Write("Add the last element " + data + ": " + list.PrintList());

            list.Insert(pos, data);
            Console.Write("Insert " + data + " in position " + pos + ": " + list.PrintList());

            pos = 3;
            list.Remove(pos);
            Console.Write("Remove element with position " + pos + ": " + list.PrintList());

            list.Reverse();
            Console.Write("Reverse list: " + list.PrintList());

            list.RemoveFirst();
            Console.Write("Remove the first element: " + list.PrintList());

            list.RemoveLast();
            Console.Write("Remove the last element: " + list.PrintList());
            Console.Write("TestList completed\n\n");
        }

        public static void TestBinaryTree()
        {
            var binaryTree = new BinaryTree<int>();
            for (var i = 0; i < N; i++)
            {
                binaryTree.Add(i);
            }
            Console.WriteLine("Remove element 5");
            binaryTree.Remove(5);
            Console.WriteLine("Add element 10");
            binaryTree.Add(10);

            var node =  binaryTree.FindNode(5);
            var result = (node == null) ? "not found" : "found: " + node.Data;
            Console.WriteLine("5 is " + result);

            node = binaryTree.FindNode(10);
            result = (node == null) ? "not found" : "found: " + node.Data;
            Console.WriteLine("10 is " + result);

            node = binaryTree.FindNode(8);
            result = (node == null) ? "not found" : "found: " + node.Data;
            Console.WriteLine("8 is " + result);

            Console.Write("TestBinaryTree completed\n\n");

        } 
        public static void TestSorting()
        {
            string[] strings = { "can", "governing", "factors", "horticulture", "botanist", "describe", "Any" };
            InsertingSort<string>.InsertionSort(strings);
            foreach (var str in strings)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
            var numbers = new[] { 7, 34, 13, -34, 4, 86, 0, 34, 1, 56, -5 };
            InsertingSort<int>.InsertionSort(numbers);
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.Write("\nTestSorting completed\n\n");
        }
        public static void Main(string[] args)
        {
            TestList();
            TestBinaryTree();
            TestSorting();
            Console.ReadLine();
        }
    }
}