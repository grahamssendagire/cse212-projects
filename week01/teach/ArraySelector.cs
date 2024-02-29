//step by step plan for implementing the "multipleof" function
//1.DEFINE THE FUNCTION SIGNATURE.
//.Name:MultiplesOf.
//.PARAMETERS: 
//Start:The starting number for generating multiples.
//Count:The number of multiples to generate.
//Return type:List of doubles(representing the multiples)
//2.INITIALIZE AN EMPTY LIST TO STORE THE MULTIPLES
//3.ITERATE'Count'times to generate the specified number of multiples.
//.inside the loop,calculate each multiple by multiplying the starting number('start') with the current iteration index(starting from1 )
//.Add the calculated multiple to the list.
//4. RETURN THE LIST OF MULTIPLES.
using System;
using System.Collections.Generic;
public static class ArraySelector
{
    public static void Run()
    
    {
    // Example usage of MultiplesOf function
    int start = 3;
    int count = 5;
    List<double> multiples = MultiplesOf(start,count);
    Console.WriteLine($"Multiples of {start}(count:{count}):");
    foreach(var multiple in multiples)
    Console.WriteLine(multiple);
    }

   private static List<double> MultiplesOf(int start, int count) {
        // Initialize an empty list to store the multiples
        List<double> result = new List<double>();

        // Iterate 'count' times to generate the specified number of multiples
        for (int i = 1; i <= count; i++) {
            // Calculate each multiple by multiplying the starting number with the current iteration index
            double multiple = start * i;
            // Add the calculated multiple to the list
            result.Add(multiple);
        }

        // Return the list of multiples
        return result;
    }
}