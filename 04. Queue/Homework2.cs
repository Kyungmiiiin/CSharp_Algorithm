
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace _04._Queue
{
    public class Homework2
    {

        static void Main()
        {
            Console.Write("문자를 입력하세요 : ");
            string Str = Console.ReadLine();
            if (IsOk(Str))
            {
                Console.WriteLine("완성입니다");
            }
            else
            {
                Console.WriteLine("미완성입니다 다시입력하세요");
            }
        }
        static bool IsOk(string text)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == '[')
                {
                    stack.Push(c);
                }
                else if (c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        return false;
                    }
                }
                else if (c == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

