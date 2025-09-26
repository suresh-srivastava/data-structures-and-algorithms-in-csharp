//OpenAddressing.cs : Program of Open Addressing - Linear Probing

using System;

namespace OpenAddressing
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

    class HashTable
    {
	    static readonly int MaxSize = 11;
	
	
	    private Employee[] arr;
	    private	int m;	//size of array
	    private int n;	//number of employee records
	    private int[] status;
	    private static readonly int EMPTY = 0;
	    private	static readonly int DELETED = 1;
	    private	static readonly int OCCUPIED = 2;

	    public HashTable()
	    {
		    m = MaxSize;
		    n = 0;
		    arr = new Employee[m];
		    status = new int[m];

		    for(int i=0; i<m; i++)
			    status[i] = EMPTY;

	    }//End of HashTable()
	
	    public int Hash(int key)
	    {
		    return key%m;
	    }//End of Hash()	
	
	    public void Insert(Employee emp)
	    {
		    int key = emp.GetEmployeeId();
		    int h = Hash(key);

		    int location = h;

		    for(int i=1; i<m; i++)
		    {
			    if(status[location]==EMPTY || status[location]==DELETED)
			    {
				    arr[location] = emp;
				    status[location] = OCCUPIED;
				    n++;
				    return;
			    }

			    if(arr[location].GetEmployeeId() == key)
			    {
				    Console.WriteLine("Duplicate key");
				    return;
			    }

			    location = (h+i)%m;
		    }

            Console.WriteLine("Table is full");
	    }//End of Insert()	
	
	    public bool Search(int key)
	    {
		    int h = Hash(key);
		    int location = h;

		    for(int i=1; i<m; i++)
		    {
			    if(status[location]==EMPTY || status[location]==DELETED)
				    return false;

			    if(arr[location].GetEmployeeId() == key)
			    {
                    Console.WriteLine(arr[location].ToString());
				    return true; 
			    }

			    location = (h+i)%m;
		    }

		    return false;
	    }//End of Search()
	
	    public void Del(int key)
	    {
		    int h = Hash(key);
		    int location = h;

		    for(int i=1; i<m; i++)
		    {
			    if(status[location]==EMPTY || status[location]==DELETED)
			    {
				    Console.WriteLine("Key not found");
				    return;
			    }

			    if(arr[location].GetEmployeeId() == key)
			    {
				    status[location] = DELETED;
				    n--;
                    Console.WriteLine("Record " + arr[location].ToString() + " deleted");
				    return;
			    }

			    location = (h + i) % m;
		    }
	    }//End of Del()	
	
	    public void Display()
	    {
		    for(int i=0; i<m; i++)
		    {
                Console.Write("[" + i + "] --> ");

			    if(status[i] == OCCUPIED)
				    Console.WriteLine(arr[i].ToString());
			    else
				    Console.WriteLine("___");
		    }
	    }//End of Display()	
	
    }//End of class HashTable

    class OpenAddressing
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
        }//End of Main()
    }//End of class OpenAddressing
}//End of namespace OpenAddressing
