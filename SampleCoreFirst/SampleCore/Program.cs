//top level programming example
//this is along the idea of using the linqpad ide
//done to try to make learning simple programming concepts without
//          the a program shell showing

using System;
using System.IO;
using static System.Console;

string[] studentsA02 = new string[] { "Gartner", "Olthoff", "Kozmak", "Zielke", "Gauthier", "Murray", "Chen", "Emmanuel" };

string[] otherstudentsA02 = new string[] { "Best", "Brower", "Cairns", "Del Colle", "Neufeld", "Pang", "Popik", "Sayong", "Walton",  "Wu"};

string[] nonstudentsA02 = new string[] { "lopez", "Riad", "Sylvester", "Tran", "Wilber" };

string[] studentsA03 = new string[] { "Lawa", "Braydon", "Zach", "Midori", "William", "Norris", "Josh" };

string[] nonstudentsA03 = new string[] { "Dominic", "Piery", "Mathieu", "Sinjan", "James", "Lucas", "Chandandeep", "Clayton", "Jashandeep", "Michal" };

string[] otherstudentsA03 = new string[] { "Rod", "Zhe", "Jeremy", "Sang"};

Random rdn = new Random();
    
int index = 0;
int assigned = 0;
string accept = "";
while (assigned < nonstudentsA03.Length)
{
    index = rdn.Next(1, nonstudentsA03.Length);
    WriteLine($"student {nonstudentsA03[index - 1]}, accept (y,n)\t");
    accept = ReadLine();
    if (accept.ToUpper().Equals("Y"))
    {
        assigned++;
    }
}
    
//WriteLine("Hello World from .Net 5");

////you still have access to thing like the args on the Main()
//WriteLine(args.Length);

////using the new concept of record datatype
////think LinqPad Program ide: 1 the body 2 then definitions

////body of main method - Executable Statements
//var friend = new Person("Don", "Welch", 65);
//WriteLine(friend);
////int years = PromptUser("How long have you known Don:\t");
////WriteLine($"{years} is a long time");

//string data = friend.ToString();
//WriteLine(data);

////Deconstructor of record
//var (first, last, age) = friend;
//WriteLine($"first={first} last={last} age={age}");

////file i/o
////use relative addressing to change the location of output
////default is in bin/xxxx/net5.0  where xxxx is either Debug or Release
////      wherever the .exe is located

////output
//File.WriteAllText("../../../Demo", friend.ToString());
////input
//int total = 0;
//foreach(string fileline in File.ReadAllLines("../../../NumberFile.txt"))
//{
//    int num = int.Parse(fileline);
//    total += num;
//}
//WriteLine($"total is {total}");

////programmer defined methods and types - declartions

////methods 1st
//int PromptUser(string message)
//{
//    Write(message);
//    return int.Parse(ReadLine());
//}

////types 2nd
//record Person(string FirstName, string LastName, int Age);