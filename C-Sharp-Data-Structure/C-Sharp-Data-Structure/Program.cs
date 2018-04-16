using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Data_Structure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var FruitTypes = new List<Fruit> {
                new Fruit { Id = 1, Name = "Banana"},
                new Fruit { Id = 2, Name = "Apple" },
                new Fruit { Id = 3, Name = "Orange" },
                new Fruit { Id = 4, Name = "Plum"},
                new Fruit { Id = 5, Name = "Pear" },
            };

            List<int> SortValues = new List<int> { 5, 4, 3, 1, 2 };
            List<Fruit> result = new List<Fruit>();
            foreach (var element in SortValues)
            {
                Fruit f = FruitTypes.FirstOrDefault(fruitElement => fruitElement.Id == element);
                result.Add(f);
            }
            foreach (var item in result)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
            }
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
