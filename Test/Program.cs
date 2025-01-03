// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using Test_Class;

var myList = new List<string>();
var myDict = new Dictionary<int, string>();
var myQueue = new Queue<string>(); 

int[] marks = new int[3] { 1, 2, 3 };
int[,] marks2D = new int[3,3] { {1, 2, 3}, {4, 5, 6}, { 7, 8, 9 } };

Console.WriteLine("Hello, World!");

Structed structed;
structed.no = 101;
structed.name = "Structed Name";

MixedFunctions mixedFuncClass = new MixedFunctions();
List<string> ingredientList= new List<string>();

int intVal = 250;
byte byteVal = (byte)intVal;
Console.WriteLine("byteVal=" + byteVal);

var anonymousData = new
{
    ForeName = "Hehe",
    SurName = "Haha"
};

string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
Array.Sort(cars);
foreach (string i in cars)
{
    Console.WriteLine(i);
}

//int.TryParse(str, out var number);
Console.WriteLine("EnumTryParse = " + Enum.TryParse("None", out MyEnum eNum));

Console.WriteLine(mixedFuncClass.FormatMessage("Attributez"));

HashSet<int> evenNumbers = new HashSet<int>();
HashSet<int> oddNumbers = new HashSet<int>();

for (int i = 0; i < 5; i++)
{
    // Populate numbers with just even numbers.
    evenNumbers.Add(i * 2);

    // Populate oddNumbers with just odd numbers.
    oddNumbers.Add((i * 2) + 1);
}

Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
DisplaySet(evenNumbers);

Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
DisplaySet(oddNumbers);

#region HashSet
// Create a new HashSet populated with even numbers.
HashSet<int> numbers = new HashSet<int>(evenNumbers);
Console.WriteLine("numbers UnionWith oddNumbers...");
numbers.UnionWith(oddNumbers);

Console.Write("numbers contains {0} elements: ", numbers.Count);
DisplaySet(numbers);

void DisplaySet(HashSet<int> collection)
{
    Console.Write("{");
    foreach (int i in collection)
    {
        Console.Write(" {0}", i);
    }
    Console.WriteLine(" }");
}
#endregion HashSet

int anInteger = 42; // assignment.
ref int location = ref anInteger; // ref assignment.
ref int sameLocation = ref location; // ref assignment
Console.WriteLine("location =" + location); // output: 42
sameLocation = 19; // assignment
Console.WriteLine("anInteger =" + anInteger); // output: 19

Console.WriteLine(mixedFuncClass.SpanValue());

mixedFuncClass.SetName("Abstract Class");
Console.WriteLine($"mixedFuncClass's abstractClass Name is " + mixedFuncClass?.Name?? "No Name");
Console.WriteLine($"Nameof mixedFuncClass = " + nameof(mixedFuncClass));
Console.WriteLine($"Nameof MixedFunctions = " + nameof(MixedFunctions));
//?? if got the output Name else "No Name"

string check = "ab cde fghi";

int k1 = 2;
int k2 = 2012;
int k3 = 4567;
int k4 = 69999;

ingredientList.Add("1 Cup of Flour");
ingredientList.Add("500ml of Water");
ingredientList.Add("3 Eggs");
ingredientList.Add("100g of Chocolate Sprinkles");

var dayCollect = new DayCollection();
var week = new DayOfWeekCollection(); 
int v = dayCollect["Tues"];
Console.WriteLine($"dayCollect for v = {v}");
Console.WriteLine($"Day of week ={week[DayOfWeek.Tuesday]}");

Console.WriteLine("mixedFuncClass.Requeue(3, check)=[" + mixedFuncClass.Requeue(3, check) + "]");

Console.WriteLine("Reverse String = [" + mixedFuncClass.ReverseAllWords(check) + "]");

mixedFuncClass.SetGIDList(1);
mixedFuncClass.SetGIDList(2);
Console.WriteLine(mixedFuncClass.Next(k1));
Console.WriteLine(mixedFuncClass.Next(k2));
Console.WriteLine(mixedFuncClass.Next(k3));
Console.WriteLine(mixedFuncClass.Next(k4));

mixedFuncClass.SetGIDList(3);
mixedFuncClass.Fibonacci(100);

mixedFuncClass.CalculateIngredientRatioNeeded(3, ingredientList);

mixedFuncClass.SetGIDList(3);

var wateringredientQuery = from ingredient in ingredientList where ingredient.Contains("Water") select ingredient;

foreach (var wateringredient in wateringredientQuery)
{
    Console.WriteLine($"wateringredientQuery = {wateringredient}");
}

Console.WriteLine("MixedFunctions.FibonacciRecursion = [" + MixedFunctions.FibonacciRecursion(10) + "]");

mixedFuncClass.PrintNumbers(1, 2, 3);
mixedFuncClass.PrintNumbers(10, 20, 30, 40, 50);

mixedFuncClass.FindingSubString(ingredientList[3], "Chocolate");


//Object?
//A class or struct definition is like a blueprint that
//specifies what the type can do. An object is basically a
//block of memory that has been allocated and configured
//according to the blueprint.

//Managed or Unmanaged Code
//Managed code -> The code which is developed in .NET Framework
//is known as managed code. This code is directly exceuted by
//CLR with the help of managed code execution. Any language that
//is written in .NET Framework is managed code.
//Unmanaged code -> The code which is developed outside of .NET
//Framework is known as unmanaged code. Applications that do not
//run under the control of CLR are said to be unmanaged

//==  vs Equals()
//== operator compares the identity of the reference
//Equals() compares only the reference

//Explain code compilation of C#
//C# compiler compile source code into Managed code
//Putting newly created code together into assemblies
//Common Language Runtime is being loaded
//CLR is carrying out the assembly

//Generic Class?
//Generice also known as generice classes, create courses or objects
//that do not have specific data type. The data type can be assigend
//at runtime.

//Differences between Class and Struct
//
//Class
//reference type in C# and inherits from System.Object
//Support inheritance
//Class is Pass by reference (reference type)
//Members are private by default
//Suitable for larger and complex objects
//Can use waste collector for memory management
//
//Struct
//value type in C# and inherits from System.Value
//Does not support inheritance
//Struct is Pass by copy (Value type)
//Members are public by default
//Suitable for small and isolated models
//Cannot use Garbage collector and hence no memory management

//return multiples values from a function in C#?
//ref/out parameters. A return statement can be used for return
//one value from a function. By using output parameters, return
//two values from a function.
//See sample: Add_Multiple & Add_Multiple1

//Anonymous type in C#
//Create new type without defining them.
//Define read only properties into a single obj without having to define
//type explicitly.
//Sample:
//var anonymousData = new
//{
//    ForeName = "Hehe",
//    SurName = "Haha"
//};

//Encapsulation?
//Encapsulation is implemented by access specifiers
//Public -> allow a class to expose its member variables and member functions to
//other functions and objects. Any public member can be accessed from outside of the class
//Private -> allow a class to hide its member variables and member functions to
//other functions and objects. Only functions of same class can be accessed
//its private members. Even instance also cannot access its private members.
//Protected -> allow a child class to access member variables and member functions
//of its base class. Helps in implementing inheritance

//Virtual vs Abstract
//Virtual
//Default implementation of virtual method is always required
//Can be overridden in the derived class though it is not required
//
//Abstract
//Has no implementation
//Must be implement in child class
//Derived class must implement the abstract form
//Even tho override keyword is not required, it can be used

//Can private virtual method can be overridden
//No, you can't as private virtual methods can't be accessed outside of the
//class

//Symbol to terminate a C#
//semicolon(;) is terminated by every statemenet in C#

//Explain Namespace in C#
//Namespace --> Employed in the organization of large code
//projects. Keep class names declared in one namespace does
//not conflict with the same class names declared in another.

//"using" statement in C#
//It indicates the program uses the specified namespace

//Abstraction
//Used to display on the class's essential features and hide unnnecessary information

//Polymorphism
//Refers to same method but different implementation
//Compile time Polymorphism -> Static binding, early binding and overloading
//Runtime Polymorphism -> Dynamic binding, late binding, overriding

//Dynamic type variables in C#?
//Store any type of value in the dynamic data type variable.
//Type checking for these types of variables take place at
//run-time.

//Exception handling in C#
//try -> Contains a block of code that will be checked for exceptions
//catch -> A program that catches an exception with the help of the
//exception handler
//finally -> It is a block of code written to run regardless of whether
//an exception is caught
//throw -> When problem occurs, it throws an exception

//Boxing and Unboxing
//Boxing => process of converting a value type data type tO
//the object or to any interface data type which is implemented
//by this value type. When the CLR boxes a value means when CLR
//is converting a value type to Object Type, it wraps the value
//inside a System.Object and stores it on the heap area in app
//domain
//Unboxing => A process which is used to extract the value type
//from the object or any implemented interface type. Boxing
//may be done implicitly, but unboxing have to be explicit by
//code

//What are C# I/O classes? Commonly used I/O Classes?
//File -> Aids in manipulation of file
//Stream Writer -> Used to write characters to a stream
//Stream Reader -> Used to read characters from a  stream
//String Reader -> Used to read a string buffer
//Path -> Perform operations on path information

//Stream Reader/Stream Write Class
//Used to read or write characters
//Members of Stream Reader are Close(), Read(), ReadLine();
//Members of Stream Writer are Close(), Write(), WriteLine();
//Example:
//using (StreamReader SR = new StreamReader("C:\\Read.txt"))
//{
//    string lines = null;

//    lines = SR.ReadLine();

//    while(lines != null)
//    {
//        Console.WriteLine(lines);
//    }
//    SR.Close();
//}

//using (StreamWriter SW = new StreamWriter("C:\\Read.txt"))
//{
//    SW.WriteLine("Add this Line");
//    SW.WriteLine("=============");
//    SW.Close();
//}

//Continue vs Break
//Break: Terminates the loop / Jump out of a loop
//Continue: instructs the program's control to exit only
//the current iteration / Jump over 1 iteration and then
//resume your loop execution

//What is an Array? Give the syntax for a single and multi-dimensional array
//Array is a data structure that stores multiple variables of same type.

//Jagged Array
//int[] jaggedArray = new int[4][];
//jaggedArray[0][2] = {1, 2}
//jaggedArray[1][4] = {3, 4, 5, 6}
//jaggedArray[2][3] = {7, 8, 9}
//jaggedArray[3][5] = {3, 4, 5, 6, 7}

//Some properties of Array
//Length = returns total number of elements in an array
//Size = Indicates whether array's length is fixed or not
//Read-only = Indicates whether array is read-only

//String? Properties of string class
//string class in C# represent a string
//Chars returns the current String's Char object
//length function returns the number of objects in the current String

//Escape sequence --> backslash(\) indicates an escape sequence
//\n - Newline character
//\b - Backspace
//\\ - Backslash
//\' - Single Quote
//\" - Double Quote

//Lambda Expressios in C#
//Create delegates or expression tree types
//Write local functioms that can be passed as arguments
//or returned as the value of function calls
//LINQ query expressions

//Regex?
//Regular expression is a template that can match a set of input
//regex is used for string parsing and character string replacement

//Fundamental of String operations?
//Concatenate = concat two strings
//Modify = replaces one string with another
//Compare = compare two strings
//Search = To find specific string, use StartWith and EndsWith

//Parsing
//Process of converting data type into another data type
//Eg. string example = "100"; int number = int.Parse(example);

//Destructor in C#
//Used to clean up memory and free resources
//Done by garbage collector on its own

//const vs readonly
//const -> compile-time constant: absolute constant, value is set
//during declaration, is in the IL code itself
//readonly -> run-time constant: can be set in constructor/init via
//config file i.e. App.config, but once it initializes it can't be changed

//Overloading and overriding
//Overloading -> when you have multiple methods in same scope, with same
//name but different signatures
//Eg.
//public class test
//{
// public void getStuff(int id)
//{ }
// public void getStuff(string name)
//{ }
//}
//Overriding -> Allows you to change functionality of a method in a child class
//public virtual void getStuff(int id)
//{ }
//public override void getStuff(int id)
//{ }


//What is a Delegate?
//Variable that holds the reference to a method
//It is a function pointer or reference type
//All Delegates are derived from System.Delegate namespace
//Both Delegate and technique that it refers to can have same signature

//Delegates with Events
//Delegated authority is used to initiate and manage events
//Delegate must always be declared first, followed by Events

//Events?
//Events are user actions that cause the application to receive
//notifications to which it must respond.
//A class that raises an event is known as a publisher,
//a class that responds/receives the event is known as subscriber
//If an event doesn't have one subscriber, it is never raised.
//Events are declared using Delegates
//public delegate void PrintNos();
//Event PrintNos myEvent1;

//Synchronous and Asynchronous operations
//Sync = technique for writing a thread-safe code in which
//only on thread can access a resource at any given time
//Async = method call returns immediately so that the 
//programme can perform other operations while the called
//method completes its work

//Reflection is the ability of code to access the assembly's
//metadata during runtime. A program reflects itself and uses
//metadata to inform or change its behavior



//Explain Get and Set Accessor properties
//Get and Set are referred to as Accesors.
//Properties make use of these.
//Implements a mechanism for reading and writing the values
//of private field
//These accessors are used to gain access to that private field

//Task vs Thread
//Thread represent an actual OS-level thread, with its own stack and kernel
//resources. Allow highest degree of control, and can set thread-level properties
//like stack size, apartment state or culture
//Task from Task Parallel Library offers the best of both worlds. A task doesn't
//create its own OS thread. Tasks are executed by TaskScheduler. Task allows you
//to find out when it finishes, and to return a result.

//Thread is a collection of instructions that can be executed
//to allow our program to perform concurrent processing.
//C# has only 1 thread by default. However, other threads
//can be created to run the code in parallel with original
//thread.

//Thread Class properties
//IsAlive -> When a thread is active, this value is actual
//Name -> Returns the thread's name. Set a name for the thread.
//Priority -> Returns the prioritized value of task set by OS.
//IsBackground -> Gets or sets a value that indicates whether
//a thread should be a background process or foreground

//What are diff states of Thread?
//Unstarted - A new thread has been created.
//Running - Thread begins execution.
//WaitSleepJoin - A thread calss sleep, another thread calls 
//wait and another thread calls join.
//Suspended - The thread has been halted.
//Aborted - The thread has died but has not been changed to
//state stopped.
//Stopped - The thread stopped

//Deadlock?
//A deadlock occurs when a process cannot complete its
//execution because two or more methods are awaiting the
//completion of one another. This is common in multi-threading.

//Explain Lock, Monitors and Mutex Object in Threading
//lock keyword ensures that only one thread can enter a
//specific code section at a time. lock(Objx) indicates that
//a lock is placed on Objx until this process releases it, at
//which point no other thread will be able to access Objx.
//
//Mutex is like a lock but it can work across multiple processes
//simultaneously.
//For example, 
//WaitOne() is used to lock the lock,
//and ReleaseMutex() is used to unlock it.
//Monitor.Enter(Objx);
//try
//{
//}
//finally (Monitor.Exit(Objx));

//Race condition?
//Two threads access the same resource and attempt to change
//it simultaneously, a race condition occurs. It is impossible
//to predict which thread will be the first to access the resource.
//We have 2 threads, T1 and T2 both which attempt to access
//shared resource called X. If both threads try to write a value
//to X, the last value written to X is saved but we don't
//know which have the order.

//Serialization and Deserialization
//Serialization proceess of converting code to binary format.
//Once converted to bytes, it is simple to store and write to
//a disc or other storage device.

//Deserialization recovering C# code from binary form.
//We need the serialized obhect, a stream containing the 
//serialized object and the namespace System to serialize an
//object.

//XSD file
//Abbreviation for XML Schema Definition
//Determines which elements should be present in the XMl
//and in what order and which properties should be current.
//During serialization of C# code, xsd.exe converts the classes
//to XSD compliant format.

//Jagged Array in C#
//int[][] jaggedArr = new int[5][];