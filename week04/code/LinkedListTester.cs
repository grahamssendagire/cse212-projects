using System.Text;

public static class LinkedListTester {
    public static void Run() {
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        var ll = new LinkedList();
        ll.InsertTail(1);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1};
        ll.InsertTail(0);
        ll.InsertTail(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0, -1};

        var ll2 = new LinkedList();
        ll2.InsertTail(1);
       

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0}
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1}

        var ll3 = new LinkedList();
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        ll3.InsertHead(2);
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        Console.WriteLine(ll3.HeadAndTailAreNull()); // True

        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        ll.InsertAfter(3, 35);
        ll.InsertAfter(5, 6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(3);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 35, 2, 2, 2, 1}
        ll.Remove(6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2, 1}
        ll.Remove(1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(7);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(5);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2, 2}
        ll.Remove(2);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2}

        var ll4 = new LinkedList();
        ll4.Remove(0);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        ll4.InsertHead(2);
        ll4.Remove(2);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        Console.WriteLine(ll4.HeadAndTailAreNull()); // True

        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        ll.Replace(2, 10);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 10, 10}
        ll.Replace(7, 5);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 10, 10}
        ll.Replace(4, 100);
        Console.WriteLine(ll.ToString()); // <LinkedList>{100, 35, 10, 10}


        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        Console.WriteLine(ll.Reverse().AsString()); // <IEnumerable>[10, 10, 35, 100}
  
  
    }

public class Node
{
    public int Data;
    public Node Next;
    public Node prev;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;
    private Node tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public void InsertTail(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.prev = tail;
            tail.Next = newNode;
            tail = newNode;   
        }
    }

    public void InsertHead(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode; 
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    public void RemoveTail()
    {
        if (head == null)
            return;
        if (head == tail)
        {
            head = null;
            tail = null;
            return;
        }
        Node current = head;
        while (current.Next != tail)
        {
            current = current.Next;
        }
        current.Next = null;
        tail = current;
    }

    public void InsertAfter(int key, int data)
    {
        Node newNode = new Node(data);
        Node current = head;
        while (current != null && current.Data != key)
        {
            current = current.Next;
        }
        if (current != null)
        {
            newNode.Next = current.Next;
            current.Next = newNode;
            if (current == tail)
                tail = newNode;
        }
    }

    public void Remove(int key)
    {
        if (head == null)
            return;
        if (head.Data == key)
        {
            head = head.Next;
            if (head == null)
                tail = null;
            return;
        }
        Node current = head;
        while (current.Next != null && current.Next.Data != key)
        {
            current = current.Next;
        }
        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            if (current.Next == null)
                tail = current;
        }
    }

    public void Replace(int key, int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == key)
            {
                current.Data = data;
            }
            current = current.Next;
        }
    }

    public LinkedList Reverse()
    {
        LinkedList reversedList = new LinkedList();
        Node current = head;
        while (current != null)
        {
            reversedList.InsertHead(current.Data);
            current = current.Next;
        }
        return reversedList;
    }

    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    public string AsString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<IEnumerable>[");
        Node current = head;
        while (current != null)
        {
            sb.Append(current.Data);
            if (current.Next != null)
                sb.Append(", ");
            current = current.Next;
        }
        sb.Append("]");
        return sb.ToString();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<LinkedList>{");
        Node current = head;
        while (current != null)
        {
            sb.Append(current.Data);
            if (current.Next != null)
                sb.Append(", ");
            current = current.Next;
        }
        sb.Append("}");
        return sb.ToString();
    }
}
}


