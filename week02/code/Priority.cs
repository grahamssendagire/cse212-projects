public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Item 1", 2); // Medium priority
        priorityQueue.Enqueue("Item 2", 1); // Low priority
        priorityQueue.Enqueue("Item 3", 3); // High priority

        // Dequeue items and check the order
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 3 first
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 1 second
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 2 last

        Console.WriteLine("---------");

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Item 4", 1); // Low priority
        priorityQueue.Enqueue("Item 5", 1); // Low priority
        priorityQueue.Enqueue("Item 6", 1); // Low priority

        // Dequeue items and check the order
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 4 first
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 5 second
        Console.WriteLine(priorityQueue.Dequeue()); // Should dequeue Item 6 last

        Console.WriteLine("---------");

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}