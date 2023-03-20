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
using System.Linq;
namespace HelloWorld // namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // sbyte = Signed Byte: 8-bit integers, value range: -128 - 127
            // sbyte mySbyte = 127;
            // sbyte mySecondSbyte = -128;

            // byte = Unsigned Byte: 8-bit integers, value range: 0 - 255
            // byte myByte = 255;
            // byte mySecondByte = 0;

            // short = Signed Short: 16-bit integer, value range -32768 - 32767 
            // short myShort = -32768; // Signed Short - maximum value: -32768 - 32768

            // ushort = Unsigned Short: 16-bit integer, value range 0 - 65535
            // ushort myUshort = 65535;

            // int = Signed Integer - most used: 32-bit integer,value range: -2,147,483,648 - 2,147,483,647
            // int myInt = 2147483647;
            // int mySecondInt = -2147483648;

            // long = Signed Integer: 64-bit integer, value range: -9,223,372,036,854,775,808 - 9,223,372,036,854,775,807
            // long myLong = 9223372036854775807;  
            // long mySecondLong = -9223372036854775808;  

            // float = Signed Decimal: 32-bit decimal (single-precision)
            // float myFloat = 0.751f; // must include "f" in the value to denote that it is a float C# will infer this to be a "double" otherwise
            // float mySecondFloat = 0.751f;
            // float myThirdFloat = 0.75f;
            
            // double = Signed Decimal: 64-bit decimal (double-precision) -- "d" is optional, 
            // double myDouble = 0.751;
            // double mySecondDouble = 0.751d;
            // double myThirdDouble = 0.75d;

            // decimal = Signed Decimal: 128-bit denoted with "m"
            // decimal myDecimal = 0.751m;
            // decimal mySecondDecimal = 0.751m;
            // decimal myThirdDecimal = 0.75m;
            
            /*
                Float and Double have some variation in accuracy
                Float & Double use less space but less accurate
                Decimal needs more space but more accurate
            */
            // Console.WriteLine("Second value = 0.751");
            // Console.WriteLine(myFloat - mySecondFloat); // second value: 0.751 = 0
            // Console.WriteLine(myDouble - mySecondDouble); // second value: 0.751 = 0
            // Console.WriteLine(myDecimal - mySecondDecimal); // second value: 0.751 = 0.000
            
            // Console.WriteLine("Second value = 0.75");          
            // Console.WriteLine(myFloat - myThirdFloat); //  0.0009999871
            // Console.WriteLine(myDouble - myThirdDouble); // 0.0010000000000000009
            // Console.WriteLine(myDecimal - myThirdDecimal); // 0.001


            // string myString = "Hello World!";
            // Console.WriteLine(myString);

            // bool myBool = true;
            // Console.WriteLine(myBool);

        // ########## ARRAYS ##########

            // declare a string type with [] to declare it as an array of strings.
            // set value to "new string[x]" where string = array length
            // string[] myGroceryArray = new string[2];

            // assign value to index
            // myGroceryArray[0] = "Guacamole";

            // to print the value, you must specify the index. Otherwise it will print "System.String[]"
            // Console.WriteLine(myGroceryArray[0]); // Guacamole
            // Console.WriteLine(myGroceryArray[1]); // Empty line
            // Console.WriteLine(myGroceryArray[2]); // Error - System.IndexOutOfRangeException: Index was outside the bounds of the array.
            
            // You can declare values when creating the array by setting them in {}, fixed length
            // string[] mySecondGroceryArray = {"Apples", "Eggs"};
            // Console.WriteLine(mySecondGroceryArray[0]);
            // Console.WriteLine(mySecondGroceryArray[1]);

            // Adding dimenstions is denoted by commas(Dimensions = commas + 1 -- [,] = 2, [,,] = 3 etc.)
                // string[,] = Two Dimensions,
                // string[,,] = Three Dimensions

            // string[,] myTwoDimensionalArray = new string[,] {
            //     {"Apples", "Eggs"},
            //     {"Milk", "Cereal"}
            // };

            // Console.WriteLine(myTwoDimensionalArray[0,1]);


            // ########## LISTS ##########

            // List<T> = Strongly typed list of objects that can be accessed by index. "T" is type, i.e: <String>
            // List is more dynamic than arrays, doesn't need to declare length or values at time of creation.
            // Can add values by placing them in {} after the ()
            // List<string> myGroceryList = new List<string>() {"Milk", "Cereal"};

            // Console.WriteLine(myGroceryList[0]);
            // Console.WriteLine(myGroceryList[1]);

            // Add a new value
            // myGroceryList.Add("Cheese");
            // Console.WriteLine(myGroceryList[2]);


            // ########## IENUMERABLE ##########

            // IEnumerable<T> = supports simple iteration over a collection of a specified type. "T" is type
            // IEnumerable is not indexed.
            // IEnumerable<string> myGroceryIEnumerable = myGroceryList;

            // Console.WriteLine(myGroceryIEnumerable.First());


        // ########## DICTIONARIES ##########
            // C# version of an object/hash
            // Dictionary<key, value>

            // Dictionary<string, string> myGroceryDictionary = new Dictionary<string, string>(){
                // {"Cheese", "Dairy"}
            // };

            // Console.WriteLine(myGroceryDictionary["Cheese"]);

            // Dictionary<string, string[]> mySecondGroceryDictionary = new Dictionary<string, string[]>(){
                // {"Dairy", new string[]{"Cheese", "Milk"}} //will map to an array of strings
            // };
            
            // Will print the value stored to the key of "Dairy" at specified index => "Cheese"
            // Console.WriteLine(mySecondGroceryDictionary["Dairy"][0]);


        // ########## OPERATORS ##########

        // int myInt = 5;
        // int mySecondInt = 10;
        // Console.WriteLine(myInt);

        // myInt++;

        // Console.WriteLine(myInt);

        // myInt += 7;

        // Console.WriteLine(myInt);

        // myInt -= 8;

        // Console.WriteLine(myInt);

        // Console.WriteLine(myInt * mySecondInt);
        // Console.WriteLine(mySecondInt / myInt);
        // Console.WriteLine(mySecondInt + myInt);
        // Console.WriteLine(myInt - mySecondInt);
        // Console.WriteLine(5 + 5 * 10);
        // Console.WriteLine((5 + 5) * 10);


        // // Exponents
        // Console.WriteLine(Math.Pow(5,4)); // 5 raised to the power of 4: Math.Pow(a,b) function. a = base, b = exponent
        // Console.WriteLine(Math.Sqrt(5)); // Square root



        // string myString = "test.";

        // Console.WriteLine(myString);

        // myString += " second test."; // concatonates like javascript. Same line, adds to end.

        // Console.WriteLine(myString);
        
        // myString = myString + " third test."; // concatonates like javascript. Same line, adds to end.

        
        // Console.WriteLine(myString);

        // myString = myString + " \"fourth\" test."; // using \ as an "escape" to add quotes

        // Console.WriteLine(myString);

        // string[] myStringArray = myString.Split(". ");
        // string[] myStringArray2 = myString.Split(".");

        // Console.WriteLine(myStringArray[0]);
        // Console.WriteLine(myStringArray[1]);
        // Console.WriteLine(myStringArray[2]);
        // Console.WriteLine(myStringArray[3]);

        // Console.WriteLine(myStringArray2[0]);
        // Console.WriteLine(myStringArray2[1]);
        // Console.WriteLine(myStringArray2[2]);
        // Console.WriteLine(myStringArray2[3]);

        // ".Equals" returns a boolean value based on the condition
        // same thing as use "==". "!=" is also available
        // Console.WriteLine(myInt.Equals(mySecondInt));
        // Console.WriteLine(myInt.Equals(mySecondInt / 2));  

        // Console.WriteLine(myInt != mySecondInt);
        // Console.WriteLine(myInt == mySecondInt / 2 );  

        // Console.WriteLine(myInt >= mySecondInt);
        // Console.WriteLine(myInt > mySecondInt / 2 );
        // Console.WriteLine(myInt <= mySecondInt);
        // Console.WriteLine(myInt < mySecondInt / 2 );    

        // Console.WriteLine(5 < 10 && 5 > 10);    
        // Console.WriteLine(5 < 10 || 5 > 10);    



    // ########## CONDITIONAL STATEMENTS ##########

        // int myInt = 5;
        // int mySecondInt = 10;

        // // IF Statements work the same way as JS.
        // if (myInt < mySecondInt){
        //     myInt += 10;
        // }

        // Console.WriteLine(myInt);

        // string myCow = "cow";
        // string myCapitalizedCow = "Cow";

        // // This vertical spacing is normal c# practice
        // if(myCow == myCapitalizedCow) 
        // {
        //     Console.WriteLine("Equal");
        // }
        // else 
        // {
        //     Console.WriteLine("ELSE: Not equal");
        // }
        
        
        // if(myCow != myCapitalizedCow) 
        // {
        //     Console.WriteLine("Not equal");
        // }

        // if(myCow == myCapitalizedCow) 
        // {
        //     Console.WriteLine("Equal");
        // }
        // else if (myCow == myCapitalizedCow.ToLower())
        // {
        //     Console.WriteLine("ELSE IF: Equal");
        // }

        // // SWITCH STATEMENT - Same as JS
        // // Cases have to be a constant value, can't be a variable.

        // switch (myCow)
        // {
        //     case "cow":
        //         Console.WriteLine("Lower Case");
        //         break;
        //     case "Cow":
        //         Console.WriteLine("Capital Case");
        //         break;
        //     default:
        //         Console.WriteLine("Default Case");
        //         break;
        // }

        // ########## LOOPS ##########

        int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};

        DateTime startTime = DateTime.Now;

        // Manually add each index -- slow
        int totalValue = intsToCompress[0] + intsToCompress[1]
            + intsToCompress[2] + intsToCompress[3]
            + intsToCompress[4] + intsToCompress[5]
            + intsToCompress[6];

            Console.WriteLine($"Manual addition: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total: {totalValue}"); // 146

            
            // For loop - faster
            int totalValue2 = 0;         
            startTime = DateTime.Now;
            
            for (int i = 0; i < intsToCompress.Length; i++)
            {
                totalValue2 += intsToCompress[i];
            }

            Console.WriteLine($"For loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total: {totalValue2}");



            // Foreach loop - fastest
            int totalValue3 = 0;
            startTime = DateTime.Now;

            foreach(int intForCompression in intsToCompress)
            {
                totalValue3 += intForCompression;
            }

            Console.WriteLine($"Foreach loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total: {totalValue3}");


            // While loop
            // condition must be defined outside of the loop
            int index = 0;
            int totalValue4 = 0;
            while(index < intsToCompress.Length)
            {
                totalValue4 += intsToCompress[index];
                index++; // this increments the index after each addition, prevents infinite loop
            }

            Console.WriteLine($"While loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total: {totalValue4}");


            // Do While loop - Checks conditional after first iteration, will always run at least once.
            // condition must be defined outside of the loop
            index = 0;
            int totalValue5 = 0;
            
            do
            {
                totalValue5 += intsToCompress[index];
                index++; // this increments the index after each addition, prevents infinite loop
            } 
            while(index < intsToCompress.Length);

            Console.WriteLine($"Do While loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total: {totalValue5}");


            // built in method
            int totalValue6 = 0;
            totalValue6 = intsToCompress.Sum();
            Console.WriteLine($"Sum function: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");


            // Foreach loop - with conditional statement
            int totalValue7 = 0;
            startTime = DateTime.Now;

            foreach(int intForCompression in intsToCompress)
            {
                if (intForCompression > 20)
                {
                totalValue7 += intForCompression;
                }
            }

            Console.WriteLine($"Foreach loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
            Console.WriteLine($"total in conditional: {totalValue7}");
        }
    }
}