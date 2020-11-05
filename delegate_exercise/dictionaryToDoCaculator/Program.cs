using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionaryToDoCaculator
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Min(int a, int b)
        {
            return a - b;
        }

        static int Mul(int a, int b)
        {
            return a * b;
        }

        static int Div(int a, int b)
        {
            return a / b;
        }

        delegate int caculator(int a, int b);
        static Dictionary<char, caculator> dic = new Dictionary<char, caculator>();

        static void Main(string[] args)
        {
            dic.Add('+', new caculator(Add));
            dic.Add('-', new caculator(Min));
            dic.Add('*', new caculator(Mul));
            dic.Add('/', new caculator(Div));
            Console.WriteLine("please input firsrt number");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("please input operator");
            char o = Console.ReadLine()[0];
            Console.WriteLine("please secend firsrt number");
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine(dic[o](a, b));

            Console.ReadLine();

        }
    }
}
