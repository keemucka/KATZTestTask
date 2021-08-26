using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class ArrayChanger
    {
        public string arrayCount;// Кол-во элементов массива
        public List<int> array = new List<int>();// Массив
        public void GetCount()// Проверка правильности введенных данных - размера массива
        {
            while(true)
            {
                arrayCount = Console.ReadLine();
                int result;
                if (Int32.TryParse(arrayCount, out result)) break;// Если натуральное - выход из цикла              
                else Console.WriteLine("Неверно введенные данные. Введите натуральное число");// Иначе требуем корректный ввод
            }
        }
        public void CreateList()// Формирование массива случайными натуральными числами
        {
            Random rnd = new Random();
            for(int i = 0; i < int.Parse(arrayCount);i++)            
                array.Add(rnd.Next(1, 100));
            Console.WriteLine("Исходный массив");
            foreach (var a in array)
                Console.Write(a + " ");
            Console.WriteLine();
        }
        public void Change()// Действия с массивом
        {
            // Не получилось сравнивать копию исходного массива с измененным, поскольку всегда считает их равными при сравнении
            // Решил использовать флажок
            bool equal = false;
            for (int i = 0; i < int.Parse(arrayCount); i++)
                if (array[i] % 2 == 0 && (i + 1) % 2 == 1)// Если элемент четный и на нечетной позиции 
                {
                    equal = true;// изменяем значение флажка, который укажет на наличие изменений в массиве
                    array[i] *= 2;
                }
            if (!equal)
                Console.WriteLine(
                    "В массиве не оказалось ни одного четного элемента стоящего на нечетном месте");
            else
            {
                Console.WriteLine("Измененный массив");
                foreach (var a in array)
                    Console.Write(a + " ");
                Console.WriteLine();
            }
            // SQL запрос, максимальное значение из нечетных на четной позиции
            try
            {
                int max = (from a in array
                               // IndexOf возвращает индекс,
                               // считаемый от нуля, то есть число по факту 
                               // на еденицу ниже нужного значения, поэтому
                               // считаем его как нечетный, ведь он перед 
                               // нашим четным
                           where a % 2 == 1 && array.IndexOf(a) % 2 == 1
                           select a).Max();
                Console.WriteLine("Максимальное значение " + max);
            }
            catch (Exception e)
            {
                Console.WriteLine("Нечетных элементов стоящих на четных местах нет");
            }           

        }
    }
}
