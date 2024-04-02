using System;
using System.Collections;
using System.Text;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;   
    private Node? curr;  
      
    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        // TODO Problem 1
        Node newNode = new Node(value);
        if (_head == null) // List is empty.
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {   //_tail.Next = newNode;//set the "Next" of the current tail to the newNode.
             newNode.Prev= _tail;//set the "prev" of the newNode to the current tail.
            _tail = newNode;//set the tail equal to the newNode or update the tail to point the newNode.
        }
    }  
    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        
        // If the list has only one item  in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail) {
            _head = null;
            _tail = null;
           
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
        
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail(int value) {
    
        if (_head == null)
            return;
        if (_head == _tail)
        {
            _head = null; 
            _tail = null;
            return;
        }
        //this code snippet removes the last node from the linked list by iterating through the list until it finds the second-to-last node,
        // sets its Next pointer to null, and updates the _tail reference to point to this second-to-last node.
       // Node curr = _head;
        
         Node? curr = _head;
         while (curr.Next != _tail)
        
        //This line starts a while loop that iterates through the linked list until curr.Next (the next node after curr) is equal to _tail. 
        //This implies that _tail is the last node of the linked list.
        {
            //  Inside the loop, curr is updated to point to the next node in the linked list.
            curr = curr.Next;
        }
        //After the loop, the Next pointer of the node referenced by curr is set to null. 
        //This effectively breaks the link between the last node and the node after it, 
        //Effectively removing the last node from the linked list.
        curr.Next = null;
        //Finally, _tail is updated to point to the node referenced by curr,
         //effectively setting _tail to the new last node of the linked list.
        _tail = curr;
        // TODO Problem 2
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail) {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
          if (_head == null)
            return;
        if (_head.Data == value)
        {
            _head = _head.Next;
            if (_head == null)
                _tail = null;
            return;
        }
        Node curr = _head;
        while (curr.Next != null && curr.Next.Data != value)
        {
            curr = curr.Next;
        }
        if (curr.Next != null)
        {
            curr.Next = curr.Next.Next;
            if (curr.Next == null)
                _tail = curr;
        }
        // TODO Problem 3
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        // TODO Problem 4
         Node curr = _head;
        while (curr != null)
        {
            if (curr.Data == oldValue )
            {
                
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // TODO Problem 5
        yield return 0; // replace this line with the correct yield return statement(s)
    
     LinkedList reversedList = new LinkedList();
        Node curr = _head;
        while (curr != null)
        {
            reversedList.InsertHead(curr.Data);
            curr = curr.Next;
        }
        
    }

      public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<LinkedList>{");
        Node curr = _head;
        while (curr != null)
        {
            sb.Append(curr.Data);
            if (curr.Next != null)
                sb.Append(", ");
            curr = curr.Next;
        }
        sb.Append("}");
        return sb.ToString();
    }
          
        public string AsString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<IEnumerable>[");
        Node curr = _head;
        while (curr!= null)
        {
            sb.Append(curr.Data);
            if (curr.Next != null)
                sb.Append(", ");
            curr = curr.Next;
        }
        sb.Append("]");
        return sb.ToString();
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull() {
       
        {
         return _head is null && _tail is null;
        }
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }   
}
