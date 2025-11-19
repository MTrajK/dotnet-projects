using DotNet.MeaningfulUnitTests.Date.Traditional.Date;

Console.WriteLine("Check if the year is a leap year.");
Console.WriteLine("Enter a year:");

var yearInput = Console.ReadLine();
var valid = int.TryParse(yearInput, out int yearInt);

if  (valid)
{
    var year = new Year(yearInt);
    var isLeapYear = year.IsLeapYear();

    if (isLeapYear)
    {
        Console.WriteLine($"{yearInt} is a leap year!");
    }
    else
    {
        Console.WriteLine($"{yearInt} is not a leap year!");
    }
    
}
else
{
    Console.WriteLine("Not a valid year!");
}