using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0327
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if 조건문
            if (DateTime.Now.Hour < 11)
            {
                Console.WriteLine("아침 먹을 시간 입니다.");
            }
            else if (DateTime.Now.Hour < 15)
            {
                Console.WriteLine("점심 먹을 시간 입니다.");
            }
            else
            {
                Console.WriteLine("저녁 먹을 시간 입니다.");
            }

            // switch 조건문
            //홀짝 구분
            Console.Write("숫자를 입력하세요 : ");

            string s_input = Console.ReadLine();
            int input = int.Parse(s_input);
            int remain = input % 2;

            //조건문
            switch (remain)
            {
                case 0:
                    Console.WriteLine("짝수입니다.");
                    break;
                case 1:
                    Console.WriteLine("홀수입니다");
                    break;
            }
            
            if (input % 2 == 0)
            {
                Console.WriteLine("짝수입니다.");
            }
            else 
            {
                Console.WriteLine("홀수입니다.");
            }

            // switch 조건문에서 break문을 의도적으로 사용하지 않는 예
            Console.WriteLine("이번 달은 몇 월 인가요 : ");
            int num1 = int.Parse(Console.ReadLine());

            switch(num1)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("겨울입니다.");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("봄입니다.");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("여름입니다.");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("가을입니다.");
                    break;
                default:
                    Console.WriteLine("대체 어떤 행성에 살고 계신가요?");
                    break;
            }
            // if문으로 계절
            if (num1 == 12 || num1 == 1 || num1 == 2)           // || 또는(or)
            {
                Console.WriteLine("겨울입니다.");
            }
            else if (num1 >= 3 && num1 <=5)                     // && 그리고(and)
            {
                Console.WriteLine("봄입니다.");
            }
            else if (num1 >= 6 && num1 <= 8)
            {
                Console.WriteLine("여름입니다.");
            }
            else if (num1 >= 9 && num1 <= 11)
            {
                Console.WriteLine("가을입니다.");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            // string.Contains 메서드
            Console.Write("입력");

            string line = Console.ReadLine();

            if (line.Contains("안녕할까말까"))
            {
                Console.WriteLine("안녕하세요..!");
            }
            else
            {
                Console.WriteLine("^^");
            }

            // 반복문 사용
            for (int i =0;  i < 1000; i++)
            {
                Console.WriteLine("출력");
            }

            int[] intArray = { 52, 273, 32, 65, 103 };
            Console.WriteLine(intArray[0]);
            Console.WriteLine(intArray[1]);
            Console.WriteLine(intArray[2]);
            Console.WriteLine(intArray[3]);
            Console.WriteLine(intArray[4]);

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            // 원하는 크기의 배열 생성 방법 ( 반복문 )
            int[] array = new int[100];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            // while 반복문
            int[] intArray2 = { 52, 273, 32, 65, 103 };
            int cnt = 0;

            while (cnt < intArray2.Length)
            {
                Console.WriteLine(cnt + "번쨰 출력: " + intArray2[cnt]);
                cnt++;
            }

            while(!Console.ReadLine().Contains("X"))
            {

            }
            Console.WriteLine("프로그램 종료");

            // foreach 반복문
            string[] fruit = { "사과", "배", "포도", "딸기", "바나나" };

            foreach (string item in fruit)
            {
                Console.WriteLine(item); 
            }

            foreach (var item in fruit)
            {
                Console.WriteLine(item);
            }

            // break 조건문 or 반복문 벗어날 때 사용하는 키워드
            while(true)
            {
                Console.Write("숫자 입력(짝수입력시 종료): ");
                int number = int.Parse(Console.ReadLine());
                if(number %2 == 0)
                {
                    break;
                }
            }

            // continue 키워드 ( 현재 반복을 멈추고 다음 반복을 진행)
            for (int j = 0; j < 10; j++)
            {
                if( j % 2 == 0 )
                {
                    continue;
                }
                
                Console.WriteLine(j);
            }
        }
    }
}
