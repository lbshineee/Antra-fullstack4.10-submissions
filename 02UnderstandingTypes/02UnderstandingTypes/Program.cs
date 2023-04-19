// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Karim! This is for UnderstandingTypes assignment\n\n");

//Assignment1: UnderstandingTypes.
// Outputs the number of bytes in memory that each of the following
//  number types uses, and the min and max values they can have
//  : sbyte, byte, short, ushort, int, unit, long, ulong, float, double, and decimal

Console.WriteLine("{0} {1,6} {2,10} {3,35}\n", "Data type", "Bytes", "Min Value", "Max Value");
Console.WriteLine($"sbyte      {sizeof(sbyte),-6}  {sbyte.MinValue,-35} {sbyte.MaxValue}");
Console.WriteLine($"byte       {sizeof(byte),-6}  {byte.MinValue,-35} {byte.MaxValue}");
Console.WriteLine($"short      {sizeof(short),-6}  {short.MinValue,-35} {short.MaxValue}");
Console.WriteLine($"ushort     {sizeof(ushort),-6}  {ushort.MinValue,-35} {ushort.MaxValue}");
Console.WriteLine($"int        {sizeof(int),-6}  {int.MinValue,-35} {int.MaxValue}");
Console.WriteLine($"uint       {sizeof(uint),-6}  {uint.MinValue,-35} {uint.MaxValue}");
Console.WriteLine($"long       {sizeof(long),-6}  {long.MinValue,-35} {long.MaxValue}");
Console.WriteLine($"ulong      {sizeof(ulong),-6}  {ulong.MinValue,-35} {ulong.MaxValue}");
Console.WriteLine($"float      {sizeof(float),-6}  {float.MinValue,-35} {float.MaxValue}");
Console.WriteLine($"double     {sizeof(double),-6}  {double.MinValue,-35} {double.MaxValue}");
Console.WriteLine($"decimal    {sizeof(decimal),-6}  {decimal.MinValue,-35} {decimal.MaxValue}");

// Write program to enter an integer number of centuries and convert it to years, days, hours,
//  minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
//  type for every data conversion. Beware of overflows

const long yearsPerCentury = 100;
const long daysPerCentury = 36524;
const long hoursPerDay = 24;
const long minsPerHour = 60;
const long secsPerMin = 60;
const long msPerSec = 1000;
const long usPerMs = 1000;
const long nsPerUs = 1000;

int centuries = 1;

centuries = int.Parse(Console.ReadLine());

long years = checked(yearsPerCentury * centuries);
long days = checked(daysPerCentury * centuries);
long hours = checked(hoursPerDay * days);
long mins = checked(minsPerHour * hours);
long secs = checked(secsPerMin * mins);
long ms = checked(msPerSec * secs);
long us = checked(usPerMs * ms);
long ns = unchecked(nsPerUs * us);


Console.WriteLine($"{centuries} centuries  = {years} years = {days} days = {hours} hours = " +
    $"{mins} minutes = {secs} seconds = {ms} milliseconds = {us} microseconds = {ns} nanoseconds");
