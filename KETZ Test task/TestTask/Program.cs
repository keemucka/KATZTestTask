using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayChanger changer = new ArrayChanger();
            Console.WriteLine("Введите количество элементов массива");
            changer.GetCount();
            changer.CreateList();
            changer.Change();
            Console.ReadKey();
        }
    }
}
