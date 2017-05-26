using System;

namespace AITDNSeven
{
    /// <summary>
    /// This project deals with delegates, what they are and their uses
    /// </summary>
    /// <author>
    /// Samuel Bancroft (c) 2017
    /// </author>
    /// <code>
    /// Made up of three main files
    /// ArbitraryClass.cs => A class declaration
    /// NameChangeHandlerDelegate.cs => A delegate declaration
    /// Program.cs => the main file
    /// </code>

    internal class Program
    {
        public static void Main(string[] args)
        {
            // A delegate is a type which hold a reference to a method
            var writer = new Writer(WriteMessage); // creates a new instance of delegate "Writer" and passes an instance of "WriteMessage()" funtion to it
            writer("This works!"); // Now a variable called "writer" uses the "WriteMessage" function to output text

            /* 
             * The code below does a number of things which may be hard to follow at first
             * Initially it instantiates a new instance of the "ArbitraryClass()" class called TestClass
             * Next it defines the TestClass member "NameChanges" (which is defined in its own file "NameChangeHandlerDelegate.cs") by setting it to an instance of the "NameChangeHandlerDelegate" which uses the "AtNameChange" method below
             * This means that the TestClass object now has access to a delegate which will take the old Name value and the new Name value (Name being a property of the "ArbitraryClass" Class)
             * The TestClass was instantiated with the Name property set as "Unset" (this happened in the classes constructor)
             * Next the code changes the TestClass Name property to "NewName", this triggers the "NameChanges" delegate in the setter which in turn runs the method defined when this delegate was instantiated (TestClass.NameChanges = new NameChangeHandlerDelegate(AtNameChange);
             * In the real world the AtNameChange() method the delegate uses would store this information in a log file
             */

            var testClass = new ArbitraryClass();
            testClass.NameChanges = new NameChangeHandlerDelegate(AtNameChange);  // Set the NameChanges delegate in the TestClass to use the AtNameChanges function declared below.

            testClass.Name = "NewName"; // Change the class name to invoke the delegate call from within the class.

            // This class could have been declared using another approach;
            // var testClass = new ArbitraryClass
            // {
            //     NameChanges = new NameChangeHandlerDelegate(AtNameChange),
            //     Name = "NewName"
            // };
            // Because the properties are in curly braces after the class instantiation, the code knows everything between the braces belongs to that new class, saving the qualifier "testClass." before each statement. 

            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }

        public delegate void Writer(string message);    // delegate type definition, note a delegate does not contain and code definition at all.

        public static void WriteMessage(string message)  // The decalaration of the delegate determines the type of methods it can be passed. This delegate is void and takes a string, so any method it uses must also be void and take a single string.
        {
            Console.WriteLine(message);
        }

        private static void AtNameChange(string oldName, string newName) // A simple method to be used with the "NameChangeHandlerDelegate" delegate above.
        {
            Console.WriteLine($"The class has changed name from {oldName} to {newName}, this change will be logged.");  // This type of string output uses string interpolation (note the $ before the first " and the values in {} curly braces mixed with the text)
        }
    }
}
