using System;

namespace Structure
{
    public class Task
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList<int>();

            // Добавление элементов
            list.AddLast(1);
            list.AddLast(2);
            list.AddFirst(0);
            list.AddLast(3);
        
            Console.WriteLine("Список после добавления элементов:");
            list.PrintList();  // 0 1 2 3

            // Удаление элемента
            list.Remove(2);
            Console.WriteLine("Список после удаления элемента (2):");
            list.PrintList();  // 0 1 3

            // Удаление первого
            list.RemoveFirst();
            Console.WriteLine("Список после удаления первого элемента:");
            list.PrintList();  // 1 3

            // Удаление последнего
            list.RemoveLast();
            Console.WriteLine("Список после удаления последнего элемента:");
            list.PrintList();  // 1

            // Очистка списка
            list.Clear();
            Console.WriteLine("Список после очистки:");
            list.PrintList();  // (пустой список)
        }
    }
    
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        
    }

    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }

        }

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                newNode.Previous = null;
                Head.Previous = newNode;
                Head = newNode;
            }
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
                
            }
            else if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
                
            }
            else if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
        }

        public Node<T> Find(T value)
        {
            Node<T> node = Head;
            while (node != null)
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return node;
                }
                else
                {
                    node = node.Next;
                }
            }

            return null;
        }

        public void Remove(T value)
        {
            var node = Find(value);
            if (node == null)
            {
                return;
            }
            
            if (Head == node)
            {
                RemoveFirst();
                return;
            }

            if (Tail == node)
            {
                RemoveLast();
                return;
            }
            
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            
        }

        public void Clear()
        {
            Head = Tail = null;
        }
        public void PrintList()
        {
            var current = Head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
    
}