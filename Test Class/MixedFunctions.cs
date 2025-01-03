using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Day = System.DayOfWeek;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Class
{
    public partial class MixedFunctions : AbstractClass
    {

        public static List<List<uint>> gidList = new();
        public static uint autoGenID = 0;
        public string MixedFunctionsStr { get; set; } = "";

        public string Name = "";
        public int Age;

        /// <summary>
        /// Constructor
        /// </summary>
        public MixedFunctions()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mixedFunctionStr"></param>
        public MixedFunctions(string mixedFunctionStr)
        {
            MixedFunctionsStr = mixedFunctionStr;
        }

        public void Deconstruct(out string mixedFunctionStr)
        {
            mixedFunctionStr = this.MixedFunctionsStr;
        }

        /// <summary>
        /// This method is to find the Next number without any identical digit to the original number k
        /// </summary>
        /// <param name="k">The Original Number</param>
        /// <returns>The Next Number</returns>
        public int Next(int k)
        {
            #region Old Code
            //var originalK = k;
            //var intList = new List<int>();

            //if (k == 0)
            //{
            //    return 1;
            //}

            //for (; k != 0; k /= 10)
            //    intList.Add(k % 10);

            //var originalArr = intList.ToArray();
            //Array.Reverse(originalArr);

            //int next = originalK + 1;

            //while (true)
            //{
            //    bool hasCommonDigits = false;

            //    var nextintList = new List<int>();

            //    var toCheck = next;

            //    for (; toCheck != 0; toCheck /= 10)
            //        nextintList.Add(toCheck % 10);

            //    var nextArray = nextintList.ToArray();

            //    foreach (var digit in nextArray)
            //    {
            //        if (originalArr.Contains(digit))
            //        {
            //            hasCommonDigits = true;
            //            break;
            //        }
            //    }

            //    if (!hasCommonDigits)
            //    {
            //        return next;
            //    }

            //    next++;
            //}
            #endregion Old Code

            #region New Code
            // Convert integer to string and get its digits
            string originalDigits = k.ToString();

            // Function to check if the digits of the number are all different from the original digits
            bool HasUniqueDigits(int number, string originalDigits)
            {
                string numberDigits = number.ToString();
                foreach (char digit in numberDigits)
                {
                    if (originalDigits.Contains(digit))
                    {
                        return false; // Found a matching digit
                    }
                }
                return true; // No matching digits found
            }

            int next = k + 1;

            // Iterate to find the next integer with unique digits
            while (true)
            {
                if (HasUniqueDigits(next, originalDigits))
                {
                    return next;
                }
                next++;
            }
            #endregion New Code
        }

        /// <summary>
        /// Requeue with spacing for the String
        /// </summary>
        /// <param name="n">The n number of spacing</param>
        /// <param name="str">The string itself</param>
        /// <returns>The string with the n spcaing</returns>
        /// <exception cref="ArgumentException"></exception>
        public string Requeue(int n, string str)
        {
            if (n <= 0)
            {
                throw new ArgumentException("The value of n must be greater than 0.");
            }

            str = str.Replace(" ", "");

            var result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (i > 0 && i % n == 0) // i must divide n = 0
                {
                    result.Append(' '); // Insert a space after every `n` characters
                }

                result.Append(str[i]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Find Fibonacci series and display in string
        /// </summary>
        /// <param name="n"></param>
        public void Fibonacci(int n)
        {
            List<int> FibonacciList = new List<int>();

            int firstTerm = 0;
            int secondTerm = 1;

            int nextTerm = 0;

            FibonacciList.Add(firstTerm);   //0
            FibonacciList.Add(secondTerm);  //1

            nextTerm = firstTerm + secondTerm;  //0+1 = 1
            Console.WriteLine("First nextTerm = " + nextTerm);

            while (nextTerm <= n)
            {
                FibonacciList.Add(nextTerm);
                firstTerm = secondTerm; //Set the previous secondTerm as firstTerm
                secondTerm = nextTerm;  //Set the previous nextTerm as secondTerm
                nextTerm = firstTerm + secondTerm;
                Console.WriteLine("nextTerm = " + nextTerm);
            }

            string fibonacciStringDisplay = "Fibonacci series : ";

            foreach (int i in FibonacciList)
            {
                fibonacciStringDisplay += i.ToString() + ", ";
            }

            Console.WriteLine(fibonacciStringDisplay);
        }

        public static int FibonacciRecursion(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
            {
                return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
            }
        }

        public double GetFibonacci(int n)
        {
            //Golden Ratio (phi)
            double phi = (1 + Math.Sqrt(5)) / 2;

            //Binet's formula
            return (Math.Pow(phi, n) - Math.Pow(1 - phi, n)) / Math.Sqrt(5);
        }

        /// <summary>
        /// Sample of Task 1
        /// </summary>
        /// <returns></returns>
        public static async Task Task1()
        {
            await new Task(() => Thread.Sleep(TimeSpan.FromSeconds(5)));
            Debug.WriteLine("Finished Task1");
        }

        /// <summary>
        /// Sample of Task 2
        /// </summary>
        /// <returns></returns>
        public static async Task Task2()
        {
            await new Task(() => Thread.Sleep(TimeSpan.FromSeconds(10)));
            Debug.WriteLine("Finished Task2");
        }

        /// <summary>
        /// Main Async Task
        /// </summary>
        /// <returns></returns>
        public static async Task MainAsync()
        {
            Task task1 = Task1();
            Task task2 = Task2();

            Console.WriteLine("Task.Delay 600 Starts");
            await Task.Delay(600);
            Console.WriteLine("Task.Delay 600 Ends");

            await Task.WhenAll(task1, task2);
            Debug.WriteLine("Done MainAsync");

            await ComputeSumAsync(2, 3);
        }

        /// <summary>
        /// Compute Sum Async numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static async Task<int> ComputeSumAsync(int a, int b)
        {
            await Task.Delay(1000);
            return a + b;
        }

        public IEnumerable<int> ExtractNumbers(string input)
        {
            Regex regex = new Regex(@"\d+");

            return regex.Matches(input)
                    .Cast<Match>()
                    .Select(m => int.Parse(m.Value));
        }

        //Disk Space split for Files
        //512 for each partition
        //ClusterFileSize

        /// <summary>
        /// This method created is to calculate ingredients ratio needed for number of people servings
        /// </summary>
        /// <param name="personToCookFor">number of people</param>
        /// <param name="ingredients">ingredients amount(ml, g)</param>
        public void CalculateIngredientRatioNeeded(int personToCookFor, List<string> ingredients)
        {
            char delimiter = ' ';

            var splittedIngredientList = new List<string[]>();

            var finalRatioOfIngredientList = new List<int>();

            var finalIngredientList = new Dictionary<string, string>();

            foreach (var ingredient in ingredients)
            {
                string[] splittedIngredient = ingredient.Split(delimiter);  //Split via Delimiters

                splittedIngredientList.Add(splittedIngredient); //Add splittedIngredients to splittedIngredientList
            }

            foreach (var splitted in splittedIngredientList)
            {
                string concatIngredientName = string.Empty;

                for (int i = 1; i < splitted.Length; i++) 
                {
                    concatIngredientName += splitted[i] + " ";
                }

                int resultsplitted;

                if (int.TryParse(splitted[0], out resultsplitted))
                {
                    var ratio = int.Parse(splitted[0]) * personToCookFor;

                    finalIngredientList.Add(ratio.ToString(), concatIngredientName);
                }
                else
                {
                    // Use Regex to split digits and letters
                    // (\d+) Matches one or more digits
                    // (\D+) Matches one or more non-digits character(i.e., letters)
                    Match match = Regex.Match(splitted[0], @"(\d+)(\D+)");

                    var ratio = int.Parse(match.Groups[1].Value) * personToCookFor;

                    concatIngredientName = match.Groups[2].Value + " " + concatIngredientName;

                    finalIngredientList.Add(ratio.ToString(), concatIngredientName);
                }
            }

            Console.WriteLine("Total Ingredients Needed: ");

            foreach(var final in finalIngredientList)
            {
                Console.WriteLine(final.Key.ToString() + " " + final.Value.ToString());
            }
        }

        public void SetGIDList(int ID)
        {
            List<uint> IDitem = new List<uint>()
            {
                autoGenID,
                (uint)ID,
            };

            if (!gidList.Any(innerlist => innerlist?.ElementAt(1) == ID))
            {
                gidList.Add(IDitem);
                autoGenID++;
                Console.WriteLine($"Added {IDitem}.");
            }
            else
            {
                var recordIndex = gidList.FindIndex(innerlist => innerlist?.ElementAt(1) == ID);
                var selectedRecord = gidList[recordIndex];
                Console.WriteLine($"Duplicate ID exists with Index:[{recordIndex}], AutoGenID:[{selectedRecord[0]}], IDItem:[{selectedRecord[1]}].");
            }
        }

        public void UpdateGIDList(uint oldID, uint newID)
        {

        }

        private int SearchElementIndex(List<string> sampleList, string elementToSearch)
        {
            int i = 0;

            while (sampleList[i] != elementToSearch)
            {
                i++;
            }
                
            return i;
        }

        public string ReverseAllWords(string words)
        {
            return new string(words.Reverse().ToArray());
        }

        //params to accept varying number of arguments
        public void PrintNumbers(params int[] numbers)
        {
            foreach (var num in numbers)
            {
                Console.WriteLine(num + " ");
            }
        }

        public static int TernarySearch(int[] arr, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid1 = left + (right - left) / 3;
                int mid2 = right - (right - left) / 3;

                if (arr[mid1] == target)
                    return mid1;

                if (arr[mid2] == target)
                    return mid2;

                if (target < arr[mid1])
                {
                    right = mid1 - 1; // Search in the left third
                }
                else if (target > arr[mid2])
                {
                    left = mid2 + 1; // Search in the right third
                }
                else
                {
                    left = mid1 + 1;  // Search in the middle third
                    right = mid2 - 1;
                }
            }

            return -1;
        }

        public string FindingSubString(string input, string substring)
        {
            int index = input.IndexOf(substring);

            if (index >= 0)
            {
                string subStr = input.Substring(index);
                Console.WriteLine(subStr);
                return subStr;
            }
            else
            {
                Console.WriteLine("SubString not found!");
                return "SubString not found!";
            }
        }

        string GenericFunctionStr<T>() where T : IBaseInterface
        {
            return typeof(T).GetType().Name;
        }

        public void Add_Multiple(int a, int b, ref int add, ref int multiply)
        {
            add = a + b;
            multiply = a * b;
        }

        public void Add_Multiple2(int a, int b, out int add, out int multiply)
        {
            add = a + b;
            multiply = a * b;
        }

        public async void Divide(int value1, int value2)
        {
            try
            {
                int div = value1 / value2;
                Console.WriteLine($"div=" + div);
            }
            catch (Exception _) when (value2 == 0)
            {
                Console.WriteLine("Value 2 is zero! {ex.Message}");
            }
            catch (Exception _)
            {
                await AsyncMethodForCatch();
            }
            finally 
            {
                await AsyncMethodForFinally();
            }
        }

        private async Task AsyncMethodForFinally()
        {
            await Task.Delay(2000);
            Console.WriteLine("Method for async Finally ");
        }

        private async Task AsyncMethodForCatch()
        {
            await Task.Delay(1000);
            Console.WriteLine("Method for async Catch ");
        }

        public static string? AdjustWidth(string value, int length)
        {
            return value?.Substring(0, Math.Min(value.Length, length)).PadRight(length);
        }

        public string? Truncate(string value, int length)
        {
            //Null-Conditional Operator for value? instead of value!= null
            return value?.Substring(0, Math.Min(value.Length, length));
        }

        public override string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }
        public override int GetAge()
        {
            return Age;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public void CallProtectedMethod()
        {
            base.TestProtectedMethod();
        }

        public void CallPublicMethod()
        {
            base.TestPublicMethod();
        }

        /// <summary>
        /// => As a syntax simplification in C# 6.0
        /// </summary>
        /// <returns></returns>
        public static string GetTime() => "Current Time = " + DateTime.Now.ToString("hh:mm:ss");

        public string OutputNameAndAge()
        {
            //C# 10 is using $ whereas C# 6 is using \
            return $"{Name} - {Age}";
        }

        public void SpeedOfLight()
        {
            double speedOfLight = 299792.458;
            FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";

            var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            string messageInSpecificCulture = message.ToString(specificCulture);
            Console.WriteLine(messageInSpecificCulture);
            // Output:
            // The speed of light is 2,99,792.458 km/s.

            string messageInInvariantCulture = FormattableString.Invariant(message);
            Console.WriteLine(messageInInvariantCulture);
            // Output is:
            // The speed of light is 299,792.458 km/s.

        }

        public static bool ValidAccountNumber(string accountID) => accountID?.Length == 10 && accountID.All(c => char.IsDigit(c));

        public string FormatMessage(string attributeName)
        {
            string result;
            if (!Enum.TryParse<FileAttributes>(attributeName, out var attributeValue))
            {
                string[] strAttr;
                result = string.Format("'{0}' is not one of the possible {2} option combinations ({1})",
                    attributeName,
                    string.Join(",", strAttr = Enum.GetNames(typeof(FileAttributes))),
                        strAttr.Length);
            }
            else
            {
                result = string.Format("'{0}' has a corresponding value of {1}",
                    attributeName, attributeValue);
            }
            return result;
        }

        public static bool LinearSearch<T>(IEnumerable<T> collection, T target)
        {
            foreach (var item in collection)
            {
                if (EqualityComparer<T>.Default.Equals(item, target))
                {
                    return true; // Element found
                }
            }
            return false; // Element not found
        }

        public static int TotalAllEvenNumbers(int[] intArray)
        {
            //LINQ
            return intArray.Where(i => i % 2 == 0).Sum(i => i);
        }

        public static bool AreAnagrams(string str1, string str2)
        {
            str1 = str1.Trim().Replace(" ", "").ToLower();
            str2 = str2.Trim().Replace(" ", "").ToLower();

            if (str1.Length != str2.Length)
                return false;

            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            return new string(arr1) == new string(arr2);
        }

        public string SpanValue(string spanValue = "26 11 2024")
        {
            //0123456789
            //26 11 2024
            //2611 2024
            string day = string.Concat(spanValue.AsSpan(0, 2),
                spanValue.AsSpan(3, 3),
                spanValue.AsSpan(6, 4));

            return day;
        }

        public void StackAlloc()
        {
            Span<int> first = stackalloc int[3] { 1, 2, 3 };
            Span<int> second = stackalloc int[] { 1, 2, 3 };
            ReadOnlySpan<int> third = stackalloc[] { 1, 2, 3 };

            // Using collection expressions:
            Span<int> fourth = [1, 2, 3];
            ReadOnlySpan<int> fifth = [1, 2, 3];

            int length = 3;
            Span<int> numbers = stackalloc int[length];
            for (var i = 0; i < length; i++)
            {
                numbers[i] = i;
            }
        }

        public void ImplicitlyLocalTypeVariable()
        {
            var greeting = "Hello";
            Console.WriteLine(greeting.GetType());  // output: System.String

            var a = 32;
            Console.WriteLine(a.GetType());  // output: System.Int32

            var xs = new List<double>();
            Console.WriteLine(xs.GetType());  // output: System.Collections.Generic.List`1[System.Double]
        }

        public void refAssignmentOperator()
        {
            void Display(int[] s) => Console.WriteLine(string.Join(" ", s));

            int[] xs = [0, 0, 0];
            Display(xs);

            ref int element = ref xs[0];
            element = 1;
            Display(xs);

            element = ref xs[^1];
            element = 3;
            Display(xs);
            // Output:
            // 0 0 0
            // 1 0 0
            // 1 0 3
        }

        public void ThreadJoin()
        {
            List<Thread> workerThreads = new List<Thread>();
            List<int> results = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(() => {
                    Thread.Sleep(new Random().Next(1000, 5000));
                    lock (results)
                    {
                        results.Add(new Random().Next(1, 10));
                    }
                });
                workerThreads.Add(thread);
                thread.Start();
            }
            // Wait for all the threads to finish so that the results list is populated.
            // If a thread is already finished when Join is called, Join will return immediately.

            foreach (Thread thread in workerThreads)
            {
                thread.Join();
            }

            Debug.WriteLine("Sum of results: " + results.Sum());
        }

    }

    /// <summary>
    /// Prevent this class from getting Override using sealed access modifier
    /// </summary>
    public sealed class SealedClass
    {
        private string name = "";
        private string Name { get => name; set => name = value; }


    }

    public static class StaticClass
    {
    }

    public abstract class AbstractClass
    {
        public abstract string GetName();

        public abstract int GetAge();

        protected void TestProtectedMethod()
        {
            Console.WriteLine("Method test!");
        }

        public void TestPublicMethod()
        {

        }
    }

    public class ChildClass : BaseClass
    {
        public ChildClass() : this(10)
        {

        }

        public ChildClass(int pValue)
        {

        }


    }

    public struct Structed
    {
        public Structed(int no, string name)
        {
            No = no;
            Name = name;
        }
        public int no;  //Assign
        public int No
        {
            get => this.no;
            set => no = value;
        }

        public string? name; //Assign
        public string? Name
        {
            get => this.name;
            set => name = value;
        }
    }

    public class BankAccount(string accountID, string owner)
    {
        public string AccountID { get; } = ValidAccountNumber(accountID)
            ? accountID
            : throw new ArgumentException("Invalid account number", nameof(accountID));

        public string Owner { get; } = string.IsNullOrWhiteSpace(owner)
            ? throw new ArgumentException("Owner name cannot be empty", nameof(owner))
            : owner;

        public override string ToString() => $"Account ID: {AccountID}, Owner: {Owner}";

        public static bool ValidAccountNumber(string accountID) =>
        accountID?.Length == 10 && accountID.All(c => char.IsDigit(c));
    }



    public class SelfQueue<T> where T : class
    {
        private Stack<T> input = new Stack<T>();
        private Stack<T> output = new Stack<T>();

        /// <summary>
        /// Push t to input
        /// </summary>
        /// <param name="t"></param>
        public void Enqueue(T t)
        {
            input.Push(t);
        }

        /// <summary>
        /// if output is 0, pop 1 input and push it to output and pop output
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (output.Count == 0)
            {
                while (input.Count > 0) 
                {
                    output.Push(input.Pop());
                }    
            }

            return output.Pop();
        }
    }

    public class Theremostat
    {
        private event EventHandler<float>? OnTemperatureChanged;
        private int _Temperature;
        public int Temperature
        {
            get
            {
                return _Temperature;
            }
            set
            {
                _Temperature = value;
                OnTemperatureChanged?.Invoke(this, value);
                // If there are any subscribers, then
                // notify them of changes in temperature
                //EventHandler<float>? localOnChanged = OnTemperatureChanged;

                //if (localOnChanged != null)
                //{
                //    _Temperature = value;
                //    // Call subscribers
                //    localOnChanged(this, value);
                //}
            }
        }
    }

    public class DayCollection
    {
        string[] days = ["Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"];

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);

        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }

            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
    }

    public class DayOfWeekCollection
    {
        Day[] days =
        [
            Day.Sunday, Day.Monday, Day.Tuesday, Day.Wednesday,
        Day.Thursday, Day.Friday, Day.Saturday
        ];

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[Day day] => FindDayIndex(day);

        private int FindDayIndex(Day day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }
            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be a defined System.DayOfWeek value.");
        }
    }

    public class NumberStore
    {
        //reference return
        private readonly int[] numbers = [1, 30, 7, 1557, 381, 63, 1027, 2550, 511, 1023];

        public ref int GetReferenceToMax()
        {
            ref int max = ref numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = ref numbers[i];
                }
            }
            return ref max;
        }

        public override string ToString() => string.Join(" ", numbers);
    }

}
