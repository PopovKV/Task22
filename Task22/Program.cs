using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22
{
    class Program
    {
        
        static void Method1(object a)
        {
            int[] array = (int[])a;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 50);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

        static void Method2(Task task, object t)
        {
            int[] a = (int[])t;
            int s = 0;
            Console.WriteLine(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                s += a[i];
            }
            Console.WriteLine("Сумма чисел = {0}", s);
        }

        static void Method3(Task task, object t)
        {
            int[] a = (int[])t;
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i]>max)                
                    max = a[i];                
            }
            Console.WriteLine("Максимальное значение = {0}", max);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Action<object> action = new Action<object>(Method1);
            Task task1 = new Task(action,array);

            Action<Task, object> actionTask1 = new Action<Task, object>(Method2);
            Task task2 = task1.ContinueWith(actionTask1, array);

            Action<Task, object> actionTask2 = new Action<Task, object>(Method3);
            Task task3 = task2.ContinueWith(actionTask2, array);

            task1.Start();

            Console.ReadKey();
        }
    }
}
