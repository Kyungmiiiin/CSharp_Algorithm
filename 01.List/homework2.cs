using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.List
{
    public class homework2
    {
        static void Main()
        {
            List<int> list = new List<int>();

            while (list.Count < 5)
            {
                Console.Write("숫자를 입력하세요 : ");
                int i = int.Parse(Console.ReadLine());

                if (!list.Contains(i))
                {
                    list.Add(i);
                    Console.WriteLine($"{i}를 추가합니다\n");
                }
                else
                {
                    list.Remove(i);
                    Console.WriteLine($"현재 가지고있는 숫자 {i}는 제거합니다\n");
                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                Console.Write($"{list[j]}, ");
            }

        }
    }
}
