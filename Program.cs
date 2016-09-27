using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static string _towerA = "A";
        private static string _towerB = "B";
        private static string _towerC = "C";

        static void Main(string[] args)
        {
            var choice = 0;

            while (choice >= 0)
            {
                System.Console.WriteLine("1: Tower of Hanoi");
                System.Console.WriteLine("2: Factorial");
                System.Console.WriteLine("3: Sum");
                System.Console.WriteLine("4: Count List Items");
                System.Console.WriteLine("5: Max");
                System.Console.WriteLine("6: QuickSort 4.1");
                System.Console.WriteLine("7: Chapter 1 - Binary Search");
                System.Console.WriteLine("8: Simple Binary Search");

                System.Console.Write("Enter your choice(-1 to quit): ");
                choice = Int32.Parse(System.Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        TowerOfHanoi();
                        break;
                    case 2:
                        Factorial();
                        break;
                    case 3:
                        DoSum();
                        break;
                    case 4:
                        CountList();
                        break;
                    case 5:
                        FindMax();
                        break;
                    case 6:
                        QuickSort();
                        break;
                    case 7:
                        BinarySearchQuickSort();
                        break;
                    case 8:
                        MovieSearch();
                        break;

                }
            }
        }

        private static void FindMax()
        {
            var numbers = new LinkedList<int>();
            numbers.AddFirst(3);
            numbers.AddFirst(1);
            numbers.AddFirst(9);
            numbers.AddFirst(7);
            numbers.AddFirst(2);

            var max = Max(numbers.First);

            System.Console.WriteLine(max);
        }

        private static int Max(LinkedListNode<int> nextNode, int max = 0)
        {
            if (nextNode == null)
            {
                return max;
            }
            else
            {
                var newMax = nextNode.Value > max ? nextNode.Value : max;
                return Max(nextNode.Next, newMax);
            }
        }

        private static void CountList()
        {
            var numbers = new LinkedList<int>();
            numbers.AddFirst(3);
            numbers.AddFirst(1);
            numbers.AddFirst(9);
            numbers.AddFirst(7);
            numbers.AddFirst(2);

            var count = CountItems(numbers.First);
            System.Console.WriteLine(count);
        }

        private static int CountItems(LinkedListNode<int> nextNode)
        {
            if (nextNode == null)
            {
                return 0;
            }
            else
            {
                return CountItems(nextNode.Next) + 1; 
            }
        }

        private static void DoSum()
        {
            var numbers = new Stack<int>();
            numbers.Push(6);
            numbers.Push(4);
            numbers.Push(2);

            System.Console.WriteLine(Sum(numbers));
            
        }

        private static int Sum(Stack<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return 0;
            }
            else
            {
                return numbers.Pop() + Sum(numbers);
            }
        }

        private static void Factorial()
        {
            var factorial = Fact(5);
            System.Console.WriteLine(factorial);
        }

        private static int Fact(int i)
        {
            if (i == 1)
            {
                return 1;
            }

            return i * Fact(i - 1);
        }

        private static void QuickSort()
        {
            int[] arrayNumbers = new int []{ 1,2,3,4,5 };
            int arrayLength = arrayNumbers.Length;
            int sumOfArray = 0;
	        while (arrayLength > 1)
	        {
			        sumOfArray =  sumOfNumbers(arrayNumbers.Take(arrayLength));
                    arrayLength--;
	        }	
            System.Console.WriteLine(sumOfArray);
        }

        private static int sumOfNumbers(IEnumerable<int> arrayNumbers)
        {
            int sum = arrayNumbers.First();
            return sum += arrayNumbers.Skip(1).Sum();
        }

        private static void BinarySearchQuickSort()               
        {
            string NamesToDisplay = "";
            var listNames = new LinkedList<string>();
            listNames.AddFirst("Alice");
            listNames.AddFirst("Amy");
            listNames.AddFirst("Anne");
            listNames.AddFirst("Hannah");
            listNames.AddFirst("Sharon");

            NamesToDisplay = PrintNamesStartingWithA(listNames.First, "");
            
            Console.WriteLine(NamesToDisplay);
        }

        private static string PrintNamesStartingWithA(LinkedListNode<string> name, string returned)
        {
            if (name == null)
            {
                return returned;
            }
            return PrintNamesStartingWithA(name.Next, returned + (name.Value.StartsWith("A") ? name.Value +"," : ""));
        }

        private static void MovieSearch()
        { 
            string [] movies = new string []{"Dumb and Dumber", "Final Destination","Rocky", "Speed","The Notebook"};
            ///int binaryPosition = BinarySearch(movies);
            //Console.WriteLine(binaryPosition);
            int recursivePosition = RecursiveAlgorithm(movies, movies.Length);
            Console.WriteLine(recursivePosition);
        }

        private static int BinarySearch(string[] movies, string searchElement = "Speed")
        {
           
            int lowPosition = 0;
            int highPosition = movies.Length;
            
            while (lowPosition <= highPosition) 
            {
                int middlePosition = (lowPosition + highPosition) / 2;
                string guess = movies[middlePosition];

                if (Compare(searchElement, guess) == 0)
                {
                    return middlePosition;
                }
                else if (Compare(searchElement, guess) > 0)
                {
                    lowPosition = middlePosition + 1;
                }
                else
                {
                    highPosition = middlePosition - 1;
                }                
            }
            return -1;
        }

        private static int Compare(string searchElement, string guess)
        {
            return String.Compare(searchElement, guess, true);
        }

        private static int RecursiveAlgorithm(string[] movies, int highPosition, int lowPosition = 0)
        {
            string findMovie = "Speed";
            int middlePosition = (highPosition + lowPosition) / 2;
            string guess = movies[middlePosition];
            if (Compare(findMovie, guess) == 0)
            {
                return middlePosition+1;
            }
            else if (Compare(findMovie, guess) > 0)
            {
                lowPosition = middlePosition + 1;
            }
            else
            {
                highPosition = middlePosition - 1;
            }   
            return RecursiveAlgorithm(movies,highPosition, lowPosition);
        }

        static void TowerOfHanoi()
        {
            MoveDisk(5, _towerA, _towerB, _towerC);
        }

        static void MoveDisk(int numberOfDisks, string fromTower, string intermediateTower, string toTower)
        {
            //if (numberOfDisks == 1)
            //{
            //    System.Console.WriteLine($"Disk 1 from { fromTower} to { toTower }");
            //}
            //else
            //{
            //    MoveDisk(numberOfDisks - 1, fromTower, toTower, intermediateTower);

            //    System.Console.WriteLine($"Disk { numberOfDisks} from { fromTower} to { toTower }");

            //    MoveDisk(numberOfDisks - 1, intermediateTower, fromTower, toTower);
            //}
        }
    }
}
