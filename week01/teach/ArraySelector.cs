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
using System.Linq;

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
//step by step plan for implementing the " RotateListRight" function
//1.DEFINE THE FUNCTION SIGNATURE:
//Name: RotateListRight
//PARAMETERS:
//.data: The list of data to rotate.
//.amount: The amount to rotate to the right.
//.Return type: List of the same type as data.
//2.DETERMINE THE EFFECTIVE AMOUNT OF ROTATION :

//.Since rotating to the right by an amount greater than the size of the list is equivalent to rotating by the remainder of dividing the amount by the size of the list, calculate the effective amount of rotation using the modulus operator.
// 3. CREATE A NEW LIST TO STORE THE ROTATED DATA

//4.ITERATE THROUGH THE ORIGINAL LIST STARTING FROM THE END

//.Copy each element to the new list, starting from the index that is effectiveAmount positions from the end of the original list.
//.Wrap around to the beginning of the original list if necessary.
//5.RETURN THE NEW ROTATED LIST
public static class ArraysTester 
{
    public static void Run() 
    {
        // Example usage of RotateListRight function
        List<int> data = Enumerable.Range(1, 9).ToList();
        int amount = 5;
        List<int> rotatedData = RotateListRight(data, amount);
        Console.WriteLine($"Rotated data (amount: {amount}):");
        foreach (var item in rotatedData) 
        {
            Console.WriteLine(item);
        }
    }

    // Function to rotate a list to the right by a given amount
    // Parameters:
    //   data: The list of data to rotate.
    //   amount: The amount to rotate to the right.
    // Returns:
    //   List of the same type as 'data' containing the rotated elements.
    private static List<T> RotateListRight<T>(List<T> data, int amount) 
    {
        // Calculate the effective amount of rotation using modulus operator
        int effectiveAmount = amount % data.Count;

        // Create a new list to store the rotated data
        List<T> rotatedData = new List<T>();

        // Iterate through the original list starting from the end
        for (int i = data.Count - effectiveAmount; i < data.Count; i++) 
        {
            // Copy each element to the new list, wrapping around to the beginning if necessary
            rotatedData.Add(data[i]);
        }
        for (int i = 0; i < data.Count - effectiveAmount; i++) 
        {
            // Copy the remaining elements to the new list
            rotatedData.Add(data[i]);
        }

        // Return the rotated list
        return rotatedData;
    }
}