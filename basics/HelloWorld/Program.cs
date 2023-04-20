﻿// See https://aka.ms/new-console-template for more information

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


using System;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models; // import Models folder
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#region Basics
// namespace HelloWorld // namespace depends on the project name. This section is basics
// {

// ########## VARIABLES ##########

// internal class Program
// {
// a "Static" method can only access attributes from other "static" attributes
// a "non-static" method can access "static" or "non-static" attributes
// static int accessibleInt = 7;

// static void Main(string[] args)
// {
// int accessibleInt = 8; // this will over-ride the variable declartion from a different scope
// Console.WriteLine("Hello World!");
// Console.WriteLine(accessibleInt);


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

// mySecondGroceryArray.Select(grocery => Console.WriteLine(grocery));

// foreach (string product in mySecondGroceryArray)
// {
//     Console.WriteLine(product);

// } 

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

// int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};

// DateTime startTime = DateTime.Now;

// // Manually add each index -- slow
// int totalValue = intsToCompress[0] + intsToCompress[1]
//     + intsToCompress[2] + intsToCompress[3]
//     + intsToCompress[4] + intsToCompress[5]
//     + intsToCompress[6];

// Console.WriteLine($"Manual addition: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total: {totalValue}"); // 146


//     // For loop - faster
//     int totalValue2 = 0;         
//     startTime = DateTime.Now;

//     for (int i = 0; i < intsToCompress.Length; i++)
//     {
//         totalValue2 += intsToCompress[i];
//     }

//     Console.WriteLine($"For loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total: {totalValue2}");



//     // Foreach loop - fastest
//     int totalValue3 = 0;
//     startTime = DateTime.Now;

//     foreach(int intForCompression in intsToCompress)
//     {
//         totalValue3 += intForCompression;
//     }

//     Console.WriteLine($"Foreach loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total: {totalValue3}");


//     // While loop
//     // condition must be defined outside of the loop
//     int index = 0;
//     int totalValue4 = 0;
//     while(index < intsToCompress.Length)
//     {
//         totalValue4 += intsToCompress[index];
//         index++; // this increments the index after each addition, prevents infinite loop
//     }

//     Console.WriteLine($"While loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total: {totalValue4}");


//     // Do While loop - Checks conditional after first iteration, will always run at least once.
//     // condition must be defined outside of the loop
//     index = 0;
//     int totalValue5 = 0;

//     do
//     {
//         totalValue5 += intsToCompress[index];
//         index++; // this increments the index after each addition, prevents infinite loop
//     } 
//     while(index < intsToCompress.Length);

//     Console.WriteLine($"Do While loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total: {totalValue5}");


//     // built in method
//     int totalValue6 = 0;
//     totalValue6 = intsToCompress.Sum();
//     Console.WriteLine($"Sum function: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");


//     // Foreach loop - with conditional statement
//     int totalValue7 = 0;
//     startTime = DateTime.Now;

//     foreach(int intForCompression in intsToCompress)
//     {
//         if (intForCompression > 20)
//         {
//         totalValue7 += intForCompression;
//         }
//     }

//     Console.WriteLine($"Foreach loop: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
//     Console.WriteLine($"total in conditional: {totalValue7}");

// int totalValue8 = GetSum(intsToCompress);
// Console.WriteLine($"Custom Method: {((decimal)(DateTime.Now - startTime).TotalMilliseconds)} milliseconds");
// Console.WriteLine($"total in conditional: {totalValue8}");

// } // this ends the main method

// ########## METHODS ##########
// setting "void" on a method means it won't expect anything to be returned but it can still return a value. 
// setting "int" means it will always have to return an integer


//     static private int GetSum(int[] intsToCompress) //params go in ()
//     {
//         // int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};
//         int totalValue = 0;
//         // DateTime startTime = DateTime.Now;

//         foreach(int intForCompression in intsToCompress)
//         {
//             totalValue += intForCompression;
//         }
//         Console.WriteLine("From custom method");

//         return totalValue; // satisfies method requirement to return an integer

//     }
// }// this ends the class

// }
#endregion

#region Advanced
namespace HelloWorld
{       
        // Class names are PascalCase, typically nouns or noun phrases
        internal class Program 
        {
            // Method names are PascalCase, typically verbs or verb phrases
            // method arguments are camelCase
            static void Main(string[] args)
            {
                // local variable names are camelCase

                //access connection string from appsettings.json file
                // IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


                // DataContextDapper dapper = new DataContextDapper(config);
                // DataContextEntity entityFramework = new DataContextEntity(config);

                // string sqlCommand = "SELECT GETDATE()";
                // dbConnection.Query<DateTime>(sqlCommand); //.Query is a Dapper command, returns an array of results
                // DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand); //.Query is a Dapper command, returns a single row

                // Console.WriteLine(rightNow);

                


                Computer myComputer = new Computer()
                { 
                    Motherboard = "z570",
                    HasWifi = true,
                    HasLTE = false,
                    ReleaseDate = DateTime.Now,
                    Price = 229.99m,
                    VideoCard = "6800XT",
                };

                // entityFramework.Add(myComputer);
                // entityFramework.SaveChanges();

                // "@" signifies multiple lines
                // string sql = @"INSERT INTO TutorialAppSchema.Computer (
                //     Motherboard,
                //     HasWifi,
                //     HasLTE,
                //     ReleaseDate,
                //     Price,
                //     VideoCard
                // ) VALUES ('" + myComputer.Motherboard
                //             + "','" + myComputer.HasWifi
                //             + "','" + myComputer.HasLTE
                //             + "','" + myComputer.ReleaseDate
                //             + "','" + myComputer.Price
                //             + "','" + myComputer.VideoCard
                // + "')";

                // Console.WriteLine(sql);

                // int result = dapper.ExecuteSqlWithRowCount<int>(sql); // returns number of rows affected. --Dapper

                // Console.WriteLine("result " + result);

                // string sqlSelect = @"SELECT        
                //     Computer.ComputerId,             
                //     Computer.Motherboard,
                //     Computer.HasWifi,
                //     Computer.HasLTE,
                //     Computer.ReleaseDate,
                //     Computer.Price,
                //     Computer.VideoCard
                    
                // FROM TutorialAppSchema.Computer";
                // Console.WriteLine(myComputer.Motherboard);
                // Console.WriteLine(myComputer.HasLTE);
                // Console.WriteLine(myComputer.HasWifi);
                // Console.WriteLine(myComputer.Price);
                // Console.WriteLine(myComputer.Motherboard);
                // Console.WriteLine(myComputer.ReleaseDate);


                // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

                // foreach(Computer singleComputer in computers)
                // {
                //     Console.WriteLine("'" + singleComputer.ComputerId
                //             + "','" + singleComputer.Motherboard
                //             + "','" + singleComputer.HasWifi
                //             + "','" + singleComputer.HasLTE
                //             + "','" + singleComputer.ReleaseDate
                //             + "','" + singleComputer.Price
                //             + "','" + singleComputer.VideoCard
                // + "'");
                // }
                // myComputer.HasWifi = false;

                // Console.WriteLine(myComputer.HasWifi);



                // IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>(); // "?" are needed since it can be nullable.

                // if(computersEF != null)
                // {
                //     foreach(Computer singleComputer in computersEF)
                //     {
                //         Console.WriteLine("'" + singleComputer.ComputerId
                //                 + "','" + singleComputer.Motherboard
                //                 + "','" + singleComputer.HasWifi
                //                 + "','" + singleComputer.HasLTE
                //                 + "','" + singleComputer.ReleaseDate
                //                 + "','" + singleComputer.Price
                //                 + "','" + singleComputer.VideoCard
                //     + "'");
                //     }
                // }

                // Car myCar = new Car()
                // {
                //     Make = "Toyota",
                //     Model = "Tacoma"
                // };

                // Console.WriteLine(myCar.Make + " " + myCar.Model);


                //########## READ/WRITE TO FILE ##########

                // File.WriteAllText("log.txt", sql); //overwrites all content everytime it is run

                // using StreamWriter openFile = new("log.txt", append: true); //appends to file instead of overwriting

                // openFile.WriteLine("\n" + sql + "\n");// adds new line before and after "sql"

                // openFile.Close(); // closes the file after writing, can avoid errors

                // string fileText = File.ReadAllText("log.txt");
                // Console.WriteLine(File.ReadAllText("log.txt"));

                // Console.WriteLine("from file variable:" + "\n\n" + fileText);


                // string computersJson = File.ReadAllText("Computers.json");

                // Console.WriteLine(computersJson);

                // this allows for camelCase json format to work without adding the "Newtonsoft.Json" package
                // JsonSerializerOptions options = new JsonSerializerOptions()
                // {
                //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                // };

                // IEnumerable<Computer>? computerDataImport = JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
                
                // When using the "Newtonsoft.Json" package, we don't need to specify options
                // IEnumerable<Computer>? computerDataImport = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

                // if(computerDataImport != null){
                //     foreach( Computer computer in computerDataImport)
                //     {
                //         // Console.WriteLine(computer.Motherboard);
                // string sql = @"INSERT INTO TutorialAppSchema.Computer (
                //     Motherboard,
                //     HasWifi,
                //     HasLTE,
                //     ReleaseDate,
                //     Price,
                //     VideoCard
                // ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
                //             + "','" + computer.HasWifi
                //             + "','" + computer.HasLTE
                //             + "','" + computer.ReleaseDate
                //             + "','" + computer.Price
                //             + "','" + EscapeSingleQuote(computer.VideoCard)
                // + "')";

                //     dapper.ExecuteSql<string>(sql);

                //     static string EscapeSingleQuote(string input)
                //     {
                //         string output = input.Replace("'", "''");
                //         return output;
                //     }

                //     }
                // }
                

                // //Serializing in both methods will return PascalCase results by default, this can be changed:
                // JsonSerializerSettings settings = new JsonSerializerSettings()
                // {
                //     //"CamelCasePropertyNamesContractResolver" uses Newtonsoft
                //     ContractResolver = new CamelCasePropertyNamesContractResolver()
                // };

                // //Newtonsoft
                // string computersCopySystem = JsonConvert.SerializeObject(computerDataImport);
                // File.WriteAllText("System_Text_Json_computers.txt", computersCopySystem);
                
                // //  System
                // // "System.Text.Json.JsonSerialzer" specifies to use the "JsonSerializer" from System, not Newtonsoft, since they both have one.
                // string computersCopyNewton = System.Text.Json.JsonSerializer.Serialize(computerDataImport);
                // string computersCopyNewton2 = JsonConvert.SerializeObject(computerDataImport, settings);
                // File.WriteAllText("Newtonsoft_Json_computers.txt", computersCopyNewton);
                // File.WriteAllText("Newtonsoft_Json_computers2.txt", computersCopyNewton2);


                //######### AUTOMAPPER ##########

                // string computersJson = File.ReadAllText("ComputersSnake.json");

                // Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
                //     //cfg.CreateMap<SourceModel, TargetModel>
                //     // Looks for fields in SourceModel that match fields in TargetModel.
                //     // Fields are called "Members" in AutoMapper
                //     // can target keys or values, and can modify values, i.e: price * 0.8m
                //     cfg.CreateMap<ComputerSnake, Computer>()
                //         .ForMember(destination => destination.ComputerId, options => 
                //             options.MapFrom(source => source.computer_id))
                //         .ForMember(destination => destination.CPUCores, options => 
                //             options.MapFrom(source => source.cpu_cores))
                //         .ForMember(destination => destination.HasLTE, options => 
                //             options.MapFrom(source => source.has_lte))
                //         .ForMember(destination => destination.HasWifi, options => 
                //             options.MapFrom(source => source.has_wifi))
                //         .ForMember(destination => destination.VideoCard, options => 
                //             options.MapFrom(source => source.video_card))
                //         .ForMember(destination => destination.Motherboard, options => 
                //             options.MapFrom(source => source.motherboard))
                //         .ForMember(destination => destination.Price, options => 
                //             options.MapFrom(source => source.price))
                //         .ForMember(destination => destination.ReleaseDate, options => 
                //             options.MapFrom(source => source.release_date));
                // }));


            // If JSON property names are set in the model, AutoMapper & extra mapping isn't needed, i.e: IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerDataImportSnake); & the Mapper block above.
            // IEnumerable<Computer>? computerDataImportSnake = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
            // if (computerDataImportSnake != null)
            // {
            //     foreach (Computer computer in computerDataImportSnake)
            //     {
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }
            
            // IEnumerable<ComputerSnake>? computerDataImportSnake = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

            // if(computerDataImportSnake != null)
            // {
            //     IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerDataImportSnake);

            //     foreach (Computer computer in computerResult)
            //     {
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }
   
//             string stringForFloat = "0.85"; // datatype should be float
//             string stringForInt = "12345"; // datatype should be int

//             float parsedStringForFloat = float.Parse(stringForFloat);
//             int parsedStringForInt = Int32.Parse(stringForInt);
//             Console.WriteLine("Int = {0}, Float = {1}", parsedStringForInt, parsedStringForFloat);


//             int age = 31;
//             string name = "Kevin";
//             string job = "Developer";

//             Console.WriteLine("String Concatenation");
//             Console.WriteLine("Hello my name is " + name + ", I am " + age + " years old");

//             //String formatting uses the index of the variables passed in. In this case:
//             // 0 = name, 1 = age, 2 = job
//             Console.WriteLine("String Formatting");
//             Console.WriteLine("Hello my name is {0}, I am {1} years old. I am a {2}", name, age, job);

//             //String interpolation uses a $ at the start before the opening quotes
//             Console.WriteLine("String interpolation");
//             Console.WriteLine($"Hello my name is {name}, I am {age} years old");

//             //Verbatim strings
//             //verbatim strings start with @ before the opening quotes, tells the compiler to take 
//             //the string literally and ignore any spaces and escape characters like \n
//             //will display it EXACTLY as shown in the quotes with line breaks/spaces etc.
//             Console.WriteLine("Verbatim String");
//             Console.WriteLine(@"Lorem ipsum \n dolar sit amet, L
            
//             orem ipsum dolor sit amet, consectetur adipiscing elit. Cras elementum erat non purus aliquam, efficitur luctus dolor mattis. Etiam condimentum non sem ac fermentum. Integer in dolor non neque sollicitudin lacinia vel ut tellus. Phasellus vitae diam ultricies, laoreet sapien nec, aliquet ligula. Vestibulum egestas non neque a blandit. Suspendisse nec erat at quam tempus vulputate et id sem. Sed non vehicula lorem. Duis mauris massa, posuere at sapien vel, aliquet maximus tortor. Maecenas sit amet risus at dolor molestie maximus. Nulla fringilla sollicitudin odio ut dignissim. Pellentesque in augue a arcu convallis egestas. Duis in nulla vel orci feugiat blandit a aliquet tellus. Suspendisse potenti. Duis pulvinar consequat sapien quis vehicula. Etiam sit amet fermentum ex. Suspendisse euismod urna risus, non porta leo tempor vitae.





// Praesent ut volutpat nunc, vel faucibus risus. Maecenas sem eros, ullamcorper eu nunc vitae, ultrices sollicitudin velit. Nullam fermentum ut tellus eu porttitor. Aliquam dui est, sollicitudin sed massa vel, tempor faucibus erat. Aliquam erat volutpat. Mauris justo erat, facilisis et fermentum fringilla, venenatis at orci. Nam nisi leo, porta eget aliquet in, euismod nec tellus. Aliquam vel ex consequat, cursus lacus a, dapibus nulla. Aenean accumsan hendrerit dui vitae imperdiet. Aliquam commodo quis leo ut facilisis. Donec sed dictum erat, et accumsan mi. Quisque at orci ut dolor mollis suscipit et a eros. Aenean metus nunc, lacinia vel massa vel, sagittis faucibus metus. Integer at venenatis felis. Vestibulum vitae neque aliquet, facilisis ligula vitae, pretium arcu.

// Praesent malesuada ipsum sit amet sem dictum, sed laoreet ex vehicula. Praesent urna turpis, facilisis vel lorem eget, suscipit commodo mauris. Aenean varius luctus orci, non sagittis tortor dignissim sit amet. Duis ornare interdum enim non accumsan. Proin at varius elit. Vestibulum vehicula urna eget nulla egestas cursus. Etiam placerat diam nibh.

// Curabitur sapien quam, blandit eu mattis in, euismod sit amet nibh. Vestibulum iaculis neque purus, eu bibendum arcu eleifend eu. Nam rhoncus, turpis vel dignissim tempus, ante erat faucibus enim, eu laoreet nulla elit nec nulla. Mauris sed faucibus sem, et vehicula ipsum. Proin auctor commodo tortor et porttitor. Sed at eros ac nibh porttitor eleifend. Praesent eu arcu diam. ");



            /*
                Challenge 1
                    Declare a string variable and don’t assign any value to it.

                    Print on the console “Please enter your name and press enter”. 
                    You can then enter your name or any other valid string like “tutorials.eu”.

                    Assign that entered string to the string variable which you have declared initially.

                    The program should write on the console that string in Uppercase in the first line, 
                    then the same string in Lowercase in the second line. In the third line, it writes on the console the 
                    string with no trailing or preceding white space like if string entered as “ tutorials.eu ” 
                    it should be written on the console as “tutorials.eu”. And in the last line, 
                    it should write the Substring of the entered string on the console.
            */

            // string myName;
            // Console.WriteLine("Please enter your name and press enter : ");
            // //Console.Readline() waits for input from the user and uses the input data
            // myName = Console.ReadLine();
            // string myNameUpperCase = String.Format("Upper Case : {0}", myName.ToUpper());
            // string myNameLowerCase = String.Format("Lower Case : {0}", myName.ToLower());
            // // Trim removes empty space before and after
            // string myNameTrim = String.Format("Trim : {0}", myName.Trim());
            // //creates a substring of the main string from the provided index. string.Substring(index, length)
            // string myNameSubstring = String.Format("Substring : {0}", myName.Substring(0,4));

            // Console.WriteLine(myNameUpperCase);
            // Console.WriteLine(myNameLowerCase);
            // Console.WriteLine(myNameTrim);
            // Console.WriteLine(myNameSubstring);


            /* 
                Challenge 2
                    This application asks the user to input a string in the first line like “Enter a string here: ”.

                    In the Second Line, it should ask for the character to search in the string which you have entered 
                    in the first line like “Enter the character to search: ”

                    On the third line, it should write the index of the first occurrence of the searched character from the string.

                    It should then ask to enter the first name and once the name is written and the enter button is pressed, 
                    it should ask to enter the last name.

                    It should then show your full name printed in a single line like in my case the output 
                    will be "Denis Panjuta". Output can be different in your case. Try to store the full name in a variable, 
                    before displaying it.
            */

            Console.WriteLine("Enter a string here: ");
            string newString = Console.ReadLine();

            Console.WriteLine("Enter a character to search for: ");
            char character = Console.ReadLine()[0]; //get first appearnce of that character
            Console.WriteLine($"The character {character} appears at index {newString.IndexOf(character)} of '{newString}'");

            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            string fullName = firstName + " " + lastName;
            Console.WriteLine("String formatting: {0} {1}",firstName, lastName);
            Console.WriteLine($"String Interpolation: {fullName}");

            }
        }
}
#endregion