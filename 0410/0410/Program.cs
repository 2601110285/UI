using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0410
{
    internal class Program
    {
        class Product
        {
            public string name;
            public int price;

            public void Price()
            {
                Console.WriteLine(name + " : " + price + "원");
            }
        }
        static void Main(string[] args)
        {
            Product product = new Product();
            product.name = "감자";
            product.price = 3000;

            Console.WriteLine(product.name + " : " + product.price + "원");

            // 응용예제
            List<Product> list = new List<Product>();

            Product potato = new Product();
            potato.name = "감자";
            potato.price = 2000;

            Product tomato = new Product();
            tomato.name = "토마토";
            tomato.price = 3000;

            list.Add(potato);
            list.Add(tomato);

            foreach (var item in list)
            {
                Console.WriteLine(item.name + " : " + item.price + "원");
            }

            // 응용예제 2
            List<Product> list2 = new List<Product>();
            list2.Add(new Product() {name = "감자", price = 2000});
            list2.Add(new Product() { name = "토마토", price = 3000 });

            foreach (var item in list)
            {
                Console.WriteLine(item.name + " : " + item.price + "원");
            }
        }
    }
}
