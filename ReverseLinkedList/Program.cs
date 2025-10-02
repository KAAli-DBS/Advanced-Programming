using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    public Node Head;

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Print()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void Reverse()
    {
        Node prev = null, current = Head, next = null;
        while (current != null)
        {
            next = current.Next;  // Store the next node
            current.Next = prev;  // Reverse the link
            prev = current;       // Move prev forward
            current = next;       // Move current forward
        }
        Head = prev;  // Update head to the new first node
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Add(23);
        list.Add(54);
        list.Add(78);
        list.Add(98);

        Console.WriteLine("Original List:");
        list.Print();

        list.Reverse();

        Console.WriteLine("Reversed List:");
        list.Print();
    }
}