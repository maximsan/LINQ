using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_operations
{
    public class Apple
    {
        public int Id { get; set; }
        public string SortName { get; set; }
        public double Size { get; set; }
    }

    public class Sort
    {
        public int Id { get; set; }
        public string SortName { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static List<Apple> apples = new List<Apple>
        {
            new Apple{Id=1, SortName = "White", Size = 12},
            new Apple{Id=2, SortName = "White", Size = 4},
            new Apple{Id=3, SortName = "White", Size = 3},
            new Apple{Id=4, SortName = "Red Green", Size = 22},
            new Apple{Id=5, SortName = "Red Green", Size = 18},
            new Apple{Id=6, SortName = "Red Green", Size = 5},
            new Apple{Id=7, SortName = "Red", Size = 15},
            new Apple{Id=8, SortName = "Red", Size = 15},
            new Apple{Id=9, SortName = "Delicious grape", Size = 15},
        };

        static List<Sort> sorts = new List<Sort>
        {
            new Sort{Id=1, SortName = "Black melon", Color = "DarkRed", Price = 123.5},
            new Sort{Id=2, SortName = "White", Color = "WhiteGreen", Price = 100.8},
            new Sort{Id=2, SortName = "Red Crown", Color = "WhiteGreen", Price = 100.8},
            new Sort{Id=3, SortName = "Red Green", Color = "RedGreen", Price = 99.9},
            new Sort{Id=4, SortName = "Red", Color = "RedInDote", Price = 109.9},
            new Sort{Id=5, SortName = "Delicious grape", Color = "DrakRed", Price = 89.9},
        };

        static void Main(string[] args)
        {

            //AallApplesJoinBySort();

            AllApplesGroupBySort();

            //AllApplesSizeMoreFive();

            //AllSortsHaveAnyApple();

            //AllSortsContainsSubString();

            //AllApplesOrderBySize();

            Console.ReadKey();
        }

        private static void AllApplesOrderBySize()
        {
            ///summary
            ///Вывести все яблоки, предварительно отсортировав их по размеру (Order by)
            ///

            var query = apples.Select(a => new
            {
                Name = a.SortName,
                Size = a.Size
            }).OrderBy(x => x.Size).Distinct();

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }

        private static void AllSortsContainsSubString()
        {
            //Вывести все сорта, название котрыx содержит определенную подстроку(Contains)

            var query = sorts.Where(s => s.SortName.Contains("Red")).Select(s => s.SortName);

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }

        private static void AllSortsHaveAnyApple()
        {
            ///summary
            ///Все сорта, по которым есть яблоки (any)
            ///
            var query = (from a in apples
                        from s in sorts
                        where a.SortName == s.SortName
                        select new
                        {
                            Sort = a.SortName
                        }).Distinct();

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }

        private static void AllApplesSizeMoreFive()
        {
            ///summary
            ///Все яблоки, вес(или размер и т.д.) больше 5 (Where)
            ///summary

            var query = from a in apples
                        where a.Size > 5
                        select new
                        {
                            Id = a.Id,
                            Sort = a.SortName,
                            Size = a.Size
                        };

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }

        private static void AllApplesGroupBySort()
        {
            var query =  from a in apples
                         //join s in sorts
                         //on a.SortName equals s.SortName
                         group a by a.SortName
                         into g
                         select new
                         {
                             Sort = g.Key,
                             Count = g.Count()
                         };

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }

            
        }

        private static void AallApplesJoinBySort()
        {
            ///summary
            ///Все яблоки с названием сорта (join)
            ///summary

            var query = from apple in apples
                        join sort in sorts
                        on apple.SortName equals sort.SortName
                        select new
                        {
                            Id = apple.Id,
                            Sort = sort.SortName,
                            Size = apple.Size,
                            Color = sort.Color,
                            Price = sort.Price
                        };


            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }
    }
}
