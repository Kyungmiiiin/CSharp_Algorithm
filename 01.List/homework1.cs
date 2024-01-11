
namespace List_과제
{
    public class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();

            Console.Write("숫자를 입력하세요 : ");
            int i = int.Parse(Console.ReadLine());

            for (int j = 0; j < i; j++)
            {
                list.Add(j);
            }

            list.Remove(0);

            for (int j = 0; j < list.Count; j++)
            {
                Console.WriteLine($"{list[j]}번 데이터");
            }
        }
    }
}
