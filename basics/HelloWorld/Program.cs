// See https://aka.ms/new-console-template for more information

//Console is a class, this is a new template, use link above to see old template
/* --- OLD CONSOLE TEMPLATE ---

using System;

namespace HelloWorld // namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

*/


// WriteLine - Always prints on a new line - Most often used.
// Write - Will add to current line
// Console.WriteLine("Hello, World!");
// Console.Write("First");
// Console.Write("Second");
// Console.WriteLine("Hello, World!");
// Console.Write("Third");


/*
dotnet run result:

Hello World!
FirstSecondHello, World!
Third

*/



// ########## VARIABLES ##########


using System;
namespace HelloWorld // namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // sbyte = Signed Byte: 8-bit integers, value range: -128 - 127
            sbyte mySbyte = 127;
            sbyte mySecondSbyte = -128;

            // byte = Unsigned Byte: 8-bit integers, value range: 0 - 255
            byte myByte = 255;
            byte mySecondByte = 0;

            // short = Signed Short: 16-bit integer, value range -32768 - 32767 
            short myShort = -32768; // Signed Short - maximum value: -32768 - 32768

            // ushort = Unsigned Short: 16-bit integer, value range 0 - 65535
            ushort myUshort = 65535;

            // int = Signed Integer - most used: 32-bit integer,value range: -2,147,483,648 - 2,147,483,647
            int myInt = 2147483647;
            int mySecondInt = -2147483648;

            // long = Signed Integer: 64-bit integer, value range: -9,223,372,036,854,775,808 - 9,223,372,036,854,775,807
            long myLong = 9223372036854775807;  
            long mySecondLong = -9223372036854775808;  

            // float = Signed Decimal: 32-bit decimal (single-precision)
            float myFloat = 0.751f; // must include "f" in the value to denote that it is a float C# will infer this to be a "double" otherwise
            float mySecondFloat = 0.751f;
            float myThirdFloat = 0.75f;
            
            // double = Signed Decimal: 64-bit decimal (double-precision) -- "d" is optional, 
            double myDouble = 0.751;
            double mySecondDouble = 0.751d;
            double myThirdDouble = 0.75d;

            // decimal = Signed Decimal: 128-bit denoted with "m"
            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.751m;
            decimal myThirdDecimal = 0.75m;
            
            /*
                Float and Double have some variation in accuracy
                Float & Double use less space but less accurate
                Decimal needs more space but more accurate
            */
            Console.WriteLine("Second value = 0.751");
            Console.WriteLine(myFloat - mySecondFloat); // second value: 0.751 = 0
            Console.WriteLine(myDouble - mySecondDouble); // second value: 0.751 = 0
            Console.WriteLine(myDecimal - mySecondDecimal); // second value: 0.751 = 0.000
            
            Console.WriteLine("Second value = 0.75");          
            Console.WriteLine(myFloat - myThirdFloat); //  0.0009999871
            Console.WriteLine(myDouble - myThirdDouble); // 0.0010000000000000009
            Console.WriteLine(myDecimal - myThirdDecimal); // 0.001


            string myString = "Hello World!";
            Console.WriteLine(myString);

            bool myBool = true;
            Console.WriteLine(myBool);
            
        }
    }
}