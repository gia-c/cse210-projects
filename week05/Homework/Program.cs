using System;

class Program 
{
    static void Main(string[] args) 
    {
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assigment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assigment2.GetSummary());
        Console.WriteLine(assigment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}