using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0320
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);
            
            Console.WriteLine("int: " + sizeof(int));
            Console.WriteLine("long: " + sizeof(long));
            Console.WriteLine("float: " + sizeof(float));
            Console.WriteLine("double: " + sizeof(double));
            Console.WriteLine("char: " + sizeof(char));

            char a = 'a';
            char b = 'b';

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a % b);

            Console.WriteLine('a' + 'b');
            Console.WriteLine(('A' + 1));
            Console.WriteLine(('A' + 1L));

            string abc = "Hello";
            Console.WriteLine(sizeof(bool));

            int output = 0;
            output = output + 52;
            output = output + 273;
            output = output + 103;
            Console.WriteLine(output);
            
            int output2 = 0;
            output2 += 52;
            output2 += 273;
            output2 += 103;
            Console.WriteLine(output2);

            
            Console.Write("입력a : ");
            string input1 = Console.ReadLine();
            Console.WriteLine(">> : " + input1);

            Console.Write("입력b(숫자) : ");             // 100 200 123
            string input2 = Console.ReadLine();
            Console.WriteLine(">> : " + int.Parse(input2) + 10);
            
            Console.Write("입력1(숫자) : ");
            string num1 = Console.ReadLine();
            Console.Write("입력2(숫자) : ");
            string num2 = Console.ReadLine();
            Console.WriteLine(int.Parse(num1) + int.Parse(num2));

            Console.WriteLine(52 + "" + 52);

            double number = 52.273103;
            Console.WriteLine(number.ToString("0.0"));
            Console.WriteLine(number.ToString("0.00"));
            Console.WriteLine(number.ToString("0.000"));
            Console.WriteLine(number.ToString("0.0000"));

            // 위에거랑 결과 같음
            Console.WriteLine(number.ToString("F1"));
            Console.WriteLine(number.ToString("F2"));
            Console.WriteLine(number.ToString("F3"));
            Console.WriteLine(number.ToString("F4"));

            Console.Write("입력A1(숫자) : ");
            string A1 = Console.ReadLine();
            Console.Write("입력B1(숫자) : ");
            string B1 = Console.ReadLine();
            Console.WriteLine(A1 + "+" + B1 + "=" + (int.Parse(A1) + int.Parse(B1)));
            Console.WriteLine(A1 + "-" + B1 + "=" + (int.Parse(A1) - int.Parse(B1)));
            Console.WriteLine(A1 + "*" + B1 + "=" + (int.Parse(A1) * int.Parse(B1)));
            Console.WriteLine(A1 + "/" + B1 + "=" + (int.Parse(A1) / int.Parse(B1)));
        }
    }
}
