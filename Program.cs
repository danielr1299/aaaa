using System;
namespace BTS
{
    class Program
    {
        static void PrintInt(int item)
        {
            Console.WriteLine(item);
        }
        static void Main()
        {
            BST<int> b1 = new BST<int>();
            b1.Add(1);
            b1.Add(2);
            b1.Add(3);
            b1.Add(54);
            b1.Add(1);
            b1.Add(33);
            //b1.Delete(1);
            b1.ScanInOrder(PrintInt);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(b1);

        }
    }
}
