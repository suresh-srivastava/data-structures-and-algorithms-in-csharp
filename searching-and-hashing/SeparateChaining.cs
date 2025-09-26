//SeparateChaining.cs : Program of Separate Chaining.

using System;

namespace SeparateChainingDemo
{
    class Employee
    {
	    private int employeeId;
	    private String employeeName;

	    public Employee(int id, String name)
	    {
		    employeeId = id;
		    employeeName = name;
	    }//End of Employee()	
	
	    public int GetEmployeeId()
	    {
		    return employeeId;
	    }//End of GetEmployeeId()

	    public void SetEmployeeId(int id)
	    {
		    employeeId = id;
	    }//End of SetEmployeeId()	
	
	    public String ToString()
	    {
		    return  employeeId + " " + employeeName + " ";
        }//End of ToString()
	
    }//End of class Employee

    class Node
    {
	    public Employee info;
	    public Node link;

	    public Node(Employee data)
	    {
		    info = data;
		    link = null;
	    }
    }//End of class Node

    class SingleLinkedList
    {
	    private Node start;

	    public SingleLinkedList()
	    {
		    start = null;
	    }//End of SingleLinkedList()
	
	    public bool IsEmpty()
	    {
		    return (start == null);
	    }//End of IsEmpty()	
	
	    public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = start;
			    while(p != null)
			    {
                    Console.Write(p.info.ToString());
				    p = p.link;
			    }
			    Console.WriteLine();
		    }
		    else
			    Console.WriteLine(" ___");
	    }//End of Display()
	
	    public Node Search(int key)
	    {
		    Node p = start;
		
		    while(p != null)
		    {
			    if(p.info.GetEmployeeId() == key)
				    break;
			    p = p.link;
		    }

		    return p;
	    }//End of Search()	
	
	    public void InsertAtBeginning(Employee data)
	    {
		    Node temp;

		    temp = new Node(data);
		    if(!IsEmpty())
			    temp.link = start;

		    start = temp;
	    }//End of InsertAtBeginning()	
	
	    public void DeleteNode(int key)
	    {
		    Node p, temp;

		    p = start;
		    if(IsEmpty())
                Console.WriteLine("Key " + key + " not present");
		    else if(p.info.GetEmployeeId() == key) //Deletion of first node
		    {
			    temp = p;
			    start = p.link;
			    temp = null;
		    }
		    else //Deletion in between or at the end
		    {
			    while(p.link != null)
			    {
				    if(p.link.info.GetEmployeeId() == key)
					    break;
				    p = p.link;
			    }
			    if(p.link == null)
				    Console.WriteLine("Key " + key + " not present");
			    else
			    {
				    temp = p.link;
				    p.link = p.link.link;
				    temp = null;
			    }
		    }//End of else
	    }//End of DeleteNode()	
	
    }//End of class SingleLinkedList

    class HashTable
    {
	    public static readonly int MaxSize = 11;
	
	    private SingleLinkedList[] arr;
	    private	int m;  //size of the array
	    private	int n;  //number of records

	    public HashTable()
	    {
            m = MaxSize;
		    n = 0;
		    arr = new SingleLinkedList[m];
	    }//End of HashTable()
	
	    private int Hash(int key)
	    {
		    return key%m;
	    }//End of Hash()	
	
	    public bool Search(int key)
	    {
		    int h = Hash(key);
		    Node p = arr[h].Search(key);

		    if(p != null)
		    {
                Console.WriteLine(p.info.ToString());
			    return true;
		    }

		    return false;
	    }//End of Search()
	
	    public void Insert(Employee emp)
	    {
		    int key = emp.GetEmployeeId();
		    int h = Hash(key);
		
		    if(arr[h]==null)
			    arr[h] = new SingleLinkedList();		
		
		    if(Search(key))
		    {
                Console.WriteLine(" Duplicate key");
			    return;
		    }
		    arr[h].InsertAtBeginning(emp);
		    n++;
	    }//End of Insert()	
	
	    public void Del(int key)
	    {
		    int h = Hash(key);
		    arr[h].DeleteNode(key);
		    n--;
	    }//End of Del()	
	
	    public void Display()
	    {
		    for(int i=0; i<m; i++)
		    {
                Console.Write("[" + i + "]  -->");

			    if(arr[i] != null)
				    arr[i].Display() ;
			    else
				    Console.WriteLine(" ___");
		    }
	    }//End of Display()
	
    }//End of class HashTable

    class SeparateChainingDemo
    {
        static void Main(string[] args)
        {
		    HashTable table = new HashTable();

		    table.Insert(new Employee(15,"Suresh"));
		    table.Insert(new Employee(28,"Manish"));
		    table.Insert(new Employee(20,"Abhishek"));
		    table.Insert(new Employee(45,"Srikant"));
		    table.Insert(new Employee(82,"Rajesh"));
		    table.Insert(new Employee(98,"Amit"));
		    table.Insert(new Employee(77,"Vijay"));
		    table.Insert(new Employee(9,"Alok"));
		    table.Insert(new Employee(34,"Vimal"));
		    table.Insert(new Employee(49,"Deepak"));

		    table.Display();

            Console.WriteLine((table.Search(15) ? "Key found" : "Key not found"));

		    table.Del(15);
		    Console.WriteLine((table.Search(15) ? "Key found" : "Key not found"));

		    table.Display();
        }
    }//End of class SeparateChainingDemo
}//End of namespace SeparateChainingDemo
