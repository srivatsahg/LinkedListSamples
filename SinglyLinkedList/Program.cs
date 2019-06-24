using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello SLL!");

            LinkedList sampleSLL = new LinkedList();

            sampleSLL.appendNode(10);
            sampleSLL.appendNode(20);
            sampleSLL.appendNode(30);
            sampleSLL.appendNode(40);

            Console.WriteLine("Printing all nodes !");
            sampleSLL.printNodes();

            Console.WriteLine("Press any key to delete last but one entry!");
            Console.ReadKey();
            sampleSLL.deleteNode(30);

            Console.WriteLine("Printing all nodes !");
            sampleSLL.printNodes();

            Console.WriteLine("Printing all reverse !");
            sampleSLL.reverseList();

            Console.WriteLine("Merge LL sample !");

            SingleLinkedListSample listOne = new SingleLinkedListSample();
            listOne.appendNode(10);
            listOne.appendNode(40);
            listOne.appendNode(50);

            SingleLinkedListSample listTwo = new SingleLinkedListSample();
            listTwo.appendNode(20);
            listTwo.appendNode(30);
            listTwo.appendNode(60);

            SinglyLinkedListNode<int> listMerged = SingleLinkedListSample.mergeLinkedList(listOne.head, listTwo.head);
            SingleLinkedListSample.printNodesMerged(listMerged);

            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
            
        }
    }


    public class SingleLinkedListSample
    {
        public SinglyLinkedListNode<int> head;

        public void appendNode(int data)
        {
            
            if (head == null)
            {
                head = new SinglyLinkedListNode<int>(data);
                return;
            }
            else
            {
                SinglyLinkedListNode<int> currentNode = head;

                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = new SinglyLinkedListNode<int>(data);
            }
        }

        public static void printNodesMerged(SinglyLinkedListNode<int> head) 
        {
            if (head == null) return;

            SinglyLinkedListNode<int> currentNode = head;

            while (currentNode != null)
            {
                Console.WriteLine($"The node value is : {currentNode.data}");
                currentNode = currentNode.next;
            }
        }


        /// <summary>
        /// Iterative method
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static SinglyLinkedListNode<int> mergeLinkedList(SinglyLinkedListNode<int> node1, SinglyLinkedListNode<int> node2)
        {
            SinglyLinkedListNode<int> head;

            if (node1 == null)
            {
                return node2;
            }
            if (node2 == null)
            {
                return node1;
            }

            //Determine the first node which has the smallest value amongst two lists, whichever lesser set it as the fixed list and treat
            // the other list as bag of nodes

            if (node1.data.CompareTo(node2.data) <= 0)
            {
                head = node1;
            }
            else
            {
                //Swapping logic to reorder the list
                head = node2;
                node2 = node1;
                node1 = head;
            }


            while (node1.next != null && node2 != null)
            {
                //Main logic
                if (node1.next.data.CompareTo(node2.data) > 0)
                {
                    SinglyLinkedListNode<int> tempNode = node2.next; //backup
                    //swap
                    node2.next = node1.next;
                    node1.next = node2;
                    //restore
                    node2 = tempNode;
                }

                node1 = node1.next; //increment
            }

            if (node1.next == null)
            {
                node1.next = node2;
            }

            return head;
        }
    }

    public class LinkedList
    {
        Node head;

        /// <summary>
        /// o---->o
        /// </summary>
        /// <param name="data"></param>
        public void appendNode(int data)
        {
            if(head == null)
            {
                head = new Node(data);
                return;
            }
            else
            {
                Node currentNode = head;

                while(currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = new Node(data);
            }
        }

        public void prependNode(int data)
        {
            if(head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node newNode = new Node(data);
                newNode.next = head;
                head = newNode;
            }
        }

        public void deleteNode(int data)
        {
            if (head == null) return;

            if(head.data == data)
            {
                head = head.next; //this node is not explicitly destroyed but eventually gc'ed
                return;
            }

            Node currentNode = head;

            while(currentNode.next != null)
            {
                if(currentNode.next.data == data)
                {
                    currentNode.next = currentNode.next.next;
                    return;
                }
                currentNode = currentNode.next;
            }
        }


        public void printNodes()
        {
            if (head == null) return;

            Node currentNode = head;

            while (currentNode != null)
            {
                Console.WriteLine($"The node value is : {currentNode.data}");
                currentNode = currentNode.next;
            }
        }

        public Node reverseList()
        {
            if (head == null) return null;
            
            else
            {
                Node currentNode = head;
                Node previous = null;
                Node next;

                while(currentNode != null)
                {
                    next = currentNode.next;
                    //current next should point to previous
                    currentNode.next = previous;
                    //previous should be now current
                    previous = currentNode;
                    //current should move to next
                    currentNode = next;
                }

                head = previous;

            }

            return head;
        }


        

    }

    /// <summary>
    /// Singly Linked List Node
    /// </summary>
    public class Node
    {
        public readonly int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
        }
    }

    public class SinglyLinkedListNode<T>
    {
        public readonly int data;
        public SinglyLinkedListNode<T> next;

        public SinglyLinkedListNode(int data)
        {
            this.data = data;
        }
    }
}
