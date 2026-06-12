using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0403
{
    // 클래스 만들기
    class FirstClass { }
    class SecondClass { }

    // 클래스 변수
    class Product
    {
        public string name;
        public int price;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 클래스 만들기
            FirstClass myClass1 = new FirstClass();
            SecondClass myClass2 = new SecondClass();
            ThirdClass myClass3 = new ThirdClass();

            // 클래스 변수
            Product product = new Product();
            product.name = "감자";
            product.price = 3000;

            Console.WriteLine(product.name + " : " + product.price + "원");

            // 문자열 처리 (대문자화 소문자화)
            string input1 = "Potato Tomato";
            Console.WriteLine(input1.ToUpper());
            Console.WriteLine(input1.ToLower());

            Console.WriteLine(input1);

            // 문자열 자르기
            string input2 = "감자 고구마 토마토";
            string[] output2 = input2.Split(' ');

            for (int i = 0; i < output2.Length; i++)
            {
                Console.WriteLine(output2[i]);
            }

            // 문자열 교체
            string input3 = "감자 고구마 토마토";
            string output3 = input3.Replace(" ", ", ");
            Console.WriteLine(output3);

            // 배열을 문자열로 변환
            string[] array = { "감자", "고구마", "토마토" };
            Console.WriteLine(string.Join("----", array));

            // 특정 시간만큼 스레드 정지
            string[] array2 = { "감자", "고구마", "토마토" };

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
                Thread.Sleep(1000);
            }

            // switch문과 무한 반복문
            bool state = true;

            while (state)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("위로");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("우로");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("좌로");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("아래로");
                        break;
                    case ConsoleKey.X:
                        state = false;
                        break;
                }
            }
            Console.Write("\n");

            // Rondom 클래스를 이용한 정수 생성
            Random random1 = new Random();

            Console.WriteLine(random1.Next());
            Console.WriteLine(random1.Next(100));
            Console.WriteLine(random1.Next(20, 100));

            // Rondom 클래스를 이용한 실수(0.0 ~ 1.0) 생성
            Random random2 = new Random();

            Console.WriteLine(random2.NextDouble());
            Console.WriteLine(random2.NextDouble());
            Console.WriteLine(random2.NextDouble());
            Console.WriteLine(random2.NextDouble());
            Console.WriteLine(random2.NextDouble());
            /* 위에 거랑 같음
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(random2.NextDouble());
            }
            */

            // 로또 번호 추천 1 - 45 5개 추천, 중복 허용
            Random random3 = new Random();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(random3.Next(1, 46));
            }

            // List 요소 추가
            Console.Write("List 요소 추가\n");
            List<int> list1 = new List<int>();

            list1.Add(52);
            list1.Add(273);
            list1.Add(32);
            list1.Add(64);

            foreach (var item in list1)
            {
                Console.WriteLine("Count: " + list1.Count + "\t Item: " + item);
            }

            // List 요소 제거
            Console.Write("List 요소 제거\n");
            List<int> list2 = new List<int>();

            list2.Add(52);
            list2.Add(52);
            list2.Add(273);
            list2.Add(32);
            list2.Add(64);

            list2.Remove(52);           // 중복이 있으면 하나만 삭제됨 (처음 만난 인덱스가 빠른 것만 삭제됨)
            foreach (var item in list2)
            {
                Console.WriteLine("Count: " + list2.Count + "\t Item: " + item);
            }

            // 교수님이랑 한 내용
            Random random4 = new Random();
            List<int> list3 = new List<int>();

            list3.Add(52);
            list3.Add(273);
            list3.Add(32);
            list3.Add(64);

            for (int i = 0;i < 100; i++)
            {
                list3.Add(random4.Next(500));
                list3.RemoveAt(0);
                Console.WriteLine("Count: " + list2.Count + "\t Item: " + list3[0]);
            }
        }
    }
}
