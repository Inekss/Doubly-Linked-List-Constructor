//Doubly linked list constructor that involve basic features for string, int and bool types.
//Program has console menu to interact with list.
//Program has error checking for invalid input of types.
//Involved function of bubble sorting with flag

using System;

class Program
{
    private static int error = 0;
    private static int numberOfElementsInList = 0;
    private static string userCommand;
    private static DoublyLinkedList list = new DoublyLinkedList();

    private static string inputStr;
    private static int inputInt;
    private static bool inputBool;

    public static void Main(string[] args)
    {
        while (true)
        {
            ShowList(list);
            Console.WriteLine("Available commands:\n1. Add\n2. Remove\n3. Change\n4. Move\n5. Sorting\n");
            Console.Write("Enter a command: ");
            userCommand = Console.ReadLine();

            switch (userCommand)
            {
                case "Add":
                    AddCommand();
                    break;
                case "Remove":
                    RemoveCommand();
                    break;
                case "Change":
                    ChangeCommand();
                    break;
                case "Move":
                    MoveCommand();
                    break;
                case "Sorting":
                    SortCommand();
                    break;
                default:
                    ShowErrorInput();
                    break;
            }
        }
    }

    private static void AddCommand()
    {
        while (true)
        {
            ShowList(list);
            Console.Write("Enter the type of element to add (String/Int/Bool): ");
            userCommand = Console.ReadLine();
            if (userCommand == "String")
            {
                AddStringElement();
                break;
            }
            else if (userCommand == "Int")
            {
                AddIntElement();
                break;
            }
            else if (userCommand == "Bool")
            {
                AddBoolElement();
                break;
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void AddStringElement()
    {
        Console.Write("To add at a specific position, type 'position', otherwise enter the string value: ");
        inputStr = Console.ReadLine();
        if (inputStr == "position")
        {
            int position = GetPositionForNewElement();
            Console.Write("Enter the string value: ");
            inputStr = Console.ReadLine();
            list.AddElement(inputStr, position);
        }
        else
        {
            int position = list.ElementCounterInList(0) + 1;
            list.AddElement(inputStr, position);
        }
    }

    private static void AddIntElement()
    {
        Console.Write("To add at a specific position, type 'position', otherwise enter the integer value: ");
        inputStr = Console.ReadLine();
        if (inputStr == "position")
        {
            int position = GetPositionForNewElement();
            Console.Write("Enter the integer value: ");
            inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out inputInt))
            {
                list.AddElement(inputInt, position);
            }
            else
            {
                ShowErrorInput();
            }
        }
        else
        {
            if (int.TryParse(inputStr, out inputInt))
            {
                int position = list.ElementCounterInList(0) + 1;
                list.AddElement(inputInt, position);
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void AddBoolElement()
    {
        Console.Write("To add at a specific position, type 'position', otherwise enter the boolean value: ");
        inputStr = Console.ReadLine();
        if (inputStr == "position")
        {
            int position = GetPositionForNewElement();
            Console.Write("Enter the boolean value: ");
            inputStr = Console.ReadLine();
            if (bool.TryParse(inputStr, out inputBool))
            {
                list.AddElement(inputBool, position);
            }
            else
            {
                ShowErrorInput();
            }
        }
        else
        {
            if (bool.TryParse(inputStr, out inputBool))
            {
                int position = list.ElementCounterInList(0) + 1;
                list.AddElement(inputBool, position);
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void RemoveCommand()
    {
        while (true)
        {
            ShowList(list);
            numberOfElementsInList = list.ElementCounterInList(0);
            if (numberOfElementsInList == 0)
            {
                ShowErrorEmptylist();
                break;
            }

            Console.Write("Enter the position to remove (or 'clear' to remove all, 'exit' to cancel): ");
            inputStr = Console.ReadLine();

            if (inputStr == "clear")
            {
                list.RemoveAllElements();
                break;
            }
            else if (inputStr == "exit")
            {
                break;
            }
            else if (int.TryParse(inputStr, out int position))
            {
                if (position < 1 || position > numberOfElementsInList)
                {
                    ShowErrorInput();
                }
                else
                {
                    list.RemoveElement(position);
                    break;
                }
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void ChangeCommand()
    {
        while (true)
        {
            ShowList(list);
            numberOfElementsInList = list.ElementCounterInList(0);
            if (numberOfElementsInList == 0)
            {
                ShowErrorEmptylist();
                break;
            }

            Console.Write("Enter the position to change (or 'exit' to cancel): ");
            inputStr = Console.ReadLine();

            if (inputStr == "exit")
            {
                break;
            }
            else if (int.TryParse(inputStr, out int position))
            {
                if (position < 1 || position > numberOfElementsInList)
                {
                    ShowErrorInput();
                }
                else
                {
                    list.ChangeElement(position);
                    break;
                }
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void MoveCommand()
    {
        while (true)
        {
            ShowList(list);
            numberOfElementsInList = list.ElementCounterInList(0);
            if (numberOfElementsInList < 2)
            {
                ShowErrorEmptylist();
                break;
            }

            Console.Write("Enter the position of the element to move (or 'exit' to cancel): ");
            inputStr = Console.ReadLine();

            if (inputStr == "exit")
            {
                break;
            }
            else if (int.TryParse(inputStr, out int fromPosition))
            {
                Console.Write("Enter the new position: ");
                inputStr = Console.ReadLine();
                if (int.TryParse(inputStr, out int toPosition))
                {
                    if (fromPosition == toPosition || fromPosition < 1 || toPosition < 1 || fromPosition > numberOfElementsInList || toPosition > numberOfElementsInList)
                    {
                        ShowErrorInput();
                    }
                    else
                    {
                        list.MoveElement(fromPosition, toPosition);
                        break;
                    }
                }
                else
                {
                    ShowErrorInput();
                }
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void SortCommand()
    {
        while (true)
        {
            ShowList(list);
            numberOfElementsInList = list.ElementCounterInList(0);
            if (numberOfElementsInList == 0)
            {
                ShowErrorEmptylist();
                break;
            }

            Console.Write("Enter the type to sort by (int/string/bool): ");
            string sortType = Console.ReadLine();
            if (sortType == "int" || sortType == "string" || sortType == "bool")
            {
                list.SortElementsInList(sortType);
                break;
            }
            else
            {
                ShowErrorInput();
            }
        }
    }

    private static void ShowList(DoublyLinkedList list)
    {
        Console.Clear();
        list.PrintList();
        Console.WriteLine();
        list.VerifyLinks();
        if (error == 1)
        {
            ShowErrorInput();
        }
        else if (error == 2)
        {
            ShowUnexpectableError();
        }
        else if (error == 3)
        {
            ShowErrorEmptylist();
        }
        error = 0;
    }

    public static void ShowErrorInput()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please try again.");
        Console.ForegroundColor = ConsoleColor.White;
        error = 1;
    }

    public static void ShowUnexpectableError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unexpected Error");
        Console.ForegroundColor = ConsoleColor.White;
        error = 2;
    }
    public static void ShowErrorEmptylist()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The list is empty");
        Console.ForegroundColor = ConsoleColor.White;
        error = 3;
    }

    public static int GetPositionForNewElement()
    {
        while (true)
        {
            Console.Write("Enter the position to add the element: ");
            numberOfElementsInList = list.ElementCounterInList(0);
            Console.WriteLine($"The list has {numberOfElementsInList} elements.");
            string positionStr = Console.ReadLine();
            if (int.TryParse(positionStr, out int position))
            {
                if (position < 1 || position > (numberOfElementsInList + 1))
                {
                    ShowErrorInput();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{position} is out of range.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    return position;
                }
            }
            else
            {
                ShowErrorInput();
            }
        }
    }
}

public class DoublyLinkedList
{
    public object Data;
    public DoublyLinkedList Next;
    public DoublyLinkedList Prev;
    private DoublyLinkedList firstElement;
    private DoublyLinkedList lastElement;

    public DoublyLinkedList(object data)
    {
        Data = data;
    }

    public DoublyLinkedList()
    {
        firstElement = new DoublyLinkedList(0);
        firstElement.Next = this;
        this.Prev = firstElement;

        lastElement = new DoublyLinkedList(0);
        this.Next = lastElement;
        lastElement.Prev = this;
    }

    public void AddElement(object data, int position)
    {
        if (position == 0)
        {
            DoublyLinkedList newNode = new DoublyLinkedList(data);
            DoublyLinkedList temp = lastElement.Prev;
            temp.Next = newNode;
            newNode.Prev = temp;

            newNode.Next = lastElement;
            lastElement.Prev = newNode;
        }
        else if (position != 0)
        {
            DoublyLinkedList current = firstElement.Next.Next;
            int currentPosition = 1;
            while (currentPosition < position && current != lastElement)
            {
                current = current.Next;
                currentPosition++;
            }

            if (currentPosition == position)
            {
                DoublyLinkedList newNode = new DoublyLinkedList(data);
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
            else
            {
                Console.WriteLine("Position exceeds the length of the list.");
            }
        }
    }

    public void RemoveElement(int position)
    {
        DoublyLinkedList current = firstElement.Next.Next;
        int currentPosition = 1;

        while (currentPosition < position && current != lastElement)
        {
            current = current.Next;
            currentPosition++;
        }

        if (currentPosition == position && current != lastElement)
        {
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
        }
    }

    public void RemoveAllElements()
    {
        int numberOfElementsInList = ElementCounterInList(0);
        while (numberOfElementsInList != 0)
        {
            numberOfElementsInList = ElementCounterInList(0);
            RemoveElement(1);
        }
    }

    public void ChangeElement(int position)
    {
        DoublyLinkedList current = firstElement.Next.Next;
        int currentPosition = 1;

        while (currentPosition < position && current != lastElement)
        {
            current = current.Next;
            currentPosition++;
        }

        if (currentPosition == position && current != lastElement)
        {
            var data = current.Data;
            string inputStr;
            int inputInt;
            bool inputBool;
            if (data is int)
            {
                while (true)
                {
                    Console.WriteLine("\nThis variable is type int. Print the changing data using type int: ");
                    inputStr = Console.ReadLine();
                    if (int.TryParse(inputStr, out inputInt))
                    {
                        current.Data = inputInt;
                        break;
                    }
                    else
                    {
                        Program.ShowErrorInput();
                        continue;
                    }
                }
            }
            else if (data is bool)
            {
                while (true)
                {
                    Console.WriteLine("\nThis variable is type Bool. Print the changing data using type Bool:  true/false");
                    inputStr = Console.ReadLine();
                    if (bool.TryParse(inputStr, out inputBool))
                    {
                        current.Data = inputBool;
                        break;
                    }
                    else
                    {
                        Program.ShowErrorInput();
                        continue;
                    }
                }
            }
            else if (data is string)
            {
                while (true)
                {
                    Console.WriteLine("\nThis variable is type string. Print the changing data using type string: ");
                    inputStr = Console.ReadLine();
                    if (inputStr == null)
                    {
                        Program.ShowErrorInput();
                        continue;
                    }
                    current.Data = inputStr;
                    break;
                }
            }
            else
            {
                Program.ShowUnexpectableError();
            }
        }
    }

    public void MoveElement(int fromPosition, int toPosition)
    {
        DoublyLinkedList current = firstElement.Next.Next;
        int currentPosition = 1;

        while (currentPosition < fromPosition && current != lastElement)
        {
            current = current.Next;
            currentPosition++;
        }

        if (currentPosition == fromPosition && current != lastElement)
        {
            object data = current.Data;
            RemoveElement(fromPosition);
            AddElement(data, toPosition);
        }
    }

    public void SortElementsInList(string sortType)
    {
        bool swapped;
        do
        {
            swapped = false;
            DoublyLinkedList current = firstElement.Next.Next;
            while (current != null && current.Next != lastElement)
            {
                bool shouldSwap = false;

                if (sortType == "string")
                {
                    if (current.Data is not string && current.Next.Data is string)
                    {
                        shouldSwap = true;
                    }
                    else if (current.Data is bool && current.Next.Data is int)
                    {
                        shouldSwap = true;
                    }
                }
                else if (sortType == "int")
                {
                    if (current.Data is not int && current.Next.Data is int)
                    {
                        shouldSwap = true;
                    }
                    else if (current.Data is bool && current.Next.Data is string)
                    {
                        shouldSwap = true;
                    }
                }
                else if (sortType == "bool")
                {
                    if (current.Data is not bool && current.Next.Data is bool)
                    {
                        shouldSwap = true;
                    }
                    else if (current.Data is int && current.Next.Data is string)
                    {
                        shouldSwap = true;
                    }
                }

                if (shouldSwap)
                {
                    object temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }

                current = current.Next;
            }
        } while (swapped);
    }

    public void PrintList()
    {
        DoublyLinkedList current = firstElement.Next.Next;
        int i = 1;
        Console.WriteLine("Doubly Linked List elements:");
        while (current != lastElement)
        {
            Console.Write(i + ")");
            Console.WriteLine(current.Data);
            current = current.Next;
            i++;
        }
        if (i == 1)
        {
            Console.WriteLine("List has not any elements.");
        }
    }

    public int ElementCounterInList(int numberOfElementsInList)
    {
        DoublyLinkedList current = firstElement.Next.Next;
        while (current != lastElement)
        {
            current = current.Next;
            numberOfElementsInList++;
        }
        return numberOfElementsInList;
    }

    public void VerifyLinks()
    {
        DoublyLinkedList current = firstElement.Next;

        Console.WriteLine("Verifying links between elements:");
        while (current != lastElement)
        {
            if (current.Next != null && current.Next.Prev != current)
            {
                Console.WriteLine("Next link error at element with data {0}.", current.Data);
                Program.ShowUnexpectableError();
                return;
            }

            if (current.Prev != null && current.Prev.Next != current)
            {
                Console.WriteLine("Prev link error at element with data {0}.", current.Data);
                Program.ShowUnexpectableError();
                return;
            }

            current = current.Next;
        }
        Console.WriteLine("All links are correct.\n");
    }
}