// See https://aka.ms/new-console-template for more information
using Internal;
using System.IO;

Console.WriteLine("Hello, hacker! This program will generate your hacker name by giving your favorite color, your astrology sign and your street number.");

try
{
    Console.WriteLine("Please enter your favorite color: ");
    string line;
    line = Console.ReadLine();

    Console.WriteLine("Please enter your astrology sign: ");
    line += Console.ReadLine();

    Console.WriteLine("Please enter your street address number: ");
    line += Console.ReadLine();

    Console.WriteLine("Your hacker name is: " + line);
}
catch (IOException e)
{
    TextWriter errorWrite = Console.Error;
    errorWrite.WriteLine(e.Message);
    errorWrite.WriteLine("Try again with inputing correct format");
    return;
}