namespace GenericHw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("1");
            int x = 10, y = 20;
            Console.WriteLine($"До Swap: x = {x}, y = {y}");
            Swapapapa.Swap(ref x, ref y);
            Console.WriteLine($"Після Swap: x = {x}, y = {y}\n");

            Console.WriteLine("2");
            var pQueue = new Queue<string, int>();
            pQueue.Enqueue("Низький пріоритет", 3);
            pQueue.Enqueue("Критичний пріоритет", 1);
            pQueue.Enqueue("Середній пріоритет", 2);

            while (!pQueue.IsEmpty)
            {
                Console.WriteLine($"Вилучено: {pQueue.Dequeue()}");
            }
            Console.WriteLine();

            Console.WriteLine("3");
            var cQueue = new CircularQueue<int>(3);
            cQueue.Enqueue(100);
            cQueue.Enqueue(200);
            cQueue.Enqueue(300);
            Console.WriteLine($"Перший елемент: {cQueue.Peek()}");
            Console.WriteLine($"Вилучено: {cQueue.Dequeue()}");
            cQueue.Enqueue(400); 
            Console.WriteLine($"Вилучено: {cQueue.Dequeue()}\n");

            Console.WriteLine("4");
            var sList = new LinkedList<string>();
            sList.Add("Перший");
            sList.Add("Другий");
            sList.AddFirst("Нульовий");
            sList.Print();
            sList.Remove("Другий");
            sList.Print();
            Console.WriteLine();

            Console.WriteLine("5");
            var dList = new DoubleLinkedList<double>();
            dList.AddLast(1.1);
            dList.AddLast(2.2);
            dList.AddFirst(0.5);
            dList.PrintForward();
            dList.PrintBackward();
        }
    }
}
    

